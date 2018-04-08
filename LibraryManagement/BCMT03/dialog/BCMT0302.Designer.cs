namespace BCMT03.dialog
{
    partial class BCMT0302
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
            this.textId = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelAbbreviation = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.textAbbreviation = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(105, 42);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(260, 19);
            this.textName.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(222, 127);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "確定";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(302, 127);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(383, 127);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Controls.Add(this.labelAbbreviation);
            this.groupBox1.Controls.Add(this.labelId);
            this.groupBox1.Controls.Add(this.textAbbreviation);
            this.groupBox1.Controls.Add(this.textId);
            this.groupBox1.Controls.Add(this.textName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(103, 27);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 12);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "会社名";
            // 
            // labelAbbreviation
            // 
            this.labelAbbreviation.AutoSize = true;
            this.labelAbbreviation.Location = new System.Drawing.Point(369, 27);
            this.labelAbbreviation.Name = "labelAbbreviation";
            this.labelAbbreviation.Size = new System.Drawing.Size(53, 12);
            this.labelAbbreviation.TabIndex = 3;
            this.labelAbbreviation.Text = "会社略称";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(22, 27);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(40, 12);
            this.labelId.TabIndex = 4;
            this.labelId.Text = "会社ID";
            // 
            // textAbbreviation
            // 
            this.textAbbreviation.Location = new System.Drawing.Point(371, 42);
            this.textAbbreviation.Name = "textAbbreviation";
            this.textAbbreviation.Size = new System.Drawing.Size(75, 19);
            this.textAbbreviation.TabIndex = 1;
            // 
            // BCMT0302
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 164);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnApply);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BCMT0302";
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BCMT0302_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textAbbreviation;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelAbbreviation;
        private System.Windows.Forms.Label labelId;
    }
}