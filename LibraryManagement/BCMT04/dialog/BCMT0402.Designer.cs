namespace BCMT04.dialog
{
    partial class BCMT0402
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
            if ( disposing && (components != null) )
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
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.textUser = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelAbbreviation = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.textMail = new System.Windows.Forms.TextBox();
            this.textId = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(151, 77);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(121, 20);
            this.cmbCompany.TabIndex = 1;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(149, 62);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(53, 12);
            this.lblCompany.TabIndex = 10;
            this.lblCompany.Text = "所属会社";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(22, 62);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(47, 12);
            this.lblUser.TabIndex = 11;
            this.lblUser.Text = "ユーザ名";
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(24, 77);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(121, 19);
            this.textUser.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelAbbreviation);
            this.groupBox1.Controls.Add(this.lblCompany);
            this.groupBox1.Controls.Add(this.cmbCompany);
            this.groupBox1.Controls.Add(this.labelId);
            this.groupBox1.Controls.Add(this.textMail);
            this.groupBox1.Controls.Add(this.textUser);
            this.groupBox1.Controls.Add(this.lblUser);
            this.groupBox1.Controls.Add(this.textId);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // labelAbbreviation
            // 
            this.labelAbbreviation.AutoSize = true;
            this.labelAbbreviation.Location = new System.Drawing.Point(287, 62);
            this.labelAbbreviation.Name = "labelAbbreviation";
            this.labelAbbreviation.Size = new System.Drawing.Size(69, 12);
            this.labelAbbreviation.TabIndex = 3;
            this.labelAbbreviation.Text = "メールアドレス";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(22, 27);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(46, 12);
            this.labelId.TabIndex = 3;
            this.labelId.Text = "ユーザID";
            // 
            // textMail
            // 
            this.textMail.Location = new System.Drawing.Point(289, 77);
            this.textMail.Name = "textMail";
            this.textMail.Size = new System.Drawing.Size(332, 19);
            this.textMail.TabIndex = 2;
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(24, 42);
            this.textId.Name = "textId";
            this.textId.ReadOnly = true;
            this.textId.Size = new System.Drawing.Size(75, 19);
            this.textId.TabIndex = 0;
            this.textId.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(576, 147);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(495, 147);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(415, 147);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "確定";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // BCMT0402
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 180);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.Name = "BCMT0402";
            this.Text = "編集画面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BCMT0402_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelAbbreviation;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textMail;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnApply;
    }
}