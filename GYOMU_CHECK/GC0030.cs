using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GYOMU_CHECK
{
    public partial class GC0030 : Form
    {
        CommonUtil comU = new CommonUtil();
        DateTime dt = System.DateTime.Now;
        private User user;

        public enum column
        {
            TRN_CHECK_H_SAGYO_YYMM,
            TRN_CHECK_H_GYOMU_CD,
            MST_GYOMU_GYOMU_NAME,
            TRN_CHECK_H_SAGYO_STATUS,
            TRN_CHECK_H_SAGYO_STATUS_NM,
            TRN_CHECK_H_SAGYO_LAST_DATE,
            TRN_CHECK_H_SAGYO_LAST_USER,
            MST_EMPLOYEE_NAME
        }

        public GC0030(User user)
        {
            this.user = user;
            InitializeComponent();

        }

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
        /// 検索ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Check() == true)
            {
                Result();
            }
            else
            {
                return;
            }
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
        /// チェックリスト一覧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIchiran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "業務チェック" || dgv.Columns[e.ColumnIndex].Name == "業務修正")
            {
                string yyyyMM = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                string Cd = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                string state = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                string Nm = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (dgv.Columns[e.ColumnIndex].Name == "業務チェック")
                {
                    GC0040 Gc0040 = new GC0040(user, yyyyMM, Cd, Nm);
                    Gc0040.ShowDialog();
                    Result();
                }
                else if (dgv.Columns[e.ColumnIndex].Name == "業務修正")
                {
                    GC0050 Gc0050 = new GC0050(user, yyyyMM, Cd, state);
                    Gc0050.ShowDialog();
                    if (Gc0050.torokuFlg)
                    {
                        Result();
                    }
                }
                if (e.RowIndex < 0)
                {
                    return;
                }
            }
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
            if (Gc0050.torokuFlg)
            {
                Result();
            }

        }

        /// <summary>
        /// メニュー画面に戻る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialization()
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
            if (!comU.CGyomu(ref dataSet, true))
            {
                this.Close();
                return;
            }
            // コンボボックスにデータテーブルをセット
            this.cmbKbn.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            this.cmbKbn.DisplayMember = "NAME";
            //// データ用の列を設定
            this.cmbKbn.ValueMember = "CD";

            //完了済みチェック
            chkKanryouzumi.Checked = false;

        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        public bool Check()
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
        public void Result()
        {
            dgvIchiran.Columns.Clear();

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
            sql.Append("    ELSE '完了' END");
            sql.Append("   ,trn_check_h.SAGYO_LAST_DATE");
            sql.Append("   ,trn_check_h.SAGYO_LAST_USER");
            sql.Append("   ,mst_shain.MST_SHAIN_NAME");
            sql.Append(" FROM trn_check_h");
            sql.Append(" LEFT JOIN mst_gyomu");
            sql.Append("   ON trn_check_h.GYOMU_CD = mst_gyomu.CD");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON trn_check_h.SAGYO_LAST_USER = mst_shain.MST_SHAIN_CODE");
            sql.Append(" WHERE 1=1");
            if (yyyyMMfrom != "")
            {
                sql.Append(" AND trn_check_h.SAGYO_YYMM >= " + yyyyMMfrom);
            }
            if (yyyyMMto != "")
            {
                sql.Append(" AND trn_check_h.SAGYO_YYMM <= " + yyyyMMto);
            }
            if (cmbKbn.Text != "すべて")
            {
                sql.Append(" AND trn_check_h.GYOMU_CD = " + cmbKbn.SelectedValue);
            }
            if (chkKanryouzumi.Checked == false)
            {
                sql.Append(" AND trn_check_h.SAGYO_STATUS != 2 ");
            }
            sql.Append(" ORDER BY ");
            sql.Append(" SAGYO_YYMM DESC ");
            sql.Append(" , HYOJI_JUN ");

            DataSet ds = new DataSet();
            if (!comU.CSerch(sql.ToString(), ref ds))
            {
                return;
            }

            dgvIchiran.DataSource = ds.Tables[0];

            dgvIchiran.Columns[(int)column.TRN_CHECK_H_SAGYO_YYMM].HeaderText = "年月";
            dgvIchiran.Columns[(int)column.TRN_CHECK_H_GYOMU_CD].HeaderText = "業務CD";
            dgvIchiran.Columns[(int)column.MST_GYOMU_GYOMU_NAME].HeaderText = "業務";
            dgvIchiran.Columns[(int)column.TRN_CHECK_H_SAGYO_STATUS].HeaderText = "完了ST";
            dgvIchiran.Columns[(int)column.TRN_CHECK_H_SAGYO_STATUS_NM].HeaderText = "進捗";
            dgvIchiran.Columns[(int)column.TRN_CHECK_H_SAGYO_LAST_DATE].HeaderText = "最終使用日";
            dgvIchiran.Columns[(int)column.MST_EMPLOYEE_NAME].HeaderText = "最終使用者";

            dgvIchiran.Columns[1].Visible = false;
            dgvIchiran.Columns[3].Visible = false;
            dgvIchiran.Columns[6].Visible = false;

            dgvIchiran.ColumnHeadersHeight = 30;
            dgvIchiran.Columns[2].Width = 120;

            //セルボタン作成
            DataGridViewButtonColumn dgvbtn = new DataGridViewButtonColumn();
            dgvbtn.Name = "業務チェック";
            dgvbtn.HeaderText = "";
            dgvbtn.Text = "業務チェック";
            dgvbtn.UseColumnTextForButtonValue = true;
            dgvbtn.Width = 75;
            dgvIchiran.Columns.Insert(0, dgvbtn);

            DataGridViewButtonColumn dgvbtnSyusei = new DataGridViewButtonColumn();
            dgvbtnSyusei.Name = "業務修正";
            dgvbtnSyusei.HeaderText = "";
            dgvbtnSyusei.Text = "業務修正";
            dgvbtnSyusei.UseColumnTextForButtonValue = true;
            dgvbtnSyusei.Width = 65;
            dgvIchiran.Columns.Insert(1, dgvbtnSyusei);

            for (int i = 0; i < dgvIchiran.RowCount; i++)
            {
                if (i % 2 == 1)
                {
                    dgvbtn.FlatStyle = FlatStyle.Popup;
                    dgvbtnSyusei.FlatStyle = FlatStyle.Popup;
                    dgvIchiran.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }

                if (dgvIchiran.RowCount == 0)
            {
                MessageBox.Show("対象がありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        public void Clear()
        {
            dgvIchiran.Columns.Clear();
            Initialization();
        }
    }
}
