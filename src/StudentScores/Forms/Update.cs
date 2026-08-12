using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentScores
{
    public partial class Update : Form
    {
        public Student Student { get; set; }

        public Update(Student student)
        {
            InitializeComponent();
            this.Student = student;

            // Gán dữ liệu vào các textbox/combobox
            txtid.Text = student.id.ToString();
            txtho.Text = student.firstName.ToString();
            txtname.Text = student.lastName.ToString();
            txtmail.Text = student.email.ToString();
            txtgiotinh.Text = student.gender.ToString();
            txtpart.Text = student.partTime.ToString();
            txtcareer.Text = student.careerAspiration.ToString();

            // Tình trạng học tập
            txtabs.Text = student.absenceDay.ToString();
            txthours.Text = student.weeklySelfStudyHours.ToString();
            txtact.Text = student.extraCurricularActivities.ToString();

            txtmath.Text = student.mathScores.ToString();
            txthis.Text = student.historyScores.ToString();
            txtphy.Text = student.physicScores.ToString();
            txtbio.Text = student.biologyScores.ToString();
            txteng.Text = student.englishScores.ToString();
            txtgeo.Text = student.geographyScores.ToString();
            txtchem.Text = student.chemistryScores.ToString();
            txtgpa.Text = student.gpa.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student.firstName = txtho.Text.Trim();
            Student.lastName = txtname.Text.Trim();
            Student.email = txtmail.Text.Trim();
            Student.gender = txtgiotinh.Text;
            Student.partTime = txtpart.Text.Trim();
            Student.absenceDay = int.Parse(txtabs.Text);
            Student.extraCurricularActivities = txtact.Text.Trim();
            Student.weeklySelfStudyHours = int.Parse(txthours.Text);
            Student.careerAspiration = txtcareer.Text.Trim();
            Student.mathScores = float.Parse(txtmath.Text);
            Student.historyScores = float.Parse(txthis.Text);
            Student.physicScores = float.Parse(txtphy.Text);
            Student.chemistryScores = float.Parse(txtchem.Text);
            Student.biologyScores = float.Parse(txtbio.Text);
            Student.geographyScores = float.Parse(txtgeo.Text);
            Student.englishScores = float.Parse(txteng.Text);

            Student.GPA(Student);
            Student.Rank(Student);
            Student.GenerateStudyAdviceAndSave();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
