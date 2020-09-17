using System;
using System.Drawing;
using System.Windows.Forms;

namespace GYOMU_CHECK
{
    public partial class GC0060 : Form
    {
        #region メンバー変数
        public string mSsagyoStatu;
        private readonly string mSagyoNm;
        private readonly string mGyomuNm;
        private readonly string mYyyyMM;
        private readonly DateTime mSagyoStart;
        private readonly DateTime mSagyoEnd;

        private DateTime cancelStart;
        private DateTime cancelEnd;
        private string collectStatus;
        private bool collectFlg = false;
        private readonly CommonUtil comU = new CommonUtil();

        public bool returnFlg = false;
        public bool endChangeFlg;
        public bool startChangeFlg;
        public DateTime returnStartDateTime;
        public DateTime returnEndDateTime;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ(開始押下時)
        /// </summary>
        /// <param name="status"></param>
        /// <param name="sagyoNm"></param>
        /// <param name="gyomuNm"></param>
        /// <param name="yyyyMM"></param>
        public GC0060(string sagyoStatus, string sagyoNm, string gyomuNm, string yyyyMM)
        {
            mSsagyoStatu = sagyoStatus;
            mSagyoNm = sagyoNm;
            mGyomuNm = gyomuNm;
            mYyyyMM = yyyyMM;
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ(終了押下時)
        /// </summary>
        /// <param name="status"></param>
        /// <param name="sagyoNm"></param>
        /// <param name="gyomuNm"></param>
        /// <param name="yyyyMM"></param>
        /// <param name="sagyoStart"></param>
        /// <param name="sagyoEnd"></param>
        public GC0060(string sagyoStatus, string sagyoNm, string gyomuNm, string yyyyMM, DateTime sagyoStart, DateTime sagyoEnd) : this(sagyoStatus, sagyoNm, gyomuNm, yyyyMM)
        {
            mSagyoStart = sagyoStart;
            mSagyoEnd = sagyoEnd;
            collectFlg = true;
        }

        /// <summary>
        /// コンストラクタ(訂正押下時)
        /// </summary>
        /// <param name="status"></param>
        /// <param name="sagyoNm"></param>
        /// <param name="gyomuNm"></param>
        /// <param name="yyyyMM"></param>
        /// <param name="sagyoStart"></param>
        /// <param name="colFlg"></param>
        public GC0060(string sagyoStatus, string sagyoNm, string gyomuNm, string yyyyMM, DateTime sagyoStart, bool colFlg) : this(sagyoStatus, sagyoNm, gyomuNm, yyyyMM)
        {
            mSagyoStart = sagyoStart;
            collectFlg = colFlg;
        }
        #endregion

        #region イベント
        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GC0060_Load(object sender, EventArgs e)
        {
            Initialization();
        }

        /// <summary>
        /// 開始日変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            //終了・訂正押下した場合
            if (collectFlg)
            {
                //変更時更新表示
                ChangeUpdateEnable();
            }
        }

        /// <summary>
        /// 終了日変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            //終了・訂正押下した場合
            if (collectFlg)
            {
                //変更時更新表示
                ChangeUpdateEnable();
            }
        }

        /// <summary>
        /// 時刻が非表示の場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropDownClosed(object sender, EventArgs e)
        {
            //終了・訂正押下した場合
            if (collectFlg)
            {
                //変更時更新表示
                ChangeUpdateEnable();
            }
        }

        /// <summary>
        /// キー押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropDownKeyDown(object sender, KeyEventArgs e)
        {
            if (collectFlg)
            {
                //変更時更新表示
                ChangeUpdateEnable();
            }
        }

        /// <summary>
        /// マウスがコントロールを離れた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeave(object sender, EventArgs e)
        {
            //終了・訂正押下した場合
            if (collectFlg)
            {
                //変更時更新表示
                ChangeUpdateEnable();
            }
        }
        #endregion

        #region メソッド
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

            //現在日取得
            DateTime dt = DateTime.Now;

            //日時範囲設定
            dtpStart.MaxDate = dt;
            dtpEnd.MaxDate = dt;

