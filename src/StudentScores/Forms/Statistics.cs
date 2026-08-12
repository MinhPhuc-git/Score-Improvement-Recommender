using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentScores
{
    public partial class StatisticsForm : Form
    {
        #region Attributes
        private AVL root;
        private List<Student> students;
        private string inpath;
        private string outpath;

        #endregion

        #region
        public AVL Root
        {
            get { return root; }
            set { root = value; }
        }
        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }
        
        public string Inpath { get { return this.inpath; } set {  this.inpath = value; } }
        public string OutPath { get { return this.outpath; } set { this.outpath = value; } }

        #endregion
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            List<Student> fullList = new List<Student>();
            root.InOrder_FULL(root.Root, fullList);
            btnNumberOfStudent.Text = fullList.Count.ToString();
            btnFemale.Text = fullList.Count(n => n.gender.Contains("Nữ") == true).ToString();
            btnMale.Text = fullList.Count(n => n.gender.Contains("Nam") == true).ToString();
            btnExcellent.Text = fullList.Count(n => n.rank.Contains("Xuất sắc") == true).ToString();
            btnGood.Text = fullList.Count(n => n.rank.Contains("Giỏi") == true).ToString();
            btnAboveAvg.Text = fullList.Count(n => n.rank.Contains("Khá") == true).ToString();
            btnAVG.Text = fullList.Count(n => n.rank.Contains("Trung Bình") == true).ToString();
            btnBad.Text = fullList.Count(n => n.rank.Contains("Yếu") == true).ToString();
            btnPoor.Text = fullList.Count(n => n.rank.Contains("Kém") == true).ToString();
        }
        private void trans(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;

            Dictionary<string, string> columnHeaders = new Dictionary<string, string>
    {
        {"id", "ID"},
        {"firstName", "Họ"},
        {"lastName", "Tên"},
        {"email", "Email"},
        {"gender", "Giới tính"},
        {"partTime", "Việc làm thêm"},
        {"absenceDay", "Số ngày vắng học"},
        {"extraCurricularActivities", "Hoạt động ngoại khóa"},
        {"weeklySelfStudyHours", "Giờ tự học/tuần"},
        {"careerAspiration", "Ước mơ"},
        {"mathScores", "Toán"},
        {"historyScores", "Lịch sử"},
        {"physicScores", "Vật lí"},
        {"chemistryScores", "Hóa học"},
        {"biologyScores", "Sinh học"},
        {"englishScores", "Tiếng Anh"},
        {"geographyScores", "Địa lí"},
        {"gpa", "GPA"},
        {"rank", "Học lực"}
    };

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                // DataPropertyName là tên thuộc tính trong class Student
                if (columnHeaders.ContainsKey(col.DataPropertyName))
                {
                    col.HeaderText = columnHeaders[col.DataPropertyName];
                }
            }
        }
        private void OutPut(List<Student> list)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
            trans(dataGridView1);
        }
        private void btnNumberOfStudent_Click(object sender, EventArgs e)
        {
            List<Student> fullList = new List<Student>();
            root.InOrder_FULL(root.Root, fullList);
            OutPut(fullList);
        }

        private void btnMale_Click(object sender, EventArgs e)
        {
            List<Student> fullList = new List<Student>();
            root.InOrder_FULL(root.Root, fullList);
            students.Clear();
            students = fullList.Where(n => n.gender.Contains("Nam")).ToList();
            OutPut(students);
        }

        private void btnFemale_Click(object sender, EventArgs e)
        {
            List<Student> fullList = new List<Student>();
            root.InOrder_FULL(root.Root, fullList);
            students.Clear();
            students = fullList.Where(n => n.gender.Contains("Nữ")).ToList();
            OutPut(students);
        }

        private void btnExcellent_Click(object sender, EventArgs e)
        {
            List<Student> fullList = new List<Student>();
            root.InOrder_FULL(root.Root, fullList);
            students.Clear();
            students = fullList.Where(n => n.rank.Contains("Xuất sắc")).ToList();
            OutPut(students);
        }

        private void btnGood_Click(object sender, EventArgs e)
        {
            List<Student> fullList = new List<Student>();
            root.InOrder_FULL(root.Root, fullList);
            students.Clear();
            students = fullList.Where(n => n.rank.Contains("Giỏi")).ToList();
            OutPut(students);
        }

        private void btnAboveAvg_Click(object sender, EventArgs e)
        {
            List<Student> fullList = new List<Student>();
            root.InOrder_FULL(root.Root, fullList);
            students.Clear();
            students = fullList.Where(n => n.rank.Contains("Khá")).ToList();
            OutPut(students);
        }

        private void btnAVG_Click(object sender, EventArgs e)
        {
            List<Student> fullList = new List<Student>();
            root.InOrder_FULL(root.Root, fullList);
            students.Clear();
            students = fullList.Where(n => n.rank.Contains("Trung Bình")).ToList();
            OutPut(students);
        }

        private void btnBad_Click(object sender, EventArgs e)
        {
            List<Student> fullList = new List<Student>();
            root.InOrder_FULL(root.Root, fullList);
            students.Clear();
            students = fullList.Where(n => n.rank.Contains("Yếu")).ToList();
            OutPut(students);
        }

        private void btnPoor_Click(object sender, EventArgs e)
        {
            List<Student> fullList = new List<Student>();
            root.InOrder_FULL(root.Root, fullList);
            students.Clear();
            students = fullList.Where(n => n.rank.Contains("Kém")).ToList();
            OutPut(students);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Export export = new Export();
            root.InOrder_FULL(root.Root, students);
            export.Students = students;
            export.Root = root;
            export.InPath = this.inpath;
            export.OutPath = this.outpath;
            export.Show();
        }
    }
}
