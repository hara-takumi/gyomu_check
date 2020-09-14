namespace GYOMU_CHECK
{
    partial class GC0040
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvIchiran = new System.Windows.Forms.DataGridView();
            this.SAGYO_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAGYO_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARENT_FLG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.START_BUTTON = new GYOMU_CHECK.DataGridViewDisableButtonColumn();
            this.END_BUTTON = new GYOMU_CHECK.DataGridViewDisableButtonColumn();
            this.COLLECT_BUTTON = new GYOMU_CHECK.DataGridViewDisableButtonColumn();
            this.SAGYO_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAGYO_STATUS_OLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.START_EMPLOYEE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.START_EMPLOYEE_ID_OLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.START_EMPLOYEE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAGYO_START_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAGYO_START_DATE_OLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_EMPLOYEE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_EMPLOYEE_ID_OLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_EMPLOYEE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAGYO_END_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAGYO_END_DATE_OLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BIKOU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BIKOU_OLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHANGE_FLG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblGyomu = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblUserNm = new System.Windows.Forms.Label();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnInsert.Location = new System.Drawing.Point(177, 624);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(79, 36);
            this.btnInsert.TabIndex = 11;
            this.btnInsert.Text = "登録";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReturn.Location = new System.Drawing.Point(26, 624);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(79, 36);
            this.btnReturn.TabIndex = 10;
            this.btnReturn.Text = "戻る";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "チェック登録";
            // 
            // dgvIchiran
            // 
            this.dgvIchiran.AllowUserToAddRows = false;
            this.dgvIchiran.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIchiran.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIchiran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIchiran.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SAGYO_CD,
            this.SAGYO_NAME,
            this.PARENT_FLG,
            this.START_BUTTON,
            this.END_BUTTON,
            this.COLLECT_BUTTON,
            this.SAGYO_STATUS,
            this.SAGYO_STATUS_OLD,
            this.STATUS_NAME,
            this.START_EMPLOYEE_ID,
            this.START_EMPLOYEE_ID_OLD,
            this.START_EMPLOYEE_NAME,
            this.SAGYO_START_DATE,
            this.SAGYO_START_DATE_OLD,
            this.END_EMPLOYEE_ID,
            this.END_EMPLOYEE_ID_OLD,
            this.END_EMPLOYEE_NAME,
            this.SAGYO_END_DATE,
            this.SAGYO_END_DATE_OLD,
            this.BIKOU,
            this.BIKOU_OLD,
            this.CHANGE_FLG});
            this.dgvIchiran.Location = new System.Drawing.Point(26, 104);
            this.dgvIchiran.Name = "dgvIchiran";
            this.dgvIchiran.RowHeadersVisible = false;
            this.dgvIchiran.RowHeadersWidth = 51;
            this.dgvIchiran.RowTemplate.Height = 21;
            this.dgvIchiran.Size = new System.Drawing.Size(1166, 503);
            this.dgvIchiran.TabIndex = 9;
            this.dgvIchiran.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIchiran_CellContentClick);
            // 
            // SAGYO_CD
            // 
            this.SAGYO_CD.DataPropertyName = "SAGYO_CD";
            this.SAGYO_CD.HeaderText = "";
            this.SAGYO_CD.Name = "SAGYO_CD";
            this.SAGYO_CD.Visible = false;
            // 
            // SAGYO_NAME
            // 
            this.SAGYO_NAME.DataPropertyName = "SAGYO_NAME";
            this.SAGYO_NAME.HeaderText = "";
            this.SAGYO_NAME.Name = "SAGYO_NAME";
            this.SAGYO_NAME.ReadOnly = true;
            this.SAGYO_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SAGYO_NAME.Width = 400;
            // 
            // PARENT_FLG
            // 
            this.PARENT_FLG.DataPropertyName = "PARENT_FLG";
            this.PARENT_FLG.HeaderText = "PARENT_FLG";
            this.PARENT_FLG.Name = "PARENT_FLG";
            this.PARENT_FLG.Visible = false;
            // 
            // START_BUTTON
            // 
            this.START_BUTTON.DataPropertyName = "START_BUTTON";
            this.START_BUTTON.HeaderText = "";
            this.START_BUTTON.Name = "START_BUTTON";
            this.START_BUTTON.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.START_BUTTON.Width = 60;
            // 
            // END_BUTTON
            // 
            this.END_BUTTON.DataPropertyName = "END_BUTTON";
            this.END_BUTTON.HeaderText = "";
            this.END_BUTTON.Name = "END_BUTTON";
            this.END_BUTTON.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.END_BUTTON.Width = 60;
            // 
            // COLLECT_BUTTON
            // 
            this.COLLECT_BUTTON.DataPropertyName = "COLLECT_BUTTON";
            this.COLLECT_BUTTON.HeaderText = "";
            this.COLLECT_BUTTON.Name = "COLLECT_BUTTON";
            this.COLLECT_BUTTON.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COLLECT_BUTTON.Width = 60;
            // 
            // SAGYO_STATUS
            // 
            this.SAGYO_STATUS.DataPropertyName = "SAGYO_STATUS";
            this.SAGYO_STATUS.HeaderText = "SAGYO_STATUS";
            this.SAGYO_STATUS.Name = "SAGYO_STATUS";
            this.SAGYO_STATUS.Visible = false;
            // 
            // SAGYO_STATUS_OLD
            // 
            this.SAGYO_STATUS_OLD.DataPropertyName = "SAGYO_STATUS_OLD";
            this.SAGYO_STATUS_OLD.HeaderText = "SAGYO_STATUS_OLD";
            this.SAGYO_STATUS_OLD.Name = "SAGYO_STATUS_OLD";
            this.SAGYO_STATUS_OLD.Visible = false;
            // 
            // STATUS_NAME
            // 
            this.STATUS_NAME.DataPropertyName = "STATUS_NAME";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.STATUS_NAME.DefaultCellStyle = dataGridViewCellStyle2;
            this.STATUS_NAME.HeaderText = "状況";
            this.STATUS_NAME.Name = "STATUS_NAME";
            this.STATUS_NAME.ReadOnly = true;
            this.STATUS_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STATUS_NAME.Width = 60;
            // 
            // START_EMPLOYEE_ID
            // 
            this.START_EMPLOYEE_ID.DataPropertyName = "START_EMPLOYEE_ID";
            this.START_EMPLOYEE_ID.HeaderText = "作業開始者ID";
            this.START_EMPLOYEE_ID.Name = "START_EMPLOYEE_ID";
            this.START_EMPLOYEE_ID.Visible = false;
            // 
            // START_EMPLOYEE_ID_OLD
            // 
            this.START_EMPLOYEE_ID_OLD.DataPropertyName = "START_EMPLOYEE_ID_OLD";
            this.START_EMPLOYEE_ID_OLD.HeaderText = "START_EMPLOYEE_ID_OLD";
            this.START_EMPLOYEE_ID_OLD.Name = "START_EMPLOYEE_ID_OLD";
            this.START_EMPLOYEE_ID_OLD.Visible = false;
            // 
            // START_EMPLOYEE_NAME
            // 
            this.START_EMPLOYEE_NAME.DataPropertyName = "START_EMPLOYEE_NAME";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.START_EMPLOYEE_NAME.DefaultCellStyle = dataGridViewCellStyle3;
            this.START_EMPLOYEE_NAME.HeaderText = "作業開始者";
            this.START_EMPLOYEE_NAME.Name = "START_EMPLOYEE_NAME";
            this.START_EMPLOYEE_NAME.ReadOnly = true;
            this.START_EMPLOYEE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.START_EMPLOYEE_NAME.Width = 90;
            // 
            // SAGYO_START_DATE
            // 
            this.SAGYO_START_DATE.DataPropertyName = "SAGYO_START_DATE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SAGYO_START_DATE.DefaultCellStyle = dataGridViewCellStyle4;
            this.SAGYO_START_DATE.HeaderText = "開始日時";
            this.SAGYO_START_DATE.Name = "SAGYO_START_DATE";
            this.SAGYO_START_DATE.ReadOnly = true;
            this.SAGYO_START_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SAGYO_START_DATE.Width = 113;
            // 
            // SAGYO_START_DATE_OLD
            // 
            this.SAGYO_START_DATE_OLD.DataPropertyName = "SAGYO_START_DATE_OLD";
            this.SAGYO_START_DATE_OLD.HeaderText = "SAGYO_START_DATE_OLD";
            this.SAGYO_START_DATE_OLD.Name = "SAGYO_START_DATE_OLD";
            this.SAGYO_START_DATE_OLD.Visible = false;
            // 
            // END_EMPLOYEE_ID
            // 
            this.END_EMPLOYEE_ID.DataPropertyName = "END_EMPLOYEE_ID";
            this.END_EMPLOYEE_ID.HeaderText = "作業終了者ID";
            this.END_EMPLOYEE_ID.Name = "END_EMPLOYEE_ID";
            this.END_EMPLOYEE_ID.Visible = false;
            // 
            // END_EMPLOYEE_ID_OLD
            // 
            this.END_EMPLOYEE_ID_OLD.DataPropertyName = "END_EMPLOYEE_ID_OLD";
            this.END_EMPLOYEE_ID_OLD.HeaderText = "END_EMPLOYEE_ID_OLD";
            this.END_EMPLOYEE_ID_OLD.Name = "END_EMPLOYEE_ID_OLD";
            this.END_EMPLOYEE_ID_OLD.Visible = false;
            // 
            // END_EMPLOYEE_NAME
            // 
            this.END_EMPLOYEE_NAME.DataPropertyName = "END_EMPLOYEE_NAME";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.END_EMPLOYEE_NAME.DefaultCellStyle = dataGridViewCellStyle5;
            this.END_EMPLOYEE_NAME.HeaderText = "作業終了者";
            this.END_EMPLOYEE_NAME.Name = "END_EMPLOYEE_NAME";
            this.END_EMPLOYEE_NAME.ReadOnly = true;
            this.END_EMPLOYEE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.END_EMPLOYEE_NAME.Width = 90;
            // 
            // SAGYO_END_DATE
            // 
            this.SAGYO_END_DATE.DataPropertyName = "SAGYO_END_DATE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SAGYO_END_DATE.DefaultCellStyle = dataGridViewCellStyle6;
            this.SAGYO_END_DATE.HeaderText = "終了日時";
            this.SAGYO_END_DATE.Name = "SAGYO_END_DATE";
            this.SAGYO_END_DATE.ReadOnly = true;
            this.SAGYO_END_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SAGYO_END_DATE.Width = 113;
            // 
            // SAGYO_END_DATE_OLD
            // 
            this.SAGYO_END_DATE_OLD.DataPropertyName = "SAGYO_END_DATE_OLD";
            this.SAGYO_END_DATE_OLD.HeaderText = "SAGYO_END_DATE_OLD";
            this.SAGYO_END_DATE_OLD.Name = "SAGYO_END_DATE_OLD";
            this.SAGYO_END_DATE_OLD.Visible = false;
            // 
            // BIKOU
            // 
            this.BIKOU.DataPropertyName = "BIKOU";
            this.BIKOU.HeaderText = "備考";
            this.BIKOU.MaxInputLength = 100;
            this.BIKOU.Name = "BIKOU";
            this.BIKOU.ReadOnly = true;
            this.BIKOU.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BIKOU_OLD
            // 
            this.BIKOU_OLD.DataPropertyName = "BIKOU_OLD";
            this.BIKOU_OLD.HeaderText = "BIKOU_OLD";
            this.BIKOU_OLD.Name = "BIKOU_OLD";
            this.BIKOU_OLD.Visible = false;
            // 
            // CHANGE_FLG
            // 
            this.CHANGE_FLG.DataPropertyName = "CHANGE_FLG";
            this.CHANGE_FLG.FalseValue = "False";
            this.CHANGE_FLG.HeaderText = "";
            this.CHANGE_FLG.Name = "CHANGE_FLG";
            this.CHANGE_FLG.TrueValue = "True";
            this.CHANGE_FLG.Visible = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblYear);
            this.pnlHeader.Controls.Add(this.lblGyomu);
            this.pnlHeader.Controls.Add(this.label8);
            this.pnlHeader.Controls.Add(this.label10);
            this.pnlHeader.Location = new System.Drawing.Point(26, 32);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(747, 66);
            this.pnlHeader.TabIndex = 26;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYear.Location = new System.Drawing.Point(61, 6);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(42, 16);
            this.lblYear.TabIndex = 107;
            this.lblYear.Text = "年月";
            // 
            // lblGyomu
            // 
            this.lblGyomu.AutoSize = true;
            this.lblGyomu.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblGyomu.Location = new System.Drawing.Point(61, 41);
            this.lblGyomu.Name = "lblGyomu";
            this.lblGyomu.Size = new System.Drawing.Size(59, 16);
            this.lblGyomu.TabIndex = 9;
            this.lblGyomu.Text = "業務名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(5, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "業務";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(5, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "年月";
            // 
            // lblUserNm
            // 
            this.lblUserNm.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUserNm.Location = new System.Drawing.Point(662, 11);
            this.lblUserNm.Name = "lblUserNm";
            this.lblUserNm.Size = new System.Drawing.Size(530, 18);
            this.lblUserNm.TabIndex = 2;
            this.lblUserNm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.DataPropertyName = "START_BUTTON";
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Width = 60;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.DataPropertyName = "END_BUTTON";
            this.dataGridViewButtonColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Width = 60;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.DataPropertyName = "COLLECT_BUTTON";
            this.dataGridViewButtonColumn3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewButtonColumn3.HeaderText = "";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.Width = 60;
            // 
            // GC0040
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 672);
            this.Controls.Add(this.lblUserNm);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvIchiran);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.label1);
            this.Name = "GC0040";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "チェック一覧画面[GC0040]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GC0040_FormClosing);
            this.Load += new System.EventHandler(this.GC0040_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvIchiran;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblUserNm;
        private System.Windows.Forms.Label lblGyomu;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARENT_FLG;
        private DataGridViewDisableButtonColumn START_BUTTON;
        private DataGridViewDisableButtonColumn END_BUTTON;
        private DataGridViewDisableButtonColumn COLLECT_BUTTON;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_STATUS_OLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn START_EMPLOYEE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn START_EMPLOYEE_ID_OLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn START_EMPLOYEE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_START_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_START_DATE_OLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_EMPLOYEE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_EMPLOYEE_ID_OLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_EMPLOYEE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_END_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAGYO_END_DATE_OLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn BIKOU;
        private System.Windows.Forms.DataGridViewTextBoxColumn BIKOU_OLD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHANGE_FLG;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
    }
}