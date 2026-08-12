using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.SqlServer.Server;
using static System.Net.Mime.MediaTypeNames;

namespace StudentScores
{
    public partial class Export : Form
    {
        #region Attributes
        private AVL root;
        private string inPath;
        private string outPath;
        private List<Student> students;
        private string currentDisplay = "Increase";
        private Student selectedStudent = null;
        #endregion

        #region Properties
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

        public string Source { get; set; }
        #endregion P

        #region Import all data from MainForms
        public Export()
        {
            InitializeComponent();
        }
        #endregion

        #region Support Function for the method to traverse, search and delete
        private void AddListOption(List<Student> student)
        {
            if (currentDisplay == "Increase")
                root.InOrder_FULL(root.Root, student);
            else if (currentDisplay == "Decrease")
                root.PreOrder_FULL(root.Root, student);
            else
                root.PreOrder_FULL(root.Root, student);
        }
        // Hỗ trợ cho các hàm Delete và Search
        // Nhận giá trị từ textbox và xác định trường dữ liệu của giá trị nhập
        private Student Option()
        {
            Student student = new Student();
            List<Student> full = new List<Student>();
            root.InOrder_FULL(root.Root, full);
            if (rdiobtnExportID.Checked)
            {
                if (!txtSearch.Text.All(char.IsDigit) || int.Parse(txtSearch.Text) < 0 && int.Parse(txtSearch.Text) > full.Count)
                {
                    MessageBox.Show($"ID phải là số 1 - {full.Count}!", "Thông báo");
                    return null;
                }
                student.id = int.Parse(txtSearch.Text);

            }

            else if (rdiobtnFirstName.Checked)
                student.firstName = txtSearch.Text.Trim();

            else if (rdiobtnLastName.Checked)
                student.lastName = txtSearch.Text.Trim();

            else if (rdiobtnAbsenceDay.Checked)
            {
                if (!txtSearch.Text.All(char.IsDigit))
                {
                    MessageBox.Show("AbsenceDay phải là số!", "Thông báo");
                    return null;
                }
                student.absenceDay = int.Parse(txtSearch.Text);
            }
            else if (rdiobtnMathScores.Checked)
            {
                if (!txtSearch.Text.All(char.IsDigit) || int.Parse(txtSearch.Text) < 0 && int.Parse(txtSearch.Text) > 100)
                {
                    MessageBox.Show("MathScores phải là số 0 - 100!", "Thông báo");
                    return null;
                }
                student.mathScores = int.Parse(txtSearch.Text);
            }

            else if (rdiobtnWeekStudy.Checked)
            {
                if (!txtSearch.Text.All(char.IsDigit))
                {
                    MessageBox.Show("WeeklyStudy phải là số!", "Thông báo");
                    return null;
                }
                student.weeklySelfStudyHours = int.Parse(txtSearch.Text);
            }

            else if (rdiobtnMale.Checked)
                student.gender = "Nam";

            else if (rdiobtnFemale.Checked)
                student.gender = "Nữ";

            else if (radioButton1.Checked)
                student.email = txtSearch.Text.Trim();

            else if (rdiobtnDiali.Checked)
            {
                if (!txtSearch.Text.All(char.IsDigit) || int.Parse(txtSearch.Text) < 0 && int.Parse(txtSearch.Text) > 100)
                {
                    MessageBox.Show("Địa lí phải là số 0 - 100!", "Thông báo");
                    return null;
                }
                student.geographyScores = float.Parse(txtSearch.Text);
            }
            else if (rdiobtnEnglish.Checked)
            {
                if (!txtSearch.Text.All(char.IsDigit) || int.Parse(txtSearch.Text) < 0 && int.Parse(txtSearch.Text) > 100)
                {
                    MessageBox.Show("Tiếng anh phải là số 0 - 100!", "Thông báo");
                    return null;
                }
                student.englishScores = float.Parse(txtSearch.Text);
            }
            else if (rdiobtnHoaHoc.Checked)
            {
                if (!txtSearch.Text.All(char.IsDigit) || int.Parse(txtSearch.Text) < 0 && int.Parse(txtSearch.Text) > 100)
                {
                    MessageBox.Show("Hóa học phải là số 0 - 100!", "Thông báo");
                    return null;
                }
                student.chemistryScores = float.Parse(txtSearch.Text);
            }
            else if (rdiobtnlichsu.Checked)
            {
                if (!txtSearch.Text.All(char.IsDigit) || int.Parse(txtSearch.Text) < 0 && int.Parse(txtSearch.Text) > 100)
                {
                    MessageBox.Show("Lịch sử phải là số 0 - 100!", "Thông báo");
                    return null;
                }
                student.historyScores = float.Parse(txtSearch.Text);
            }
            else if (rdiobtnVatli.Checked)
            {
                if (!txtSearch.Text.All(char.IsDigit) || int.Parse(txtSearch.Text) < 0 && int.Parse(txtSearch.Text) > 100)
                {
                    MessageBox.Show("Vật lí phải là số 0 - 100!", "Thông báo");
                    return null;
                }
                student.physicScores = float.Parse(txtSearch.Text);
            }
            else if (ridobtnSinhHoc.Checked)
            {
                if (!txtSearch.Text.All(char.IsDigit) || int.Parse(txtSearch.Text) < 0 && int.Parse(txtSearch.Text) > 100)
                {
                    MessageBox.Show("Sinh học phải là số 0 - 100!", "Thông báo");
                    return null;
                }
                student.biologyScores = float.Parse(txtSearch.Text);
            }
            else if (rdiobtnGPA.Checked)
            {
                if (!txtSearch.Text.All(char.IsDigit) || int.Parse(txtSearch.Text) < 0 && int.Parse(txtSearch.Text) > 4)
                {
                    MessageBox.Show("GPA phải là số 0 - 4!", "Thông báo");
                    return null;
                }
                student.gpa = float.Parse(txtSearch.Text);
            }
            else if (rdiobtnHanhKiem.Checked)
                student.rank = txtSearch.Text;

            return student;
        }
        #endregion

