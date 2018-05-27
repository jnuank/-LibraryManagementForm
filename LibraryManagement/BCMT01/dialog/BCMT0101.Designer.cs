﻿namespace BCMT01.dialog
{
    partial class BCMT0101
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCategory3 = new Common.control.CategoryDropDownList();
            this.cmbCategory2 = new Common.control.CategoryDropDownList();
            this.cmbCategory1 = new Common.control.CategoryDropDownList();
            this.lblCategory3 = new System.Windows.Forms.Label();
            this.lblCategory2 = new System.Windows.Forms.Label();
            this.lblCategory1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtGridView = new BCMT01.dialog.BookMasterDataGridView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCategory3);
            this.groupBox1.Controls.Add(this.cmbCategory2);
            this.groupBox1.Controls.Add(this.cmbCategory1);
            this.groupBox1.Controls.Add(this.lblCategory3);
            this.groupBox1.Controls.Add(this.lblCategory2);
            this.groupBox1.Controls.Add(this.lblCategory1);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.lblTitle);
            this.groupBox1.Controls.Add(this.lblId);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Location = new System.Drawing.Point(28, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(928, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索条件";
            // 
            // cmbCategory3
            // 
            this.cmbCategory3.FormattingEnabled = true;
            this.cmbCategory3.Location = new System.Drawing.Point(740, 69);
            this.cmbCategory3.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory3.Name = "cmbCategory3";
            this.cmbCategory3.Size = new System.Drawing.Size(160, 23);
            this.cmbCategory3.TabIndex = 14;
            // 
            // cmbCategory2
            // 
            this.cmbCategory2.FormattingEnabled = true;
            this.cmbCategory2.Location = new System.Drawing.Point(440, 69);
            this.cmbCategory2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory2.Name = "cmbCategory2";
            this.cmbCategory2.Size = new System.Drawing.Size(160, 23);
            this.cmbCategory2.TabIndex = 13;
            // 
            // cmbCategory1
            // 
            this.cmbCategory1.FormattingEnabled = true;
            this.cmbCategory1.Location = new System.Drawing.Point(140, 69);
            this.cmbCategory1.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory1.Name = "cmbCategory1";
            this.cmbCategory1.Size = new System.Drawing.Size(160, 23);
            this.cmbCategory1.TabIndex = 6;
            // 
            // lblCategory3
            // 
            this.lblCategory3.AutoSize = true;
            this.lblCategory3.BackColor = System.Drawing.Color.PowderBlue;
            this.lblCategory3.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCategory3.Location = new System.Drawing.Point(621, 75);
            this.lblCategory3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory3.Name = "lblCategory3";
            this.lblCategory3.Size = new System.Drawing.Size(105, 19);
            this.lblCategory3.TabIndex = 12;
            this.lblCategory3.Text = "書籍区分3：";
            // 
            // lblCategory2
            // 
            this.lblCategory2.AutoSize = true;
            this.lblCategory2.BackColor = System.Drawing.Color.PowderBlue;
            this.lblCategory2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCategory2.Location = new System.Drawing.Point(321, 75);
            this.lblCategory2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory2.Name = "lblCategory2";
            this.lblCategory2.Size = new System.Drawing.Size(105, 19);
            this.lblCategory2.TabIndex = 11;
            this.lblCategory2.Text = "書籍区分2：";
            // 
            // lblCategory1
            // 
            this.lblCategory1.AutoSize = true;
            this.lblCategory1.BackColor = System.Drawing.Color.PowderBlue;
            this.lblCategory1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCategory1.Location = new System.Drawing.Point(21, 75);
            this.lblCategory1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory1.Name = "lblCategory1";
            this.lblCategory1.Size = new System.Drawing.Size(105, 19);
            this.lblCategory1.TabIndex = 9;
            this.lblCategory1.Text = "書籍区分1：";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(325, 31);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(575, 22);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.PowderBlue;
            this.lblTitle.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitle.Location = new System.Drawing.Point(223, 36);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(75, 19);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "タイトル：";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.BackColor = System.Drawing.Color.PowderBlue;
            this.lblId.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblId.Location = new System.Drawing.Point(21, 35);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(36, 19);
            this.lblId.TabIndex = 6;
            this.lblId.Text = "ID：";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(75, 31);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(135, 22);
            this.txtId.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(980, 111);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 29);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1101, 111);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 29);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(980, 449);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 29);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "新規作成";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1101, 449);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtGridView
            // 
            this.dtGridView.Location = new System.Drawing.Point(28, 147);
            this.dtGridView.Name = "dtGridView";
            this.dtGridView.Size = new System.Drawing.Size(1173, 295);
            this.dtGridView.TabIndex = 6;
            this.dtGridView.CellDubleClick += new BCMT01.dialog.BookMasterDataGridView.CellDubleClickHandler(this.dtGridView_CellDubleClick);
            // 
            // BCMT0101
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 485);
            this.Controls.Add(this.dtGridView);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "BCMT0101";
            this.Text = "書籍管理画面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BCMT0101_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCategory3;
        private System.Windows.Forms.Label lblCategory2;
        private System.Windows.Forms.Label lblCategory1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private Common.control.CategoryDropDownList cmbCategory1;
        private Common.control.CategoryDropDownList cmbCategory3;
        private Common.control.CategoryDropDownList cmbCategory2;
        private BookMasterDataGridView dtGridView;
    }
}