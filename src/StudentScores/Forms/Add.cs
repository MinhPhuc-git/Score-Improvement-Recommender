using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentScores
{
    public partial class Add : Form
    {
        private List<Student> liststudents;
        private AVL root;
        private string inPath;
        private string outPath;
        private Export exp;

        #region
        public string InPath
        {
            get { return inPath; }
            set { inPath = value; }
        }
        public string OutPath
        {
            get { return outPath; }
            set { outPath = value; }
        }
        public AVL Root
        {
            get { return root; }
            set { root = value; }
        }
        public List<Student> ListStudent
        {
            get { return liststudents; }
            set { liststudents = value; }
        }
        public Export Exp
        {
            get { return exp; }
            set { exp = value; }
        }
        #endregion


        public Add()
        {
            InitializeComponent();
        }
        private void trans()
        {
            if (dgvAdd.Columns.Count == 0) return;


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

            foreach (DataGridViewColumn col in dgvAdd.Columns)
            {
                if (columnHeaders.ContainsKey(col.DataPropertyName))
                {
                    col.HeaderText = columnHeaders[col.DataPropertyName];
                }
            }
        }
        private void Add_Load(object sender, EventArgs e)
        {
            dgvAdd.DataSource = this.liststudents;
            trans();
            txtHeight_CountData.Text = dgvAdd.RowCount.ToString() + "\n Height: " + root.Root.Height.ToString();
            txtID.Text = this.liststudents.Count + 1 + "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string gender = rdiobtnMale.Checked == true ? "Nam" : "Nữ";
            string partTime = rdiobtnYes.Checked == true ? "Có" : "Không";
            string activities = rdiobtnActiYes.Checked == true ? "Có" : "Không";
            int checkID = int.Parse(txtID.Text);
            Student check = new Student();
            check.id = checkID;
            
            Comparer<Student> comparer = Comparer<Student>.Create((a, b) => a.id.CompareTo(b.id));
            if(root.Find(root.Root,check,comparer) == true)
            {
                MessageBox.Show("Id đã tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            Student addStudent = new Student(int.Parse(txtID.Text), txtFirstName.Text, txtLastName.Text, txtGmail.Text,
                gender, partTime, int.Parse(txtAbsence.Text), activities, int.Parse(txtWeekStudyHours.Text),
                txtCareerAspiration.Text, int.Parse(txtMath.Text), int.Parse(txtHistory.Text), int.Parse(txtPhys.Text),
                int.Parse(txtChemistry.Text), int.Parse(txtBiology.Text), int.Parse(txtGeo.Text), int.Parse(txtEng.Text));

            int abs = int.Parse(txtAbsence.Text);
            addStudent.absenceDay = abs;    
            addStudent.GPA(addStudent);
            addStudent.Rank(addStudent);
            root.AddStudent(addStudent, comparer);
            liststudents.Clear();
            root.InOrder_FULL(root.Root, liststudents);

            dgvAdd.DataSource = null;
            dgvAdd.DataSource = liststudents;
            txtID.Text = this.ListStudent.Count + 1 + " ";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtGmail.Text = "";
            txtAbsence.Text = "";
            rdiobtnActiNo.Checked = false;
            rdiobtnActiYes.Checked = false;
            rdiobtnMale.Checked = false;
            rdiobtnFeMale.Checked = false;
            rdiobtnYes.Checked = false;
            rdiobtnNo.Checked = false;
            txtWeekStudyHours.Text = "";
            txtCareerAspiration.Text = "";
            txtMath.Text = "";
            txtHistory.Text = "";
            txtPhys.Text = "";
            txtChemistry.Text = "";
            txtBiology.Text = "";
            txtGeo.Text = "";
            txtEng.Text = "";

            txtHeight_CountData.Text = dgvAdd.RowCount.ToString() + "\nHeight: " + root.Root.Height.ToString();
            
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            this.Hide();
            Export expNew = new Export();
            expNew.Root = root;
            expNew.InPath = inPath;
            expNew.OutPath = outPath;
            expNew.Students = liststudents;
            expNew.Show();
        }
    }
}
