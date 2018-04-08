namespace BCMT04.dialog
{
    partial class BCMT0401
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.textUser = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.groupRetired = new System.Windows.Forms.GroupBox();
            this.rdobtnExcludedRetired = new System.Windows.Forms.RadioButton();
            this.rdobtnIncludedRetired = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new Common.control.DataGridViewCustom();
            this.groupSearch.SuspendLayout();
            this.groupRetired.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(490, 98);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(584, 98);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(65, 61);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(121, 20);
            this.cmbCompany.TabIndex = 1;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(6, 64);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(53, 12);
            this.lblCompany.TabIndex = 6;
            this.lblCompany.Text = "所属会社";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(9, 28);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(47, 12);
            this.lblUser.TabIndex = 7;
            this.lblUser.Text = "ユーザ名";
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(65, 25);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(121, 19);
            this.textUser.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(490, 311);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "新規作成";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(584, 311);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupSearch
            // 
            this.groupSearch.Controls.Add(this.cmbCompany);
            this.groupSearch.Controls.Add(this.lblCompany);
            this.groupSearch.Controls.Add(this.lblUser);
            this.groupSearch.Controls.Add(this.textUser);
            this.groupSearch.Controls.Add(this.groupRetired);
            this.groupSearch.Location = new System.Drawing.Point(12, 12);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(463, 114);
            this.groupSearch.TabIndex = 0;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "検索条件";
            // 
            // groupRetired
            // 
            this.groupRetired.Controls.Add(this.rdobtnExcludedRetired);
            this.groupRetired.Controls.Add(this.rdobtnIncludedRetired);
            this.groupRetired.Location = new System.Drawing.Point(209, 18);
            this.groupRetired.Name = "groupRetired";
            this.groupRetired.Size = new System.Drawing.Size(81, 68);
            this.groupRetired.TabIndex = 2;
            this.groupRetired.TabStop = false;
            this.groupRetired.Text = "退職者";
            // 
            // rdobtnExcludedRetired
            // 
            this.rdobtnExcludedRetired.AutoSize = true;
            this.rdobtnExcludedRetired.Location = new System.Drawing.Point(6, 42);
            this.rdobtnExcludedRetired.Name = "rdobtnExcludedRetired";
            this.rdobtnExcludedRetired.Size = new System.Drawing.Size(65, 16);
            this.rdobtnExcludedRetired.TabIndex = 1;
            this.rdobtnExcludedRetired.TabStop = true;
            this.rdobtnExcludedRetired.Text = "含めない";
            this.rdobtnExcludedRetired.UseVisualStyleBackColor = true;
            // 
            // rdobtnIncludedRetired
            // 
            this.rdobtnIncludedRetired.AutoSize = true;
            this.rdobtnIncludedRetired.Location = new System.Drawing.Point(6, 20);
            this.rdobtnIncludedRetired.Name = "rdobtnIncludedRetired";
            this.rdobtnIncludedRetired.Size = new System.Drawing.Size(54, 16);
            this.rdobtnIncludedRetired.TabIndex = 0;
            this.rdobtnIncludedRetired.TabStop = true;
            this.rdobtnIncludedRetired.Text = "含める";
            this.rdobtnIncludedRetired.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(647, 173);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // BCMT0401
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 346);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Name = "BCMT0401";
            this.Text = "ユーザメンテナンス画面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BCMT0401_FormClosing);
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            this.groupRetired.ResumeLayout(false);
            this.groupRetired.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupSearch;
        private System.Windows.Forms.GroupBox groupRetired;
        private System.Windows.Forms.RadioButton rdobtnExcludedRetired;
        private System.Windows.Forms.RadioButton rdobtnIncludedRetired;
        private Common.control.DataGridViewCustom dataGridView1;
    }
}