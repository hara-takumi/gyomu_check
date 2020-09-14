using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GYOMU_CHECK
{
    public partial class GC0040 : Form
    {
        private readonly CommonUtil comU = new CommonUtil();
        private readonly User user;
        private readonly string sagyoYYMM;
        private readonly string gyomuCd;
        private readonly string gyomuNm;
        bool changeFlg = true;
        bool errorFlg = false;
        MySqlTransaction transaction = null;
        MySqlCommand command = new MySqlCommand();
        private readonly string programId = "GC0040";


        public enum column
        {
            //CHECK,
            TRN_CHECK_B_SAGYO_CD,
            MST_SAGYO_NAME,
            MST_SAGYO_PARENT_FLG,
            START_BUTTON,
            END_BUTTON,
            COLLECT_BUTTON,
            TRN_CHECK_B_SAGYO_STATUS,
            TRN_CHECK_B_SAGYO_STATUS_OLD,
            STATUS_NAME,
            START_EMPLOYEE_ID,
            START_EMPLOYEE_ID_OLD,
            START_EMPLOYEE_NAME,
            TRN_CHECK_B_SAGYO_START_DATE,
            TRN_CHECK_B_SAGYO_START_DATE_OLD,
            END_EMPLOYEE_ID,
            END_EMPLOYEE_ID_OLD,
            END_EMPLOYEE_NAME,
            TRN_CHECK_B_SAGYO_END_DATE,
            TRN_CHECK_B_SAGYO_END_DATE_OLD,
            TRN_CHECK_B_BIKOU,
            TRN_CHECK_B_BIKOU_OLD,
            CHANGE_FLG

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="user"></param>
        /// <param name="yyyyMM"></param>
        /// <param name="Cd"></param>
        /// <param name="Nm"></param>
        public GC0040(User user, string yyyyMM, string Cd, string Nm)
        {
            sagyoYYMM = comU.CReplace(yyyyMM);
            gyomuCd = Cd;
            gyomuNm = Nm;
            this.user = user;
            InitializeComponent();
        }

        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GC0040_Load(object sender, EventArgs e)
        {
            Initialization();
            lblUserNm.Text = user.Name;
        }
        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialization()
        {
            DataSet dataSet = new DataSet();
            if (!comU.CGyomu(ref dataSet, false))
            {
                errorFlg = true;
                Close();
                return;
            }

            lblGyomu.Text = gyomuNm;
            lblYear.Text = sagyoYYMM.Substring(0, 4) + "/" + sagyoYYMM.Substring(4, 2);
            //排他登録
            TorokuHaita();
            //一覧表示
            DgvDisply();
        }

        /// <summary>
        /// 排他登録
        /// </summary>
        private void TorokuHaita()
        {
            //データベースに接続できなかった場合
            if (!comU.CConnect(ref transaction, ref command))
            {
                errorFlg = true;
                return;
            }
            //排他登録に失敗した場合
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
        /// 各種ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIchiran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0) return;

            //if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, e.RowIndex].Value) return;

            String status = (String)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, e.RowIndex].Value;
            String sagyoNm = (String)dgvIchiran[(int)column.MST_SAGYO_NAME, e.RowIndex].Value;
            //開始押下
            if (e.ColumnIndex == (int)column.START_BUTTON)
            {
                //ボタンが非活性の場合処理終了
                DataGridViewDisableButtonCell startButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!startButtonCell.Enabled)
                {
                    return;
                }

                GC0060 Gc0060 = new GC0060(status, sagyoNm, gyomuNm, sagyoYYMM);
                Gc0060.ShowDialog();
                if (Gc0060.returnFlg)
                {
                    dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, e.RowIndex].Value = "1";
                    dgvIchiran[(int)column.STATUS_NAME, e.RowIndex].Value = "処理中";
                    dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, e.RowIndex].Value = Gc0060.returnStartDateTime;
                    dgvIchiran[(int)column.START_EMPLOYEE_ID, e.RowIndex].Value = user.Id;
                    dgvIchiran[(int)column.START_EMPLOYEE_NAME, e.RowIndex].Value = user.Name;
                    //活性制御
                    DataGridViewDisableButtonCell endButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[e.RowIndex].Cells[(int)column.END_BUTTON];
                    DataGridViewDisableButtonCell collectButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[e.RowIndex].Cells[(int)column.COLLECT_BUTTON];

                    endButtonCell.Enabled = true;
                    collectButtonCell.Enabled = true;
                    startButtonCell.Enabled = false;
                }
            }
            //終了押下
            else if (e.ColumnIndex == (int)column.END_BUTTON)
            {
                //ボタンが非活性の場合処理終了
                DataGridViewDisableButtonCell endButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!endButtonCell.Enabled)
                {
                    return;
                }
                DateTime sagyoStart = DateTime.Parse(dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, e.RowIndex].Value.ToString());
                GC0060 Gc0060 = new GC0060(status, sagyoNm, gyomuNm, sagyoYYMM, sagyoStart, false);
                Gc0060.ShowDialog();
                if (Gc0060.returnFlg)
                {
                    dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, e.RowIndex].Value = "2";
                    dgvIchiran[(int)column.STATUS_NAME, e.RowIndex].Value = "完了";
                    dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_END_DATE, e.RowIndex].Value = Gc0060.returnEndDateTime;
                    dgvIchiran[(int)column.END_EMPLOYEE_ID, e.RowIndex].Value = user.Id;
                    dgvIchiran[(int)column.END_EMPLOYEE_NAME, e.RowIndex].Value = user.Name;
                    //活性制御
                    DataGridViewDisableButtonCell collectButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[e.RowIndex].Cells[(int)column.COLLECT_BUTTON];
                    endButtonCell.Enabled = false;
                    collectButtonCell.Enabled = true;
                }
            }
            //訂正押下
            else if (e.ColumnIndex == (int)column.COLLECT_BUTTON)
            {
                //ボタンが非活性の場合処理終了
                DataGridViewDisableButtonCell collectButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!collectButtonCell.Enabled)
                {
                    return;
                }
                GC0060 Gc0060 = null;
                DateTime sagyoStart = DateTime.Parse(dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, e.RowIndex].Value.ToString());
                //進捗が進行中の場合
                if ((String)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, e.RowIndex].Value == "1")
                {

                    Gc0060 = new GC0060(status, sagyoNm, gyomuNm, sagyoYYMM, sagyoStart, true);
                }
                //進捗が完了の場合
                else if ((String)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, e.RowIndex].Value == "2")
                {
                    DateTime sagyoEnd = DateTime.Parse(dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_END_DATE, e.RowIndex].Value.ToString());

                    Gc0060 = new GC0060(status, sagyoNm, gyomuNm, sagyoYYMM, sagyoStart, sagyoEnd);
                }
                Gc0060.ShowDialog();

                if (Gc0060.returnFlg)
                {
                    DataGridViewDisableButtonCell startButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[e.RowIndex].Cells[(int)column.START_BUTTON];
                    DataGridViewDisableButtonCell endButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[e.RowIndex].Cells[(int)column.END_BUTTON];
                    //未実施の場合
                    if (Gc0060.mStatus == "0")
                    {
                        dgvIchiran[(int)column.STATUS_NAME, e.RowIndex].Value = "未着手";
                        dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, e.RowIndex].Value = "0";
                        dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, e.RowIndex].Value = DBNull.Value;
                        dgvIchiran[(int)column.START_EMPLOYEE_ID, e.RowIndex].Value = null;
                        dgvIchiran[(int)column.START_EMPLOYEE_NAME, e.RowIndex].Value = null;
                        dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_END_DATE, e.RowIndex].Value = DBNull.Value;
                        dgvIchiran[(int)column.END_EMPLOYEE_ID, e.RowIndex].Value = null;
                        dgvIchiran[(int)column.END_EMPLOYEE_NAME, e.RowIndex].Value = null;
                        //活性制御
                        startButtonCell.Enabled = true;
                        endButtonCell.Enabled = false;
                        collectButtonCell.Enabled = false;
                    }
                    //処理中の場合
                    else if (Gc0060.mStatus == "1")
                    {

                        dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, e.RowIndex].Value = "1";
                        dgvIchiran[(int)column.STATUS_NAME, e.RowIndex].Value = "処理中";
                        if (Gc0060.startChangeFlg)
                        {
                            dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, e.RowIndex].Value = Gc0060.returnStartDateTime;
                            dgvIchiran[(int)column.START_EMPLOYEE_ID, e.RowIndex].Value = user.Id;
                            dgvIchiran[(int)column.START_EMPLOYEE_NAME, e.RowIndex].Value = user.Name;
                        }
                        dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_END_DATE, e.RowIndex].Value = DBNull.Value;
                        dgvIchiran[(int)column.END_EMPLOYEE_ID, e.RowIndex].Value = null;
                        dgvIchiran[(int)column.END_EMPLOYEE_NAME, e.RowIndex].Value = null;
                        //活性制御
                        endButtonCell.Enabled = true;
                    }
                    //完了の場合
                    else
                    {

                        dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, e.RowIndex].Value = "2";
                        dgvIchiran[(int)column.STATUS_NAME, e.RowIndex].Value = "完了";
                        if (Gc0060.startChangeFlg)
                        {
                            dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, e.RowIndex].Value = Gc0060.returnStartDateTime;
                            dgvIchiran[(int)column.START_EMPLOYEE_ID, e.RowIndex].Value = user.Id;
                            dgvIchiran[(int)column.START_EMPLOYEE_NAME, e.RowIndex].Value = user.Name;
                        }

                        if (Gc0060.endChangeFlg)
                        {
                            dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_END_DATE, e.RowIndex].Value = Gc0060.returnEndDateTime;
                            dgvIchiran[(int)column.END_EMPLOYEE_ID, e.RowIndex].Value = user.Id;
                            dgvIchiran[(int)column.END_EMPLOYEE_NAME, e.RowIndex].Value = user.Name;
                        }

                        //活性制御
                        collectButtonCell.Enabled = true;
                    }
                }
            }
            dgvIchiran.Invalidate();
        }

        /// <summary>
        /// 年月一覧画面に戻る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 明細表示
        /// </summary>
        private void DgvDisply()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     TRN_CHECK_B.SAGYO_CD");
            sql.Append("    ,MST_SAGYO.NAME");
            sql.Append("    ,MST_SAGYO.PARENT_FLG");
            sql.Append("    ,TRN_CHECK_B.SAGYO_STATUS");
            sql.Append("    ,TRN_CHECK_B.SAGYO_STATUS AS SAGYO_STATUS_OLD");
            sql.Append("    ,CASE WHEN MST_SAGYO.PARENT_FLG = '1' THEN ''");
            sql.Append("    WHEN trn_check_B.SAGYO_STATUS = '0' THEN '未着手'");
            sql.Append("    WHEN trn_check_B.SAGYO_STATUS = '1' THEN '処理中'");
            sql.Append("    ELSE '完了' END AS STATUS_NAME");
            sql.Append("    ,START_USER.MST_SHAIN_CODE");
            sql.Append("    ,START_USER.MST_SHAIN_CODE AS START_EMPLOYEE_ID_OLD");
            sql.Append("    ,START_USER.MST_SHAIN_NAME AS START_EMPLOYEE_NAME");
            sql.Append("    ,TRN_CHECK_B.SAGYO_START_DATE");
            sql.Append("    ,TRN_CHECK_B.SAGYO_START_DATE AS SAGYO_START_DATE_OLD");
            sql.Append("    ,END_USER.MST_SHAIN_CODE");
            sql.Append("    ,END_USER.MST_SHAIN_CODE AS END_EMPLOYEE_ID_OLD");
            sql.Append("    ,END_USER.MST_SHAIN_NAME AS END_EMPLOYEE_NAME");
            sql.Append("    ,TRN_CHECK_B.SAGYO_END_DATE");
            sql.Append("    ,TRN_CHECK_B.SAGYO_END_DATE AS SAGYO_END_DATE_OLD");
            sql.Append("    ,TRN_CHECK_B.BIKOU");
            sql.Append("    ,TRN_CHECK_B.BIKOU AS BIKOU_OLD");
            sql.Append(" FROM TRN_CHECK_B");
            sql.Append(" LEFT JOIN MST_SAGYO");
            sql.Append(" ON TRN_CHECK_B.SAGYO_CD = MST_SAGYO.CD");
            sql.Append(" LEFT JOIN mst_shain START_USER");
            sql.Append(" ON START_USER.MST_SHAIN_CODE = TRN_CHECK_B.SAGYO_START_USER");
            sql.Append(" LEFT JOIN mst_shain END_USER");
            sql.Append(" ON END_USER.MST_SHAIN_CODE = TRN_CHECK_B.SAGYO_END_USER");
            sql.Append(" WHERE MST_SAGYO.DEL_FLG = 0");
            sql.Append(" AND (TRN_CHECK_B.DISUSE_FLG = 1 OR MST_SAGYO.PARENT_FLG = 1 )");
            sql.Append($" AND TRN_CHECK_B.GYOMU_CD = {gyomuCd}");
            sql.Append($" AND TRN_CHECK_B.SAGYO_YYMM = {sagyoYYMM}");
            sql.Append(" ORDER BY MST_SAGYO.HYOJI_JUN");

            DataSet ds = new DataSet();
            //検索結果が返ってこなかった場合
            if (!comU.CSerch(sql.ToString(), ref ds))
            {
                Close();
                return;
            }
            //取得したデータ件数が0件の場合
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("指定した業務の作業が登録されていません。\n\r作業マスタの登録を行ってください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            //セルボタン作成
            DataGridViewDisableButtonColumn dgvBtnStrat = new DataGridViewDisableButtonColumn();
            dgvBtnStrat.Name = "開始";
            dgvBtnStrat.UseColumnTextForButtonValue = true;
            dgvBtnStrat.Width = 60;

            DataGridViewDisableButtonColumn dgvBtnEnd = new DataGridViewDisableButtonColumn();
            dgvBtnEnd.Name = "終了";
            dgvBtnEnd.UseColumnTextForButtonValue = true;
            dgvBtnEnd.Width = 60;

            DataGridViewDisableButtonColumn dgvBtnFix = new DataGridViewDisableButtonColumn();
            dgvBtnFix.Name = "状況訂正";
            dgvBtnFix.UseColumnTextForButtonValue = true;
            dgvBtnFix.Width = 80;

            //変更確認チェックボックス作成
            DataGridViewCheckBoxColumn dgvcbc = new DataGridViewCheckBoxColumn();
            dgvcbc.TrueValue = true;
            dgvcbc.FalseValue = false;

            dgvIchiran.Rows.Clear();
            Enumerable.Range(0, ds.Tables[0].Rows.Count).Select(index => ds.Tables[0].Rows[index] as DataRow).ToList()
                .ForEach(dr => 
                {
                    dgvIchiran.Rows.Add();
                    int indx = dgvIchiran.Rows.Count - 1;
                    dgvIchiran.Rows[indx].Cells["SAGYO_NAME"].Value = dr["NAME"].ToString();
                    dgvIchiran.Rows[indx].Cells["PARENT_FLG"].Value = dr["PARENT_FLG"].ToString();
                    dgvIchiran.Rows[indx].Cells["START_BUTTON"].Value = dgvBtnStrat.Name;
                    dgvIchiran.Rows[indx].Cells["END_BUTTON"].Value = dgvBtnEnd.Name;
                    dgvIchiran.Rows[indx].Cells["COLLECT_BUTTON"].Value = dgvBtnFix.Name;
                    dgvIchiran.Rows[indx].Cells["SAGYO_STATUS"].Value = dr["SAGYO_STATUS"].ToString();
                    dgvIchiran.Rows[indx].Cells["SAGYO_STATUS_OLD"].Value = dr["SAGYO_STATUS_OLD"].ToString();
                    dgvIchiran.Rows[indx].Cells["STATUS_NAME"].Value = dr["STATUS_NAME"].ToString();
                    dgvIchiran.Rows[indx].Cells["START_EMPLOYEE_ID_OLD"].Value = dr["START_EMPLOYEE_ID_OLD"].ToString();
                    dgvIchiran.Rows[indx].Cells["START_EMPLOYEE_NAME"].Value = dr["START_EMPLOYEE_NAME"].ToString();
                    if (!dr["SAGYO_START_DATE"].ToString().Equals(""))
                    {
                        dgvIchiran.Rows[indx].Cells["SAGYO_START_DATE"].Value = Convert.ToDateTime(dr["SAGYO_START_DATE"].ToString()).ToString("yyyy/MM/dd HH:mm");
                    }
                    if (!dr["SAGYO_START_DATE_OLD"].ToString().Equals(""))
                    {
                        dgvIchiran.Rows[indx].Cells["SAGYO_START_DATE_OLD"].Value = Convert.ToDateTime(dr["SAGYO_START_DATE_OLD"].ToString()).ToString("yyyy/MM/dd HH:mm");
                    }
                    dgvIchiran.Rows[indx].Cells["END_EMPLOYEE_ID_OLD"].Value = dr["END_EMPLOYEE_ID_OLD"].ToString();
                    dgvIchiran.Rows[indx].Cells["END_EMPLOYEE_NAME"].Value = dr["END_EMPLOYEE_NAME"].ToString();
                    if (!dr["SAGYO_END_DATE"].ToString().Equals(""))
                    {
                        dgvIchiran.Rows[indx].Cells["SAGYO_END_DATE"].Value = Convert.ToDateTime(dr["SAGYO_END_DATE"].ToString()).ToString("yyyy/MM/dd HH:mm");
                    }
                    if (!dr["SAGYO_END_DATE_OLD"].ToString().Equals(""))
                    {
                        dgvIchiran.Rows[indx].Cells["SAGYO_END_DATE_OLD"].Value = Convert.ToDateTime(dr["SAGYO_END_DATE_OLD"].ToString()).ToString("yyyy/MM/dd HH:mm");
                    }
                    dgvIchiran.Rows[indx].Cells["BIKOU"].Value = dr["BIKOU"].ToString();
                    dgvIchiran.Rows[indx].Cells["BIKOU_OLD"].Value = dr["BIKOU_OLD"].ToString();

                    if (indx % 2 == 1)
                    {
                        dgvIchiran.Rows[indx].DefaultCellStyle.BackColor = Color.LightBlue;
                    }

                    DataGridViewDisableButtonCell startButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[indx].Cells["START_BUTTON"];
                    DataGridViewDisableButtonCell endButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[indx].Cells["END_BUTTON"];
                    DataGridViewDisableButtonCell collectButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[indx].Cells["COLLECT_BUTTON"];

                    if ((bool)dr["PARENT_FLG"])
                    {
                        dgvIchiran.Rows[indx].Cells["START_BUTTON"] = new DataGridViewTextBoxCell();
                        dgvIchiran.Rows[indx].Cells["END_BUTTON"] = new DataGridViewTextBoxCell();
                        dgvIchiran.Rows[indx].Cells["COLLECT_BUTTON"] = new DataGridViewTextBoxCell();
                        dgvIchiran.Rows[indx].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if(dr["SAGYO_STATUS"].ToString() == "0")
                    {
                        endButtonCell.Enabled = false;
                        collectButtonCell.Enabled = false;
                        dgvIchiran.Rows[indx].Cells["CHANGE_FLG"].Value = false;
                    }
                    else if (dr["SAGYO_STATUS"].ToString() == "1")
                    {
                        startButtonCell.Enabled = false;
                        dgvIchiran.Rows[indx].Cells["CHANGE_FLG"].Value = false;
                    }
                    else if (dr["SAGYO_STATUS"].ToString() == "2")
                    {
                        startButtonCell.Enabled = false;
                        endButtonCell.Enabled = false;
                        dgvIchiran.Rows[indx].Cells["CHANGE_FLG"].Value = false;
                    }

                    dgvIchiran.Rows[indx].Height = 30;
                });


            //dgvIchiran.DataSource = ds.Tables[0];

            ////セルボタン作成
            //DataGridViewDisableButtonColumn dgvBtnStrat = new DataGridViewDisableButtonColumn();
            //dgvBtnStrat.Text = "開始";
            //dgvBtnStrat.UseColumnTextForButtonValue = true;
            //dgvBtnStrat.Width = 60;
            //dgvIchiran.Columns.Insert((int)column.START_BUTTON, dgvBtnStrat);

            //DataGridViewDisableButtonColumn dgvBtnEnd = new DataGridViewDisableButtonColumn();
            //dgvBtnEnd.Text = "終了";
            //dgvBtnEnd.UseColumnTextForButtonValue = true;
            //dgvBtnEnd.Width = 60;
            //dgvIchiran.Columns.Insert((int)column.END_BUTTON, dgvBtnEnd);

            //DataGridViewDisableButtonColumn dgvBtnFix = new DataGridViewDisableButtonColumn();
            //dgvBtnFix.Text = "状況訂正";
            //dgvBtnFix.UseColumnTextForButtonValue = true;
            //dgvBtnFix.Width = 80;
            //dgvIchiran.Columns.Insert((int)column.COLLECT_BUTTON, dgvBtnFix);

            ////変更確認チェックボックス作成
            //DataGridViewCheckBoxColumn dgvcbc = new DataGridViewCheckBoxColumn();
            //dgvIchiran.Columns.Insert((int)column.CHANGE_FLG, dgvcbc);
            //dgvcbc.TrueValue = true;
            //dgvcbc.FalseValue = false;

            ////作業名列固定
            //dgvIchiran.RowTemplate.Height = 70;
            //dgvIchiran.Columns[(int)column.MST_SAGYO_NAME].Frozen = true;
            //dgvIchiran.Columns[(int)column.MST_SAGYO_NAME].Width = 400;
            //dgvIchiran.Columns[(int)column.STATUS_NAME].Width = 60;
            //dgvIchiran.Columns[(int)column.START_EMPLOYEE_NAME].Width = 80;
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_START_DATE].Width = 113;
            //dgvIchiran.Columns[(int)column.END_EMPLOYEE_NAME].Width = 80;
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_END_DATE].Width = 113;
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_BIKOU].Width = 100;

            //dgvIchiran.Columns[(int)column.MST_SAGYO_NAME].HeaderText = "";
            //dgvIchiran.Columns[(int)column.STATUS_NAME].HeaderText = "状況";
            //dgvIchiran.Columns[(int)column.START_EMPLOYEE_NAME].HeaderText = "作業開始者";
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_START_DATE].HeaderText = "開始日時";
            //dgvIchiran.Columns[(int)column.END_EMPLOYEE_NAME].HeaderText = "作業終了者";
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_END_DATE].HeaderText = "終了日時";
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_BIKOU].HeaderText = "備考";

            //dgvIchiran.Columns[(int)column.MST_SAGYO_NAME].ReadOnly = true;
            //dgvIchiran.Columns[(int)column.STATUS_NAME].ReadOnly = true;
            //dgvIchiran.Columns[(int)column.START_EMPLOYEE_NAME].ReadOnly = true;
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_START_DATE].ReadOnly = true;
            //dgvIchiran.Columns[(int)column.END_EMPLOYEE_NAME].ReadOnly = true;
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_END_DATE].ReadOnly = true;

            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_CD].Visible = false;
            //dgvIchiran.Columns[(int)column.MST_SAGYO_PARENT_FLG].Visible = false;
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_STATUS].Visible = false;
            //dgvIchiran.Columns[(int)column.START_EMPLOYEE_ID].Visible = false;
            //dgvIchiran.Columns[(int)column.END_EMPLOYEE_ID].Visible = false;
            //dgvIchiran.Columns[(int)column.CHANGE_FLG].Visible = false;

            //dgvIchiran.Columns[(int)column.END_EMPLOYEE_ID_OLD].Visible = false;
            //dgvIchiran.Columns[(int)column.START_EMPLOYEE_ID_OLD].Visible = false;
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_BIKOU_OLD].Visible = false;
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_START_DATE_OLD].Visible = false;
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_END_DATE_OLD].Visible = false;
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_STATUS_OLD].Visible = false;

            //dgvIchiran.Columns[(int)column.STATUS_NAME].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvIchiran.Columns[(int)column.START_EMPLOYEE_NAME].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_START_DATE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvIchiran.Columns[(int)column.END_EMPLOYEE_NAME].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_END_DATE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            //((DataGridViewTextBoxColumn)dgvIchiran.Columns[(int)column.TRN_CHECK_B_BIKOU]).MaxInputLength = 100;

            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_START_DATE].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm";
            //dgvIchiran.Columns[(int)column.TRN_CHECK_B_SAGYO_END_DATE].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm";


            ////実施要否チェック済み
            //for (int i = 0; i < dgvIchiran.RowCount; i++)
            //{
            //    if (i % 2 == 1)
            //    {
            //        dgvIchiran.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
            //    }
            //    DataGridViewDisableButtonCell startButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[i].Cells[(int)column.START_BUTTON];
            //    DataGridViewDisableButtonCell endButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[i].Cells[(int)column.END_BUTTON];
            //    DataGridViewDisableButtonCell collectButtonCell = (DataGridViewDisableButtonCell)dgvIchiran.Rows[i].Cells[(int)column.COLLECT_BUTTON];

            //    if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
            //    {
            //        dgvIchiran[(int)column.START_BUTTON, i] = new DataGridViewTextBoxCell();
            //        dgvIchiran[(int)column.END_BUTTON, i] = new DataGridViewTextBoxCell();
            //        dgvIchiran[(int)column.COLLECT_BUTTON, i] = new DataGridViewTextBoxCell();
            //        dgvIchiran.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
            //        dgvIchiran.Rows[i].ReadOnly = true;
            //    }
            //    else if ((String)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, i].Value == "0")
            //    {
            //        endButtonCell.Enabled = false;
            //        collectButtonCell.Enabled = false;
            //        dgvIchiran[(int)column.CHANGE_FLG, i].Value = false;

            //    }
            //    else if ((String)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, i].Value == "1")
            //    {
            //        startButtonCell.Enabled = false;
            //        dgvIchiran[(int)column.CHANGE_FLG, i].Value = false;
            //    }
            //    else if ((String)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, i].Value == "2")
            //    {
            //        startButtonCell.Enabled = false;
            //        endButtonCell.Enabled = false;
            //        dgvIchiran[(int)column.CHANGE_FLG, i].Value = false;

            //    }
            //}
            ////ソートの不可
            //foreach (DataGridViewColumn column in this.dgvIchiran.Columns)
            //{
            //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
            //dgvIchiran.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// 登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            UpdateGyomu();
        }

        /// <summary>
        /// 業務更新
        /// </summary>
        private void UpdateGyomu()
        {
            DialogResult result = MessageBox.Show("更新を行います。よろしいでしょうか。？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //明細の更新行をチェックする
                CheckMeisaiChange();
                //更新を行うか判定
                if (!CheckUpdate())
                {
                    MessageBox.Show("明細が変更されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //データベースに接続できない場合
                if (!comU.CConnect(ref transaction, ref command)) return;

                //業務チェックヘッダの更新に失敗した場合
                if (!UpdateGyomuCheckHeader(transaction))
                {
                    MessageBox.Show("業務チェックヘッダの更新に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //業務チェック明細の更新に失敗した場合
                if (!UpdateGyomuCheckBody(transaction))
                {
                    MessageBox.Show("業務チェック明細の更新に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                transaction.Commit();
                MessageBox.Show("更新が完了しました。", "");

                //排他削除
                DeleteHaita();
                changeFlg = false;
                Close();
            }
        }

        /// <summary>
        /// 業務チェックヘッダー更新
        /// </summary>
        private bool UpdateGyomuCheckHeader(MySqlTransaction transaction)
        {
            //すべて2の場合、完了、すべて0の場合、未着手
            string sagyoState = "0";
            bool firstFlg = false;

            Enumerable.Range(0, dgvIchiran.Rows.Count - 1).Select(indx => dgvIchiran.Rows[indx])
                .Where(row => row.Cells["PARENT_FLG"].Value.ToString().Equals("False")).ToList()
                .ForEach(row =>
                {
                    if (sagyoState.Equals("0"))
                    {
                        //最初の行のステータスを保持
                        if (!firstFlg)
                        {
                            sagyoState = row.Cells["SAGYO_STATUS"].Value.ToString();
                            firstFlg = true;
                        }
                        //ステータスが一致しない場合処理中
                        if (sagyoState != row.Cells["SAGYO_STATUS"].Value.ToString())
                        {
                            sagyoState = "1";
                        }
                    }
                });


            //for (int i = 0; i <= dgvIchiran.Rows.Count - 1; i++)
            //{
            //    //親項目の場合スキップ
            //    if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
            //    {
            //        continue;
            //    }
            //    //最初の行のステータスを保持
            //    else if(!firstFlg)
            //    {
            //        sagyoState = dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, i].Value.ToString();
            //        firstFlg = true;
            //    }
            //    //ステータスが一致しない場合処理中
            //    else if(sagyoState != dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, i].Value.ToString())
            //    {
            //        sagyoState = "1";
            //    }
            //    //ステータスが処理中の場合処理終了
            //    if(sagyoState == "1")
            //    {
            //        break;
            //    }
            //}
            DateTime lastDate = DateTime.Now;
            string lastUser = user.Id;
            //ステータスが処理中の場合、
            if ("1".Equals(sagyoState))
            {
                lastDate = DateTime.MinValue;
                Enumerable.Range(0, dgvIchiran.Rows.Count - 1).Select(indx => dgvIchiran.Rows[indx])
                .Where(row => row.Cells["PARENT_FLG"].Value.ToString().Equals("False")).ToList()
                .ForEach(row =>
                {
                    //作業終了日が空白以外の場合
                    if (!string.IsNullOrEmpty(row.Cells["SAGYO_END_DATE"].Value.ToString()))
                    {
                        //現在日より作業終了日が前の場合
                        if (DateTime.Parse(row.Cells["SAGYO_END_DATE"].Value.ToString()) > lastDate)
                        {
                            lastDate = DateTime.Parse(row.Cells["SAGYO_END_DATE"].Value.ToString());
                            lastUser = row.Cells["END_EMPLOYEE_ID"].Value.ToString();
                        }
                    }
                    //作業開始日が空白以外の場合
                    else if (!string.IsNullOrEmpty(row.Cells["SAGYO_START_DATE"].Value.ToString()))
                    {
                        //現在日より作業開始日が前の場合
                        if (DateTime.Parse(row.Cells["SAGYO_START_DATE"].Value.ToString()) > lastDate)
                        {
                            lastDate = DateTime.Parse(row.Cells["SAGYO_START_DATE"].Value.ToString());
                            lastUser = row.Cells["START_EMPLOYEE_ID"].Value.ToString();
                        }
                    }
                });
                //GetLastDate(ref lastUser, ref lastDate);
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE TRN_CHECK_H ");
            sql.Append($"    SET  SAGYO_STATUS = {sagyoState}");
            //ステータスが未着手の場合
            if ("0".Equals(sagyoState))
            {
                sql.Append("    ,    SAGYO_LAST_USER = null  ");
                sql.Append("    ,    SAGYO_LAST_DATE = null ");
            }
            else
            {
                sql.Append($"    ,    SAGYO_LAST_USER = {lastUser}  ");
                sql.Append($"    ,    SAGYO_LAST_DATE = {comU.CAddQuotation(lastDate.Date.ToString())} ");
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

        /// <summary>
        /// 最終作業者と最終作業日を取得
        /// </summary>
        //private void GetLastDate(ref string lastUser,ref DateTime lastDate)
        //{
        //    Enumerable.Range(0, dgvIchiran.Rows.Count - 1).Select(indx => dgvIchiran.Rows[indx])
        //        .Where(row => row.Cells["PARENT_FLG"].Value.ToString().Equals("False")).ToList()
        //        .ForEach(row =>
        //        {
        //            if (!string.IsNullOrEmpty(row.Cells["SAGYO_END_DATE"].Value.ToString()))
        //            {
        //                if (DateTime.Parse(row.Cells["SAGYO_END_DATE"].Value.ToString()) > lastDate)
        //                {
        //                    lastDate = DateTime.Parse(dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_END_DATE, i].Value.ToString());
        //                    lastUser = (string)dgvIchiran[(int)column.END_EMPLOYEE_ID, i].Value.ToString();
        //                }
        //            }
        //            else if (!string.IsNullOrEmpty((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, i].Value.ToString()))
        //            {
        //                if (DateTime.Parse(dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, i].Value.ToString()) > lastDate)
        //                {
        //                    lastDate = DateTime.Parse(dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, i].Value.ToString());
        //                    lastUser = (string)dgvIchiran[(int)column.START_EMPLOYEE_ID, i].Value.ToString();
        //                }
        //            }
        //        });



        //    for (int i = 0; i <= dgvIchiran.Rows.Count - 1; i++)
        //    {
        //        //親項目の場合スキップ
        //        if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
        //        {
        //            continue;
        //        }
        //        if (!string.IsNullOrEmpty((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_END_DATE, i].Value.ToString()))
        //        {
        //            if (DateTime.Parse(dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_END_DATE, i].Value.ToString()) > lastDate)
        //            {
        //                lastDate = DateTime.Parse(dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_END_DATE, i].Value.ToString());
        //                lastUser = (string)dgvIchiran[(int)column.END_EMPLOYEE_ID, i].Value.ToString();
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, i].Value.ToString()))
        //        {
        //            if (DateTime.Parse(dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, i].Value.ToString()) > lastDate)
        //            {
        //                lastDate = DateTime.Parse(dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, i].Value.ToString());
        //                lastUser = (string)dgvIchiran[(int)column.START_EMPLOYEE_ID, i].Value.ToString();
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 値の変更が行われている場合、行ごとにチェックをする
        /// </summary>
        private void CheckMeisaiChange()
        {
            bool updateFlg;

            Enumerable.Range(0, dgvIchiran.Rows.Count - 1).Select(indx => dgvIchiran.Rows[indx])
                .Where(row => row.Cells["PARENT_FLG"].Value.ToString().Equals("False")).ToList()
                .ForEach(row => 
                {
                    updateFlg = true;
                    //備考の確認
                    if (!row.Cells["BIKOU"].Value.ToString().Equals(row.Cells["BIKOU_OLD"].Value.ToString()))
                    {
                        row.Cells["CHANGE_FLG"].Value = true;
                        return;
                    }
                    //作業ステータスの確認
                    if (!row.Cells["SAGYO_STATUS"].Value.ToString().Equals(row.Cells["SAGYO_STATUS_OLD"].Value.ToString()))
                    {
                        row.Cells["CHANGE_FLG"].Value = true;
                        return;
                    }
                    switch (row.Cells["SAGYO_STATUS"].Value)
                    {
                        //未着手の場合
                        case "0":
                            updateFlg = false;
                            break;
                        //処理中の場合
                        case "1":
                            if (row.Cells["SAGYO_START_DATE"].Value.ToString().Equals(row.Cells["SAGYO_START_DATE_OLD"].Value.ToString())
                                && row.Cells["START_EMPLOYEE_ID"].Value.ToString().Equals(row.Cells["START_EMPLOYEE_ID_OLD"].Value.ToString()))
                            {
                                updateFlg = false;
                            }
                            break;
                        //完了の場合
                        case "2":
                            if (row.Cells["SAGYO_END_DATE"].Value.ToString().Equals(row.Cells["SAGYO_END_DATE_OLD"].Value.ToString())
                                && row.Cells["END_EMPLOYEE_ID"].Value.ToString().Equals(row.Cells["END_EMPLOYEE_ID_OLD"].Value.ToString()))
                            {
                                updateFlg = false;
                            }
                            break;
                    }
                    row.Cells["CHANGE_FLG"].Value = updateFlg;
                });


            //for (int i = 0; i <= dgvIchiran.Rows.Count - 1; i++)
            //{
            //    updateFlg = true;
            //    //親項目の場合スキップ
            //    if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
            //    {
            //        continue;
            //    }
            //    //備考の確認
            //    if (!((string)dgvIchiran[(int)column.TRN_CHECK_B_BIKOU, i].Value.ToString()).Equals((string)dgvIchiran[(int)column.TRN_CHECK_B_BIKOU_OLD, i].Value.ToString()))
            //    {
            //        dgvIchiran[(int)column.CHANGE_FLG, i].Value = true;
            //        continue;
            //    }
            //    //作業ステータスの確認
            //    if (!((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, i].Value.ToString()).Equals((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS_OLD, i].Value.ToString()))
            //    {
            //        dgvIchiran[(int)column.CHANGE_FLG, i].Value = true;
            //        continue;
            //    }
            //    switch (dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, i].Value)
            //    {
            //        //未着手の場合
            //        case "0":
            //            updateFlg = false;
            //            break;
            //        //処理中の場合
            //        case "1":
            //            if (((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, i].Value.ToString()).Equals((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE_OLD, i].Value.ToString())
            //                && ((string)dgvIchiran[(int)column.START_EMPLOYEE_ID, i].Value.ToString()).Equals((string)dgvIchiran[(int)column.START_EMPLOYEE_ID_OLD, i].Value.ToString()))
            //            {
            //                updateFlg = false;
            //            }
            //            break;
            //        //完了の場合
            //        case "2":
            //            if (((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_END_DATE, i].Value.ToString()).Equals((string)dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_END_DATE_OLD, i].Value.ToString())
            //                && ((string)dgvIchiran[(int)column.END_EMPLOYEE_ID, i].Value.ToString()).Equals((string)dgvIchiran[(int)column.END_EMPLOYEE_ID_OLD, i].Value.ToString()))
            //            {
            //                updateFlg = false;
            //            }
            //            break;
            //    }
            //    dgvIchiran[(int)column.CHANGE_FLG, i].Value = updateFlg;
            //}
        }

        /// <summary>
        /// テーブルの更新を行うか判定する
        /// </summary>
        private bool CheckUpdate()
        {
            changeFlg = false;
            Enumerable.Range(0, dgvIchiran.Rows.Count - 1).Select(indx => dgvIchiran.Rows[indx])
                .Where(row => row.Cells["PARENT_FLG"].Value.ToString().Equals("False")).ToList()
                .ForEach(row =>
                {
                    if ((bool)row.Cells["CHANGE_FLG"].Value)
                    {
                        changeFlg = true;
                    }
                });
            return changeFlg;


            //for (int i = 0; i <= dgvIchiran.Rows.Count - 1; i++)
            //{
            //    //親項目の場合スキップ
            //    if ((bool)dgvIchiran[(int)column.MST_SAGYO_PARENT_FLG, i].Value)
            //    {
            //        continue;
            //    }
            //    if ((bool)dgvIchiran[(int)column.CHANGE_FLG, i].Value)
            //    {
            //        return true;
            //    }
            //}

            //return false;
        }

        /// <summary>
        /// 業務チェック明細の更新
        /// </summary>
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
                if (!(bool)dgvIchiran[(int)column.CHANGE_FLG, i].Value)
                {
                    continue;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE TRN_CHECK_B ");
                sql.Append($"    SET  SAGYO_STATUS = {dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_STATUS, i].Value}");
                sql.Append($"    ,    BIKOU = {comU.CAddQuotation(dgvIchiran[(int)column.TRN_CHECK_B_BIKOU, i].Value.ToString())}");
                sql.Append($"    ,    SAGYO_START_USER = {comU.CAddQuotation(dgvIchiran[(int)column.START_EMPLOYEE_ID, i].Value.ToString())}");
                if (string.IsNullOrEmpty(dgvIchiran[(int)column.START_EMPLOYEE_ID, i].Value.ToString()))
                {
                    sql.Append("    ,    SAGYO_START_DATE = null");
                }
                else
                {
                    sql.Append($"    ,    SAGYO_START_DATE = {comU.CAddQuotation(dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_START_DATE, i].Value.ToString())}");
                }
                sql.Append($"    ,    SAGYO_END_USER = {comU.CAddQuotation(dgvIchiran[(int)column.END_EMPLOYEE_ID, i].Value.ToString())}");
                if (string.IsNullOrEmpty(dgvIchiran[(int)column.END_EMPLOYEE_ID, i].Value.ToString()))
                {
                    sql.Append("    ,    SAGYO_END_DATE = null");
                }
                else
                {
                    sql.Append($"    ,    SAGYO_END_DATE = {comU.CAddQuotation(dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_END_DATE, i].Value.ToString())}");
                }
                sql.Append("     ,    UPD_DT = now() ");
                sql.Append($"    ,    UPD_USER = {user.Id}  ");
                sql.Append($"    ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
                sql.Append($" WHERE GYOMU_CD = {gyomuCd}");
                sql.Append($" AND SAGYO_YYMM = {sagyoYYMM}");
                sql.Append($" AND SAGYO_CD = {dgvIchiran[(int)column.TRN_CHECK_B_SAGYO_CD, i].Value}");

                if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
                {
                    flg = false;
                    break;
                }
            }

            return flg;
        }

        /// <summary>
        /// ✕ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GC0040_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!errorFlg)
            {
                CheckMeisaiChange();

                if (CheckUpdate() && changeFlg)
                {
                    DialogResult result = MessageBox.Show("内容が変更されています。　変更は破棄されますが、よろしいですか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {

                        DeleteHaita();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    DeleteHaita();
                }

            }
        }
        /// <summary>
        /// 排他の削除
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
    }
}
