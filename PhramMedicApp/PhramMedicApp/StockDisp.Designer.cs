using System.Windows.Forms; 

namespace PhramMedicApp
{
    partial class StockDisp
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
        private void InitializeComponent(string status)
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stockList = new System.Windows.Forms.DataGridView();
            this.medCB = new System.Windows.Forms.ComboBox();
            this.dispMed = new System.Windows.Forms.Button();
            this.buyMed = new System.Windows.Forms.Button();
            this.sellMed = new System.Windows.Forms.Button();
            this.qrDisp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sellMed);
            this.groupBox1.Controls.Add(this.buyMed);
            this.groupBox1.Controls.Add(this.dispMed);
            this.groupBox1.Controls.Add(this.medCB);
            this.groupBox1.Controls.Add(this.stockList);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1239, 344);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stok Listesi";
            this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            // 
            // stockList
            // 
            this.stockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockList.Location = new System.Drawing.Point(30, 69);
            this.stockList.Name = "stockList";
            this.stockList.RowHeadersWidth = 51;
            this.stockList.RowTemplate.Height = 24;
            this.stockList.Size = new System.Drawing.Size(1177, 193);
            this.stockList.TabIndex = 0;
            this.stockList.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

            // 
            // medCB
            // 
            this.medCB.FormattingEnabled = true;
            this.medCB.Location = new System.Drawing.Point(438, 292);
            this.medCB.Name = "medCB";
            this.medCB.Size = new System.Drawing.Size(277, 24);
            this.medCB.TabIndex = 1;
            this.medCB.Anchor = AnchorStyles.None;
            this.medCB.Anchor = AnchorStyles.Top;
            this.medCB.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // dispMed
            // 
            this.dispMed.Location = new System.Drawing.Point(738, 286);
            this.dispMed.Name = "dispMed";
            this.dispMed.Size = new System.Drawing.Size(135, 34);
            this.dispMed.TabIndex = 2;
            this.dispMed.Text = "İlaç Görüntüle";
            this.dispMed.UseVisualStyleBackColor = true;
            this.dispMed.Anchor = AnchorStyles.None;
            this.dispMed.Anchor = AnchorStyles.Top;
            this.dispMed.Click += new System.EventHandler(this.dispMed_Click);

            //
            //qrDisp
            //
            this.qrDisp.Location = new System.Drawing.Point(900,286);
            this.qrDisp.Name = "qrDisp";
            this.qrDisp.Size = new System.Drawing.Size(135, 34);
            this.qrDisp.TabIndex = 2;
            this.qrDisp.Text = "QR Kod ile Ara";
            this.qrDisp.UseVisualStyleBackColor = true;
            this.qrDisp.Anchor = AnchorStyles.None;
            this.qrDisp.Anchor = AnchorStyles.Top;
            //this.qrDisp.Click += new System.EventHandler(this.qrDisp_Click);


            // 
            // StockDisp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 368);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 410);
            this.MinimumSize = new System.Drawing.Size(1280, 410);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox1);
            this.Name = "StockDisp";
            this.Text = "Stok Görüntüle";
            this.groupBox1.ResumeLayout(false);
            this.Load += new System.EventHandler(this.StockDisp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockList)).EndInit();
            this.ResumeLayout(false);

            switch (status)
            {
                case "ECZ":
                    // 
                    // sellMed
                    // 
                    this.sellMed.Location = new System.Drawing.Point(771, 15);
                    this.sellMed.Name = "sellMed";
                    this.sellMed.Size = new System.Drawing.Size(135, 25);
                    this.sellMed.TabIndex = 4;
                    this.sellMed.Text = "İlaç Sat";
                    this.sellMed.UseVisualStyleBackColor = true;
                    this.sellMed.Anchor = AnchorStyles.None;
                    this.sellMed.Anchor = AnchorStyles.Top;
                    this.sellMed.Click += new System.EventHandler(this.sellMed_Click);

                    // 
                    // buyMed
                    // 
                    this.buyMed.Location = new System.Drawing.Point(598, 15);
                    this.buyMed.Name = "buyMed";
                    this.buyMed.Size = new System.Drawing.Size(135, 25);
                    this.buyMed.TabIndex = 3;
                    this.buyMed.Text = "İlaç Al";
                    this.buyMed.UseVisualStyleBackColor = true;
                    this.buyMed.Anchor = AnchorStyles.None;
                    this.buyMed.Anchor = AnchorStyles.Top;
                    this.buyMed.Click += new System.EventHandler(this.buyMed_Click);
                    break;

                case "KLF":
                    // 
                    // sellMed
                    // 
                    this.sellMed.Location = new System.Drawing.Point(771, 15);
                    this.sellMed.Name = "sellMed";
                    this.sellMed.Size = new System.Drawing.Size(135, 25);
                    this.sellMed.TabIndex = 4;
                    this.sellMed.Text = "İlaç Sat";
                    this.sellMed.UseVisualStyleBackColor = true;
                    this.sellMed.Anchor = AnchorStyles.None;
                    this.sellMed.Anchor = AnchorStyles.Top;
                    this.sellMed.Click += new System.EventHandler(this.sellMed_Click);
                    this.buyMed.Dispose();
                    break;
                case "STK":
                    this.buyMed.Dispose();
                    this.sellMed.Dispose();
                    this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StockDisp_FormClosed);
                    break;
            }
        }

        #endregion
        
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button dispMed;
        private System.Windows.Forms.ComboBox medCB;
        private System.Windows.Forms.DataGridView stockList;
        private System.Windows.Forms.Button sellMed;
        private System.Windows.Forms.Button buyMed;
        private System.Windows.Forms.Button qrDisp;
    }
}