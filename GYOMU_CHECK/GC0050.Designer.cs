namespace GYOMU_CHECK
{
    partial class GC0050
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.dgvIchiran = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKbn = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDisply = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblUserNm = new System.Windows.Forms.Label();
            this.lblUpd = new System.Windows.Forms.Label();
            this.pnlUpd = new System.Windows.Forms.Panel();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblGyomu = new System.Windows.Forms.Label();
            this.pnlIns = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).BeginInit();
            this.pnlUpd.SuspendLayout();
            this.pnlIns.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(74, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 103;
            this.label3.Text = "/";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMonth.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(96, 3);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(43, 24);
            this.cmbMonth.TabIndex = 2;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // cmbYear
            // 
            this.cmbYear.BackColor = System.Drawing.SystemColors.Window;
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbYear.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(3, 3);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(65, 24);
            this.cmbYear.TabIndex = 1;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // dgvIchiran
            // 
            this.dgvIchiran.AllowUserToAddRows = false;
            this.dgvIchiran.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIchiran.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIchiran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIchiran.Location = new System.Drawing.Point(35, 168);
            this.dgvIchiran.Name = "dgvIchiran";
            this.dgvIchiran.RowHeadersVisible = false;
            this.dgvIchiran.RowHeadersWidth = 51;
            this.dgvIchiran.RowTemplate.Height = 21;
            this.dgvIchiran.Size = new System.Drawing.Size(1166, 437);
            this.dgvIchiran.TabIndex = 5;
            this.dgvIchiran.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIchiran_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(34, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 102;
            this.label2.Text = "年月";
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnInsert.Location = new System.Drawing.Point(207, 624);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(79, 36);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "登録";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReturn.Location = new System.Drawing.Point(35, 624);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(79, 36);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "戻る";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 100;
            this.label1.Text = "業務登録";
            // 
            // cmbKbn
            // 
            this.cmbKbn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKbn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbKbn.FormattingEnabled = true;
            this.cmbKbn.Location = new System.Drawing.Point(3, 46);
            this.cmbKbn.Name = "cmbKbn";
            this.cmbKbn.Size = new System.Drawing.Size(136, 20);
            this.cmbKbn.TabIndex = 3;
            this.cmbKbn.SelectedIndexChanged += new System.EventHandler(this.cmbKbn_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(34, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 104;
            this.label6.Text = "業務";
            // 
            // btnDisply
            // 
            this.btnDisply.Location = new System.Drawing.Point(80, 119);
            this.btnDisply.Name = "btnDisply";
            this.btnDisply.Size = new System.Drawing.Size(80, 33);
            this.btnDisply.TabIndex = 4;
            this.btnDisply.Text = "表示";
            this.btnDisply.UseVisualStyleBackColor = true;
            this.btnDisply.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDelete.Location = new System.Drawing.Point(292, 624);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 36);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblUserNm
            // 
            this.lblUserNm.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUserNm.Location = new System.Drawing.Point(712, 11);
            this.lblUserNm.Name = "lblUserNm";
            this.lblUserNm.Size = new System.Drawing.Size(483, 18);
            this.lblUserNm.TabIndex = 101;
            this.lblUserNm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUpd
            // 
            this.lblUpd.AutoSize = true;
            this.lblUpd.ForeColor = System.Drawing.Color.Red;
            this.lblUpd.Location = new System.Drawing.Point(452, 129);
            this.lblUpd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUpd.Name = "lblUpd";
            this.lblUpd.Size = new System.Drawing.Size(248, 12);
            this.lblUpd.TabIndex = 105;
            this.lblUpd.Text = "※開始済みの作業の実施要否の変更はできません";
            // 
            // pnlUpd
            // 
            this.pnlUpd.Controls.Add(this.lblYear);
            this.pnlUpd.Controls.Add(this.lblGyomu);
            this.pnlUpd.Location = new System.Drawing.Point(80, 37);
            this.pnlUpd.Name = "pnlUpd";
            this.pnlUpd.Size = new System.Drawing.Size(232, 76);
            this.pnlUpd.TabIndex = 106;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYear.Location = new System.Drawing.Point(3, 11);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(42, 16);
            this.lblYear.TabIndex = 107;
            this.lblYear.Text = "年月";
            // 
            // lblGyomu
            // 
            this.lblGyomu.AutoSize = true;
            this.lblGyomu.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblGyomu.Location = new System.Drawing.Point(3, 50);
            this.lblGyomu.Name = "lblGyomu";
            this.lblGyomu.Size = new System.Drawing.Size(59, 16);
            this.lblGyomu.TabIndex = 9;
            this.lblGyomu.Text = "業務名";
            // 
            // pnlIns
            // 
            this.pnlIns.Controls.Add(this.cmbMonth);
            this.pnlIns.Controls.Add(this.cmbYear);
            this.pnlIns.Controls.Add(this.label3);
            this.pnlIns.Controls.Add(this.cmbKbn);
            this.pnlIns.Location = new System.Drawing.Point(80, 37);
            this.pnlIns.Name = "pnlIns";
            this.pnlIns.Size = new System.Drawing.Size(232, 76);
            this.pnlIns.TabIndex = 107;
            // 
            // GC0050
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 672);
            this.Controls.Add(this.pnlIns);
            this.Controls.Add(this.pnlUpd);
            this.Controls.Add(this.lblUpd);
            this.Controls.Add(this.lblUserNm);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDisply);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvIchiran);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.label1);
            this.Name = "GC0050";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "業務登録画面[GC0050]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Proto_FormClosing);
            this.Load += new System.EventHandler(this.GC0050_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).EndInit();
            this.pnlUpd.ResumeLayout(false);
            this.pnlUpd.PerformLayout();
            this.pnlIns.ResumeLayout(false);
            this.pnlIns.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.DataGridView dgvIchiran;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKbn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDisply;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblUserNm;
        private System.Windows.Forms.Label lblUpd;
        private System.Windows.Forms.Panel pnlUpd;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblGyomu;
        private System.Windows.Forms.Panel pnlIns;
    }
}