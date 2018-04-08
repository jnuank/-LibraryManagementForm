namespace BCHT01.dialog
{
    partial class BCHT0101
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
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnUserSearch = new System.Windows.Forms.Button();
            this.lblLoanEnd = new System.Windows.Forms.Label();
            this.lblLoanStart = new System.Windows.Forms.Label();
            this.dateLoanEnd = new System.Windows.Forms.DateTimePicker();
            this.dateLoanStart = new System.Windows.Forms.DateTimePicker();
            this.chkScheduleOver = new System.Windows.Forms.CheckBox();
            this.chkLending = new System.Windows.Forms.CheckBox();
            this.lblCategory3 = new System.Windows.Forms.Label();
            this.lblCategory2 = new System.Windows.Forms.Label();
            this.lblCategory1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupRanking = new System.Windows.Forms.GroupBox();
            this.groupTerm = new System.Windows.Forms.GroupBox();
            this.rdTotalTop = new System.Windows.Forms.RadioButton();
            this.rdYearTop = new System.Windows.Forms.RadioButton();
            this.rdMonthTop = new System.Windows.Forms.RadioButton();
            this.groupType = new System.Windows.Forms.GroupBox();
            this.rdUser = new System.Windows.Forms.RadioButton();
            this.rdBook = new System.Windows.Forms.RadioButton();
            this.chkRanking = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new Common.control.DataGridViewCustom();
            this.cmbCategory1 = new Common.control.CategoryDropDownList();
            this.cmbCategory2 = new Common.control.CategoryDropDownList();
            this.cmbCategory3 = new Common.control.CategoryDropDownList();
            this.groupSearch.SuspendLayout();
            this.groupRanking.SuspendLayout();
            this.groupTerm.SuspendLayout();
            this.groupType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupSearch
            // 
            this.groupSearch.Controls.Add(this.cmbCategory3);
            this.groupSearch.Controls.Add(this.cmbCategory2);
            this.groupSearch.Controls.Add(this.cmbCategory1);
            this.groupSearch.Controls.Add(this.lblUser);
            this.groupSearch.Controls.Add(this.label1);
            this.groupSearch.Controls.Add(this.txtUserName);
            this.groupSearch.Controls.Add(this.btnUserSearch);
            this.groupSearch.Controls.Add(this.lblLoanEnd);
            this.groupSearch.Controls.Add(this.lblLoanStart);
            this.groupSearch.Controls.Add(this.dateLoanEnd);
            this.groupSearch.Controls.Add(this.dateLoanStart);
            this.groupSearch.Controls.Add(this.chkScheduleOver);
            this.groupSearch.Controls.Add(this.chkLending);
            this.groupSearch.Controls.Add(this.lblCategory3);
            this.groupSearch.Controls.Add(this.lblCategory2);
            this.groupSearch.Controls.Add(this.lblCategory1);
            this.groupSearch.Controls.Add(this.txtTitle);
            this.groupSearch.Controls.Add(this.lblTitle);
            this.groupSearch.Controls.Add(this.lblId);
            this.groupSearch.Controls.Add(this.txtId);
            this.groupSearch.Location = new System.Drawing.Point(12, 12);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(759, 200);
            this.groupSearch.TabIndex = 0;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "検索条件";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.PowderBlue;
            this.lblUser.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUser.Location = new System.Drawing.Point(15, 171);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(66, 15);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "ユーザ名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(334, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "~";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtUserName.Location = new System.Drawing.Point(129, 164);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(121, 22);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.TabStop = false;
            // 
            // btnUserSearch
            // 
            this.btnUserSearch.Location = new System.Drawing.Point(256, 165);
            this.btnUserSearch.Name = "btnUserSearch";
            this.btnUserSearch.Size = new System.Drawing.Size(75, 23);
            this.btnUserSearch.TabIndex = 9;
            this.btnUserSearch.Text = "ユーザ検索";
            this.btnUserSearch.UseVisualStyleBackColor = true;
            this.btnUserSearch.Click += new System.EventHandler(this.btnUserSearch_Click);
            // 
            // lblLoanEnd
            // 
            this.lblLoanEnd.AutoSize = true;
            this.lblLoanEnd.BackColor = System.Drawing.Color.PowderBlue;
            this.lblLoanEnd.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLoanEnd.Location = new System.Drawing.Point(362, 136);
            this.lblLoanEnd.Name = "lblLoanEnd";
            this.lblLoanEnd.Size = new System.Drawing.Size(100, 15);
            this.lblLoanEnd.TabIndex = 0;
            this.lblLoanEnd.Text = "貸出日(終了)：";
            // 
            // lblLoanStart
            // 
            this.lblLoanStart.AutoSize = true;
            this.lblLoanStart.BackColor = System.Drawing.Color.PowderBlue;
            this.lblLoanStart.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLoanStart.Location = new System.Drawing.Point(15, 136);
            this.lblLoanStart.Name = "lblLoanStart";
            this.lblLoanStart.Size = new System.Drawing.Size(100, 15);
            this.lblLoanStart.TabIndex = 0;
            this.lblLoanStart.Text = "貸出日(開始)：";
            // 
            // dateLoanEnd
            // 
            this.dateLoanEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateLoanEnd.Location = new System.Drawing.Point(468, 134);
            this.dateLoanEnd.Name = "dateLoanEnd";
            this.dateLoanEnd.Size = new System.Drawing.Size(200, 19);
            this.dateLoanEnd.TabIndex = 8;
            this.dateLoanEnd.Value = new System.DateTime(2017, 4, 20, 0, 0, 0, 0);
            // 
            // dateLoanStart
            // 
            this.dateLoanStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateLoanStart.Location = new System.Drawing.Point(128, 134);
            this.dateLoanStart.Name = "dateLoanStart";
            this.dateLoanStart.Size = new System.Drawing.Size(200, 19);
            this.dateLoanStart.TabIndex = 7;
            this.dateLoanStart.Value = new System.DateTime(2017, 4, 20, 0, 0, 0, 0);
            // 
            // chkScheduleOver
            // 
            this.chkScheduleOver.AutoSize = true;
            this.chkScheduleOver.BackColor = System.Drawing.Color.PowderBlue;
            this.chkScheduleOver.Location = new System.Drawing.Point(129, 98);
            this.chkScheduleOver.Name = "chkScheduleOver";
            this.chkScheduleOver.Size = new System.Drawing.Size(108, 16);
            this.chkScheduleOver.TabIndex = 6;
            this.chkScheduleOver.Text = "返却予定日超過";
            this.chkScheduleOver.UseVisualStyleBackColor = false;
            this.chkScheduleOver.CheckedChanged += new System.EventHandler(this.chkScheduleOver_CheckedChanged);
            // 
            // chkLending
            // 
            this.chkLending.AutoSize = true;
            this.chkLending.BackColor = System.Drawing.Color.PowderBlue;
            this.chkLending.Location = new System.Drawing.Point(18, 98);
            this.chkLending.Name = "chkLending";
            this.chkLending.Size = new System.Drawing.Size(87, 16);
            this.chkLending.TabIndex = 5;
            this.chkLending.Text = "貸出中を除く";
            this.chkLending.UseVisualStyleBackColor = false;
            // 
            // lblCategory3
            // 
            this.lblCategory3.AutoSize = true;
            this.lblCategory3.BackColor = System.Drawing.Color.PowderBlue;
            this.lblCategory3.Location = new System.Drawing.Point(435, 66);
            this.lblCategory3.Name = "lblCategory3";
            this.lblCategory3.Size = new System.Drawing.Size(65, 12);
            this.lblCategory3.TabIndex = 0;
            this.lblCategory3.Text = "書籍区分3：";
            // 
            // lblCategory2
            // 
            this.lblCategory2.AutoSize = true;
            this.lblCategory2.BackColor = System.Drawing.Color.PowderBlue;
            this.lblCategory2.Location = new System.Drawing.Point(223, 66);
            this.lblCategory2.Name = "lblCategory2";
            this.lblCategory2.Size = new System.Drawing.Size(65, 12);
            this.lblCategory2.TabIndex = 0;
            this.lblCategory2.Text = "書籍区分2：";
            // 
            // lblCategory1
            // 
            this.lblCategory1.AutoSize = true;
            this.lblCategory1.BackColor = System.Drawing.Color.PowderBlue;
            this.lblCategory1.Location = new System.Drawing.Point(16, 68);
            this.lblCategory1.Name = "lblCategory1";
            this.lblCategory1.Size = new System.Drawing.Size(65, 12);
            this.lblCategory1.TabIndex = 0;
            this.lblCategory1.Text = "書籍区分1：";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(299, 25);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(442, 19);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.PowderBlue;
            this.lblTitle.Location = new System.Drawing.Point(233, 32);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(46, 12);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "タイトル：";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.BackColor = System.Drawing.Color.PowderBlue;
            this.lblId.Location = new System.Drawing.Point(16, 32);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(46, 12);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "書籍ID：";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(92, 25);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(118, 19);
            this.txtId.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1019, 571);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1019, 202);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(937, 202);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(937, 571);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "帳票出力";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupRanking
            // 
            this.groupRanking.Controls.Add(this.groupTerm);
            this.groupRanking.Controls.Add(this.groupType);
            this.groupRanking.Location = new System.Drawing.Point(787, 34);
            this.groupRanking.Name = "groupRanking";
            this.groupRanking.Size = new System.Drawing.Size(307, 162);
            this.groupRanking.TabIndex = 2;
            this.groupRanking.TabStop = false;
            // 
            // groupTerm
            // 
            this.groupTerm.Controls.Add(this.rdTotalTop);
            this.groupTerm.Controls.Add(this.rdYearTop);
            this.groupTerm.Controls.Add(this.rdMonthTop);
            this.groupTerm.Location = new System.Drawing.Point(165, 25);
            this.groupTerm.Name = "groupTerm";
            this.groupTerm.Size = new System.Drawing.Size(125, 120);
            this.groupTerm.TabIndex = 1;
            this.groupTerm.TabStop = false;
            this.groupTerm.Text = "期間";
            // 
            // rdTotalTop
            // 
            this.rdTotalTop.AutoSize = true;
            this.rdTotalTop.Location = new System.Drawing.Point(16, 68);
            this.rdTotalTop.Name = "rdTotalTop";
            this.rdTotalTop.Size = new System.Drawing.Size(81, 16);
            this.rdTotalTop.TabIndex = 2;
            this.rdTotalTop.TabStop = true;
            this.rdTotalTop.Text = "総合TOP10";
            this.rdTotalTop.UseVisualStyleBackColor = true;
            // 
            // rdYearTop
            // 
            this.rdYearTop.AutoSize = true;
            this.rdYearTop.Location = new System.Drawing.Point(16, 48);
            this.rdYearTop.Name = "rdYearTop";
            this.rdYearTop.Size = new System.Drawing.Size(81, 16);
            this.rdYearTop.TabIndex = 1;
            this.rdYearTop.TabStop = true;
            this.rdYearTop.Text = "年間TOP10";
            this.rdYearTop.UseVisualStyleBackColor = true;
            // 
            // rdMonthTop
            // 
            this.rdMonthTop.AutoSize = true;
            this.rdMonthTop.Location = new System.Drawing.Point(16, 26);
            this.rdMonthTop.Name = "rdMonthTop";
            this.rdMonthTop.Size = new System.Drawing.Size(81, 16);
            this.rdMonthTop.TabIndex = 0;
            this.rdMonthTop.TabStop = true;
            this.rdMonthTop.Text = "当月TOP10";
            this.rdMonthTop.UseVisualStyleBackColor = true;
            // 
            // groupType
            // 
            this.groupType.Controls.Add(this.rdUser);
            this.groupType.Controls.Add(this.rdBook);
            this.groupType.Location = new System.Drawing.Point(15, 25);
            this.groupType.Name = "groupType";
            this.groupType.Size = new System.Drawing.Size(122, 120);
            this.groupType.TabIndex = 0;
            this.groupType.TabStop = false;
            this.groupType.Text = "種別";
            // 
            // rdUser
            // 
            this.rdUser.AutoSize = true;
            this.rdUser.Location = new System.Drawing.Point(14, 47);
            this.rdUser.Name = "rdUser";
            this.rdUser.Size = new System.Drawing.Size(63, 16);
            this.rdUser.TabIndex = 1;
            this.rdUser.TabStop = true;
            this.rdUser.Text = "ユーザー";
            this.rdUser.UseVisualStyleBackColor = true;
            // 
            // rdBook
            // 
            this.rdBook.AutoSize = true;
            this.rdBook.Location = new System.Drawing.Point(14, 25);
            this.rdBook.Name = "rdBook";
            this.rdBook.Size = new System.Drawing.Size(35, 16);
            this.rdBook.TabIndex = 0;
            this.rdBook.TabStop = true;
            this.rdBook.Text = "本";
            this.rdBook.UseVisualStyleBackColor = true;
            // 
            // chkRanking
            // 
            this.chkRanking.AutoSize = true;
            this.chkRanking.Location = new System.Drawing.Point(787, 12);
            this.chkRanking.Name = "chkRanking";
            this.chkRanking.Size = new System.Drawing.Size(93, 16);
            this.chkRanking.TabIndex = 1;
            this.chkRanking.Text = "ランキング出力";
            this.chkRanking.UseVisualStyleBackColor = false;
            this.chkRanking.CheckedChanged += new System.EventHandler(this.chkRanking_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 239);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1082, 326);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.TabStop = false;
            // 
            // cmbCategory1
            // 
            this.cmbCategory1.FormattingEnabled = true;
            this.cmbCategory1.Location = new System.Drawing.Point(92, 63);
            this.cmbCategory1.Name = "cmbCategory1";
            this.cmbCategory1.Size = new System.Drawing.Size(121, 20);
            this.cmbCategory1.TabIndex = 2;
            // 
            // cmbCategory2
            // 
            this.cmbCategory2.FormattingEnabled = true;
            this.cmbCategory2.Location = new System.Drawing.Point(299, 60);
            this.cmbCategory2.Name = "cmbCategory2";
            this.cmbCategory2.Size = new System.Drawing.Size(121, 20);
            this.cmbCategory2.TabIndex = 3;
            // 
            // cmbCategory3
            // 
            this.cmbCategory3.FormattingEnabled = true;
            this.cmbCategory3.Location = new System.Drawing.Point(506, 60);
            this.cmbCategory3.Name = "cmbCategory3";
            this.cmbCategory3.Size = new System.Drawing.Size(121, 20);
            this.cmbCategory3.TabIndex = 4;
            // 
            // BCHT0101
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 632);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupRanking);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.chkRanking);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupSearch);
            this.Name = "BCHT0101";
            this.Text = "貸出履歴画面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BCHT0101_FormClosing);
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            this.groupRanking.ResumeLayout(false);
            this.groupTerm.ResumeLayout(false);
            this.groupTerm.PerformLayout();
            this.groupType.ResumeLayout(false);
            this.groupType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSearch;
        private System.Windows.Forms.CheckBox chkScheduleOver;
        private System.Windows.Forms.CheckBox chkLending;
        private System.Windows.Forms.Label lblCategory3;
        private System.Windows.Forms.Label lblCategory2;
        private System.Windows.Forms.Label lblCategory1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoanEnd;
        private System.Windows.Forms.Label lblLoanStart;
        private System.Windows.Forms.DateTimePicker dateLoanEnd;
        private System.Windows.Forms.DateTimePicker dateLoanStart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnUserSearch;
        private System.Windows.Forms.GroupBox groupRanking;
        private System.Windows.Forms.GroupBox groupTerm;
        private System.Windows.Forms.GroupBox groupType;
        private System.Windows.Forms.CheckBox chkRanking;
        private System.Windows.Forms.RadioButton rdTotalTop;
        private System.Windows.Forms.RadioButton rdYearTop;
        private System.Windows.Forms.RadioButton rdMonthTop;
        private System.Windows.Forms.RadioButton rdUser;
        private System.Windows.Forms.RadioButton rdBook;
        private Common.control.DataGridViewCustom dataGridView1;
        private Common.control.CategoryDropDownList cmbCategory1;
        private Common.control.CategoryDropDownList cmbCategory3;
        private Common.control.CategoryDropDownList cmbCategory2;
    }
}