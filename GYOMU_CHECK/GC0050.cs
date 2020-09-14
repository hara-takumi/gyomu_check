using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GYOMU_CHECK
{
    public partial class GC0050 : Form
    {
        private User user;
        CommonUtil comU = new CommonUtil();
        public bool torokuFlg = false;
        bool errorFlg = false;
        bool changeFlg = false;
        bool headerChangeFlg = false;
        private string sagyoState;
        private string stateMode;
        MySqlCommand command = new MySqlCommand();

        public enum column
        {
            MST_SAGYO_CD,
            MST_SAGYO_NAME,
            MST_SAGYO_PARENT_FLG,
            TRN_CHECK_B_DISUSE_FLG,
            TRN_CHECK_B_DISUSE_FLG_OLD,
            TRN_CHECK_B_SAGYO_STATUS,
            STATUS_NAME,
            TRN_CHECK_B_SAGYO_USER,
            TRN_CHECK_B_SAGYO_DATE
        }

        public enum mode
        {
            INSERT,
            UPDATE
        }

        int gamenMode;
        string sagyoYYMM;
        string gyomuCd;
        string programId = "GC0050";
        public GC0050(User user)
        {
            this.user = user;
            gamenMode = (int)mode.INSERT;
            InitializeComponent();
        }

        public GC0050(User user, string yyyyMM, string Cd, string state)
        {
            this.user = user;
            gamenMode = (int)mode.UPDATE;
            sagyoYYMM = comU.CReplace(yyyyMM);
            gyomuCd = Cd;
            stateMode = state;
            InitializeComponent();
        }

        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GC0050_Load(object sender, EventArgs e)
        {
            Initialization();
            lblUserNm.Text = user.Name;
        }


        private void Proto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!errorFlg && !torokuFlg)
            {
                if (ChangeDetection())
                {
                    DialogResult result = MessageBox.Show("内容が変更されています。　変更は破棄されますが、よろしいですか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {
                        if (gamenMode == (int)mode.UPDATE)
                        {
                            DeleteHaita();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (gamenMode == (int)mode.UPDATE)
                    {
                        DeleteHaita();
                    }
                }
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialization()
        {



            //新規の場合
            if (gamenMode == (int)mode.INSERT)
            {
                DataSet dataSet = new DataSet();
                if (!comU.CGyomu(ref dataSet, false))
                {
                    errorFlg = true;
                    this.Close();
                    return;
                }
                pnlIns.Visible = true;
                pnlUpd.Visible = false;
                // コンボボックスにデータテーブルをセット
                this.cmbKbn.DataSource = dataSet.Tables[0];
                // 表示用の列を設定
                this.cmbKbn.DisplayMember = "NAME";
                //// データ用の列を設定
                this.cmbKbn.ValueMember = "CD";
                this.cmbKbn.SelectedIndex = -1;

                //コンボボックス設定(年月)
                DateTime dt = System.DateTime.Now;
                cmbYear.DataSource = comU.CYear(false).ToArray();
                cmbYear.Text = dt.ToString("yyyy");
                cmbMonth.DataSource = comU.CMonth(false).ToArray();
                cmbMonth.Text = dt.ToString("MM");

                btnDelete.Visible = false;
                btnInsert.Enabled = false;
                lblUpd.Visible = false;

                this.ActiveControl = this.cmbKbn;
            }
            //更新の場合
            else
            {
                pnlIns.Visible = false;
                pnlUpd.Visible = true;

                lblYear.Text = sagyoYYMM.Substring(0, 4) + "/" + sagyoYYMM.Substring(4, 2);
                string gyomuName ="";
                GetGyomuName(ref gyomuName);
                lblGyomu.Text = gyomuName;
                btnDisply.Visible = false;
                cmbYear.Enabled = false;
                cmbMonth.Enabled = false;
                cmbKbn.Enabled = false;
                btnInsert.Text = "更新";
                TorokuHaita();
                DisplyUpdate();
            }
        }
        private void GetGyomuName(ref string gyomuName)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("    NAME");
            sql.Append(" FROM mst_gyomu");
            sql.Append(" WHERE ");
            sql.Append(" DEL_FLG = 0 ");
            sql.Append($" AND CD = {gyomuCd} ");
            sql.Append(" ORDER BY ");
            sql.Append(" HYOJI_JUN ");

            DataSet ds = new DataSet();
            if (!comU.CSerch(sql.ToString(), ref ds))
            {
                return;
            }
            if (ds.Tables["Table1"].Rows.Count != 0)
            {
                gyomuName = ds.Tables["Table1"].Rows[0]["NAME"].ToString();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 排他登録
        /// </summary>
        private void TorokuHaita()
        {
            MySqlTransaction transaction = null;
            if (!comU.CConnect(ref transaction, ref command))
            {
                errorFlg = true;
                return;
            }
            if (!comU.InsertHaitaTrn(transaction, ref command, sagyoYYMM, gyomuCd, user.Id, programId))
            {
                errorFlg = true;
                Close();
            }
            else
            {
                transaction.Commit();
            }
        }

        /// <summary>
        /// 排他削除
        /// </summary>
        private void DeleteHaita()
        {
            MySqlTransaction transaction = null;
            if (!comU.CConnect(ref transaction, ref command))
            {
                return;
            }
            if (!comU.DeleteHaitaTrn(transaction, ref command, sagyoYYMM, gyomuCd))
            {
                Close();
            }

            transaction.Commit();
            command.Connection.Close();
        }


        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 作成ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            sagyoYYMM = cmbYear.SelectedValue.ToString() + cmbMonth.SelectedValue.ToString();
            //業務の作成チェック
            if (!SearchGyomu())
            {
                return;
            }
            if (dgvIchiran.RowCount != 0)
            {
                if (changeFlg)
                {
                    DialogResult result = MessageBox.Show("内容が変更されています。　変更は破棄されますが、よろしいですか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    //何が選択されたか調べる
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            Clear();
            DisplyInsert();
        }

        /// <summary>
        /// 業務検索
        /// </summary>
        /// <returns></returns>
        private bool SearchGyomu()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM TRN_CHECK_H");
            sql.Append($" WHERE GYOMU_CD = {cmbKbn.SelectedValue}");
            sql.Append($" AND SAGYO_YYMM = {sagyoYYMM}");

            if (this.cmbKbn.SelectedIndex == -1)
            {
                MessageBox.Show("業務を選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DataSet ds = new DataSet();
            if (!comU.CSerch(sql.ToString(), ref ds))
            {
                return false;
            }
            if (ds.Tables["Table1"].Rows.Count > 0)
            {
                MessageBox.Show("すでに作成済みの業務です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }


        private void DisplyInsert()
        {

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     CD");
            sql.Append("    ,NAME");
            sql.Append("    ,PARENT_FLG");
            sql.Append(" FROM mst_sagyo");
            sql.Append(" WHERE DEL_FLG = 0");
            sql.Append($" AND GYOMU_CD = {cmbKbn.SelectedValue}");
            sql.Append(" ORDER BY HYOJI_JUN");


            DataSet ds = new DataSet();
            if (!comU.CSerch(sql.ToString(), ref ds))
            {
                btnInsert.Enabled = false;
                return;
            }
            if (ds.Tables["Table1"].Rows.Count == 0)
            {
                MessageBox.Show("指定した業務の作業が登録されていません。\n\r作業マスタの登録を行ってください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnInsert.Enabled = false;
                return;
            }

            dgvIchiran.DataSource = ds.Tables[0];
            btnInsert.Enabled = true;
            headerChangeFlg = false;
            changeFlg = false;

            DataGridViewCheckBoxColumn dgvcbc = new DataGridViewCheckBoxColumn();
            dgvcbc.Name = "実施要否";
            dgvcbc.Width = 80;
            dgvIchiran.Columns.Insert((int)column.TRN_CHECK_B_DISUSE_FLG, dgvcbc);
            dgvcbc.TrueValue = true;
            dgvcbc.FalseValue = false;

            //一覧表示
            dgvIchiran.Columns[(int)column.MST_SAGYO_CD].Visible = false;
            dgvIchiran.Columns[(int)column.MST_SAGYO_PARENT_FLG].Visible = false;
            dgvIchiran.Columns[(int)column.MST_SAGYO_NAME].HeaderText = "";
            dgvIchiran.Columns[(int)column.MST_SAGYO_NAME].Width = 400;

            //実施要否チェック済み
            for (int i = 0; i < dgvIchiran.RowCount; i++)
            {
                if (i % 2 == 1)
                {
                    dgvIchiran.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                }

                if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
                {
                    dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i] = new DataGridViewTextBoxCell();
                    dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i].Value = "";
                    dgvIchiran.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    dgvIchiran.Rows[i].ReadOnly = true;
                }
                else
                {

                    DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                    dgvIchiran[2, i] = cell;
                    dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i].Value = true;
                }

            }
            dgvIchiran.Columns[1].ReadOnly = true;
            foreach (DataGridViewColumn column in this.dgvIchiran.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }
        private void DisplyUpdate()
        {

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     TRN_CHECK_B.SAGYO_CD");
            sql.Append("    ,MST_SAGYO.NAME");
            sql.Append("    ,MST_SAGYO.PARENT_FLG");
            sql.Append("    ,TRN_CHECK_B.DISUSE_FLG");
            sql.Append("    ,TRN_CHECK_B.SAGYO_STATUS");
            sql.Append("    ,CASE WHEN MST_SAGYO.PARENT_FLG = '1' THEN ''");
            sql.Append("    WHEN trn_check_B.SAGYO_STATUS = '0' THEN '未着手'");
            sql.Append("    WHEN trn_check_B.SAGYO_STATUS = '1' THEN '処理中'");
            sql.Append("    ELSE '完了' END");
            sql.Append("    ,TRN_CHECK_B.SAGYO_END_USER");
            sql.Append("    ,TRN_CHECK_B.SAGYO_END_DATE");
            sql.Append(" FROM TRN_CHECK_B");
            sql.Append(" LEFT JOIN MST_SAGYO");
            sql.Append(" ON TRN_CHECK_B.SAGYO_CD = MST_SAGYO.CD");
            sql.Append(" WHERE MST_SAGYO.DEL_FLG = 0");
            sql.Append($" AND TRN_CHECK_B.GYOMU_CD = {gyomuCd}");
            sql.Append($" AND TRN_CHECK_B.SAGYO_YYMM = {sagyoYYMM}");
            sql.Append(" ORDER BY MST_SAGYO.HYOJI_JUN");


            DataSet ds = new DataSet();
            if (!comU.CSerch(sql.ToString(), ref ds))
            {
                this.Close();
                return;
            }
            if (ds.Tables["Table1"].Rows.Count == 0)
            {
                MessageBox.Show("指定した業務の作業が登録されていません。\n\r作業マスタの登録を行ってください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            dgvIchiran.DataSource = ds.Tables[0];

            //セルチェックボックス作成
            DataGridViewCheckBoxColumn dgvcbc = new DataGridViewCheckBoxColumn();
            dgvIchiran.Columns.Insert((int)column.TRN_CHECK_B_DISUSE_FLG, dgvcbc);
            dgvcbc.TrueValue = true;
            dgvcbc.FalseValue = false;

            //一覧表示
            dgvIchiran.Columns[(int)column.MST_SAGYO_CD].Visible = false;
            dgvIchiran.Columns[(int)column.MST_SAGYO_PARENT_FLG].Visible = false;
            dgvIchiran.Columns[(int)column.TRN_CHECK_B_DISUSE_FLG_OLD].Visible = false;
            dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_STATUS].Visible = false;
            dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_USER].Visible = false;
            dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_DATE].Visible = false;

            dgvIchiran.Columns[(int)column.MST_SAGYO_NAME].HeaderText = "";

            dgvIchiran.Columns[(int)column.MST_SAGYO_NAME].Width = 400;

            dgvIchiran.Columns[(int)column.TRN_CHECK_B_DISUSE_FLG].HeaderText = "実施要否";
            dgvIchiran.Columns[(int)column.STATUS_NAME].HeaderText = "状況";
            dgvIchiran.Columns[(int)column.TRN_CHECK_B_DISUSE_FLG].Width = 80;

            dgvIchiran.Columns[(int)column.MST_SAGYO_NAME].ReadOnly = true;
            dgvIchiran.Columns[(int)column.STATUS_NAME].ReadOnly = true;
            dgvIchiran.Columns[(int)column.STATUS_NAME].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //明細背景色変更
            for (int i = 0; i < dgvIchiran.RowCount; i++)
            {
                if (i % 2 == 1)
                {
                    dgvIchiran.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                }
                //親作業の場合、背景色緑、テキスト非活性
                if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
                {
                    dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i] = new DataGridViewTextBoxCell();
                    dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i].Value = "";
                    dgvIchiran.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    dgvIchiran.Rows[i].ReadOnly = true;
                }
                else
                {
                    DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                    dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i] = cell;
                    dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i].Value = dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG_OLD, i].Value;
                }

                //STATUSが未実施以外の場合、編集不可
                //「処理中」「完了」を赤文字                
                if ((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, i].Value != "0")
                {
                    dgvIchiran.Rows[i].ReadOnly = true;
                    dgvIchiran.Rows[i].Cells[(int)column.STATUS_NAME].Style.ForeColor = Color.Red;
                }

            }
            foreach (DataGridViewColumn column in this.dgvIchiran.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        /// <summary>
        /// クリアボタン
        /// </summary>
        private void Clear()
        {
            if (dgvIchiran.RowCount != 0)
            {
                dgvIchiran.DataSource = null;
                dgvIchiran.Rows.Clear();
                dgvIchiran.Columns.Clear();
            }
        }

        private void dgvIchiran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == (int)column.TRN_CHECK_B_DISUSE_FLG)
            {
                //変更フラグ
                changeFlg = true;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //新規の場合
            if (gamenMode == (int)mode.INSERT)
            {
                if (headerChangeFlg)
                {
                    MessageBox.Show("ヘッダーの値が変更されています。\n\r一覧の再表示を行ってください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Toroku();
                }
            }
            else
            {
                Update();
            }

        }
        /// <summary>
        ///更新処理
        /// </summary>
        private void Update()
        {
            if (!CheckToroku())
            {
                return;
            }
            DialogResult result = MessageBox.Show("更新を行います。よろしいでしょうか。？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //変更が行われていない場合
                if (!ChangeDetection())
                {
                    MessageBox.Show("明細が変更されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MySqlTransaction transaction = null;
                if (!comU.CConnect(ref transaction, ref command))
                {
                    return;
                }
                if (CheckUpdateGyomuHeader())
                {
                    if (!UpdateGyomuCheckHeader(transaction))
                    {

                        MessageBox.Show("業務チェックヘッダの更新に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                if (!UpdateGyomuCheckBody(transaction))
                {
                    MessageBox.Show("業務チェック明細の更新に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                transaction.Commit();

                MessageBox.Show("更新が完了しました。", "");
                if (gamenMode == (int)mode.UPDATE)
                {
                    DeleteHaita();
                }
                torokuFlg = true;
                this.Close();
            }
        }
        

        private bool UpdateGyomuCheckHeader(MySqlTransaction transaction)
        {
            String sagyoDate = null;
            String sagyoUser = null;
            if (stateMode != "2")
            {
                if (sagyoState == "1")
                {
                    DataSet ds = new DataSet();
                    if (!GetCheckMeisai(ref ds))
                    {
                        return false;
                    }
                    sagyoUser = ds.Tables["Table1"].Rows[0]["SAGYO_START_USER"].ToString();
                    sagyoDate = ((DateTime)ds.Tables["Table1"].Rows[0]["SAGYO_START_DATE"]).ToString("yyyyMMdd");
                }
                else
                {
                    DataSet ds = new DataSet();
                    if (!GetCheckMeisai(ref ds))
                    {
                        return false;
                    }
                    sagyoUser = ds.Tables["Table1"].Rows[0]["SAGYO_END_USER"].ToString();
                    sagyoDate = ((DateTime)ds.Tables["Table1"].Rows[0]["SAGYO_END_DATE"]).ToString("yyyyMMdd");
                }
            }

            StringBuilder sql = new StringBuilder();

            sql.Append(" UPDATE TRN_CHECK_H ");
            sql.Append($"    SET  SAGYO_STATUS = {sagyoState}");
            //完了モードの場合最終作業を更新しない
            if (stateMode != "2")
            {
                sql.Append($"     ,    SAGYO_LAST_USER = {sagyoUser} ");
                sql.Append($"     ,    SAGYO_LAST_DATE = {sagyoDate} ");
            }
            sql.Append("     ,    UPD_DT = now() ");
            sql.Append($"    ,    UPD_USER = {user.Id}  ");
            sql.Append($"    ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
            sql.Append($" WHERE GYOMU_CD = {gyomuCd}");
            sql.Append($" AND SAGYO_YYMM = {sagyoYYMM}");

            if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
            {
                return false;
            }
            return true;
        }
        private bool GetCheckMeisai(ref DataSet ds)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     SAGYO_START_USER");
            sql.Append("    ,SAGYO_START_DATE");
            sql.Append("    ,SAGYO_END_USER");
            sql.Append("    ,SAGYO_END_DATE");
            sql.Append(" FROM TRN_CHECK_B");
            sql.Append($" WHERE SAGYO_STATUS = {sagyoState}");
            sql.Append($" AND GYOMU_CD = {gyomuCd}");
            sql.Append($" AND SAGYO_YYMM = {sagyoYYMM}");
            if (sagyoState == "1")
            {
                sql.Append(" ORDER BY SAGYO_START_DATE desc");
            }
            else
            {
                sql.Append(" ORDER BY SAGYO_END_DATE desc");
            }
            if (!comU.CSerch(sql.ToString(), ref ds))
            {
                return false;
            }
            return true;
        }
        private bool CheckUpdateGyomuHeader()
        {
            for (int i = 0; i <= dgvIchiran.Rows.Count - 1; i++)
            {
                //親項目の場合スキップ
                if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
                {
                    continue;
                }
                //実施する
                if ((bool)dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i].Value)
                {
                    //未実施の場合
                    if ((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, i].Value == "0")
                    {
                        //完了状態から実施する業務を追加する/場合
                        if (stateMode == "2")
                        {
                            sagyoState = "1";
                            return true;
                        }
                        return false;
                    }
                    //処理中の場合
                    else if ((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, i].Value == "1")
                    {
                        sagyoState = "1";
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }

            }
            //すべてが完了済み、または実施不要
            sagyoState = "2";
            return true;
        }


        private bool UpdateGyomuCheckBody(MySqlTransaction transaction)
        {
            bool flg = true;

            for (int i = 0; i <= dgvIchiran.Rows.Count - 1; i++)
            {
                //親項目の場合スキップ
                if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
                {
                    continue;
                }
                ///変更のあった行のみを対象
                if ((bool)dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i].Value)
                {
                    if ((bool)dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG_OLD, i].Value)
                    {
                        continue;
                    }
                }
                else
                {
                    if (!(bool)dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG_OLD, i].Value)
                    {
                        continue;
                    }
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE TRN_CHECK_B ");
                sql.Append($"    SET  DISUSE_FLG = {dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i].Value}");
                sql.Append("     ,    UPD_DT = now() ");
                sql.Append($"    ,    UPD_USER = {user.Id}  ");
                sql.Append($"    ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
                sql.Append($" WHERE GYOMU_CD = {gyomuCd}");
                sql.Append($" AND SAGYO_YYMM = {sagyoYYMM}");
                sql.Append($" AND SAGYO_CD = {dgvIchiran[(int)column.MST_SAGYO_CD, i].Value}");

                if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
                {
                    flg = false;
                    break;
                }
            }

            return flg;
        }

        private void Toroku()
        {
            if (!CheckToroku())
            {
                return;
            }
            DialogResult result = MessageBox.Show("登録を行います。よろしいでしょうか。？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                MySqlTransaction transaction = null;
                if (!comU.CConnect(ref transaction, ref command))
                {
                    return;
                }
                if (!InsertGyomuCheckHeader(transaction))
                {

                    MessageBox.Show("業務チェックヘッダの作成に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!InsertGyomuCheckBody(transaction))
                {
                    MessageBox.Show("業務チェック明細の作成に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                transaction.Commit();
                MessageBox.Show("登録が完了しました。", "");
                torokuFlg = true;
                this.Close();
            }
        }
        private bool CheckToroku()
        {
            for (int i = 0; i < dgvIchiran.RowCount; i++)
            {
                if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
                {
                    continue;
                }

                if ((bool)dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i].Value)
                {
                    return true;
                }
            }
            MessageBox.Show("実施要否は1つ以上選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        private bool InsertGyomuCheckHeader(MySqlTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO TRN_CHECK_H ");
            sql.Append("    (GYOMU_CD ");
            sql.Append("    ,SAGYO_YYMM ");
            sql.Append("    ,SAGYO_STATUS ");
            sql.Append("    ,INS_DT ");
            sql.Append("    ,INS_USER ");
            sql.Append("    ,INS_PGM ");
            sql.Append("    ,UPD_DT ");
            sql.Append("    ,UPD_USER ");
            sql.Append("    ,UPD_PGM) ");
            sql.Append(" VALUES ");
            sql.Append($"    ({comU.CAddQuotation(cmbKbn.SelectedValue.ToString())} ");
            sql.Append($"    ,{sagyoYYMM} ");
            sql.Append("    ,0 ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{user.Id} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{user.Id} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)}) ");

            if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
            {
                return false;
            }
            return true;
        }

        private bool InsertGyomuCheckBody(MySqlTransaction transaction)
        {
            bool flg = true;

            for (int i = 0; i <= dgvIchiran.Rows.Count - 1; i++)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO TRN_CHECK_B ");
                sql.Append("    (GYOMU_CD ");
                sql.Append("    ,SAGYO_YYMM ");
                sql.Append("    ,SAGYO_CD ");
                sql.Append("    ,SAGYO_STATUS ");
                sql.Append("    ,DISUSE_FLG ");
                sql.Append("    ,INS_DT ");
                sql.Append("    ,INS_USER ");
                sql.Append("    ,INS_PGM ");
                sql.Append("    ,UPD_DT ");
                sql.Append("    ,UPD_USER ");
                sql.Append("    ,UPD_PGM) ");
                sql.Append(" VALUES ");
                sql.Append($"    ({comU.CAddQuotation(cmbKbn.SelectedValue.ToString())} ");
                sql.Append($"    ,{sagyoYYMM} ");
                sql.Append($"    ,{comU.CAddQuotation(dgvIchiran.Rows[i].Cells[(int)column.MST_SAGYO_CD].Value.ToString())} ");
                sql.Append("    ,0 ");
                if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
                {
                    sql.Append("    ,false ");
                }
                else
                {
                    sql.Append($"    ,{dgvIchiran.Rows[i].Cells[(int)column.TRN_CHECK_B_DISUSE_FLG].Value} ");
                }
                sql.Append("    ,now() ");
                sql.Append($"    ,{user.Id} ");
                sql.Append($"    ,{comU.CAddQuotation(programId)} ");
                sql.Append("    ,now() ");
                sql.Append($"    ,{user.Id} ");
                sql.Append($"    ,{comU.CAddQuotation(programId)}) ");

                if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
                {
                    flg = false;
                    break;
                }
            }

            return flg;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MySqlTransaction transaction = null;
            DialogResult result = MessageBox.Show("削除を行います。よろしいでしょうか。？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                if (CheckSagyoStart())
                {
                    DialogResult dialogResult = MessageBox.Show("作業開始済みの作業が含まれます。よろしいでしょうか。？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    //何が選択されたか調べる
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                if (!comU.CConnect(ref transaction, ref command))
                {
                    return;
                }
                if (!DeleteGyomuCheckHeader(transaction))
                {
                    MessageBox.Show("業務チェックヘッダの削除に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!DelteGyomuCheckBody(transaction))
                {
                    MessageBox.Show("業務チェック明細の削除に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                transaction.Commit();
                if (gamenMode == (int)mode.UPDATE)
                {
                    DeleteHaita();
                }
                torokuFlg = true;

                MessageBox.Show("削除が完了しました。", "");
                this.Close();
            }
        }

        private bool DeleteGyomuCheckHeader(MySqlTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM TRN_CHECK_H ");
            sql.Append($" WHERE GYOMU_CD = {gyomuCd}");
            sql.Append($" AND SAGYO_YYMM = {sagyoYYMM}");

            if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
            {
                return false;
            }
            return true;
        }

        private bool DelteGyomuCheckBody(MySqlTransaction transaction)
        {
            bool flg = true;

            for (int i = 0; i <= dgvIchiran.Rows.Count - 1; i++)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM TRN_CHECK_B ");
                sql.Append($" WHERE GYOMU_CD = {gyomuCd}");
                sql.Append($" AND SAGYO_YYMM = {sagyoYYMM}");

                if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
                {
                    flg = false;
                    break;
                }
            }

            return flg;
        }
        private bool ChangeDetection()
        {
            //新規の場合
            if (gamenMode == (int)mode.INSERT)
            {
                return changeFlg;
            }
            for (int i = 0; i <= dgvIchiran.Rows.Count - 1; i++)
            {
                if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
                {
                    continue;
                }
                if ((bool)dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i].Value & !(bool)dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG_OLD, i].Value)
                {
                    return true;
                }
                if (!(bool)dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG, i].Value & (bool)dgvIchiran[(int)column.TRN_CHECK_B_DISUSE_FLG_OLD, i].Value)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckSagyoStart()
        {
            for (int i = 0; i <= dgvIchiran.Rows.Count - 1; i++)
            {
                if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
                {
                    continue;
                }
                else if ((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, i].Value != "0")
                {
                    return true;
                }
            }
            return false;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            headerChangeFlg = true;
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            headerChangeFlg = true;
        }

        private void cmbKbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            headerChangeFlg = true;
        }
    }
}
