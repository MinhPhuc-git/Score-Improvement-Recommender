using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudentScores
{
    public class ReadFile
    {
        private string inPath;
        private string outPath;

        public string InPath { get { return this.inPath; } set { this.inPath = value; } }
        public string OutPath { get { return this.outPath; } set { this.outPath = value; } }
        public ReadFile(string inPath)
        {
            this.inPath = inPath;
        }
        public ReadFile(string inPath, string outPath)
        {
            this.inPath = inPath;
            this.outPath = outPath;
        }
        // Scan File dựa trên tiêu chí được chọn ở UI
        public AVL ScanFile(Comparer<Student> comparer)
        {
            AVL aVL = new AVL(comparer);
            StreamReader scamFile = new StreamReader(this.inPath);
            string head = scamFile.ReadLine();
            while (!scamFile.EndOfStream)
            {
                string line = scamFile.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] fields = line.Split(',');
                Student student = new Student();
                student.id = int.Parse(fields[0]);
                student.firstName = fields[1];
                student.lastName = fields[2];
                student.email = fields[3];
                student.gender = fields[4].ToLower() == "male" ? "Nam" : "Nữ";
                student.partTime = fields[5].ToLower() == "true" ? "Có" : "Không";
                student.absenceDay = int.Parse(fields[6]);
                student.extraCurricularActivities = fields[7].ToLower() == "true" ? "Có" : "Không";
                student.weeklySelfStudyHours = int.Parse(fields[8]);
                switch (fields[9].ToLower())
                {
                    case "teacher":
                        student.careerAspiration = "Giáo viên";
                        break;
                    case "doctor":
                        student.careerAspiration = "Bác sĩ";
                        break;
                    case "lawyer":
                        student.careerAspiration = "Luật sư";
                        break;
                    case "software engineer":
                        student.careerAspiration = "Kỹ sư phần mềm";
                        break;
                    case "banker":
                        student.careerAspiration = "Ngân hàng";
                        break;
                    case "accountant":
                        student.careerAspiration = "Kế toán";
                        break;
                    case "scientist":
                        student.careerAspiration = "Nhà khoa học";
                        break;
                    case "game developer":
                        student.careerAspiration = "Lập trình game";
                        break;
                    case "writer":
                        student.careerAspiration = "Nhà văn";
                        break;
                    case "designer":
                        student.careerAspiration = "Thiết kế";
                        break;
                    case "construction engineer":
                        student.careerAspiration = "Kỹ sư xây dựng";
                        break;
                    case "stock investor":
                        student.careerAspiration = "Nhà đầu tư chứng khoán";
                        break;
                    case "real estate developer":
                        student.careerAspiration = "Nhà phát triển bất động sản";
                        break;
                    case "government officer":
                        student.careerAspiration = "Công chức nhà nước";
                        break;
                    case "business owner":
                        student.careerAspiration = "Chủ doanh nghiệp";
                        break;
                    case "artist":
                        student.careerAspiration = "Nghệ sĩ";
                        break;
                    default:
                        student.careerAspiration = "Chưa xác định nghề nghiệp"; // giữ nguyên nếu không có trong danh sách
                        break;
                }
                student.mathScores = double.Parse(fields[10]);
                student.historyScores = double.Parse(fields[11]);
                student.physicScores = double.Parse(fields[12]);
                student.chemistryScores = double.Parse(fields[13]);
                student.biologyScores = double.Parse(fields[14]);
                student.englishScores = double.Parse(fields[15]);
                student.geographyScores = double.Parse(fields[16]);
                student.GPA(student);
                student.Rank(student);
                student.GenerateStudyAdviceAndSave();
                aVL.AddStudent(student,comparer);
            }
            Console.WriteLine("Dữ liệu đã được làm sạch và add vào cây thành công !!!");
            scamFile.Close();
            return aVL;
        }

        private void PreOder(NodeAVL node, StreamWriter writer)
        {
            if (node == null) return;
            Student s = node.Value;
            writer.WriteLine($"{s.id},{s.firstName},{s.lastName},{s.email},{s.gender}" +
           $",{s.partTime},{s.absenceDay},{s.extraCurricularActivities},{s.weeklySelfStudyHours}" +
           $",{s.careerAspiration},{s.mathScores},{s.historyScores},{s.physicScores}" +
           $",{s.chemistryScores},{s.biologyScores},{s.englishScores},{s.geographyScores},{s.gpa},{s.rank}");

            PreOder(node.Left, writer);

            PreOder(node.Right, writer);
        }

        private void InOrder(NodeAVL node, StreamWriter writer)
        {
            if (node == null) return;

            InOrder(node.Left, writer);

            Student s = node.Value;
            writer.WriteLine($"{s.id} , {s.firstName} , {s.lastName},{s.email},{s.gender}" +
           $",{s.partTime},{s.absenceDay},{s.extraCurricularActivities},{s.weeklySelfStudyHours}" +
           $",{s.careerAspiration},{s.mathScores},{s.historyScores},{s.physicScores}" +
           $",{s.chemistryScores},{s.biologyScores},{s.englishScores},{s.geographyScores},{s.gpa},{s.rank}");
            
            InOrder(node.Right, writer);
        }

        private void PostOrder(NodeAVL node, StreamWriter writer)
        {
            if (node == null) return;


            PostOrder(node.Right, writer);

            Student s = node.Value;
            writer.WriteLine($"{s.id} , {s.firstName} , {s.lastName},{s.email},{s.gender}" +
           $",{s.partTime},{s.absenceDay},{s.extraCurricularActivities},{s.weeklySelfStudyHours}" +
           $",{s.careerAspiration},{s.mathScores},{s.historyScores},{s.physicScores}" +
           $",{s.chemistryScores},{s.biologyScores},{s.englishScores},{s.geographyScores},{s.gpa},{s.rank}");

            PostOrder(node.Left, writer);
        }

        private void PreOder_FULL(NodeAVL node, StreamWriter writer)
        {
            if (node == null) return;

            // GHI NODE VALUE CHÍNH
            Student s = node.Value;
            writer.WriteLine(ToCSV(s));

            // GHI DANH SÁCH NODESTUDENT
            foreach (Student st in node.NodeStudent)
                writer.WriteLine(ToCSV(st));

            PreOder_FULL(node.Left, writer);
            PreOder_FULL(node.Right, writer);
        }


        private void InOrder_FULL(NodeAVL node, StreamWriter writer)
        {
            if (node == null) return;

            InOrder_FULL(node.Left, writer);

            Student s = node.Value;
            writer.WriteLine(ToCSV(s));

            foreach (Student st in node.NodeStudent)
                writer.WriteLine(ToCSV(st));

            InOrder_FULL(node.Right, writer);
        }

        private void PostOrder_FULL(NodeAVL node, StreamWriter writer)
        {
            if (node == null) return;

            PostOrder_FULL(node.Left, writer);
            PostOrder_FULL(node.Right, writer);

            Student s = node.Value;
            writer.WriteLine(ToCSV(s));

            foreach (Student st in node.NodeStudent)
                writer.WriteLine(ToCSV(st));
        }

        private string ToCSV(Student s)
        {
            return $"{s.id},{s.firstName},{s.lastName},{s.email},{s.gender}," +
                   $"{s.partTime},{s.absenceDay},{s.extraCurricularActivities},{s.weeklySelfStudyHours}," +
                   $"{s.careerAspiration},{s.mathScores},{s.historyScores},{s.physicScores}," +
                   $"{s.chemistryScores},{s.biologyScores},{s.englishScores},{s.geographyScores},{s.gpa},{s.rank}";
        }


        public void WriteToFile(AVL node,string outPath,int n)
        {
            string[] list = { "PreOrder", "InOrder", "PostOrder" };
            StreamWriter streamWriter = new StreamWriter(this.outPath, false, Encoding.UTF8);
            streamWriter.WriteLine("ID, Họ, Tên,Email,Giới tính, Việc làm thêm,Số ngày vắng học,Hoạt động ngoại khóa,Số giờ học/tuần,Ước mơ, Toán, Lịch sử,Vật lí,Hóa học, Sinh học,Tiếng anh,Địa lý,GPA,Học lực");
            if(n == 0)
                PreOder_FULL(node.Root, streamWriter);
            else if(n == 1)
                InOrder_FULL(node.Root, streamWriter);
            else
                PostOrder_FULL(node.Root, streamWriter);
            Console.WriteLine($"Dữ liệu đã được duyệt bằng {list[n]} và lưu vào " + this.outPath);

            streamWriter.Close();
        }
    }
}
