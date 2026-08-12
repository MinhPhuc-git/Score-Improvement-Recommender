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
    public partial class Detail : Form
    {
        private Student student;
        public Detail(Student s)
        {
            InitializeComponent();
            this.student = s;
            this.Load += Detail_Load;
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            // Thông tin cơ bản
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
            labela.Text = student.feedback;
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}
