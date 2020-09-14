using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYOMU_CHECK
{
    class CommonUtil
    {
        /// <summary>
        /// 検索結果を返す
        /// </summary>
        /// <param name="sql">SQL文</param>
        /// <returns>DataSet</returns>
        public bool CSerch(string sql, ref DataSet ds)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;

            // データベース接続の準備
            var connection = new MySqlConnection(connectionString);
            try
            {

                // データベースの接続開始
                connection.Open();
            }
            catch
            {

                MessageBox.Show("DBの接続に失敗しました。", "エラー");
                return false;
            }

            // 実行するSQLの準備
            var command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = sql;

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            try
            {
                adapter.Fill(dt);

                command.Dispose();

                connection.Close();
                connection.Dispose();

                ds.Tables.Add(dt);

                return true;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString(), "エラー");
                MessageBox.Show("テーブルの取得に失敗しました。", "エラー");
                return false;
            }
        }


        /// <summary>
        /// 登録・削除可能か判定
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool CExecute(ref MySqlTransaction transaction, ref MySqlCommand command, string sql)
        {

            try
            {
                command.CommandText = sql;

                // 実行
                command.ExecuteNonQuery();

                return true;

            }
            catch (MySqlException me)
            {
                // クローズ
                transaction.Rollback();
                command.Connection.Close();
                return false;
            }

        }

        /// <summary>
        /// 登録・削除可能か判定
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool CConnect(ref MySqlTransaction transaction, ref MySqlCommand command)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
            try
            {
                // データベース接続の準備
                var connection = new MySqlConnection(connectionString);

                // 実行するSQLの準備
                command.Connection = connection;

                // オープン
                command.Connection.Open();

                // コマンドオブジェクトにコネクションを設定します。
                // トランザクションを使用する場合、設定しないと例外が発生します。
                command.Connection = connection;

                // トランザクションを開始します。
                transaction = connection.BeginTransaction();

                return true;

            }
            catch (MySqlException me)
            {
                // クローズ
                transaction.Rollback();
                command.Connection.Close();
                MessageBox.Show("DB接続に失敗しました。", "エラー");
                return false;
            }

        }

        /// <summary>
        /// 時間を取得
        /// </summary>
        /// <returns></returns>
        public List<int> CHour()
        {
            List<int> listHour = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                listHour.Add(i);
            }

            return listHour;
        }

        /// <summary>
        /// 分を取得
        /// </summary>
        /// <returns></returns>
        public List<int> CMinute()
        {
            List<int> listMinute = new List<int>();
            for (int i = 0; i < 60; i++)
            {
                listMinute.Add(i);
            }

            return listMinute;
        }

        /// <summary>
        /// 年を取得
        /// </summary>
        /// <returns></returns>
        public List<string> CYear(bool brankFlg)
        {
            List<string> listYear = new List<string>();
            DateTime dt = System.DateTime.Now;
            string str;
            for (int i = dt.Year - 10; i <= dt.Year + 1; i++)
            {
                str = Convert.ToString(i);
                listYear.Add(str);
            }
            if (brankFlg)
            {
                listYear.Insert(0, "");
            }
            return listYear;
        }

        /// <summary>
        /// 月を取得
        /// </summary>
        /// <returns></returns>
        public List<string> CMonth(bool brankFlg)
        {
            List<string> listMonth = new List<string>();
            string str;
            for (int i = 1; i < 13; i++)
            {
                if (i < 10)
                {
                    str = Convert.ToString(i).PadLeft(2, '0');
                }
                else
                {
                    str = Convert.ToString(i);
                }
                listMonth.Add(str);
            }
            if (brankFlg)
            {
                listMonth.Insert(0, "");
            }
            return listMonth;
        }

        /// <summary>
        /// 業務コンボボックス設定
        /// </summary>
        /// <returns></returns>
        public bool CGyomu(ref DataSet ds, bool allFlg)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT ");
                sql.Append("     CD");
                sql.Append("    ,NAME");
                sql.Append(" FROM mst_gyomu");
                sql.Append(" WHERE ");
                sql.Append(" DEL_FLG = 0 ");
                sql.Append(" ORDER BY ");
                sql.Append(" HYOJI_JUN ");
                var connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;

                // データベース接続の準備
                var connection = new MySqlConnection(connectionString);

                // データベースの接続開始
                connection.Open();

                // 実行するSQLの準備
                var command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = sql.ToString();

                DataTable dt = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                adapter.Fill(dt);

                command.Dispose();

                connection.Close();
                connection.Dispose();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("業務マスタが登録されていません。\n\r業務マスタの登録を行ってください。", "エラー");
                    return false;
                }

                if (allFlg)
                {

                    DataRow row = dt.NewRow();
                    row["CD"] = "0";
                    row["NAME"] = "すべて";
                    dt.Rows.InsertAt(row, 0);
                }

                ds.Tables.Add(dt);

                return true;

            }
            catch (MySqlException me)
            {
                MessageBox.Show("DBの接続に失敗しました。", "エラー");
                return false;
            }
        }


        /// <summary>
        /// 作業コンボボックス設定
        /// </summary>
        /// <returns></returns>
        public bool CSagyo(ref DataSet ds, string gyomuCd)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT ");
                sql.Append("     CD");
                sql.Append("    ,NAME");
                sql.Append(" FROM mst_SAGYO");
                sql.Append(" WHERE ");
                sql.Append(" DEL_FLG = 0 ");
                sql.Append(" AND ");
                sql.Append($" GYOMU_CD = {gyomuCd} ");
                sql.Append(" ORDER BY ");
                sql.Append(" HYOJI_JUN ");
                var connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;

                // データベース接続の準備
                var connection = new MySqlConnection(connectionString);

                // データベースの接続開始
                connection.Open();

                // 実行するSQLの準備
                var command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = sql.ToString();

                DataTable dt = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                adapter.Fill(dt);

                command.Dispose();

                connection.Close();
                connection.Dispose();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("作業マスタが登録されていません。\n\r作業マスタの登録を行ってください。", "エラー");
                    return false;
                }


                ds.Tables.Add(dt);

                return true;

            }
            catch (MySqlException me)
            {
                MessageBox.Show("DBの接続に失敗しました。", "エラー");
                return false;
            }
        }




        /// <summary>
        /// 文字列を'でくくる
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string CAddQuotation(string str)
        {
            return "'" + str + "'";
        }

        /// <summary>
        /// 文字列の/を削除
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string CReplace(string str)
        {
            return str.Replace("/", "");
        }

        /// <summary>
        /// 排他登録
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="command"></param>
        /// <param name="yyyyMM"></param>
        /// <param name="kbn"></param>
        /// <param name="id"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        public bool InsertHaitaTrn(MySqlTransaction transaction, ref MySqlCommand command, string yyyyMM, string kbn, string id, string pId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     *");
            sql.Append(" FROM TRN_HAITA");
            sql.Append($" WHERE GYOMU_CD = {kbn}");
            sql.Append($" AND SAGYO_YYMM = {yyyyMM}");
            DataSet ds = new DataSet();
            if (!CSerch(sql.ToString(), ref ds))
            {
                return false;
            }

            if (ds.Tables["Table1"].Rows.Count != 0)
            {
                MessageBox.Show("他のユーザーが編集中です。", "エラー");
                return false;
            }
            sql = new StringBuilder();
            sql.Append(" INSERT INTO TRN_HAITA ");
            sql.Append("    (GYOMU_CD ");
            sql.Append("    ,SAGYO_YYMM ");
            sql.Append("    ,USER ");
            sql.Append("    ,INS_DT ");
            sql.Append("    ,INS_USER ");
            sql.Append("    ,INS_PGM ");
            sql.Append("    ,UPD_DT ");
            sql.Append("    ,UPD_USER ");
            sql.Append("    ,UPD_PGM) ");
            sql.Append(" VALUES ");
            sql.Append($"    ({CAddQuotation(kbn)} ");
            sql.Append($"    ,{yyyyMM} ");
            sql.Append($"    ,{id} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{id} ");
            sql.Append($"    ,{CAddQuotation(pId)} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{id} ");
            sql.Append($"    ,{CAddQuotation(pId)}) ");

            if (!CExecute(ref transaction, ref command, sql.ToString()))
            {
                MessageBox.Show("他のユーザーが編集中です。", "エラー");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 削除排他
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="command"></param>
        /// <param name="yyyyMM"></param>
        /// <param name="kbn"></param>
        /// <returns></returns>
        public bool DeleteHaitaTrn(MySqlTransaction transaction, ref MySqlCommand command, string yyyyMM, string kbn)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM TRN_HAITA ");
            sql.Append($" WHERE GYOMU_CD = {kbn}");
            sql.Append($" AND SAGYO_YYMM = {yyyyMM}");
            if (!CExecute(ref transaction, ref command, sql.ToString()))
            {
                MessageBox.Show("排他テーブルの削除に失敗しました。", "エラー");
                return false;
            }
            return true;
        }

        /// <summary>
        /// ユーザー排他削除
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="command"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool DeleteHaitaUser(MySqlTransaction transaction, ref MySqlCommand command, string user)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM TRN_HAITA ");
            sql.Append($" WHERE USER = {CAddQuotation(user)}");
            if (!CExecute(ref transaction, ref command, sql.ToString()))
            {
                MessageBox.Show("排他テーブルの削除に失敗しました。", "エラー");
                return false;
            }
            return true;
        }

        /// <summary>
        /// パスワードハッシュ化
        /// </summary>
        /// <param name="password"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetHashedPassword(string passwd)
        {
            // パスワードをUTF-8エンコードでバイト配列として取り出す
            byte[] byteValues = Encoding.UTF8.GetBytes(passwd);

            // SHA256のハッシュ値を計算する
            SHA256 crypto256 = new SHA256CryptoServiceProvider();
            byte[] hash256Value = crypto256.ComputeHash(byteValues);

            // SHA256の計算結果をUTF8で文字列として取り出す
            StringBuilder buf = new StringBuilder();
            for (int i = 0; i < hash256Value.Length; i++)
            {
                // 16進の数値を文字列として取り出す
                buf.AppendFormat("{0:X2}", hash256Value[i]);
            }
            return buf.ToString();

        }
    }
}
