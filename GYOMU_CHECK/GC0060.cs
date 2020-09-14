using System;
using System.Drawing;
using System.Windows.Forms;

namespace GYOMU_CHECK
{
    public partial class GC0060 : Form
    {
        public string mStatus;
        private string mSagyoNm;
        private string mGyomuNm;
        private string mYyyyMM;
        private DateTime mSagyoStart;
        private DateTime mSagyoEnd;

        private DateTime cancelStart;
        private DateTime cancelEnd;
        private string collectStatus;
        private bool collectFlg = false;
        CommonUtil comU = new CommonUtil();

        public string returnStatus;
        public bool returnFlg;
        public bool cancelFlg;
        public bool endChangeFlg;
        public bool startChangeFlg;
        public DateTime returnStartDateTime;
        public DateTime returnEndDateTime;


        public GC0060(string status, string sagyoNm, string gyomuNm, string yyyyMM)
        {
            mStatus = status;
            mSagyoNm = sagyoNm;
            mGyomuNm = gyomuNm;
            mYyyyMM = yyyyMM;
            InitializeComponent();
        }
        public GC0060(string status, string sagyoNm, string gyomuNm, string yyyyMM, DateTime sagyoStart, DateTime sagyoEnd) : this(status, sagyoNm, gyomuNm, yyyyMM)
        {

            mSagyoStart = sagyoStart;
            mSagyoEnd = sagyoEnd;
            collectFlg = true;
        }

        public GC0060(string status, string sagyoNm, string gyomuNm, string yyyyMM, DateTime sagyoStart, bool colFlg) : this(status, sagyoNm, gyomuNm, yyyyMM)
        {

            mSagyoStart = sagyoStart;
            collectFlg = colFlg;
        }

        private void GC0060_Load(object sender, EventArgs e)
        {
            Initialization();

        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialization()
        {

            lblKbn.Text = mGyomuNm;
            lblSagyo.Text = mSagyoNm;
            lblDate.Text = mYyyyMM.Substring(0, 4) + "/" + mYyyyMM.Substring(4, 2);
            //コンボボックス設定
            cmbHStart.DataSource = comU.CHour().ToArray();
            cmbHEnd.DataSource = comU.CHour().ToArray();
            cmbMStart.DataSource = comU.CMinute().ToArray();
            cmbMEnd.DataSource = comU.CMinute().ToArray();

            DateTime dt = System.DateTime.Now;

            returnFlg = false;
            cancelFlg = false;

            //日時範囲設定
            dtpStart.MaxDate = dt;
            dtpEnd.MaxDate = dt;

            pnlLbl.Visible = false;
            if (collectFlg)
            {
                lblTitle.Text = "状況訂正";
                lblMessage.Text = "変更する項目を入力してください";
                btnInsert.Text = "更新";
                cmbHStart.Text = Convert.ToString(mSagyoStart.Hour);
                cmbMStart.Text = Convert.ToString(mSagyoStart.Minute);
                dtpStart.Value = mSagyoStart.Date;
                collectStatus = mStatus;
                //処理中の場合
                if (mStatus == "1")
                {
                    btnEndCancel.Visible = false;
                    pnlEnd.Visible = false;
                }
                else if (mStatus == "2")
                {
                    btnStartCancel.Enabled = false;
                    dtpEnd.Value = mSagyoEnd.Date;
                    cmbHEnd.Text = Convert.ToString(mSagyoEnd.Hour);
                    cmbMEnd.Text = Convert.ToString(mSagyoEnd.Minute);
                }

                btnInsert.Enabled = false;
            }
            else
            {
                var firstDayOfMonth = new DateTime(dt.Year, dt.Month - 1, 1);
                dtpStart.MinDate = firstDayOfMonth;
                dtpEnd.MinDate = firstDayOfMonth;

                btnStartCancel.Visible = false;
                btnEndCancel.Visible = false;

                if (mStatus == "0")
                {
                    lblTitle.Text = "開始登録";
                    lblMessage.Text = "作業開始日時を入力してください";

                    cmbHStart.Text = Convert.ToString(dt.Hour);
                    cmbMStart.Text = Convert.ToString(dt.Minute);

                    //非表示
                    pnlEnd.Visible = false;
                }
                else if (mStatus == "1")
                {
                    lblTitle.Text = "終了登録";
                    lblMessage.Text = "作業終了日時を入力してください";

                    //非表示
                    pnlStart.Visible = false;
                    pnlLbl.Visible = true;
                    lblStartDate.Text = mSagyoStart.ToString("yyyy/MM/dd");
                    lblStartTime.Text = mSagyoStart.ToString("HH:mm");
                    cmbHEnd.Text = Convert.ToString(dt.Hour);
                    cmbMEnd.Text = Convert.ToString(dt.Minute);
                }
            }


        }
        private void ChangeUpdateEnable()
        {

            if (!mStatus.Equals(collectStatus))
            {
                btnInsert.Enabled = true;
                return;
            }
            DateTime startDate = DateTime.Parse(dtpStart.Value.ToString());
            int startHour = int.Parse(cmbHStart.Text);
            int startMinute = int.Parse(cmbMStart.Text);
            DateTime startDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, startHour, startMinute, 00);
            if (mSagyoStart  != startDateTime)
            {
                btnInsert.Enabled = true;
                return;
            }
            if(mStatus.Equals("2"))
            {
                DateTime endDate = DateTime.Parse(dtpEnd.Value.ToString());
                int endHour = int.Parse(cmbHEnd.Text);
                int endMinute = int.Parse(cmbMEnd.Text);
                DateTime endDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, endHour, endMinute, 00);
                if(mSagyoEnd != endDateTime)
                {
                    btnInsert.Enabled = true;
                    return;
                }
            }

