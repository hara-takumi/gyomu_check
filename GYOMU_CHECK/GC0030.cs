using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GYOMU_CHECK
{
    public partial class GC0030 : Form
    {
        #region メンバー変数
        private readonly CommonUtil comU = new CommonUtil();
        private readonly DateTime dt = DateTime.Now;
        private readonly User user;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="user"></param>
        public GC0030(User user)
        {
            this.user = user;
            InitializeComponent();
        }
        #endregion

        #region イベント処理
        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GC0030_Load(object sender, EventArgs e)
        {
            Initialization();
            lblUserNm.Text = user.Name;
        }

        /// <summary>
        /// チェックリスト一覧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIchiran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //業務チェックボタンまたは業務修正ボタンを押下した場合
            if (dgv.Columns[e.ColumnIndex].Name == "GYOMU_CHEACK" || dgv.Columns[e.ColumnIndex].Name == "GYOMU_SYUSEI")
            {
                string yyyyMM = dgv.Rows[e.RowIndex].Cells["SAGYO_YYMM"].Value.ToString();
                string gyomuCd = dgv.Rows[e.RowIndex].Cells["GYOMU_CD"].Value.ToString();
                string sagyoState = dgv.Rows[e.RowIndex].Cells["SAGYO_STATUS"].Value.ToString();
                string gyomuNm = dgv.Rows[e.RowIndex].Cells["GYOMU_NAME"].Value.ToString();
                //業務チェックボタンを押下した場合
                if (dgv.Columns[e.ColumnIndex].Name == "GYOMU_CHEACK")
                {
                    GC0040 Gc0040 = new GC0040(user, yyyyMM, gyomuCd, gyomuNm);
                    Gc0040.ShowDialog();
                    Result();
                }
                //業務修正ボタンを押下した場合
                else if (dgv.Columns[e.ColumnIndex].Name == "GYOMU_SYUSEI")
                {
                    GC0050 Gc0050 = new GC0050(user, yyyyMM, gyomuCd, sagyoState);
                    Gc0050.ShowDialog();
                    //登録された場合、再検索
                    if (Gc0050.torokuFlg) Result();
                }
                if (e.RowIndex < 0) return;
            }
        }
        #endregion

        #region メソッド
        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialization()
        {
            //コンボボックス設定(年月)
            cmbYearFrom.DataSource = comU.CYear(true).ToArray();
            cmbYearFrom.Text = dt.ToString("yyyy");
            cmbMonthFrom.DataSource = comU.CMonth(true).ToArray();
            cmbMonthFrom.Text = dt.ToString("MM");
            cmbYearTo.DataSource = comU.CYear(true).ToArray();
            cmbYearTo.Text = dt.ToString("yyyy");
            cmbMonthTo.DataSource = comU.CMonth(true).ToArray();
            cmbMonthTo.Text = dt.ToString("MM");

            //コンボボックスの設定(業務区分)
            // コンボボックスにデータテーブルをセット
            DataSet dataSet = new DataSet();
            //業務区分データ取得
            if (!comU.CGyomu(ref dataSet, true))
            {
                Close();
                return;
            }
            // コンボボックスにデータテーブルをセット
            cmbKbn.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            cmbKbn.DisplayMember = "NAME";
            //// データ用の列を設定
            cmbKbn.ValueMember = "CD";

            //完了済みチェック
            chkKanryouzumi.Checked = false;
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        private bool CheckSearch()
        {
            //年必須
            if (cmbYearFrom.SelectedIndex == 0 & cmbMonthFrom.SelectedIndex != 0)
            {
                MessageBox.Show("月を選択した場合は年を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbYearTo.SelectedIndex == 0 & cmbMonthTo.SelectedIndex != 0)
            {
                MessageBox.Show("月を選択した場合は年を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //月必須
            if (cmbMonthFrom.SelectedIndex == 0 & cmbYearFrom.SelectedIndex != 0)
            {
                MessageBox.Show("年を選択した場合は月を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbMonthTo.SelectedIndex == 0 & cmbYearTo.SelectedIndex != 0)
            {
                MessageBox.Show("年を選択した場合は月を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //日付逆転チェック
            string yyyyMMfrom = cmbYearFrom.Text + cmbMonthFrom.Text;
            string yyyyMMto = cmbYearTo.Text + cmbMonthTo.Text;
            if (yyyyMMfrom != "" && yyyyMMto != "" && yyyyMMto.Length == 6)
            {
                if (yyyyMMfrom.CompareTo(yyyyMMto) == 1)
                {
                    MessageBox.Show("年月が逆転しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 検索結果
        /// </summary>
        private void Result()
        {
            dgvIchiran.Rows.Clear();

            string yyyyMMfrom = cmbYearFrom.Text + cmbMonthFrom.Text;
            string yyyyMMto = cmbYearTo.Text + cmbMonthTo.Text;

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     INSERT(trn_check_h.SAGYO_YYMM, 5, 0, '/') AS TRN_CHECK_H_SAGYO_YYMM");
            sql.Append("    ,trn_check_h.GYOMU_CD");
            sql.Append("    ,mst_gyomu.NAME");
            sql.Append("    ,trn_check_h.SAGYO_STATUS");
            sql.Append("    ,CASE WHEN trn_check_h.SAGYO_STATUS = '0' THEN '未着手'");
            sql.Append("    WHEN trn_check_h.SAGYO_STATUS = '1' THEN '処理中'");
            sql.Append("    ELSE '完了' END AS SAGYO_STATUS_NAME");
            sql.Append("   ,trn_check_h.SAGYO_LAST_DATE");
            sql.Append("   ,trn_check_h.SAGYO_LAST_USER");
            sql.Append("   ,mst_shain.MST_SHAIN_NAME");
            sql.Append(" FROM trn_check_h");
            sql.Append(" LEFT JOIN mst_gyomu");
            sql.Append("   ON trn_check_h.GYOMU_CD = mst_gyomu.CD");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON trn_check_h.SAGYO_LAST_USER = mst_shain.MST_SHAIN_CODE");
            sql.Append(" WHERE 1=1");
            //開始年月が空白の場合
            if (yyyyMMfrom != "")
            {
                sql.Append(" AND trn_check_h.SAGYO_YYMM >= " + yyyyMMfrom);
            }
            //終了年月が空白の場合
            if (yyyyMMto != "")
            {
                sql.Append(" AND trn_check_h.SAGYO_YYMM <= " + yyyyMMto);
            }
            //業務区分で「すべて」以外が選択されている場合
            if (cmbKbn.Text != "すべて")
            {
                sql.Append(" AND trn_check_h.GYOMU_CD = " + cmbKbn.SelectedValue);
            }
            //「完了済みを含む」にチェックが入っていない場合
            if (chkKanryouzumi.Checked == false)
            {
                sql.Append(" AND trn_check_h.SAGYO_STATUS != 2 ");
            }
            sql.Append(" ORDER BY ");
            sql.Append(" SAGYO_YYMM DESC ");
            sql.Append(" , HYOJI_JUN ");

            DataSet ds = new DataSet();
            //検索結果が返ってこない場合
            if (!comU.CSerch(sql.ToString(), ref ds)) return;

            //検索結果が0件の場合
            if(ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("対象がありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //セルボタン作成
            DataGridViewButtonColumn dgvbtn = new DataGridViewButtonColumn();
            dgvbtn.Name = "業務チェック";
            dgvbtn.HeaderText = "";
            dgvbtn.Text = "業務チェック";
            dgvbtn.UseColumnTextForButtonValue = true;
            dgvbtn.Width = 75;

            DataGridViewButtonColumn dgvbtnSyusei = new DataGridViewButtonColumn();
            dgvbtnSyusei.Name = "業務修正";
            dgvbtnSyusei.HeaderText = "";
            dgvbtnSyusei.Text = "業務修正";
            dgvbtnSyusei.UseColumnTextForButtonValue = true;
            dgvbtnSyusei.Width = 65;

            //一覧に検索結果を表示
            dgvIchiran.Rows.Clear();
            Enumerable.Range(0, ds.Tables[0].Rows.Count).Select(indx => ds.Tables[0].Rows[indx] as DataRow).ToList()
                .ForEach(dr =>
                {
                    dgvIchiran.Rows.Add();
                    int indx = dgvIchiran.Rows.Count - 1;
                    dgvIchiran.Rows[indx].Cells["GYOMU_CHEACK"].Value = dgvbtn.Name;
                    dgvIchiran.Rows[indx].Cells["GYOMU_SYUSEI"].Value = dgvbtnSyusei.Name;
                    dgvIchiran.Rows[indx].Cells["SAGYO_YYMM"].Value = dr["TRN_CHECK_H_SAGYO_YYMM"].ToString();
                    dgvIchiran.Rows[indx].Cells["GYOMU_CD"].Value = dr["GYOMU_CD"].ToString();
                    dgvIchiran.Rows[indx].Cells["GYOMU_NAME"].Value = dr["NAME"].ToString();
                    dgvIchiran.Rows[indx].Cells["SAGYO_STATUS"].Value = dr["SAGYO_STATUS"].ToString();
                    dgvIchiran.Rows[indx].Cells["SAGYO_STATUS_NM"].Value = dr["SAGYO_STATUS_NAME"].ToString();
                    if (!dr["SAGYO_LAST_DATE"].ToString().Equals(""))
                    {
                        dgvIchiran.Rows[indx].Cells["SAGYO_LAST_DATE"].Value = Convert.ToDateTime(dr["SAGYO_LAST_DATE"].ToString()).ToString("yyyy/MM/dd");
                    }
                    dgvIchiran.Rows[indx].Cells["SAGYO_LAST_USER"].Value = dr["MST_SHAIN_NAME"].ToString();
                    //背景色を青色に変更
                    if(indx % 2 == 1)
                    {
                        dgvIchiran.Rows[indx].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    dgvIchiran.Rows[indx].Height = 30;
                });

            //dgvIchiran.DataSource = ds.Tables[0];

            //dgvIchiran.Columns[(int)column.TRN_CHECK_H_SAGYO_YYMM].HeaderText = "年月";
            //dgvIchiran.Columns[(int)column.TRN_CHECK_H_GYOMU_CD].HeaderText = "業務CD";
            //dgvIchiran.Columns[(int)column.MST_GYOMU_GYOMU_NAME].HeaderText = "業務";
            //dgvIchiran.Columns[(int)column.TRN_CHECK_H_SAGYO_STATUS].HeaderText = "完了ST";
            //dgvIchiran.Columns[(int)column.TRN_CHECK_H_SAGYO_STATUS_NM].HeaderText = "進捗";
            //dgvIchiran.Columns[(int)column.TRN_CHECK_H_SAGYO_LAST_DATE].HeaderText = "最終使用日";
            //dgvIchiran.Columns[(int)column.MST_EMPLOYEE_NAME].HeaderText = "最終使用者";

            //dgvIchiran.Columns[1].Visible = false;
            //dgvIchiran.Columns[3].Visible = false;
            //dgvIchiran.Columns[6].Visible = false;

            //dgvIchiran.ColumnHeadersHeight = 30;
            //dgvIchiran.Columns[2].Width = 120;

            ////セルボタン作成
            //DataGridViewButtonColumn dgvbtn = new DataGridViewButtonColumn();
            //dgvbtn.Name = "業務チェック";
            //dgvbtn.HeaderText = "";
            //dgvbtn.Text = "業務チェック";
            //dgvbtn.UseColumnTextForButtonValue = true;
            //dgvbtn.Width = 75;
            //dgvIchiran.Columns.Insert(0, dgvbtn);

            //DataGridViewButtonColumn dgvbtnSyusei = new DataGridViewButtonColumn();
            //dgvbtnSyusei.Name = "業務修正";
            //dgvbtnSyusei.HeaderText = "";
            //dgvbtnSyusei.Text = "業務修正";
            //dgvbtnSyusei.UseColumnTextForButtonValue = true;
            //dgvbtnSyusei.Width = 65;
            //dgvIchiran.Columns.Insert(1, dgvbtnSyusei);

            //for (int i = 0; i < dgvIchiran.RowCount; i++)
            //{
            //    if (i % 2 == 1)
            //    {
            //        dgvbtn.FlatStyle = FlatStyle.Popup;
            //        dgvbtnSyusei.FlatStyle = FlatStyle.Popup;
            //        dgvIchiran.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
            //    }
            //}

            //    if (dgvIchiran.RowCount == 0)
            //{
            //    MessageBox.Show("対象がありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        private void Clear()
        {
            dgvIchiran.Rows.Clear();
            Initialization();
        }
        #endregion

        #region ボタンイベント
        /// <summary>
        /// 検索ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //検索入力チェック
            if (CheckSearch() == true) Result();
            else return;
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// 業務登録画面に遷移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            GC0050 Gc0050 = new GC0050(user);
            Gc0050.ShowDialog();
            //登録された場合、再検索
            if (Gc0050.torokuFlg) Result();
        }

        /// <summary>
        /// メニュー画面に戻る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
