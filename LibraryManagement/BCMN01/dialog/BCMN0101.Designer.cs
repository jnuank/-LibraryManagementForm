namespace BCMN01.dialog
{
    partial class BCMN0101
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
            this.btnBookSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLend = new System.Windows.Forms.Button();
            this.btnGetBack = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuAdminPass = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBookMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCategoryMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCompanyMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBookSearch
            // 
            this.btnBookSearch.Location = new System.Drawing.Point(16, 89);
            this.btnBookSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBookSearch.Name = "btnBookSearch";
            this.btnBookSearch.Size = new System.Drawing.Size(155, 72);
            this.btnBookSearch.TabIndex = 0;
            this.btnBookSearch.Text = "図書検索画面";
            this.btnBookSearch.UseVisualStyleBackColor = true;
            this.btnBookSearch.Click += new System.EventHandler(this.btnBookSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(188, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "会社で保管している図書を検索します";
            // 
            // btnLend
            // 
            this.btnLend.Location = new System.Drawing.Point(16, 178);
            this.btnLend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLend.Name = "btnLend";
            this.btnLend.Size = new System.Drawing.Size(155, 72);
            this.btnLend.TabIndex = 1;
            this.btnLend.Text = "貸出画面";
            this.btnLend.UseVisualStyleBackColor = true;
            this.btnLend.Click += new System.EventHandler(this.btnLend_Click);
            // 
            // btnGetBack
            // 
            this.btnGetBack.Location = new System.Drawing.Point(16, 271);
            this.btnGetBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetBack.Name = "btnGetBack";
            this.btnGetBack.Size = new System.Drawing.Size(155, 72);
            this.btnGetBack.TabIndex = 2;
            this.btnGetBack.Text = "返却画面";
            this.btnGetBack.UseVisualStyleBackColor = true;
            this.btnGetBack.Click += new System.EventHandler(this.btnGetBack_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(16, 364);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(155, 72);
            this.btnHistory.TabIndex = 3;
            this.btnHistory.Text = "貸出履歴画面";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(281, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 34);
            this.label5.TabIndex = 11;
            this.label5.Text = "図書管理システム";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(188, 198);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "本の貸出を行います";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(188, 291);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "本の返却を行います";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(188, 384);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "貸出履歴を表示します";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdminPass,
            this.menuAdminTools});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(843, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuAdminPass
            // 
            this.menuAdminPass.Name = "menuAdminPass";
            this.menuAdminPass.Size = new System.Drawing.Size(169, 24);
            this.menuAdminPass.Text = "管理者パスワード入力(&P)";
            this.menuAdminPass.Click += new System.EventHandler(this.menuAdminPass_Click);
            // 
            // menuAdminTools
            // 
            this.menuAdminTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBookMaintenance,
            this.menuCategoryMaintenance,
            this.menuUserMaintenance,
            this.menuCompanyMaintenance,
            this.menuAdminMaintenance});
            this.menuAdminTools.Enabled = false;
            this.menuAdminTools.Name = "menuAdminTools";
            this.menuAdminTools.Size = new System.Drawing.Size(128, 24);
            this.menuAdminTools.Text = "管理者メニュー(&A)";
            // 
            // menuBookMaintenance
            // 
            this.menuBookMaintenance.Name = "menuBookMaintenance";
            this.menuBookMaintenance.Size = new System.Drawing.Size(249, 26);
            this.menuBookMaintenance.Text = "書籍マスタメンテナンス(&B)";
            this.menuBookMaintenance.Click += new System.EventHandler(this.menuBookMaintenance_Click);
            // 
            // menuCategoryMaintenance
            // 
            this.menuCategoryMaintenance.Name = "menuCategoryMaintenance";
            this.menuCategoryMaintenance.Size = new System.Drawing.Size(249, 26);
            this.menuCategoryMaintenance.Text = "分類マスタメンテナンス(&C)";
            this.menuCategoryMaintenance.Click += new System.EventHandler(this.menuCategoryMaintenance_Click);
            // 
            // menuUserMaintenance
            // 
            this.menuUserMaintenance.Name = "menuUserMaintenance";
            this.menuUserMaintenance.Size = new System.Drawing.Size(249, 26);
            this.menuUserMaintenance.Text = "ユーザマスタメンテナンス(&U)";
            this.menuUserMaintenance.Click += new System.EventHandler(this.menuUserMaintenance_Click);
            // 
            // menuCompanyMaintenance
            // 
            this.menuCompanyMaintenance.Name = "menuCompanyMaintenance";
            this.menuCompanyMaintenance.Size = new System.Drawing.Size(249, 26);
            this.menuCompanyMaintenance.Text = "会社マスタメンテナンス(&M)";
            this.menuCompanyMaintenance.Click += new System.EventHandler(this.menuCompanyMaintenance_Click);
            // 
            // menuAdminMaintenance
            // 
            this.menuAdminMaintenance.Name = "menuAdminMaintenance";
            this.menuAdminMaintenance.Size = new System.Drawing.Size(249, 26);
            this.menuAdminMaintenance.Text = "管理者マスタメンテナンス(&D)";
            this.menuAdminMaintenance.Click += new System.EventHandler(this.menuAdminMaintenance_Click);
            // 
            // BCMN0101
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 471);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnGetBack);
            this.Controls.Add(this.btnLend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBookSearch);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "BCMN0101";
            this.Text = "メニュー画面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BCMN0101_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBookSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLend;
        private System.Windows.Forms.Button btnGetBack;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdminPass;
        private System.Windows.Forms.ToolStripMenuItem menuAdminTools;
        private System.Windows.Forms.ToolStripMenuItem menuBookMaintenance;
        private System.Windows.Forms.ToolStripMenuItem menuCategoryMaintenance;
        private System.Windows.Forms.ToolStripMenuItem menuUserMaintenance;
        private System.Windows.Forms.ToolStripMenuItem menuCompanyMaintenance;
        private System.Windows.Forms.ToolStripMenuItem menuAdminMaintenance;
    }
}