            pnlLbl.Visible = false;
            //終了・訂正押下した場合
            if (collectFlg)
            {
                lblTitle.Text = "状況訂正";
                lblMessage.Text = "変更する項目を入力してください";
                btnInsert.Text = "更新";
                cmbHStart.Text = Convert.ToString(mSagyoStart.Hour);
                cmbMStart.Text = Convert.ToString(mSagyoStart.Minute);
                dtpStart.Value = mSagyoStart.Date;
                collectStatus = mSsagyoStatu;
                //処理中の場合
                if (mSsagyoStatu == "1")
                {
                    btnEndCancel.Visible = false;
                    pnlEnd.Visible = false;
                }
                //完了の場合
                else if (mSsagyoStatu == "2")
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
                //開始日・終了日の最小表示日を設定
                var firstDayOfMonth = new DateTime(dt.Year, dt.Month - 1, 1);
                dtpStart.MinDate = firstDayOfMonth;
                dtpEnd.MinDate = firstDayOfMonth;

                //開始・終了取消を非表示
                btnStartCancel.Visible = false;
                btnEndCancel.Visible = false;

                //未処理の場合
                if (mSsagyoStatu == "0")
                {
                    lblTitle.Text = "開始登録";
                    lblMessage.Text = "作業開始日時を入力してください";

                    cmbHStart.Text = Convert.ToString(dt.Hour);
                    cmbMStart.Text = Convert.ToString(dt.Minute);

                    //非表示
                    pnlEnd.Visible = false;
                }
                //処理中の場合
                else if (mSsagyoStatu == "1")
                {
                    lblTitle.Text = "終了登録";
                    lblMessage.Text = "作業終了日時を入力してください";

                    //開始日・時刻入力欄を非表示
                    pnlStart.Visible = false;
                    //開始日・時刻入力ラベル欄を表示
                    pnlLbl.Visible = true;
                    lblStartDate.Text = mSagyoStart.ToString("yyyy/MM/dd");
                    lblStartTime.Text = mSagyoStart.ToString("HH:mm");
                    cmbHEnd.Text = Convert.ToString(dt.Hour);
                    cmbMEnd.Text = Convert.ToString(dt.Minute);
                }
            }
        }

        /// <summary>
        /// 変更時更新表示処理
        /// </summary>
        private void ChangeUpdateEnable()
        {
            //遷移時の作業ステータスと選択した作業ステータスが違う場合
            if (!mSsagyoStatu.Equals(collectStatus))
            {
                btnInsert.Enabled = true;
                return;
            }
            DateTime startDate = DateTime.Parse(dtpStart.Value.ToString());
            int startHour = int.Parse(cmbHStart.Text);
            int startMinute = int.Parse(cmbMStart.Text);
            DateTime startDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, startHour, startMinute, 00);
            //遷移時開始時刻と入力した開始時刻が異なる場合
            if (mSagyoStart  != startDateTime)
            {
                btnInsert.Enabled = true;
                return;
            }
            //完了済みの場合
            if(mSsagyoStatu.Equals("2"))
            {
                DateTime endDate = DateTime.Parse(dtpEnd.Value.ToString());
                int endHour = int.Parse(cmbHEnd.Text);
                int endMinute = int.Parse(cmbMEnd.Text);
                DateTime endDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, endHour, endMinute, 00);
                //遷移時終了時刻と入力した終了時刻が異なる場合
                if (mSagyoEnd != endDateTime)
                {
                    btnInsert.Enabled = true;
                    return;
                }
            }

            btnInsert.Enabled = false;
        }

        /// <summary>
        /// 登録チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckInsert()
        {
            //終了・訂正押下した場合
            if (collectFlg)
            {
                //完了済みの場合
                if (mSsagyoStatu == "2")
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
        #endregion

        #region ボタンイベント
        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            returnFlg = false;
            Close();
        }

        /// <summary>
        /// 登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //終了・訂正押下した場合
            if (collectFlg)
            {
                DialogResult result = MessageBox.Show("変更を行います。よろしいでしょうか。？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                //何が選択されたか調べる
                if (result == DialogResult.No)
                {
                    return;
                }

                //未処理の場合
                if (mSsagyoStatu != "0")
                {
                    DateTime startDate = DateTime.Parse(dtpStart.Value.ToString());
                    int startHour = int.Parse(cmbHStart.Text);
                    int startMinute = int.Parse(cmbMStart.Text);
                    returnStartDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, startHour, startMinute, 00);
                    //遷移時の開始時刻と入力した開始時刻が異なる場合
                    if (mSagyoStart != returnStartDateTime)
                    {
                        startChangeFlg = true;
                    }
                }
                //完了済みの場合
                if (mSsagyoStatu == "2")
                {
                    DateTime endDate = DateTime.Parse(dtpEnd.Value.ToString());

                    int endHour = int.Parse(cmbHEnd.Text);
                    int endtMinute = int.Parse(cmbMEnd.Text);
                    returnEndDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, endHour, endtMinute, 00);
                    //遷移時の終了時刻と入力した終了時刻が異なる場合
                    if (mSagyoEnd != returnEndDateTime)
                    {
                        endChangeFlg = true;
                    }
                }
            }
            else
            {
                //未処理の場合
                if (mSsagyoStatu == "0")
                {
                    DateTime startDate = DateTime.Parse(dtpStart.Value.ToString());
                    int startHour = int.Parse(cmbHStart.Text);
                    int startMinute = int.Parse(cmbMStart.Text);
                    returnStartDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, startHour, startMinute, 00);
                }
                //処理中の場合
                if (mSsagyoStatu == "1")
                {
                    DateTime endDate = DateTime.Parse(dtpEnd.Value.ToString());
                    int endHour = int.Parse(cmbHEnd.Text);
                    int endtMinute = int.Parse(cmbMEnd.Text);
                    returnEndDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, endHour, endtMinute, 00);
                }
            }
            //登録チェック
            if (!CheckInsert()) return;

            returnFlg = true;
            Close();
        }

        /// <summary>
        /// 終了取消ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndCancel_Click(object sender, EventArgs e)
        {
            //完了済みの場合
            if (mSsagyoStatu == "2")
            {
                //ステータスと処理中に変更
                mSsagyoStatu = "1";
                //終了日・時刻表示欄を非表示
                pnlEnd.Enabled = false;
                //開始取消ボタン表示
                btnStartCancel.Enabled = true;
                //開始日・時刻表示欄を非表示
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
            //処理中の場合
            else
            {
                //ステータスを完了済みに変更
                mSsagyoStatu = "2";
                //終了日・時刻表示欄を表示
                pnlEnd.Enabled = true;
                //開始取消ボタン非表示
                btnStartCancel.Enabled = false;
                btnEndCancel.Text = "終了取消";

                dtpEnd.Format = DateTimePickerFormat.Custom;
                dtpEnd.CustomFormat = "yyyy/MM/dd";
                dtpEnd.Value = (DateTime)cancelEnd.Date;
                cmbHEnd.Text = Convert.ToString(cancelEnd.Hour);
                cmbMEnd.Text = Convert.ToString(cancelEnd.Minute);
            }
            //変更時更新表示
            ChangeUpdateEnable();
            dtpStart.Focus();
        }

        /// <summary>
        /// 開始取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartCancel_Click(object sender, EventArgs e)
        {
            //処理中の場合
            if (mSsagyoStatu == "1")
            {
                //ステータスを未処理に変更
                mSsagyoStatu = "0";
                //開始日・時刻表示欄を表示
                pnlStart.Enabled = false;
                //終了取消ボタン非表示
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
            //未処理の場合
            else
            {
                //ステータスを処理中に変更
                mSsagyoStatu = "1";
                //開始日・時刻表示欄を非表示
                pnlStart.Enabled = true;
                //終了取消ボタン表示
                btnEndCancel.Enabled = true;
                btnStartCancel.Text = "開始取消";

                dtpStart.Format = DateTimePickerFormat.Custom;
                dtpStart.CustomFormat = "yyyy/MM/dd";
                dtpStart.Value = (DateTime)cancelStart.Date;
                cmbHStart.Text = Convert.ToString(cancelStart.Hour);
                cmbMStart.Text = Convert.ToString(cancelStart.Minute);
                dtpStart.Focus();
            }
            //変更時更新表示
            ChangeUpdateEnable();
        }
        #endregion
    }
}
