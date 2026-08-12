using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StudentScores
{
    public partial class MainForm : Form
    {
        #region Attributes
        private string inPath;

        private string outPath;

        private AVL root;

        private List<Student> students = new List<Student>();
        #endregion
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
        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }
        #endregion
        public MainForm(string inPath,string outPath,List<Student> s,AVL root)
        {
            InitializeComponent();
            this.inPath = inPath;
            this.outPath = outPath;
            this.root = root;
            this.students = s;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = this.students;
            trans();
        }
        public MainForm()
        {
            InitializeComponent();
        }

        #region List file ra screen và add vào datagridview
        // List các file csv để in ra 
        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV File(*csv)|*.csv";
            openFileDialog.Title = "Chose file to open";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                LoadCsvToGrid(path);
            }
        }

        private void LoadCsvToGrid(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length == 0)
            {
                MessageBox.Show("Khong co du lieu");
                return;
            }

            string[] header = lines[0].Split(',');

            DataTable dt = new DataTable();
            // Tạo cột cho các trường dữ liệu
            foreach (string item in header)
            {
                dt.Columns.Add(item.Trim());
            }

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                string[] fields = lines[i].Split(',');

                dt.Rows.Add(fields);
            }
            dataGridView1.DataSource = dt;
            this.inPath = filePath;
            btnExport.Enabled = true;
        }
        #endregion
        private void trans()
        {
            if (dataGridView1.Columns.Count == 0) return;

   
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

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (columnHeaders.ContainsKey(col.DataPropertyName))
                {
                    col.HeaderText = columnHeaders[col.DataPropertyName];
                }
            }
        }
        #region Go to Export.form and send all data from MainForms to Export
        private void btnExport_Click(object sender, EventArgs e)
        {
            ReadFile read = new ReadFile(inPath);
            Comparer<Student> s = Comparer<Student>.Create((a, b) => a.id.CompareTo(b.id));
            this.outPath = "Clean-List.csv";
            AVL avl = read.ScanFile(s);
            root = avl;
            Export export = new Export();
            export.Source = "Main";
            export.Root = root;
            export.InPath = inPath;
            export.OutPath = outPath;
            root.InOrder_FULL(root.Root, students);
            export.Students = students;
            export.Students = students;
            this.Hide();
            export.Show();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
