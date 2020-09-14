using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GYOMU_CHECK
{
    public partial class GC0010 : Form
    {
        #region メンバー変数
        private readonly CommonUtil comU = new CommonUtil();
        MySqlCommand command = new MySqlCommand();
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GC0010()
        {
            InitializeComponent();

            txtUserCd.Text = "1111";
            txtPw.Text = "6666666666";
        }
        #endregion

        #region イベント処理
        /// <summary>
        /// ✕ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GC0010_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region ボタンイベント
        /// <summary>
        /// ログインボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //ユーザーCDが空白の場合
            if (string.IsNullOrEmpty(txtUserCd.Text))
            {
                MessageBox.Show("ユーザーCDを入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserCd.Focus();
                return;
            }
            //パスワードが空白の場合
            else if (string.IsNullOrEmpty(txtPw.Text))
            {
                MessageBox.Show("パスワードを入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPw.Focus();
                return;
            }
            //ユーザーCDとパスワードが入力されている場合
            else
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT ");
                sql.Append("     MST_SHAIN_CODE");
                sql.Append("    ,MST_SHAIN_NAME");
                sql.Append("    ,MST_SHAIN_SHOZOKU_CD");
                sql.Append("    ,MST_SHAINPW_PASSWORD");
                sql.Append(" FROM mst_shain");
                sql.Append(" LEFT JOIN mst_shainpw");
                sql.Append("   ON MST_SHAIN_CODE = MST_SHAINPW_CODE");
                sql.Append($" WHERE MST_SHAIN_CODE = {comU.CAddQuotation(txtUserCd.Text)}");
                sql.Append(" AND MST_SHAIN_TEKIYO_DATE_STR <= CURDATE()");
                sql.Append(" AND MST_SHAIN_TEKIYO_DATE_END >= CURDATE()");
                sql.Append($" AND MST_SHAINPW_GENERAITON = (select MAX(MST_SHAINPW_GENERAITON) from mst_shainpw WHERE MST_SHAINPW_CODE = {comU.CAddQuotation(txtUserCd.Text)})");

                DataSet ds = new DataSet();
                //検索結果が返ってこない場合
                if (!comU.CSerch(sql.ToString(), ref ds))
                {
                    return;
                }
                //取得データが0件以上の場合
                if (ds.Tables[0].Rows.Count != 0)
                {
                    string id = "";
                    string name = "";
                    string kengen = "";
                    string hash = comU.GetHashedPassword(txtPw.Text);
                    Enumerable.Range(0, ds.Tables[0].Rows.Count).Select(idx => ds.Tables[0].Rows[idx] as DataRow)
                        .Where(dr => dr["MST_SHAIN_CODE"].ToString().Equals(txtUserCd.Text) 
                        && dr["MST_SHAINPW_PASSWORD"].ToString().Equals(hash)).ToList()
                        .ForEach(dr =>
                        {
                            id = dr["MST_SHAIN_CODE"].ToString();
                            name = dr["MST_SHAIN_NAME"].ToString();
                            kengen = dr["MST_SHAIN_SHOZOKU_CD"].ToString();
                        });
                    User user = new User(id, name, kengen);

                    MySqlTransaction transaction = null;
                    //データベースに接続できない場合
                    if (!comU.CConnect(ref transaction, ref command)) return;

                    //排他テーブルの削除に失敗した場合
                    if (!comU.DeleteHaitaUser(transaction, ref command, id)) return;

                    transaction.Commit();

                    GC0020 frm = new GC0020(user);
                    frm.Show();
                    Hide();
                    return;

                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    //string hash = comU.GetHashedPassword(txtPw.Text);
                    //    if (ds.Tables[0].Rows[i]["MST_SHAINPW_PASSWORD"].ToString().Equals(hash))
                    //    {
                    //        string id = ds.Tables[0].Rows[i]["MST_SHAIN_CODE"].ToString();
                    //        string name = ds.Tables[0].Rows[i]["MST_SHAIN_NAME"].ToString();
                    //        string kengen = ds.Tables[0].Rows[i]["MST_SHAIN_SHOZOKU_CD"].ToString();
                    //        User user = new User(id, name, kengen);

                    //        MySqlTransaction transaction = null;
                    //        if (!comU.CConnect(ref transaction, ref command))
                    //        {
                    //            return;
                    //        }
                    //        if (!comU.DeleteHaitaUser(transaction, ref command, id))
                    //        {

                    //            return;
                    //        }
                    //        transaction.Commit();

                    //        GC0020 frm = new GC0020(user);
                    //        frm.Show();
                    //        this.Hide();
                    //        return;
                    //    }
                    //}

                }
                MessageBox.Show("ユーザーCDまたはパスワードが正しくありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