            btnInsert.Enabled = false;
        }

        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            returnFlg = false;
            this.Close();
        }
        private bool CheckInsert()
        {
            if (collectFlg)
            {
                if (mStatus == "2")
                {
                    if (returnStartDateTime > returnEndDateTime)
                    {
                        MessageBox.Show("開始日時より前の日時は入力できません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;

                    }
                }
            }
            else
            {
                if (mSagyoStart > returnEndDateTime)
                {
                    MessageBox.Show("開始日時より前の日時は入力できません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }
            }
            return true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            if (collectFlg)
            {
                DialogResult result = MessageBox.Show("変更を行います。よろしいでしょうか。？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                //何が選択されたか調べる
                if (result == DialogResult.No)
                {
                    return;
                }

                if (mStatus != "0")
                {
                    DateTime startDate = DateTime.Parse(dtpStart.Value.ToString());
                    int startHour = int.Parse(cmbHStart.Text);
                    int startMinute = int.Parse(cmbMStart.Text);
                    returnStartDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, startHour, startMinute, 00);
                    if (mSagyoStart != returnEndDateTime)
                    {
                        startChangeFlg = true;
                    }
                }
                if (mStatus == "2")
                {
                    DateTime endDate = DateTime.Parse(dtpEnd.Value.ToString());

                    int endHour = int.Parse(cmbHEnd.Text);
                    int endtMinute = int.Parse(cmbMEnd.Text);
                    returnEndDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, endHour, endtMinute, 00);
                    if (mSagyoEnd != returnEndDateTime)
                    {
                        endChangeFlg = true;
                    }
                }
            }
            else
            {
                if (mStatus == "0")
                {
                    DateTime startDate = DateTime.Parse(dtpStart.Value.ToString());
                    int startHour = int.Parse(cmbHStart.Text);
                    int startMinute = int.Parse(cmbMStart.Text);
                    returnStartDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, startHour, startMinute, 00);
                }
                if (mStatus == "1")
                {
                    DateTime endDate = DateTime.Parse(dtpEnd.Value.ToString());
                    int endHour = int.Parse(cmbHEnd.Text);
                    int endtMinute = int.Parse(cmbMEnd.Text);
                    returnEndDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, endHour, endtMinute, 00);
                }
            }
            if (!CheckInsert())
            {
                return;
            }

            returnFlg = true;
            this.Close();
        }

        private void btnEndCancel_Click(object sender, EventArgs e)
        {
            if (mStatus == "2")
            {
                mStatus = "1";
                pnlEnd.Enabled = false;
                btnStartCancel.Enabled = true;
                pnlStart.Enabled = true;
                btnEndCancel.Text = "終了復活";
                
                int endHour = int.Parse(cmbHEnd.Text);
                int endMinute = int.Parse(cmbMEnd.Text);
                cancelEnd = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day, endHour, endMinute, 00);

                dtpEnd.Format = DateTimePickerFormat.Custom;
                dtpEnd.CustomFormat = " ";
                cmbHEnd.Text = null;
                cmbMEnd.Text = null;
            }
            else
            {
                mStatus = "2";
                pnlEnd.Enabled = true;
                btnStartCancel.Enabled = false;
                btnEndCancel.Text = "終了取消";

                dtpEnd.Format = DateTimePickerFormat.Custom;
                dtpEnd.CustomFormat = "yyyy/MM/dd";
                dtpEnd.Value = (DateTime)cancelEnd.Date;
                cmbHEnd.Text = Convert.ToString(cancelEnd.Hour);
                cmbMEnd.Text = Convert.ToString(cancelEnd.Minute);
            }
            ChangeUpdateEnable();
            dtpStart.Focus();

        }

        private void btnStartCancel_Click(object sender, EventArgs e)
        {
            if (mStatus == "1")
            {
                mStatus = "0";
                pnlStart.Enabled = false;
                btnEndCancel.Enabled = false;
                btnStartCancel.Text = "開始復活";

                int startHour = int.Parse(cmbHStart.Text);
                int startMinute = int.Parse(cmbMStart.Text);
                cancelStart = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, startHour, startMinute, 00);

                dtpStart.Format = DateTimePickerFormat.Custom;
                dtpStart.CustomFormat = " ";
                cmbHStart.Text = null;
                cmbMStart.Text = null;

            }
            else
            {
                mStatus = "1";
                pnlStart.Enabled = true;
                btnEndCancel.Enabled = true;
                btnStartCancel.Text = "開始取消";

                dtpStart.Format = DateTimePickerFormat.Custom;
                dtpStart.CustomFormat = "yyyy/MM/dd";
                dtpStart.Value = (DateTime)cancelStart.Date;
                cmbHStart.Text = Convert.ToString(cancelStart.Hour);
                cmbMStart.Text = Convert.ToString(cancelStart.Minute);
                dtpStart.Focus();
            }
            ChangeUpdateEnable();

        }


        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (collectFlg)
            {

                ChangeUpdateEnable();
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (collectFlg)
            {

                ChangeUpdateEnable();
            }
        }

        private void DropDownClosed(object sender, EventArgs e)
        {
            if (collectFlg)
            {

                ChangeUpdateEnable();
            }
        }
        private void DropDownKeyDown(object sender, KeyEventArgs e)
        {
            if (collectFlg)
            {

                ChangeUpdateEnable();
            }
        }
        private void MouseLeave(object sender, EventArgs e)
        {
            if (collectFlg)
            {

                ChangeUpdateEnable();
            }
        }
    }
}