        #region Export Choice
        // Xác định tiêu chí từ phản hồi của rdiobutton => trả về cho các phương thức cần xác định tiêu chí
        private Comparison<Student> GetComparison()
        {
            if (rdiobtnExportID.Checked)
                return (a, b) => a.id.CompareTo(b.id);

            if (rdiobtnFirstName.Checked)
                return (a, b) => a.firstName.CompareTo(b.firstName);

            if (rdiobtnLastName.Checked)
                return (a, b) => a.lastName.CompareTo(b.lastName);

            if (rdiobtnAbsenceDay.Checked)
                return (a, b) => a.absenceDay.CompareTo(b.absenceDay);

            if (rdiobtnMathScores.Checked)
                return (a, b) => a.mathScores.CompareTo(b.mathScores);

            if (rdiobtnWeekStudy.Checked)
                return (a, b) => a.weeklySelfStudyHours.CompareTo(b.weeklySelfStudyHours);

            if (rdiobtnMale.Checked)
                return (a, b) => a.gender.CompareTo(b.gender);
            if (rdiobtnFemale.Checked)
                return (a, b) => b.gender.CompareTo(a.gender);
            if (radioButton1.Checked)
                return (a, b) => b.email.CompareTo(a.email);
            if (rdiobtnDiali.Checked)
                return (a, b) => b.geographyScores.CompareTo(a.geographyScores);
            if (rdiobtnEnglish.Checked)
                return (a, b) => b.englishScores.CompareTo(a.englishScores);
            if (rdiobtnHoaHoc.Checked)
                return (a, b) => b.chemistryScores.CompareTo(a.chemistryScores);
            if (rdiobtnlichsu.Checked)
                return (a, b) => b.historyScores.CompareTo(a.historyScores);
            if (rdiobtnVatli.Checked)
                return (a, b) => b.physicScores.CompareTo(a.physicScores);
            if (ridobtnSinhHoc.Checked)
                return (a, b) => b.biologyScores.CompareTo(a.biologyScores);
            if (rdiobtnGPA.Checked)
                return (a, b) => b.gpa.CompareTo(a.gpa);
            if (rdiobtnHanhKiem.Checked)
                return (a, b) => b.rank.CompareTo(a.rank);
            return null;
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

        // Chọn tiêu chí cột để duyệt và lưu dữ liệu
        private void ExportOption(Comparison<Student> comparison)
        {
            Comparer<Student> choice = Comparer<Student>.Create(comparison);

            AVL newRoot = new AVL(choice);
            List<Student> fullList = new List<Student>();
            root.InOrder_FULL(root.Root, fullList);
            foreach (Student student in fullList)
                newRoot.AddStudent(student, choice);

            root = newRoot;
            students.Clear();
            root.InOrder(root.Root, students);
            fullList.Clear();
            root.InOrder_FULL(root.Root, fullList);


            dataGridView1.DataSource = null;
            dataGridView1.DataSource = fullList.ToList();

            dgvSameData.DataSource = null;
            dgvSameData.DataSource = students.ToList();
            trans(dataGridView1);
            trans(dgvSameData);

            btnPreO.Enabled = true;
            btnDecrease_Ino.Enabled = true;
            btnIncrease_InO.Enabled = true;
            lblHeight.Text = "Height: " + (root.CountHeight(root.Root) - 1);
            lblCountData.Text = "Number: " + dataGridView1.RowCount;
            lblNumberOfSameData.Text = dgvSameData.RowCount.ToString();
            lblsamedata.Text = "SameData: " + students.Count;
        }
        // Tất cả hàm dưới dùng để gửi các tiêu chí duyệt và lưu dữ liệu cho Export Option
        private void rdiobtnExportID_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }
        private void rdiobtnFirstName_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }
        private void rdiobtnAlphabet_LastName_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }

        private void rdiobtnMath_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }

        private void rdiobtnAbsence_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }

        private void rdiobtnStudy_Hours_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }

        private void rdiobtnMale_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }

        private void rdiobtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }
        private void rdiobtnEnglish_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }

        private void rdiobtnVatli_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }

        private void rdiobtnHoaHoc_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }

        private void rdiobtnDiali_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }
        private void ridobtnSinhHoc_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }
        private void rdiobtnlichsu_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }
        private void rdiobtnHanhKiem_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }

        private void rdiobtnGPA_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ExportOption(GetComparison());
        }
        #endregion
        #region Btn PreO Increase Decrease
        private void btnPreO_Click(object sender, EventArgs e)
        {
            List<Student> temp = new List<Student>();
            root.PreOrder_FULL(root.Root, temp);
            students.Clear();
            root.PreOrder(root.Root, students);
            OutPut(students, temp);
        }
        private void btnIncrease_InO_Click(object sender, EventArgs e)
        {
            List<Student> temp = new List<Student>();
            root.InOrder_FULL(root.Root, temp);
            students.Clear();
            root.InOrder(root.Root, students);
            OutPut(students, temp);

        }

        private void btnDecrease_Ino_Click(object sender, EventArgs e)
        {
            List<Student> temp = new List<Student>();
            root.PostOrder_FULL(root.Root, temp);
            students.Clear();
            root.PostOrder(root.Root, students);
            OutPut(students, temp);

        }
        #endregion

        #region Delete
        private void DeleteOption()
        {
            Student student = selectedStudent;
            if (student == null)
            {
                MessageBox.Show("Vui lòng chọn học sinh để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Comparer<Student> comparer = Comparer<Student>.Create(GetComparison());

            bool deleted = root.Delete(student, comparer);
            if (!deleted)
            {
                MessageBox.Show("Vui lòng chọn học sinh để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            students.Clear();
            AddListOption(students);
            List<Student> samedata = new List<Student>();
            root.InOrder(root.Root, samedata);
            OutPut(samedata,students);
            lblCountData.Text = students.Count.ToString();
            lblHeight.Text = root.Root.Height + "";
        }
        private void btndDelete_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null)
            {
                MessageBox.Show("Vui lòng chọn học sinh để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa học sinh {selectedStudent.firstName} {selectedStudent.lastName} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                DeleteOption();
            }
        }
        #endregion

        #region Search
        private void SearchOption()
        {
            Student studentOption = Option();
            if (studentOption == null) return;

            List<Student> fullStudents = new List<Student>();
            root.InOrder_FULL(root.Root, fullStudents);

            List<Student> listSearch = fullStudents.Where(s =>
            {

                if (rdiobtnExportID.Checked)
                    return s.id == studentOption.id;

                else if (rdiobtnFirstName.Checked)
                {
                    string input = studentOption.firstName.Trim();
                    string name = s.firstName.Trim();

                    if (input.Length == 1)
                        return name.StartsWith(input, StringComparison.OrdinalIgnoreCase);

                    if (input.Length < name.Length)
                        return name.StartsWith(input, StringComparison.OrdinalIgnoreCase);

                    return name.Equals(input, StringComparison.OrdinalIgnoreCase);
                }

                else if (rdiobtnLastName.Checked)
                {
                    string input = studentOption.lastName.Trim();
                    string name = s.lastName.Trim();

                    if (input.Length == 1)
                        return name.StartsWith(input, StringComparison.OrdinalIgnoreCase);

                    if (input.Length < name.Length)
                        return name.StartsWith(input, StringComparison.OrdinalIgnoreCase);

                    return name.Equals(input, StringComparison.OrdinalIgnoreCase);
                }


                else if (rdiobtnAbsenceDay.Checked)
                    return s.absenceDay == studentOption.absenceDay;

                else if (rdiobtnMathScores.Checked)
                    return s.mathScores == studentOption.mathScores;

                else if (rdiobtnWeekStudy.Checked)
                    return s.weeklySelfStudyHours == studentOption.weeklySelfStudyHours;

                else if (rdiobtnMale.Checked || rdiobtnFemale.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtSearch.Text))
                        return (rdiobtnMale.Checked && s.gender == "Nam") || (rdiobtnFemale.Checked && s.gender == "Nữ");

                    return s.gender.Equals(txtSearch.Text.Trim(), StringComparison.OrdinalIgnoreCase);
                }

                else if (radioButton1.Checked)
                    return s.email == studentOption.email;

                else if (rdiobtnDiali.Checked)
                    return s.geographyScores == studentOption.geographyScores;

                else if (rdiobtnEnglish.Checked)
                    return s.englishScores == studentOption.englishScores;

                else if (rdiobtnHoaHoc.Checked)
                    return s.chemistryScores == studentOption.chemistryScores;

                else if (rdiobtnlichsu.Checked)
                    return s.historyScores == studentOption.historyScores;

                else if (rdiobtnVatli.Checked)
                    return s.physicScores == studentOption.physicScores;

                else if (ridobtnSinhHoc.Checked)
                    return s.biologyScores == studentOption.biologyScores;

                else if (rdiobtnGPA.Checked)
                    return s.gpa == studentOption.gpa;

                else if (rdiobtnHanhKiem.Checked)
                    return s.rank == studentOption.rank;

                return false;
            }).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listSearch;
            trans(dataGridView1);
            trans(dgvSameData);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Chọn tiêu chí tìm kiếm trước khi search!!!");
                return;
            }
            SearchOption();
        }
        #endregion

        #region Output All data in height when input
        private void btnHeight_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHeight.Text))
            {
                MessageBox.Show("Vui lòng nhập chiều cao muốn xem!!!");
                return;
            }
            if (txtHeight.Text.All(char.IsDigit) == false)
            {
                MessageBox.Show($"Vui lòng nhập giá trị là số 0 - {root.Root.Height - 1}!!");
                return;
            }
            int height = int.Parse(txtHeight.Text);
            List<Student> studentHeight = new List<Student>();
            if (txtHeight.Text.All(char.IsDigit) == false || height < 0 || height > root.Root.Height - 1)
            {
                MessageBox.Show($"Nhập số nguyên trong khoảng từ 0 - {root.Root.Height - 1}");
                return;
            }
            root.XuatTang(root.Root, height, 0, studentHeight);
            dataGridView1.DataSource = studentHeight;
            dataGridView1.Refresh();
            lblCountData.Text = "Number: " + dataGridView1.RowCount;
            lblHeight.Text = "Height: " + txtHeight.Text;
        }
        #endregion

        #region Save data as file path with the method in the last choice
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.Title = "Chọn nơi lưu file CSV";
                saveFileDialog.FileName = "StudentData.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = saveFileDialog.FileName;
                    this.outPath = selectedPath;

                    AVL tree = root;
                    ReadFile file = new ReadFile(this.inPath, this.outPath);

                    string[] listOutPut = { "PreOrder", "Increase", "Decrease" };
                    foreach (string s in listOutPut)
                    {
                        if (s.ToLower() == currentDisplay.ToLower())
                        {
                            file.WriteToFile(root, this.outPath, Array.IndexOf(listOutPut, currentDisplay));
                        }
                    }

                    MessageBox.Show($"Đã lưu vào file {this.outPath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region Back to MainForm
        private void btnMainForm_Click(object sender, EventArgs e)
        {
            MainForm mainforms = new MainForm();
            mainforms.Root = root;
            mainforms.InPath = inPath;
            mainforms.OutPath = outPath;
            mainforms.Students = students;
            this.Hide();
            mainforms.Show();
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add add = new Add();
            add.Root = root;
            add.InPath = inPath;
            add.OutPath = outPath;
            add.ListStudent = students;
            add.Exp = new Export();
            add.Show();
        }

        private void Export_Load(object sender, EventArgs e)
        {
            if (Source == "Main")
            {
                ReadFile scanFile = new ReadFile(InPath);
                Comparer<Student> comparer = Comparer<Student>.Create((a, b) => a.id.CompareTo(b.id));
                root = new AVL(comparer);
                root = scanFile.ScanFile(comparer);
                students.Clear();
                root.InOrder(root.Root, students);

                List<Student> fullStudent = new List<Student>();
                root.InOrder_FULL(root.Root, fullStudent);
                OutPut(students, fullStudent);
                Source = "";
            }
            else
            {
                dataGridView1.DataSource = this.students.ToList();
                dgvSameData.DataSource = this.students.ToList();
                lblCountData.Text = "Number: " + dataGridView1.RowCount;
                lblchieuchao.Text = "Height: " + (root.Root.Height - 1);
            }   
        }

        private void btnLeaf_Click(object sender, EventArgs e)
        {
            List<Student> students = new List<Student>();
            root.Leaf(root.Root, students);
            dataGridView1.Refresh();
            dataGridView1.DataSource = students;
            lblla.Text = "Leaf: " + dataGridView1.RowCount.ToString();
            lblCountData.Text = "Number: " + students.Count();
        }

        private void Statistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            StatisticsForm form = new StatisticsForm();
            form.Root = root;
            form.Students = students;
            form.Inpath = inPath;
            form.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReadFile scan = new ReadFile(InPath);
            List<Student> fullStudent = new List<Student>();
            Comparer<Student> comparer = Comparer<Student>.Create((a, b) => a.id.CompareTo(b.id));
            root = scan.ScanFile(comparer);
            fullStudent.Clear();
            students.Clear();
            root.InOrder_FULL(root.Root, fullStudent);
            root.InOrder(root.Root, students);
            OutPut(students, fullStudent);
        }

        private void OutPut(List<Student> sameData, List<Student> fullStudent)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = fullStudent;
            dgvSameData.DataSource = null;
            dgvSameData.DataSource = sameData;
            trans(dgvSameData);
            trans(dataGridView1);
            lblCountData.Text = "Number: " + dataGridView1.RowCount;
            lblchieuchao.Text = "Height: " + (root.Root.Height - 1);
            lblsamedata.Text= "SameData: "+ sameData.Count;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            selectedStudent = new Student(
                Convert.ToInt32(row.Cells["id"].Value),
                row.Cells["firstName"].Value.ToString(),
                row.Cells["lastName"].Value.ToString(),
                row.Cells["email"].Value.ToString(),
                row.Cells["gender"].Value.ToString(),
                row.Cells["partTime"].Value.ToString(),
                Convert.ToInt32(row.Cells["absenceDay"].Value),
                row.Cells["extraCurricularActivities"].Value.ToString(),
                Convert.ToInt32(row.Cells["weeklySelfStudyHours"].Value),
                row.Cells["careerAspiration"].Value.ToString(),
                Convert.ToSingle(row.Cells["mathScores"].Value),
                Convert.ToSingle(row.Cells["historyScores"].Value),
                Convert.ToSingle(row.Cells["physicScores"].Value),
                Convert.ToSingle(row.Cells["chemistryScores"].Value),
                Convert.ToSingle(row.Cells["biologyScores"].Value),
                Convert.ToSingle(row.Cells["geographyScores"].Value),
                Convert.ToSingle(row.Cells["englishScores"].Value)
            );

            selectedStudent.GPA(selectedStudent);
            selectedStudent.Rank(selectedStudent);
            selectedStudent.GenerateStudyAdviceAndSave();

            //DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
         
            //int id = Convert.ToInt32(row.Cells["id"].Value);
            //string fname = row.Cells["firstName"].Value.ToString();
            //string lname = row.Cells["lastName"].Value.ToString();
            //string mail = row.Cells["email"].Value.ToString();
            //string gender = row.Cells["gender"].Value.ToString();
            //string partime = row.Cells["partTime"].Value.ToString();
            //int abs = Convert.ToInt32(row.Cells["absenceDay"].Value);
            //string active = row.Cells["extraCurricularActivities"].Value.ToString();
            //int hours = Convert.ToInt32(row.Cells["weeklySelfStudyHours"].Value);
            //string career = row.Cells["careerAspiration"].Value.ToString();

            //float math = Convert.ToSingle(row.Cells["mathScores"].Value);
            //float his = Convert.ToSingle(row.Cells["historyScores"].Value);
            //float phy = Convert.ToSingle(row.Cells["physicScores"].Value);
            //float chem = Convert.ToSingle(row.Cells["chemistryScores"].Value);
            //float bio = Convert.ToSingle(row.Cells["biologyScores"].Value);
            //float eng = Convert.ToSingle(row.Cells["englishScores"].Value);
            //float geo = Convert.ToSingle(row.Cells["geographyScores"].Value);

            Detail formStudent = new Detail(selectedStudent);
            formStudent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null)
            {
                MessageBox.Show("Vui lòng chọn học sinh trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Update editForm = new Update(selectedStudent);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Xóa học sinh cũ khỏi AVL theo ID
                Comparer<Student> comparer = Comparer<Student>.Create((a, b) => a.id.CompareTo(b.id));
                root.Delete(selectedStudent, comparer);

                // Thêm lại học sinh đã sửa
                root.AddStudent(selectedStudent, comparer);

                // Cập nhật DataGridView
                List<Student> fullList = new List<Student>();
                root.InOrder_FULL(root.Root, fullList);
                students.Clear();
                root.InOrder(root.Root, students);
                OutPut(students, fullList);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvSameData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            selectedStudent = new Student(
                Convert.ToInt32(row.Cells["id"].Value),
                row.Cells["firstName"].Value.ToString(),
                row.Cells["lastName"].Value.ToString(),
                row.Cells["email"].Value.ToString(),
                row.Cells["gender"].Value.ToString(),
                row.Cells["partTime"].Value.ToString(),
                Convert.ToInt32(row.Cells["absenceDay"].Value),
                row.Cells["extraCurricularActivities"].Value.ToString(),
                Convert.ToInt32(row.Cells["weeklySelfStudyHours"].Value),
                row.Cells["careerAspiration"].Value.ToString(),
                Convert.ToSingle(row.Cells["mathScores"].Value),
                Convert.ToSingle(row.Cells["historyScores"].Value),
                Convert.ToSingle(row.Cells["physicScores"].Value),
                Convert.ToSingle(row.Cells["chemistryScores"].Value),
                Convert.ToSingle(row.Cells["biologyScores"].Value),
                Convert.ToSingle(row.Cells["geographyScores"].Value),
                Convert.ToSingle(row.Cells["englishScores"].Value)
            );

            selectedStudent.GPA(selectedStudent);
            selectedStudent.Rank(selectedStudent);
            selectedStudent.GenerateStudyAdviceAndSave();
            Detail formStudent = new Detail(selectedStudent);
            formStudent.Show();
        }

        private void btnNode1con_Click(object sender, EventArgs e)
        {
            List<Student> list = new List<Student>();

            root.GetOneChildNodes(root.Root, list);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;

            lblNode1con.Text = "Node 1 con: " + list.Count.ToString();

            trans(dataGridView1);
        }
    }
}

