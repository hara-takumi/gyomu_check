using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GYOMU_CHECK
{
    public partial class MS0010 : Form
    {
        private User user;
        CommonUtil comU = new CommonUtil();
        MySqlCommand command = new MySqlCommand();
        MySqlTransaction transaction = null;
        string programId = "MS0010";
        private int passNumber = 3;
        public MS0010(User user)
        {
            InitializeComponent();
            this.user = user;
            txtOldPass.PasswordChar = '●';
            txtNewPass.PasswordChar = '●';
            txtNewPass2.PasswordChar = '●';
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!CheckUpdate())
            {
                return;
            }
            Update();
        }
        private void Update()
        {
            DialogResult result = MessageBox.Show("変更を行います。よろしいでしょうか。？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                if (!comU.CConnect(ref transaction, ref command))
                {
                    return;
                }

                if (!UpdatePasswordMst(transaction))
                {

                    MessageBox.Show("パスワードマスタの更新に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                transaction.Commit();
                MessageBox.Show("変更が完了しました。", "");
                this.Close();

            }
        }

        private bool UpdatePasswordMst(MySqlTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" INSERT INTO mst_shainpw ");
            sql.Append("    (MST_SHAINPW_CODE ");
            sql.Append("    ,MST_SHAINPW_GENERAITON ");
            sql.Append("    ,MST_SHAINPW_PASSWORD ");
            sql.Append("    ,MST_SHAINPW_INS_DT ");
            sql.Append("    ,MST_SHAINPW_INS_USER ");
            sql.Append("    ,MST_SHAINPW_INS_PGM ");
            sql.Append("    ,MST_SHAINPW_UPD_DT ");
            sql.Append("    ,MST_SHAINPW_UPD_USER ");
            sql.Append("    ,MST_SHAINPW_UPD_PGM) ");
            sql.Append(" SELECT  ");
            sql.Append($"     {user.Id} ");
            sql.Append("    ,MAX(MST_SHAINPW_GENERAITON) + 1 ");
            sql.Append($"    ,{comU.GetHashedPassword(txtNewPass.Text)})");
            sql.Append("    ,now() ");
            sql.Append($"    ,{user.Id} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{user.Id} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)} ");
            sql.Append("FROM mst_shainpw");

            if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
            {
                return false;
            }
            return true;
        }

        private bool CheckUpdate()
        {
            if(string.IsNullOrEmpty(txtOldPass.Text.ToString())|| string.IsNullOrEmpty(txtNewPass.Text.ToString())|| string.IsNullOrEmpty(txtNewPass2.Text.ToString()))
            {
                MessageBox.Show("すべて入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNewPass.Text.Length < 10 || txtNewPass2.Text.Length < 10 || txtOldPass.Text.Length < 10)
            {
                MessageBox.Show("パスワードは10文字以上で入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!txtNewPass.Text.Equals(txtNewPass2.Text))
            {
                MessageBox.Show("新パスワードと確認パスワードが一致していません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPass2.Focus();
                return false;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MST_SHAINPW_PASSWORD");
            sql.Append(" FROM mst_shain");
            sql.Append(" LEFT JOIN mst_shainpw");
            sql.Append("   ON MST_SHAIN_CODE = MST_SHAINPW_CODE");
            sql.Append($" WHERE MST_SHAIN_CODE = {user.Id}");
            sql.Append($" AND MST_SHAINPW_GENERAITON = (select MAX(MST_SHAINPW_GENERAITON) from mst_shainpw WHERE MST_SHAINPW_CODE = {user.Id})");

            DataSet ds = new DataSet();
            if (!comU.CSerch(sql.ToString(), ref ds))
            {
                return false;
            }

            if (ds.Tables["Table1"].Rows.Count == 0)
            {

                MessageBox.Show("旧パスワードが間違っています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPass.Focus();
                return false;
            }
            for (int i = 0; i < ds.Tables["Table1"].Rows.Count; i++)
            {
                if (ds.Tables["Table1"].Rows[i]["MST_SHAINPW_PASSWORD"].ToString().Equals(comU.GetHashedPassword(txtOldPass.Text)))
                {
                    //過去に登録されたパスワードかチェック
                    return CheckTorokuPass();
                }
            }

            MessageBox.Show("旧パスワードが間違っています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtOldPass.Focus();
            return false;


        }
        private bool CheckTorokuPass()
        {
            //過去3回使用されていないか
            StringBuilder sqlPass = new StringBuilder();
            sqlPass.Append(" SELECT ");
            sqlPass.Append("     MST_SHAINPW_PASSWORD");
            sqlPass.Append(" FROM mst_shain");
            sqlPass.Append(" LEFT JOIN mst_shainpw");
            sqlPass.Append("   ON MST_SHAIN_CODE = MST_SHAINPW_CODE");
            sqlPass.Append($" WHERE MST_SHAIN_CODE = {user.Id}");
            sqlPass.Append($" AND MST_SHAINPW_GENERAITON > (select MAX(MST_SHAINPW_GENERAITON) from mst_shainpw WHERE MST_SHAINPW_CODE = {user.Id}) -{passNumber}");

            DataSet dsPass = new DataSet();
            if (!comU.CSerch(sqlPass.ToString(), ref dsPass))
            {
                return false;
            }

            for (int i = 0; i < dsPass.Tables["Table1"].Rows.Count; i++)
            {
                if (dsPass.Tables["Table1"].Rows[i]["MST_SHAINPW_PASSWORD"].ToString().Equals(comU.GetHashedPassword(txtNewPass.Text)))
                {
                    MessageBox.Show("過去に使用されたパスワードです。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void btnReturn_Click_1(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
