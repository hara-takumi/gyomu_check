namespace GYOMU_CHECK
{
    partial class GC0060
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
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlStart = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbMStart = new System.Windows.Forms.ComboBox();
            this.cmbHStart = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLbl = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.pnlEnd = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMEnd = new System.Windows.Forms.ComboBox();
            this.cmbHEnd = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnStartCancel = new System.Windows.Forms.Button();
            this.btnEndCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblKbn = new System.Windows.Forms.Label();
            this.lblSagyo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlStart.SuspendLayout();
            this.pnlLbl.SuspendLayout();
            this.pnlEnd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReturn.Location = new System.Drawing.Point(63, 395);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(88, 36);
            this.btnReturn.TabIndex = 16;
            this.btnReturn.Text = "戻る";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnInsert.Location = new System.Drawing.Point(396, 395);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(88, 36);
            this.btnInsert.TabIndex = 17;
            this.btnInsert.Text = "登録";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMessage.Location = new System.Drawing.Point(141, 176);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(290, 27);
            this.lblMessage.TabIndex = 104;
            this.lblMessage.Text = "開始日";
            // 
            // pnlStart
            // 
            this.pnlStart.Controls.Add(this.label8);
            this.pnlStart.Controls.Add(this.cmbMStart);
            this.pnlStart.Controls.Add(this.cmbHStart);
            this.pnlStart.Controls.Add(this.dtpStart);
            this.pnlStart.Controls.Add(this.label2);
            this.pnlStart.Controls.Add(this.label1);
            this.pnlStart.Location = new System.Drawing.Point(122, 206);
            this.pnlStart.Name = "pnlStart";
            this.pnlStart.Size = new System.Drawing.Size(258, 97);
            this.pnlStart.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(155, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 107;
            this.label8.Text = "：";
            // 
            // cmbMStart
            // 
            this.cmbMStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMStart.FormattingEnabled = true;
            this.cmbMStart.Location = new System.Drawing.Point(172, 61);
            this.cmbMStart.MaxLength = 2;
            this.cmbMStart.Name = "cmbMStart";
            this.cmbMStart.Size = new System.Drawing.Size(42, 20);
            this.cmbMStart.TabIndex = 8;
            this.cmbMStart.DropDownClosed += new System.EventHandler(this.DropDownClosed);
            this.cmbMStart.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DropDownKeyDown);
            this.cmbMStart.MouseLeave += new System.EventHandler(this.MouseLeave);
            // 
            // cmbHStart
            // 
            this.cmbHStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbHStart.FormattingEnabled = true;
            this.cmbHStart.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbHStart.Location = new System.Drawing.Point(109, 61);
            this.cmbHStart.MaxLength = 2;
            this.cmbHStart.Name = "cmbHStart";
            this.cmbHStart.Size = new System.Drawing.Size(40, 20);
            this.cmbHStart.TabIndex = 7;
            this.cmbHStart.DropDownClosed += new System.EventHandler(this.DropDownClosed);
            this.cmbHStart.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DropDownKeyDown);
            this.cmbHStart.MouseLeave += new System.EventHandler(this.MouseLeave);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(109, 16);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(131, 19);
            this.dtpStart.TabIndex = 6;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(19, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 106;
            this.label2.Text = "開始時刻";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 105;
            this.label1.Text = "開始日";
            // 
            // pnlLbl
            // 
            this.pnlLbl.Controls.Add(this.label11);
            this.pnlLbl.Controls.Add(this.label9);
            this.pnlLbl.Controls.Add(this.lblStartDate);
            this.pnlLbl.Controls.Add(this.lblStartTime);
            this.pnlLbl.Controls.Add(this.lblStart);
            this.pnlLbl.Location = new System.Drawing.Point(122, 205);
            this.pnlLbl.Name = "pnlLbl";
            this.pnlLbl.Size = new System.Drawing.Size(258, 97);
            this.pnlLbl.TabIndex = 110;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(19, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 112;
            this.label11.Text = "開始時刻";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(19, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 111;
            this.label9.Text = "開始日";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStartDate.Location = new System.Drawing.Point(112, 17);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(88, 16);
            this.lblStartDate.TabIndex = 110;
            this.lblStartDate.Text = "2020/01/01";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStartTime.Location = new System.Drawing.Point(112, 62);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(38, 14);
            this.lblStartTime.TabIndex = 109;
            this.lblStartTime.Text = "00:00";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStart.Location = new System.Drawing.Point(106, 21);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(0, 14);
            this.lblStart.TabIndex = 108;
            // 
            // pnlEnd
            // 
            this.pnlEnd.Controls.Add(this.label5);
            this.pnlEnd.Controls.Add(this.cmbMEnd);
            this.pnlEnd.Controls.Add(this.cmbHEnd);
            this.pnlEnd.Controls.Add(this.dtpEnd);
            this.pnlEnd.Controls.Add(this.label4);
            this.pnlEnd.Controls.Add(this.label3);
            this.pnlEnd.Location = new System.Drawing.Point(122, 308);
            this.pnlEnd.Name = "pnlEnd";
            this.pnlEnd.Size = new System.Drawing.Size(258, 84);
            this.pnlEnd.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 110;
            this.label5.Text = "：";
            // 
            // cmbMEnd
            // 
            this.cmbMEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMEnd.FormattingEnabled = true;
            this.cmbMEnd.Location = new System.Drawing.Point(172, 56);
            this.cmbMEnd.MaxLength = 2;
            this.cmbMEnd.Name = "cmbMEnd";
            this.cmbMEnd.Size = new System.Drawing.Size(42, 20);
            this.cmbMEnd.TabIndex = 12;
            this.cmbMEnd.DropDownClosed += new System.EventHandler(this.DropDownClosed);
            this.cmbMEnd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DropDownKeyDown);
            this.cmbMEnd.MouseLeave += new System.EventHandler(this.MouseLeave);
            // 
            // cmbHEnd
            // 
            this.cmbHEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbHEnd.FormattingEnabled = true;
            this.cmbHEnd.Location = new System.Drawing.Point(109, 56);
            this.cmbHEnd.MaxLength = 2;
            this.cmbHEnd.Name = "cmbHEnd";
            this.cmbHEnd.Size = new System.Drawing.Size(40, 20);
            this.cmbHEnd.TabIndex = 11;
            this.cmbHEnd.DropDownClosed += new System.EventHandler(this.DropDownClosed);
            this.cmbHEnd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DropDownKeyDown);
            this.cmbHEnd.MouseLeave += new System.EventHandler(this.MouseLeave);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(109, 9);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(131, 19);
            this.dtpEnd.TabIndex = 10;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(19, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 109;
            this.label4.Text = "終了時刻";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(19, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 108;
            this.label3.Text = "終了日";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.Location = new System.Drawing.Point(111, 138);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 16);
            this.label15.TabIndex = 103;
            this.label15.Text = "作業";
            // 
            // btnStartCancel
            // 
            this.btnStartCancel.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStartCancel.Location = new System.Drawing.Point(396, 226);
            this.btnStartCancel.Name = "btnStartCancel";
            this.btnStartCancel.Size = new System.Drawing.Size(88, 36);
            this.btnStartCancel.TabIndex = 14;
            this.btnStartCancel.Text = "開始取消";
            this.btnStartCancel.UseVisualStyleBackColor = true;
            this.btnStartCancel.Click += new System.EventHandler(this.btnStartCancel_Click);
            // 
            // btnEndCancel
            // 
            this.btnEndCancel.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEndCancel.Location = new System.Drawing.Point(396, 332);
            this.btnEndCancel.Name = "btnEndCancel";
            this.btnEndCancel.Size = new System.Drawing.Size(88, 36);
            this.btnEndCancel.TabIndex = 15;
            this.btnEndCancel.Text = "終了取消";
            this.btnEndCancel.UseVisualStyleBackColor = true;
            this.btnEndCancel.Click += new System.EventHandler(this.btnEndCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(111, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 102;
            this.label7.Text = "業務";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(111, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 100;
            this.label10.Text = "年月";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDate.Location = new System.Drawing.Point(173, 70);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(24, 16);
            this.lblDate.TabIndex = 105;
            this.lblDate.Text = "年";
            // 
            // lblKbn
            // 
            this.lblKbn.AutoSize = true;
            this.lblKbn.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblKbn.Location = new System.Drawing.Point(173, 103);
            this.lblKbn.Name = "lblKbn";
            this.lblKbn.Size = new System.Drawing.Size(49, 14);
            this.lblKbn.TabIndex = 107;
            this.lblKbn.Text = "業務名";
            // 
            // lblSagyo
            // 
            this.lblSagyo.AutoEllipsis = true;
            this.lblSagyo.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSagyo.Location = new System.Drawing.Point(173, 138);
            this.lblSagyo.Name = "lblSagyo";
            this.lblSagyo.Size = new System.Drawing.Size(258, 38);
            this.lblSagyo.TabIndex = 108;
            this.lblSagyo.Text = "作業名";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitle.Location = new System.Drawing.Point(62, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(93, 20);
            this.lblTitle.TabIndex = 109;
            this.lblTitle.Text = "開始登録";
            // 
            // GC0060
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 455);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSagyo);
            this.Controls.Add(this.lblKbn);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnEndCancel);
            this.Controls.Add(this.btnStartCancel);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pnlEnd);
            this.Controls.Add(this.pnlStart);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.pnlLbl);
            this.Name = "GC0060";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GC0060";
            this.Load += new System.EventHandler(this.GC0060_Load);
            this.pnlStart.ResumeLayout(false);
            this.pnlStart.PerformLayout();
            this.pnlLbl.ResumeLayout(false);
            this.pnlLbl.PerformLayout();
            this.pnlEnd.ResumeLayout(false);
            this.pnlEnd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbMStart;
        private System.Windows.Forms.ComboBox cmbHStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMEnd;
        private System.Windows.Forms.ComboBox cmbHEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnStartCancel;
        private System.Windows.Forms.Button btnEndCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblKbn;
        private System.Windows.Forms.Label lblSagyo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlLbl;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpStart;
    }
}