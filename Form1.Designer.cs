namespace ContactsFromDB_dotnet_4._7._2
{
    partial class Form1
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
            this.btnnew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnexport = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtname2 = new System.Windows.Forms.TextBox();
            this.txtnumber2 = new System.Windows.Forms.TextBox();
            this.txtid2 = new System.Windows.Forms.TextBox();
            this.pbform1 = new System.Windows.Forms.PictureBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.chkdel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbform1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(12, 12);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(122, 33);
            this.btnnew.TabIndex = 0;
            this.btnnew.Text = "New Contact";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(15, 67);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(343, 22);
            this.txtsearch.TabIndex = 1;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // btnexport
            // 
            this.btnexport.Location = new System.Drawing.Point(616, 64);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(122, 28);
            this.btnexport.TabIndex = 3;
            this.btnexport.Text = "Export to Excel";
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 95);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(726, 569);
            this.dgv.TabIndex = 4;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtname2);
            this.groupBox1.Controls.Add(this.txtnumber2);
            this.groupBox1.Controls.Add(this.txtid2);
            this.groupBox1.Controls.Add(this.pbform1);
            this.groupBox1.Controls.Add(this.btnedit);
            this.groupBox1.Controls.Add(this.btndel);
            this.groupBox1.Location = new System.Drawing.Point(744, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 569);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detailed Information";
            // 
            // txtname2
            // 
            this.txtname2.Location = new System.Drawing.Point(18, 470);
            this.txtname2.Name = "txtname2";
            this.txtname2.ReadOnly = true;
            this.txtname2.Size = new System.Drawing.Size(522, 22);
            this.txtname2.TabIndex = 10;
            // 
            // txtnumber2
            // 
            this.txtnumber2.Location = new System.Drawing.Point(18, 535);
            this.txtnumber2.Name = "txtnumber2";
            this.txtnumber2.ReadOnly = true;
            this.txtnumber2.Size = new System.Drawing.Size(522, 22);
            this.txtnumber2.TabIndex = 9;
            // 
            // txtid2
            // 
            this.txtid2.Location = new System.Drawing.Point(18, 408);
            this.txtid2.Name = "txtid2";
            this.txtid2.ReadOnly = true;
            this.txtid2.Size = new System.Drawing.Size(522, 22);
            this.txtid2.TabIndex = 6;
            // 
            // pbform1
            // 
            this.pbform1.Location = new System.Drawing.Point(18, 21);
            this.pbform1.Name = "pbform1";
            this.pbform1.Size = new System.Drawing.Size(638, 359);
            this.pbform1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbform1.TabIndex = 8;
            this.pbform1.TabStop = false;
            // 
            // btnedit
            // 
            this.btnedit.Enabled = false;
            this.btnedit.Location = new System.Drawing.Point(546, 530);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(122, 33);
            this.btnedit.TabIndex = 5;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btndel
            // 
            this.btndel.Enabled = false;
            this.btndel.Location = new System.Drawing.Point(546, 403);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(122, 33);
            this.btndel.TabIndex = 4;
            this.btndel.Text = "Delete";
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // chkdel
            // 
            this.chkdel.AutoSize = true;
            this.chkdel.Location = new System.Drawing.Point(364, 69);
            this.chkdel.Name = "chkdel";
            this.chkdel.Size = new System.Drawing.Size(113, 20);
            this.chkdel.TabIndex = 2;
            this.chkdel.Text = "Show Deleted";
            this.chkdel.UseVisualStyleBackColor = true;
            this.chkdel.CheckedChanged += new System.EventHandler(this.chkdel_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1430, 676);
            this.Controls.Add(this.chkdel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnnew);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbform1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtname2;
        private System.Windows.Forms.TextBox txtnumber2;
        private System.Windows.Forms.TextBox txtid2;
        private System.Windows.Forms.PictureBox pbform1;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.CheckBox chkdel;
    }
}

