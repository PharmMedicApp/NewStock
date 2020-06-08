namespace PhramMedicApp
{
    partial class MedicineDisplayECZ
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.medicineList = new System.Windows.Forms.DataGridView();
            this.dispQR = new System.Windows.Forms.Button();
            this.dispStock = new System.Windows.Forms.Button();
            this.dispMed = new System.Windows.Forms.Button();
            this.medicineCB = new System.Windows.Forms.ComboBox();
            this.prosRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.medPic = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.medicineList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medPic)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // medicineList
            // 
            this.medicineList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.medicineList.Location = new System.Drawing.Point(19, 70);
            this.medicineList.Name = "medicineList";
            this.medicineList.RowHeadersWidth = 51;
            this.medicineList.RowTemplate.Height = 24;
            this.medicineList.Size = new System.Drawing.Size(849, 185);
            this.medicineList.TabIndex = 0;
            // 
            // dispQR
            // 
            this.dispQR.Location = new System.Drawing.Point(683, 281);
            this.dispQR.Name = "dispQR";
            this.dispQR.Size = new System.Drawing.Size(123, 30);
            this.dispQR.TabIndex = 1;
            this.dispQR.Text = "QR Kod ile Ara";
            this.dispQR.UseVisualStyleBackColor = true;
            this.dispQR.Click += new System.EventHandler(this.dispQR_Click);
            // 
            // dispStock
            // 
            this.dispStock.Location = new System.Drawing.Point(729, 21);
            this.dispStock.Name = "dispStock";
            this.dispStock.Size = new System.Drawing.Size(123, 28);
            this.dispStock.TabIndex = 2;
            this.dispStock.Text = "Stok Görüntüle";
            this.dispStock.UseVisualStyleBackColor = true;
            this.dispStock.Click += new System.EventHandler(this.dispStock_Click);
            // 
            // dispMed
            // 
            this.dispMed.Location = new System.Drawing.Point(448, 281);
            this.dispMed.Name = "dispMed";
            this.dispMed.Size = new System.Drawing.Size(123, 30);
            this.dispMed.TabIndex = 3;
            this.dispMed.Text = "İlaç Görüntüle";
            this.dispMed.UseVisualStyleBackColor = true;
            this.dispMed.Click += new System.EventHandler(this.dispMed_Click);
            // 
            // medicineCB
            // 
            this.medicineCB.BackColor = System.Drawing.SystemColors.Window;
            this.medicineCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.medicineCB.FormattingEnabled = true;
            this.medicineCB.Location = new System.Drawing.Point(203, 285);
            this.medicineCB.Name = "medicineCB";
            this.medicineCB.Size = new System.Drawing.Size(220, 24);
            this.medicineCB.TabIndex = 4;
            // 
            // prosRTB
            // 
            this.prosRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prosRTB.BackColor = System.Drawing.SystemColors.Window;
            this.prosRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prosRTB.Location = new System.Drawing.Point(6, 21);
            this.prosRTB.Name = "prosRTB";
            this.prosRTB.ReadOnly = true;
            this.prosRTB.Size = new System.Drawing.Size(333, 731);
            this.prosRTB.TabIndex = 5;
            this.prosRTB.Text = "(İlaç Prospektüs Ekranı)";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.prosRTB);
            this.groupBox1.Location = new System.Drawing.Point(916, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 758);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prospektüs";
            // 
            // medPic
            // 
            this.medPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.medPic.Location = new System.Drawing.Point(12, 381);
            this.medPic.Name = "medPic";
            this.medPic.Size = new System.Drawing.Size(891, 389);
            this.medPic.TabIndex = 7;
            this.medPic.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.medicineList);
            this.groupBox2.Controls.Add(this.dispStock);
            this.groupBox2.Controls.Add(this.dispQR);
            this.groupBox2.Controls.Add(this.dispMed);
            this.groupBox2.Controls.Add(this.medicineCB);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(891, 343);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İlaç Listesi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "İlaç Seç: ";
            // 
            // MedicineDisplayECZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 792);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.medPic);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(1285, 839);
            this.Name = "MedicineDisplayECZ";
            this.Text = "MedicineDisplayECZ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MedicineDisplayECZ_FormClosed);
            this.Load += new System.EventHandler(this.MedicineDisplayECZ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.medicineList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medPic)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView medicineList;
        private System.Windows.Forms.Button dispQR;
        private System.Windows.Forms.Button dispStock;
        private System.Windows.Forms.Button dispMed;
        private System.Windows.Forms.ComboBox medicineCB;
        private System.Windows.Forms.RichTextBox prosRTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox medPic;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}