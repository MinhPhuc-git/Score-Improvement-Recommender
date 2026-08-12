namespace StudentScores
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpRank = new System.Windows.Forms.GroupBox();
            this.btnPoor = new System.Windows.Forms.Button();
            this.btnBad = new System.Windows.Forms.Button();
            this.btnAVG = new System.Windows.Forms.Button();
            this.btnAboveAvg = new System.Windows.Forms.Button();
            this.btnGood = new System.Windows.Forms.Button();
            this.btnExcellent = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNumberOfStudent = new System.Windows.Forms.Button();
            this.btnMale = new System.Windows.Forms.Button();
            this.btnFemale = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpRank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(120, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THỐNG KÊ SINH VIÊN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng số sinh viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nam:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nữ:";
            // 
            // grpRank
            // 
            this.grpRank.Controls.Add(this.btnPoor);
            this.grpRank.Controls.Add(this.btnBad);
            this.grpRank.Controls.Add(this.btnAVG);
            this.grpRank.Controls.Add(this.btnAboveAvg);
            this.grpRank.Controls.Add(this.btnGood);
            this.grpRank.Controls.Add(this.btnExcellent);
            this.grpRank.Controls.Add(this.label10);
            this.grpRank.Controls.Add(this.label9);
            this.grpRank.Controls.Add(this.label8);
            this.grpRank.Controls.Add(this.label7);
            this.grpRank.Controls.Add(this.label6);
            this.grpRank.Controls.Add(this.label5);
            this.grpRank.Location = new System.Drawing.Point(40, 210);
            this.grpRank.Name = "grpRank";
            this.grpRank.Size = new System.Drawing.Size(330, 200);
            this.grpRank.TabIndex = 9;
            this.grpRank.TabStop = false;
            this.grpRank.Text = "Phân loại học lực";
            // 
            // btnPoor
            // 
            this.btnPoor.BackColor = System.Drawing.Color.Orange;
            this.btnPoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPoor.Location = new System.Drawing.Point(214, 171);
            this.btnPoor.Name = "btnPoor";
            this.btnPoor.Size = new System.Drawing.Size(75, 23);
            this.btnPoor.TabIndex = 19;
            this.btnPoor.Text = "\r\n\r\n";
            this.btnPoor.UseVisualStyleBackColor = false;
            this.btnPoor.Click += new System.EventHandler(this.btnPoor_Click);
            // 
            // btnBad
            // 
            this.btnBad.BackColor = System.Drawing.Color.Orange;
            this.btnBad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBad.Location = new System.Drawing.Point(214, 144);
            this.btnBad.Name = "btnBad";
            this.btnBad.Size = new System.Drawing.Size(75, 23);
            this.btnBad.TabIndex = 18;
            this.btnBad.Text = "\r\n\r\n";
            this.btnBad.UseVisualStyleBackColor = false;
            this.btnBad.Click += new System.EventHandler(this.btnBad_Click);
            // 
            // btnAVG
            // 
            this.btnAVG.BackColor = System.Drawing.Color.Orange;
            this.btnAVG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAVG.Location = new System.Drawing.Point(214, 115);
            this.btnAVG.Name = "btnAVG";
            this.btnAVG.Size = new System.Drawing.Size(75, 23);
            this.btnAVG.TabIndex = 17;
            this.btnAVG.Text = "\r\n\r\n";
            this.btnAVG.UseVisualStyleBackColor = false;
            this.btnAVG.Click += new System.EventHandler(this.btnAVG_Click);
            // 
            // btnAboveAvg
            // 
            this.btnAboveAvg.BackColor = System.Drawing.Color.Orange;
            this.btnAboveAvg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAboveAvg.Location = new System.Drawing.Point(214, 85);
            this.btnAboveAvg.Name = "btnAboveAvg";
            this.btnAboveAvg.Size = new System.Drawing.Size(75, 23);
            this.btnAboveAvg.TabIndex = 16;
            this.btnAboveAvg.Text = "\r\n\r\n";
            this.btnAboveAvg.UseVisualStyleBackColor = false;
            this.btnAboveAvg.Click += new System.EventHandler(this.btnAboveAvg_Click);
            // 
            // btnGood
            // 
            this.btnGood.BackColor = System.Drawing.Color.Orange;
            this.btnGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGood.Location = new System.Drawing.Point(214, 55);
            this.btnGood.Name = "btnGood";
            this.btnGood.Size = new System.Drawing.Size(75, 23);
            this.btnGood.TabIndex = 15;
            this.btnGood.Text = "\r\n\r\n";
            this.btnGood.UseVisualStyleBackColor = false;
            this.btnGood.Click += new System.EventHandler(this.btnGood_Click);
            // 
            // btnExcellent
            // 
            this.btnExcellent.BackColor = System.Drawing.Color.Orange;
            this.btnExcellent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcellent.Location = new System.Drawing.Point(214, 25);
            this.btnExcellent.Name = "btnExcellent";
            this.btnExcellent.Size = new System.Drawing.Size(75, 23);
            this.btnExcellent.TabIndex = 14;
            this.btnExcellent.Text = "\r\n\r\n";
            this.btnExcellent.UseVisualStyleBackColor = false;
            this.btnExcellent.Click += new System.EventHandler(this.btnExcellent_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 6;
            this.label10.Text = "Kém:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 7;
            this.label9.Text = "Yếu:";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 8;
            this.label8.Text = "Trung Bình:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "Khá:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Giỏi:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Xuất sắc:";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Orange;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(140, 430);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 35);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNumberOfStudent
            // 
            this.btnNumberOfStudent.BackColor = System.Drawing.Color.Orange;
            this.btnNumberOfStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNumberOfStudent.Location = new System.Drawing.Point(225, 80);
            this.btnNumberOfStudent.Name = "btnNumberOfStudent";
            this.btnNumberOfStudent.Size = new System.Drawing.Size(75, 23);
            this.btnNumberOfStudent.TabIndex = 11;
            this.btnNumberOfStudent.UseVisualStyleBackColor = false;
            this.btnNumberOfStudent.Click += new System.EventHandler(this.btnNumberOfStudent_Click);
            // 
            // btnMale
            // 
            this.btnMale.BackColor = System.Drawing.Color.Orange;
            this.btnMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMale.Location = new System.Drawing.Point(225, 110);
            this.btnMale.Name = "btnMale";
            this.btnMale.Size = new System.Drawing.Size(75, 23);
            this.btnMale.TabIndex = 12;
            this.btnMale.Text = "\r\n\r\n";
            this.btnMale.UseVisualStyleBackColor = false;
            this.btnMale.Click += new System.EventHandler(this.btnMale_Click);
            // 
            // btnFemale
            // 
            this.btnFemale.BackColor = System.Drawing.Color.Orange;
            this.btnFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFemale.Location = new System.Drawing.Point(225, 140);
            this.btnFemale.Name = "btnFemale";
            this.btnFemale.Size = new System.Drawing.Size(75, 23);
            this.btnFemale.TabIndex = 13;
            this.btnFemale.Text = "\r\n\r\n";
            this.btnFemale.UseVisualStyleBackColor = false;
            this.btnFemale.Click += new System.EventHandler(this.btnFemale_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(404, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1368, 359);
            this.dataGridView1.TabIndex = 14;
            // 
            // StatisticsForm
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1784, 961);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnFemale);
            this.Controls.Add(this.btnMale);
            this.Controls.Add(this.btnNumberOfStudent);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpRank);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "\r\n";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.grpRank.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.GroupBox grpRank;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPoor;
        private System.Windows.Forms.Button btnBad;
        private System.Windows.Forms.Button btnAVG;
        private System.Windows.Forms.Button btnAboveAvg;
        private System.Windows.Forms.Button btnGood;
        private System.Windows.Forms.Button btnExcellent;
        private System.Windows.Forms.Button btnNumberOfStudent;
        private System.Windows.Forms.Button btnMale;
        private System.Windows.Forms.Button btnFemale;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
