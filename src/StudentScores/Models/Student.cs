using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentScores
{
    public class Student
    {
        #region Attributes
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string partTime { get; set; }
        public int absenceDay { get; set; }
        public string extraCurricularActivities { get; set; }
        public int weeklySelfStudyHours { get; set; }
        public string careerAspiration { get; set; }
        public double mathScores { get; set; }
        public double historyScores { get; set; }
        public double physicScores { get; set; }
        public double chemistryScores { get; set; }
        public double biologyScores { get; set; }
        public double englishScores { get; set; }
        public double geographyScores { get; set; }
        public double gpa { get; set; }

        public string rank { get; set; }

        public string feedback { get; set; }
        #endregion

        public Student() { }
        public Student(int id, string firstName, string lastName, string email, string gender, string partTime,
            int absence, string activities, int studyHours, string career, double math,
            double his, double phys, double chem, double bio, double geo, double eng)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.gender = gender;
            this.partTime = partTime;
            this.weeklySelfStudyHours = studyHours;
            this.absenceDay = absenceDay;
            this.extraCurricularActivities = activities;
            this.careerAspiration = career;
            this.mathScores = math;
            this.historyScores = his;
            this.physicScores = phys;
            this.chemistryScores = chem;
            this.biologyScores = bio;
            this.geographyScores = geo;
            this.englishScores = eng;
        }
        public Student GPA(Student a)
        {
            double sum = ((a.biologyScores + a.chemistryScores + a.englishScores + a.geographyScores + a.historyScores + a.mathScores + a.physicScores) / 7);
            a.gpa = Math.Round((sum / 25), 2);
            return a;
        }
        public Student Rank(Student a)
        {
            if (a.gpa >= 3.6)
                a.rank = "Xuất sắc";
            if (a.gpa >= 3.2 && a.gpa < 3.6)
                a.rank = "Giỏi";
            if (a.gpa >= 2.5 && a.gpa < 3.2)
                a.rank = "Khá";
            if (a.gpa >= 2 && a.gpa < 2.5)
                a.rank = "Trung Bình";
            if (a.gpa >= 1 && a.gpa < 2)
                a.rank = "Yếu";
            else if(a.gpa < 1)
                a.rank = "Kém";
            return a;
        }
        public void GenerateStudyAdviceAndSave()
        {
            this.feedback = GenerateStudyAdvice();
        }

        private string GenerateStudyAdvice()
        {
            List<string> advice = new List<string>();

            // 1. Kiểm tra điểm số từng môn
            Dictionary<string, double> subjects = new Dictionary<string, double>
    {
        { "Toán", mathScores },
        { "Lịch sử", historyScores },
        { "Vật lý", physicScores },
        { "Hóa học", chemistryScores },
        { "Sinh học", biologyScores },
        { "Địa lý", geographyScores },
        { "Tiếng Anh", englishScores }
    };

            int lowScoreCount = 0;

            foreach (var subject in subjects)
            {
                if (subject.Value < 85)
                {
                    lowScoreCount++;

                    advice.Add($"• Môn {subject.Key} điểm vẫn chưa cao. Gợi ý cách cải thiện: " +
                        $"{GetLearningTool(subject.Key)}");
                }
            }

            // 2. Kiểm tra số ngày nghỉ học
            if (absenceDay >= 10)
            {
                advice.Add("• Bạn nghỉ học quá nhiều! Cần đi học đầy đủ để không bị hổng kiến thức.");
            }
            else if (absenceDay >= 5)
            {
                advice.Add("• Bạn nghỉ học hơi nhiều, nên hạn chế nghỉ để đảm bảo theo kịp bài.");
            }

            // 3. Kiểm tra việc làm thêm + nhiều điểm thấp
            if (lowScoreCount >= 3 && partTime.ToLower() == "có")
            {
                advice.Add("• Bạn có nhiều môn điểm thấp và còn làm thêm. Hãy giảm thời gian làm và tập trung học tập hơn.");
            }

            if (!advice.Any())
                return "Tình hình học tập ổn định. Tiếp tục phát huy!";

            return string.Join("\n", advice);
        }


        // Hàm gợi ý công cụ học tập theo từng môn
        private string GetLearningTool(string subject)
        {
            switch (subject)
            {
                case "Toán":
                    return "Xem bài giảng trên OLM, luyện đề trên VietJack và VnDoc, dùng máy tính Casio để thực hành giải nhanh.";

                case "Lịch sử":
                    return "Học bằng sơ đồ tư duy, xem video tổng hợp kiến thức trên YouTube liên quan tới lỗ hổng của mình, luyện trắc nghiệm trên VnDoc.";

                case "Vật lý":
                    return "Xem bài giảng trên OLM hoặc YouTube để xem mình bị hỏng kiến thức ở đâu, dùng PhET mô phỏng và luyện bài tập trên Violympic.";

                case "Hóa học":
                    return "Ôn bảng tuần hoàn, xem video của Thầy Phan Khắc Nghệ, dùng ứng dụng Periodic Table và luyện trắc nghiệm trên VietJack.";

                case "Sinh học":
                    return "Học bằng hình vẽ SGK, xem video của Thầy Cao Cường, dùng sơ đồ quá trình sinh học và luyện đề trên OLM.";

                case "Địa lý":
                    return "Dùng Atlat Địa Lý Việt Nam, luyện kỹ năng đọc bản đồ, xem bài giảng trên YouTube và luyện trắc nghiệm trên VnDoc.";

                case "Tiếng Anh":
                    return "Dùng Duolingo để luyện từ vựng, dùng Elsa Speak luyện phát âm, xem video Grammar trên YouTube và luyện đề trên TOEIC Test / IELTS Test Online.";

                default:
                    return "Sử dụng tài liệu tham khảo và bài giảng phù hợp với môn học.";
            }
        }

    }
}