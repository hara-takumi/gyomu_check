﻿namespace GYOMU_CHECK
{
    partial class GC0030
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvIchiran = new System.Windows.Forms.DataGridView();
            this.btnReturn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMonthFrom = new System.Windows.Forms.ComboBox();
            this.cmbYearFrom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMonthTo = new System.Windows.Forms.ComboBox();
            this.cmbYearTo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbKbn = new System.Windows.Forms.ComboBox();
            this.chkKanryouzumi = new System.Windows.Forms.CheckBox();
            this.lblUserNm = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GYOMU_CHEACK = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GYOMU_SYUSEI = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SAGYO_YYMM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GYOMU_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GYOMU_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAGYO_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAGYO_STATUS_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAGYO_LAST_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAGYO_LAST_USER_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAGYO_LAST_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(41, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 100;
            this.label1.Text = "年月";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(37, 117);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 33);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(140, 117);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 33);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(244, 117);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 33);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "新規";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvIchiran
            // 
            this.dgvIchiran.AllowUserToAddRows = false;
            this.dgvIchiran.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIchiran.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIchiran.ColumnHeadersHeight = 40;
            this.dgvIchiran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvIchiran.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GYOMU_CHEACK,
            this.GYOMU_SYUSEI,
            this.SAGYO_YYMM,
            this.GYOMU_CD,
            this.GYOMU_NAME,
            this.SAGYO_STATUS,
            this.SAGYO_STATUS_NM,
            this.SAGYO_LAST_DATE,
            this.SAGYO_LAST_USER_CD,
            this.SAGYO_LAST_USER});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIchiran.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvIchiran.Location = new System.Drawing.Point(38, 167);
            this.dgvIchiran.Name = "dgvIchiran";
            this.dgvIchiran.ReadOnly = true;
            this.dgvIchiran.RowHeadersVisible = false;
            this.dgvIchiran.RowHeadersWidth = 30;
            this.dgvIchiran.RowTemplate.Height = 21;
            this.dgvIchiran.Size = new System.Drawing.Size(1143, 439);
            this.dgvIchiran.TabIndex = 10;
            this.dgvIchiran.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIchiran_CellContentClick);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReturn.Location = new System.Drawing.Point(38, 624);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(79, 36);
            this.btnReturn.TabIndex = 11;
            this.btnReturn.Text = "戻る";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(229, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 102;
            this.label3.Text = "～";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(158, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 16);
            this.label4.TabIndex = 101;
            this.label4.Text = "/";
            // 
            // cmbMonthFrom
            // 
            this.cmbMonthFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonthFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMonthFrom.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbMonthFrom.FormattingEnabled = true;
            this.cmbMonthFrom.Location = new System.Drawing.Point(180, 42);
            this.cmbMonthFrom.Name = "cmbMonthFrom";
            this.cmbMonthFrom.Size = new System.Drawing.Size(43, 24);
            this.cmbMonthFrom.TabIndex = 2;
            // 
            // cmbYearFrom
            // 
            this.cmbYearFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbYearFrom.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbYearFrom.FormattingEnabled = true;
            this.cmbYearFrom.Location = new System.Drawing.Point(87, 42);
            this.cmbYearFrom.Name = "cmbYearFrom";
            this.cmbYearFrom.Size = new System.Drawing.Size(65, 24);
            this.cmbYearFrom.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(330, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 16);
            this.label5.TabIndex = 103;
            this.label5.Text = "/";
            // 
            // cmbMonthTo
            // 
            this.cmbMonthTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonthTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMonthTo.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbMonthTo.FormattingEnabled = true;
            this.cmbMonthTo.Location = new System.Drawing.Point(352, 43);
            this.cmbMonthTo.Name = "cmbMonthTo";
            this.cmbMonthTo.Size = new System.Drawing.Size(43, 24);
            this.cmbMonthTo.TabIndex = 4;
            // 
            // cmbYearTo
            // 
            this.cmbYearTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbYearTo.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbYearTo.FormattingEnabled = true;
            this.cmbYearTo.Location = new System.Drawing.Point(259, 43);
            this.cmbYearTo.Name = "cmbYearTo";
            this.cmbYearTo.Size = new System.Drawing.Size(65, 24);
            this.cmbYearTo.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(41, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 105;
            this.label6.Text = "業務";
            // 
            // cmbKbn
            // 
            this.cmbKbn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKbn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbKbn.FormattingEnabled = true;
            this.cmbKbn.Location = new System.Drawing.Point(87, 84);
            this.cmbKbn.Name = "cmbKbn";
            this.cmbKbn.Size = new System.Drawing.Size(136, 20);
            this.cmbKbn.TabIndex = 5;
            // 
            // chkKanryouzumi
            // 
            this.chkKanryouzumi.AutoSize = true;
            this.chkKanryouzumi.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkKanryouzumi.Location = new System.Drawing.Point(259, 84);
            this.chkKanryouzumi.Name = "chkKanryouzumi";
            this.chkKanryouzumi.Size = new System.Drawing.Size(116, 20);
            this.chkKanryouzumi.TabIndex = 6;
            this.chkKanryouzumi.Text = "完了済を含む";
            this.chkKanryouzumi.UseVisualStyleBackColor = true;
            // 
            // lblUserNm
            // 
            this.lblUserNm.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUserNm.Location = new System.Drawing.Point(732, 11);
            this.lblUserNm.Name = "lblUserNm";
            this.lblUserNm.Size = new System.Drawing.Size(449, 18);
            this.lblUserNm.TabIndex = 104;
            this.lblUserNm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(40, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 106;
            this.label2.Text = "業務一覧";
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.DataPropertyName = "GYOMU_CHEACK";
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.DataPropertyName = "GYOMU_SYUSEI";
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // GYOMU_CHEACK
            // 
            this.GYOMU_CHEACK.DataPropertyName = "GYOMU_CHEACK";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GYOMU_CHEACK.DefaultCellStyle = dataGridViewCellStyle2;
            this.GYOMU_CHEACK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GYOMU_CHEACK.HeaderText = "";
            this.GYOMU_CHEACK.Name = "GYOMU_CHEACK";
            this.GYOMU_CHEACK.ReadOnly = true;
            this.GYOMU_CHEACK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GYOMU_CHEACK.Width = 120;
            // 
            // GYOMU_SYUSEI
            // 
            this.GYOMU_SYUSEI.DataPropertyName = "GYOMU_SYUSEI";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GYOMU_SYUSEI.DefaultCellStyle = dataGridViewCellStyle3;
            this.GYOMU_SYUSEI.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GYOMU_SYUSEI.HeaderText = "";
            this.GYOMU_SYUSEI.Name = "GYOMU_SYUSEI";
            this.GYOMU_SYUSEI.ReadOnly = true;
            this.GYOMU_SYUSEI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GYOMU_SYUSEI.Width = 120;
            // 
            // SAGYO_YYMM
            // 
            this.SAGYO_YYMM.DataPropertyName = "SAGYO_YYMM";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SAGYO_YYMM.DefaultCellStyle = dataGridViewCellStyle4;
            this.SAGYO_YYMM.HeaderText = "年月";
            this.SAGYO_YYMM.Name = "SAGYO_YYMM";
            this.SAGYO_YYMM.ReadOnly = true;
            // 
            // GYOMU_CD
            // 
            this.GYOMU_CD.DataPropertyName = "GYOMU_CD";
            this.GYOMU_CD.HeaderText = "業務CD";
            this.GYOMU_CD.Name = "GYOMU_CD";
            this.GYOMU_CD.ReadOnly = true;
            this.GYOMU_CD.Visible = false;
            // 
            // GYOMU_NAME
            // 
            this.GYOMU_NAME.DataPropertyName = "GYOMU_NAME";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GYOMU_NAME.DefaultCellStyle = dataGridViewCellStyle5;
            this.GYOMU_NAME.HeaderText = "業務";
            this.GYOMU_NAME.Name = "GYOMU_NAME";
            this.GYOMU_NAME.ReadOnly = true;
            this.GYOMU_NAME.Width = 150;
            // 
            // SAGYO_STATUS
            // 
            this.SAGYO_STATUS.DataPropertyName = "SAGYO_STATUS";
            this.SAGYO_STATUS.HeaderText = "進捗CD";
            this.SAGYO_STATUS.Name = "SAGYO_STATUS";
            this.SAGYO_STATUS.ReadOnly = true;
            this.SAGYO_STATUS.Visible = false;
            // 
            // SAGYO_STATUS_NM
            // 
            this.SAGYO_STATUS_NM.DataPropertyName = "SAGYO_STATUS_NM";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SAGYO_STATUS_NM.DefaultCellStyle = dataGridViewCellStyle6;
            this.SAGYO_STATUS_NM.HeaderText = "進捗";
            this.SAGYO_STATUS_NM.Name = "SAGYO_STATUS_NM";
            this.SAGYO_STATUS_NM.ReadOnly = true;
            // 
            // SAGYO_LAST_DATE
            // 
            this.SAGYO_LAST_DATE.DataPropertyName = "SAGYO_LAST_DATE";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SAGYO_LAST_DATE.DefaultCellStyle = dataGridViewCellStyle7;
            this.SAGYO_LAST_DATE.HeaderText = "最終使用日";
            this.SAGYO_LAST_DATE.Name = "SAGYO_LAST_DATE";
            this.SAGYO_LAST_DATE.ReadOnly = true;
            this.SAGYO_LAST_DATE.Width = 120;
            // 
            // SAGYO_LAST_USER_CD
            // 
            this.SAGYO_LAST_USER_CD.DataPropertyName = "SAGYO_LAST_USER_CD";
            this.SAGYO_LAST_USER_CD.HeaderText = "最終使用者CD";
            this.SAGYO_LAST_USER_CD.Name = "SAGYO_LAST_USER_CD";
            this.SAGYO_LAST_USER_CD.ReadOnly = true;
            this.SAGYO_LAST_USER_CD.Visible = false;
            this.SAGYO_LAST_USER_CD.Width = 120;
            // 
            // SAGYO_LAST_USER
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SAGYO_LAST_USER.DefaultCellStyle = dataGridViewCellStyle8;
            this.SAGYO_LAST_USER.HeaderText = "最終使用者";
            this.SAGYO_LAST_USER.Name = "SAGYO_LAST_USER";
            this.SAGYO_LAST_USER.ReadOnly = true;
            this.SAGYO_LAST_USER.Width = 120;
            // 
            // GC0030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 672);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUserNm);
            this.Controls.Add(this.chkKanryouzumi);
            this.Controls.Add(this.cmbKbn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbMonthTo);
            this.Controls.Add(this.cmbYearTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMonthFrom);
            this.Controls.Add(this.cmbYearFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.dgvIchiran);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Name = "GC0030";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "業務一覧画面[GC0030]";
            this.Load += new System.EventHandler(this.GC0030_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvIchiran;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMonthFrom;
        private System.Windows.Forms.ComboBox cmbYearFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMonthTo;
        private System.Windows.Forms.ComboBox cmbYearTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbKbn;
        private System.Windows.Forms.CheckBox chkKanryouzumi;
        private System.Windows.Forms.Label lblUserNm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn GYOMU_CHEACK;
        private System.Windows.Forms.DataGridViewButtonColumn GYOMU_SYUSEI;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_YYMM;
        private System.Windows.Forms.DataGridViewTextBoxColumn GYOMU_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn GYOMU_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_STATUS_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_LAST_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_LAST_USER_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_LAST_USER;
    }
}