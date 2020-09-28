using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GYOMU_CHECK
{
    public partial class MS0020 : Form
    {
        #region メンバー変数
        MySqlCommand command = new MySqlCommand();
        private readonly CommonUtil comU = new CommonUtil();
        private readonly DateTime dt = DateTime.Now;
        private readonly User user;
        bool changeFlg = false;
        private readonly List<Holiday> torokuList = new List<Holiday>();
        #endregion

        #region 定数
        const string programId = "MS0020";
        const string nationalHoliday = "1";
        const string companyHoliday = "2";
        const string insertStatus = "0";
        const string updateStatus = "1";
        const string deleteStatus = "2";
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="user"></param>
        public MS0020(User user)
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
        private void MS0020_Load(object sender, EventArgs e)
        {
            //コンボボックス設定(年月)
            cmbYearFrom.DataSource = comU.CYear(true).ToArray();
            cmbYearFrom.Text = dt.ToString("yyyy");
        }

        /// <summary>
        /// ✕ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MS0020_FormClosing(object sender, FormClosingEventArgs e)
        {
            //変更されている場合
            if (changeFlg)
            {
                DialogResult result = MessageBox.Show("内容が変更されています。\n\r変更は破棄されますが、よろしいですか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    changeFlg = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// セル変更時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCalender1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string year = cmbYearFrom.Text;
            string oldDate;

            Enumerable.Range(1, 12).ToList()
                .ForEach(row => 
                {
                    Control[] cs = Controls.Find("dgvCalender" + row.ToString(), true);

                    DataGridView dgv = (DataGridView)cs[0];

                    string currentDay = dgv[e.ColumnIndex, e.RowIndex - 1].Value.ToString();
                    string currentMonth = String.Format("{0:D2}", Convert.ToInt32(tabControl1.SelectedIndex) + 1);
                    string currentDate = year + currentMonth + String.Format("{0:D2}", Convert.ToInt32(currentDay));
                    oldDate = currentDate;
                    //選択セルがnull以外の場合
                    if (dgv[e.ColumnIndex, e.RowIndex].Value != null)
                    {
                        string currentCellName = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
                        if (dgv[e.ColumnIndex, e.RowIndex].ReadOnly == false)
                        {
                            if (torokuList.Count != 0)
                            {
                                torokuList.Where(listHoliday => torokuList.Count >= 1).ToList().ForEach(listHoliday =>
                                {
                                    if (oldDate.Equals(listHoliday.Date))
                                    {
                                        Holiday holiday = new Holiday(currentCellName, currentDate, listHoliday.kbn, "1");
                                        torokuList.Add(holiday);
                                    }
                                });


                                //foreach (Holiday listHoliday in torokuList)
                                //{
                                //    //登録されているデータと選択セルのデータが一致する場合
                                //    if (oldDate.Equals(listHoliday.Date))
                                //    {
                                //        Holiday holiday = new Holiday(currentCellName, currentDate, listHoliday.kbn, updateStatus);
                                //        torokuList.Add(holiday);
                                //        break;
                                //    }
                                //}
                            }
                            else
                            {
                                Holiday holiday = new Holiday(currentCellName, currentDate, companyHoliday, updateStatus);
                                torokuList.Add(holiday);
                            }
                            //torokuList.Add(holiday);
                            changeFlg = true;
                        }
                    }
                    else
                    {
                        //選択セルが編集可能な場合
                        if (dgv[e.ColumnIndex, e.RowIndex].ReadOnly == false)
                        {
                            //登録件数が1件以上ある場合
                            if (torokuList.Count != 0)
                            {
                                torokuList.Where(listHoliday => torokuList.Count >= 1).ToList()
                                .ForEach(listHoliday => 
                                {
                                    Holiday holiday = new Holiday("", currentDate, listHoliday.kbn, updateStatus);
                                    torokuList.Add(holiday);
                                });

                                //foreach (Holiday listHoliday in torokuList)
                                //{
                                //    //登録されているデータと選択セルのデータが一致する場合
                                //    if (oldDate.Equals(listHoliday.Date))
                                //    {
                                //        Holiday holiday = new Holiday("", currentDate, listHoliday.kbn, updateStatus);
                                //        torokuList.Add(holiday);
                                //    }
                                //    break;
                                //}
                            }
                            else
                            {
                                //選択セルがnullの場合
                                if (dgv[e.ColumnIndex, e.RowIndex].Value == null)
                                {
                                    Holiday holiday = new Holiday("", currentDate, companyHoliday, updateStatus);
                                    torokuList.Add(holiday);
                                }
                                else
                                {
                                    Holiday holiday = new Holiday("", currentDate, companyHoliday, insertStatus);
                                    torokuList.Add(holiday);
                                }
                            }

                            changeFlg = true;
                        }
                    }
                });

            //for (int m = 1; m < 13; m++)
            //{
            //    Control[] cs = Controls.Find("dgvCalender" + m.ToString(), true);

            //    DataGridView dgv = (DataGridView)cs[0];

            //    string currentDay = dgv[e.ColumnIndex, e.RowIndex - 1].Value.ToString();
            //    string tab = String.Format("{0:D2}", Convert.ToInt32(tabControl1.SelectedIndex) + 1);
            //    string currentDate = year + tab + String.Format("{0:D2}", Convert.ToInt32(currentDay));
            //    old = currentDate;
            //    if (dgv[e.ColumnIndex, e.RowIndex].Value != null)
            //    {
            //        string currentCellName = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            //        if (dgv[e.ColumnIndex, e.RowIndex].ReadOnly == false)
            //        {
            //            if (torokuList.Count != 0)
            //            {
            //                foreach (Holiday listHoliday in torokuList)
            //                {
            //                    if (old.Equals(listHoliday.Date))
            //                    {
            //                        Holiday holiday = new Holiday(currentCellName, currentDate, listHoliday.kbn, "1");
            //                        torokuList.Add(holiday);
            //                        break;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                Holiday holiday = new Holiday(currentCellName, currentDate, "2", "1");
            //                torokuList.Add(holiday);
            //            }

            //            changeFlg = true;
            //        }
            //    }
            //    else
            //    {
            //        if (dgv[e.ColumnIndex, e.RowIndex].ReadOnly == false)
            //        {
            //            if (torokuList.Count != 0)
            //            {
            //                foreach (Holiday listHoliday in torokuList)
            //                {
            //                    if (old.Equals(listHoliday.Date))
            //                    {
            //                        Holiday holiday = new Holiday("", currentDate, listHoliday.kbn, "1");
            //                        torokuList.Add(holiday);
            //                    }
            //                    break;
            //                }
            //            }
            //            else
            //            {
            //                if (dgv[e.ColumnIndex, e.RowIndex].Value == null)
            //                {
            //                    Holiday holiday = new Holiday("", currentDate, "2", "1");
            //                    torokuList.Add(holiday);
            //                }
            //                else
            //                {
            //                    Holiday holiday = new Holiday("", currentDate, "2", "0");
            //                    torokuList.Add(holiday);
            //                }
            //            }

            //            changeFlg = true;
            //        }
            //    }
            //}
        }

        /// <summary>
        /// タブ変更時にカレントセル変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enumerable.Range(1, 12).ToList()
                .ForEach(row => 
                {
                    Control[] cs = Controls.Find("dgvCalender" + row.ToString(), true);

                    DataGridView dgv = (DataGridView)cs[0];

                    dgv.CurrentCell = null;
                });

            //for (int m = 1; m < 13; m++)
            //{
            //    Control[] cs = Controls.Find("dgvCalender" + m.ToString(), true);

            //    DataGridView dgv = (DataGridView)cs[0];

            //    dgv.CurrentCell = null;
            //}
        }
        #endregion

        #region メソッド
        /// <summary>
        /// カレンダー作成
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        private void CreateCalendar()
        {
            //コンボで選択した年
            int year = Convert.ToInt32(cmbYearFrom.Text);

            Holiday[] dateHoliday = GetHoliday(Convert.ToString(year));

            Enumerable.Range(1, 12).ToList()
                .ForEach(month => 
                {
                    //年月の設定
                    DateTime ymd = new DateTime(year, month, 1);
                    DateTime preYmd = ymd.AddMonths(-1);

                    //月の最終日取得(28~31)
                    int finalDay = DateTime.DaysInMonth(ymd.Year, ymd.Month);
                    int prefinalDay = DateTime.DaysInMonth(preYmd.Year, preYmd.Month);

                    DayOfWeek week = ymd.DayOfWeek; //曜日取得
                    int start = (int)ymd.DayOfWeek; //曜日をint型にキャストする。土曜なら「6」、日曜なら「0」
                    int cellIndex = start; //セル位置
                    int rowCount = 0; //行位置

                    int frstDay = 1; //日付の最初

                    Control[] cs = Controls.Find("dgvCalender" + month.ToString(), true);

                    DataGridView dgv = (DataGridView)cs[0];

                    dgv.Rows.Clear();

                    //rowとcell作成
                    Enumerable.Range(0, 6).ToList()
                    .ForEach(cell => 
                    {
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.Height = 20;
                        newRow.ReadOnly = true;
                        newRow.DefaultCellStyle.Font = new Font("Meiryo UI", 12);
                        newRow.CreateCells(dgv);
                        dgv.Rows.Add(newRow);

                        DataGridViewRow newText = new DataGridViewRow();
                        newText.Height = 50;
                        newText.ReadOnly = true;
                        newText.CreateCells(dgv);
                        dgv.Rows.Add(newText);
                    });

                    //前月31日~で埋める
                    Enumerable.Range(0, start).ToList()
                    .ForEach(beforeday =>
                    {
                        dgv.Rows[rowCount].Cells[beforeday].Value = prefinalDay - start + 1;
                        dgv.Rows[rowCount].Cells[beforeday].Style.Font = new Font("Meiryo UI", 11);
                        dgv.Rows[rowCount].Cells[beforeday].Style.ForeColor = Color.LightGray;
                        prefinalDay++;
                    });

                    //月初から月末まで
                    Enumerable.Range(0, finalDay).ToList()
                    .ForEach(day =>
                    {
                        if (day + 1 != 1)
                        {
                            dgv.Rows[rowCount].Cells[cellIndex].Value = day + 1;
                        }
                        //1日の位置
                        else
                        {
                            dgv.Rows[0].Cells[start].Value = day + 1;
                        }

                        //現在のセルの日付
                        DateTime tmp = new DateTime(year, month, day + 1);

                        //折り返し表示
                        dgv.Rows[rowCount + 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                        //祝日を編集不可
                        List<Holiday> listHoliday = dateHoliday.AsEnumerable().ToList();

                        listHoliday.ForEach(holiday => 
                        {
                            //現在の日付と取得日付が一致する場合
                            if (tmp.ToString() == holiday.Date)
                            {
                                //取得日付区分が国民の祝日の場合
                                if (holiday.kbn.Equals(nationalHoliday))
                                {
                                    dgv.Rows[rowCount + 1].Cells[cellIndex].ReadOnly = true;
                                }
                                else
                                {
                                    dgv.Rows[rowCount + 1].Cells[cellIndex].ReadOnly = false;
                                }
                                dgv.Rows[rowCount + 1].Cells[cellIndex].Value = holiday.Name;
                                dgv.Rows[rowCount].Cells[cellIndex].Style.ForeColor = Color.Red;
                            }
                        });

                        //foreach (Holiday listHoliday in dateHoliday)
                        //{
                        //    //現在の日付と取得日付が一致する場合
                        //    if (tmp.ToString() == listHoliday.Date)
                        //    {
                        //        //取得日付区分が国民の祝日の場合
                        //        if (listHoliday.kbn.Equals(nationalHoliday))
                        //        {
                        //            dgv.Rows[rowCount + 1].Cells[cellIndex].ReadOnly = true;
                        //        }
                        //        else
                        //        {
                        //            dgv.Rows[rowCount + 1].Cells[cellIndex].ReadOnly = false;
                        //        }
                        //        dgv.Rows[rowCount + 1].Cells[cellIndex].Value = listHoliday.Name;
                        //        dgv.Rows[rowCount].Cells[cellIndex].Style.ForeColor = Color.Red;
                        //    }
                        //}

                        switch (cellIndex)
                        {
                            //日曜
                            case 0:
                                dgv.Rows[rowCount].Cells[cellIndex].Style.ForeColor = Color.Red;
                                //次のcellへ
                                cellIndex++;
                                break;
                            //土曜
                            case 6:
                                dgv.Rows[rowCount].Cells[cellIndex].Style.ForeColor = Color.Blue;
                                //土曜の場合、次のrowへ
                                cellIndex = 0;
                                rowCount = rowCount + 2;
                                break;
                            //上記以外
                            default:
                                //次のcellへ
                                cellIndex++;
                                break;
                        }
                    });

                    //次月1日~で埋める
                    Enumerable.Range(cellIndex, 7).Where(nextday => nextday < 7)
                    .ToList()
                    .ForEach(nextday =>
                    {
                        dgv.Rows[rowCount].Cells[nextday].Value = frstDay;
                        dgv.Rows[rowCount].Cells[nextday].Style.Font = new Font("Meiryo UI", 11);
                        dgv.Rows[rowCount].Cells[nextday].Style.ForeColor = Color.LightGray;
                        frstDay++;
                    });
                });

            //for(int m = 1; m < 13; m++)
            //{
            //    //年月の設定
            //    DateTime ymd = new DateTime(year, m, 1);
            //    DateTime preYmd = ymd.AddMonths(-1);

            //    //月の最終日取得(28~31)
            //    int mLength = DateTime.DaysInMonth(ymd.Year, ymd.Month);
            //    int preLength = DateTime.DaysInMonth(preYmd.Year, preYmd.Month);

            //    DayOfWeek week = ymd.DayOfWeek; //曜日取得
            //    int start = (int)ymd.DayOfWeek; //曜日をint型にキャストする。土曜なら「6」、日曜なら「0」
            //    int cellCount = start; //セル位置
            //    int rowCount = 0; //行位置

            //    int day = 1;

            //    Control[] cs = this.Controls.Find("dgvCalender" + m.ToString(), true);

            //    DataGridView dgv = (DataGridView)cs[0];

            //    dgv.Rows.Clear();

            //    dgv.ReadOnly = false;

            //    foreach (DataGridViewColumn c in dgv.Columns)
            //    {
            //        c.SortMode = DataGridViewColumnSortMode.NotSortable;
            //    }

            //    dgv.AllowUserToAddRows = false;
            //    dgv.AllowUserToDeleteRows = false;
            //    dgv.AllowUserToResizeColumns = false;
            //    dgv.AllowUserToResizeRows = false;
            //    dgv.MultiSelect = false;
            //    dgv.RowHeadersVisible = false;
            //    dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgv.DefaultCellStyle.Font = new Font("Meiryo UI", 15);
            //    dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //    //rowとcell作成
            //    for (int i = 0; i < 6; i++)
            //    {
            //        DataGridViewRow newRow = new DataGridViewRow();
            //        newRow.Height = 20;
            //        newRow.ReadOnly = true;
            //        newRow.DefaultCellStyle.Font = new Font("Meiryo UI", 12);
            //        newRow.CreateCells(dgv);
            //        dgv.Rows.Add(newRow);

            //        DataGridViewRow newText = new DataGridViewRow();
            //        newText.Height = 50;
            //        newText.ReadOnly = true;
            //        newText.CreateCells(dgv);
            //        dgv.Rows.Add(newText);
            //    }

            //    //前月31日~で埋める
            //    for (int i = start - 1; i > -1; i--)
            //    {
            //        dgv.Rows[rowCount].Cells[i].Value = preLength;
            //        dgv.Rows[rowCount].Cells[i].Style.Font = new Font("Meiryo UI", 11);
            //        dgv.Rows[rowCount].Cells[i].Style.ForeColor = Color.LightGray;
            //        preLength--;
            //    }

            //    //月初から月末まで
            //    for (int i = 0; i < mLength; i++)
            //    {
            //        if (i + 1 != 1)
            //        {
            //            dgv.Rows[rowCount].Cells[cellCount].Value = i + 1;
            //        }
            //        //1日の位置
            //        else
            //        {
            //            dgv.Rows[0].Cells[start].Value = i + 1;
            //        }

            //        ////現在のセルの日付
            //        DateTime tmp = new DateTime(year, m, i + 1);

            //        //折り返し表示
            //        dgv.Rows[rowCount + 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //        ////祝日を編集不可
            //        foreach (Holiday listHoliday in dateHoliday)
            //        {
            //            if (tmp.ToString() == listHoliday.Date)
            //            {
            //                if (listHoliday.kbn.Equals("1"))
            //                {
            //                    dgv.Rows[rowCount + 1].Cells[cellCount].ReadOnly = true;
            //                }
            //                else
            //                {
            //                    dgv.Rows[rowCount + 1].Cells[cellCount].ReadOnly = false;
            //                }
            //                dgv.Rows[rowCount + 1].Cells[cellCount].Value = listHoliday.Name;
            //                dgv.Rows[rowCount].Cells[cellCount].Style.ForeColor = Color.Red;
            //            }
            //        }

            //        switch (cellCount)
            //        {
            //            //日曜
            //            case 0:
            //                dgv.Rows[rowCount].Cells[cellCount].Style.ForeColor = Color.Red;
            //                //次のcellへ
            //                cellCount++;
            //                break;
            //            //土曜
            //            case 6:
            //                dgv.Rows[rowCount].Cells[cellCount].Style.ForeColor = Color.Blue;
            //                //土曜の場合、次のrowへ
            //                cellCount = 0;
            //                rowCount = rowCount + 2;
            //                break;
            //            //上記以外
            //            default:
            //                //次のcellへ
            //                cellCount++;
            //                break;
            //        }
            //    }
            //    //次月1日~で埋める
            //    for (int i = cellCount; i < 7; i++)
            //    {
            //        dgv.Rows[rowCount].Cells[i].Value = day;
            //        dgv.Rows[rowCount].Cells[i].Style.Font = new Font("Meiryo UI", 11);
            //        dgv.Rows[rowCount].Cells[i].Style.ForeColor = Color.LightGray;
            //        day++;
            //    }
            //}
        }

        /// <summary>
        /// 祝日マスタのデータ取得
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private Holiday[] GetHoliday(string year)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("      HOLIDAY_DATE");
            sql.Append("    ,HOLIDAY_NAME");
            sql.Append("    ,HOLIDAY_KBN");
            sql.Append(" FROM mst_holiday");
            sql.Append(" WHERE ");
            sql.Append($"  DATE_FORMAT(HOLIDAY_DATE, '%Y') = {year}");
            sql.Append(" ORDER BY HOLIDAY_DATE");

            DataSet ds = new DataSet();
            if (!comU.CSerch(sql.ToString(), ref ds))
            {
                Close();
            }

            Holiday[] holidays = new Holiday[ds.Tables[0].Rows.Count];
            int i = 0;
            Enumerable.Range(0, ds.Tables[0].Rows.Count).Select(indx => ds.Tables[0].Rows[indx] as DataRow).ToList()
                .ForEach(dr =>
                {
                    string name = dr["HOLIDAY_NAME"].ToString();
                    string date = dr["HOLIDAY_DATE"].ToString();
                    string kbn = dr["HOLIDAY_KBN"].ToString();
                    holidays[i] = new Holiday(name, date, kbn);
                    i++;
                });

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    string name = ds.Tables[0].Rows[i]["HOLIDAY_NAME"].ToString();
            //    string date = ds.Tables[0].Rows[i]["HOLIDAY_DATE"].ToString();
            //    string kbn = ds.Tables[0].Rows[i]["HOLIDAY_KBN"].ToString();
            //    holidays[i] = new Holiday(name, date, kbn);
            //}
            return holidays;
        }

        /// <summary>
        /// SQL処理
        /// </summary>
        /// <param name="List"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public void Processing(List<Holiday> List, MySqlTransaction transaction)
        {
            List.ForEach(holiday =>
                {
                    //登録を行う場合
                    if (holiday.status == insertStatus)
                    {
                        string insertMonth = Convert.ToString(Convert.ToInt32(tabControl1.SelectedIndex) + 1);
                        string insertDate = cmbYearFrom.Text + String.Format("{0:D2}", insertMonth) + dt.Day;
                        StringBuilder sql = new StringBuilder();
                        sql.Append(" INSERT INTO MST_HOLIDAY ");
                        sql.Append("    (HOLIDAY_DATE ");
                        sql.Append("    ,HOLIDAY_NAME ");
                        sql.Append("    ,HOLIDAY_KBN ");
                        sql.Append("    ,INS_DT ");
                        sql.Append("    ,INS_USER ");
                        sql.Append("    ,INS_PGM ");
                        sql.Append("    ,UPD_DT ");
                        sql.Append("    ,UPD_USER ");
                        sql.Append("    ,UPD_PGM) ");
                        sql.Append(" VALUES ");
                        sql.Append($"   ('{holiday.Date}' ");
                        sql.Append($"   ,'{holiday.Name}' ");
                        sql.Append("    ,'2'");
                        sql.Append("    ,now() ");
                        sql.Append($"   ,{user.Id} ");
                        sql.Append($"   ,{comU.CAddQuotation(programId)} ");
                        sql.Append("    ,now() ");
                        sql.Append($"   ,{user.Id} ");
                        sql.Append($"   ,{comU.CAddQuotation(programId)}) ");

                        //祝日の登録に失敗した場合
                        if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
                        {
                            MessageBox.Show("祝日の登録に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //更新を行う場合
                    else if (holiday.status == updateStatus)
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.Append(" UPDATE MST_HOLIDAY ");
                        sql.Append($"    SET  HOLIDAY_NAME = '{holiday.Name}'");
                        sql.Append("     ,    HOLIDAY_KBN = '2'");
                        sql.Append("     ,    UPD_DT = now() ");
                        sql.Append($"    ,    UPD_USER = {user.Id} ");
                        sql.Append($"    ,    UPD_PGM = {comU.CAddQuotation(programId)} ");
                        sql.Append($" WHERE HOLIDAY_DATE = {holiday.Date}");

                        //祝日の更新に失敗した場合
                        if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
                        {
                            MessageBox.Show("祝日の更新に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //削除を行う場合
                    else if (holiday.status == deleteStatus)
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.Append(" DELETE FROM MST_HOLIDAY ");
                        sql.Append($" WHERE HOLIDAY_DATE = '{holiday.Date}'");

                        //祝日の削除に失敗した場合
                        if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
                        {
                            MessageBox.Show("祝日の削除に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                });

            //foreach (Holiday holiday in List)
            //{
            //    if (holiday.status == "0")
            //    {
            //        string tab = Convert.ToString(Convert.ToInt32(tabControl1.SelectedIndex) + 1);
            //        string insertDate = cmbYearFrom.Text + String.Format("{0:D2}", tab) + dt.Day;
            //        StringBuilder sql = new StringBuilder();
            //        sql.Append(" INSERT INTO MST_HOLIDAY ");
            //        sql.Append("    (HOLIDAY_DATE ");
            //        sql.Append("    ,HOLIDAY_NAME ");
            //        sql.Append("    ,HOLIDAY_KBN ");
            //        sql.Append("    ,INS_DT ");
            //        sql.Append("    ,INS_USER ");
            //        sql.Append("    ,INS_PGM ");
            //        sql.Append("    ,UPD_DT ");
            //        sql.Append("    ,UPD_USER ");
            //        sql.Append("    ,UPD_PGM) ");
            //        sql.Append(" VALUES ");
            //        sql.Append($"   ('{holiday.Date}' ");
            //        sql.Append($"   ,'{holiday.Name}' ");
            //        sql.Append("    ,'2'");
            //        sql.Append("    ,now() ");
            //        sql.Append($"   ,{user.Id} ");
            //        sql.Append($"   ,{comU.CAddQuotation(programId)} ");
            //        sql.Append("    ,now() ");
            //        sql.Append($"   ,{user.Id} ");
            //        sql.Append($"   ,{comU.CAddQuotation(programId)}) ");

            //        if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
            //        {
            //            MessageBox.Show("祝日マスタの登録に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else if (holiday.status == "1")
            //    {
            //        StringBuilder sql = new StringBuilder();
            //        sql.Append(" UPDATE MST_HOLIDAY ");
            //        sql.Append($"    SET  HOLIDAY_NAME = '{holiday.Name}'");
            //        sql.Append("     ,    HOLIDAY_KBN = '2'");
            //        sql.Append("     ,    UPD_DT = now() ");
            //        sql.Append($"    ,    UPD_USER = {user.Id} ");
            //        sql.Append($"    ,    UPD_PGM = {comU.CAddQuotation(programId)} ");
            //        sql.Append($" WHERE HOLIDAY_DATE = {holiday.Date}");

            //        if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
            //        {
            //            MessageBox.Show("祝日マスタの更新に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else if (holiday.status == "2")
            //    {
            //        StringBuilder sql = new StringBuilder();
            //        sql.Append(" DELETE FROM MST_HOLIDAY ");
            //        sql.Append($" WHERE HOLIDAY_DATE = '{holiday.Date}'");
            //        if (!comU.CExecute(ref transaction, ref command, sql.ToString()))
            //        {
            //            MessageBox.Show("祝日マスタの削除に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }
        #endregion

        #region ボタンイベント
        /// <summary>
        /// 表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            //カレンダー表示
            CreateCalendar();
        }

        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 祝日設定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            string year = cmbYearFrom.Text;
            //コンボ選択年の祝日を取得
            Holiday[] dateHoliday = GetHoliday(year);
            string oldDate;

            Enumerable.Range(1, 12).ToList()
                .ForEach(month => 
                {
                    Control[] cs = Controls.Find("dgvCalender" + month.ToString(), true);

                    DataGridView dgv = (DataGridView)cs[0];

                    foreach (DataGridViewCell cell in dgv.SelectedCells)
                    {
                        //偶数行を選択した場合、編集不可
                        if (cell.RowIndex % 2 != 1)
                        {
                            cell.ReadOnly = true;
                        }
                        else
                        {
                            //日付がライトグレイまたは日付が空白の場合
                            if (dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor == Color.LightGray
                            || dgv[cell.ColumnIndex, cell.RowIndex - 1].Value == null)
                            {
                                cell.ReadOnly = true;
                            }
                            else
                            {
                                cell.ReadOnly = false;
                                //日付部の文字色を赤色にする
                                dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Red;
                                changeFlg = true;

                                string currentDay = dgv[cell.ColumnIndex, cell.RowIndex - 1].Value.ToString();
                                string currentMonth = String.Format("{0:D2}", Convert.ToInt32(tabControl1.SelectedIndex) + 1);
                                string currentDate = year + currentMonth + String.Format("{0:D2}", Convert.ToInt32(currentDay));
                                oldDate = currentDate;
                                //選択したセルがnull以外の場合
                                if (cell.Value != null)
                                {
                                    List<Holiday> listHoliday = dateHoliday.AsEnumerable().ToList();

                                    bool breakFlg = true;
                                    listHoliday.ForEach(holiday => 
                                    {
                                        if(breakFlg)
                                        {
                                            //データに登録されている国民の祝日と選択した祝日名が一致し、かつ国民の祝日の場合
                                            if (holiday.Name.Equals(cell.Value) & holiday.kbn.Equals(nationalHoliday))
                                            {
                                                MessageBox.Show("国民の祝日は変更できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                cell.ReadOnly = true;
                                                breakFlg = false;
                                            }
                                        }
                                    });

                                    //foreach (Holiday listHoliday in dateHoliday)
                                    //{
                                    //    //データに登録されている国民の祝日と選択した祝日名が一致し、かつ国民の祝日の場合
                                    //    if (listHoliday.Name.Equals(cell.Value) & listHoliday.kbn.Equals(nationalHoliday))
                                    //    {
                                    //        MessageBox.Show("国民の祝日は変更できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //        cell.ReadOnly = true;
                                    //        break;
                                    //    }
                                    //}
                                }
                                else
                                {
                                    //選択セルが編集できる場合
                                    if (cell.ReadOnly == false)
                                    {
                                        //登録データが0件のある場合
                                        Holiday holiday = new Holiday("", currentDate, deleteStatus, insertStatus);
                                        torokuList.Add(holiday);
                                        //登録データが1件以上ある場合
                                        //if (torokuList.Count != 0)
                                        //{
                                        //    Holiday holiday;

                                        //    torokuList.Where(listHoliday => torokuList.Count >= 1).ToList()
                                        //    .ForEach(listHoliday => 
                                        //    {
                                        //        if (oldDate.Equals(listHoliday.Date))
                                        //        {
                                        //            holiday = new Holiday("", currentDate, listHoliday.kbn, updateStatus);
                                        //            torokuList.Add(holiday);
                                        //        }
                                        //    });

                                        //    //foreach (Holiday listHoliday in torokuList)
                                        //    //{
                                        //    //    if (oldDate.Equals(listHoliday.Date))
                                        //    //    {
                                        //    //        holiday = new Holiday("", currentDate, listHoliday.kbn, updateStatus);
                                        //    //        torokuList.Add(holiday);
                                        //    //    }
                                        //    //    break;
                                        //    //}
                                        //    holiday = new Holiday("", currentDate, companyHoliday, insertStatus);
                                        //    torokuList.Add(holiday);
                                        //}
                                        //else
                                        //{
                                        //    Holiday holiday = new Holiday("", currentDate, deleteStatus, insertStatus);
                                        //    torokuList.Add(holiday);
                                        //}

                                        changeFlg = true;
                                    }
                                }
                            }
                        }
                    }
                });

            //for (int m = 1; m < 13; m++)
            //{
            //    Control[] cs = Controls.Find("dgvCalender" + m.ToString(), true);

            //    DataGridView dgv = (DataGridView)cs[0];

            //    foreach (DataGridViewCell cell in dgv.SelectedCells)
            //    {
            //        if (cell.RowIndex % 2 != 1)
            //        {
            //            cell.ReadOnly = true;
            //        }
            //        else
            //        {
            //            if (dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor == Color.LightGray)
            //            {
            //                cell.ReadOnly = true;

            //            }
            //            else
            //            {
            //                cell.ReadOnly = false;
            //                //日付部の文字色を赤色にする
            //                dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Red;
            //                changeFlg = true;

            //                string currentDay = dgv[cell.ColumnIndex, cell.RowIndex - 1].Value.ToString();
            //                string tab = String.Format("{0:D2}", Convert.ToInt32(tabControl1.SelectedIndex) + 1);
            //                string currentDate = year + tab + String.Format("{0:D2}", Convert.ToInt32(currentDay));
            //                old = currentDate;

            //                if (cell.Value != null)
            //                {
            //                    foreach (Holiday listHoliday in dateHoliday)
            //                    {
            //                        if (listHoliday.Name.Equals(cell.Value) & listHoliday.kbn.Equals("1"))
            //                        {
            //                            MessageBox.Show("国民の祝日は変更できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                            break;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    if (cell.ReadOnly == false)
            //                    {
            //                        if (torokuList.Count != 0)
            //                        {
            //                            Holiday holiday;
            //                            foreach (Holiday listHoliday in torokuList)
            //                            {
            //                                if (old.Equals(listHoliday.Date))
            //                                {
            //                                    holiday = new Holiday("", currentDate, listHoliday.kbn, "1");
            //                                    torokuList.Add(holiday);
            //                                }
            //                                break;
            //                            }
            //                            holiday = new Holiday("", currentDate, "2", "0");
            //                            torokuList.Add(holiday);
            //                        }
            //                        else
            //                        {
            //                            Holiday holiday = new Holiday("", currentDate, "2", "0");
            //                            torokuList.Add(holiday);
            //                        }

            //                        changeFlg = true;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 祝日解除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRelease_Click(object sender, EventArgs e)
        {
            string year = cmbYearFrom.Text;
            Holiday[] dateHoliday = GetHoliday(year);
            bool companyflg = true;

            Enumerable.Range(1, 12).ToList()
                .ForEach(month => 
                {
                    //国民の祝日の場合通らない
                    if (companyflg)
                    {
                        Control[] cs = Controls.Find("dgvCalender" + month.ToString(), true);

                        DataGridView dgv = (DataGridView)cs[0];

                        foreach (DataGridViewCell cell in dgv.SelectedCells)
                        {
                            //選択セルが奇数行の場合
                            if (cell.RowIndex % 2 == 1)
                            {
                                string currentCellName = "";
                                string currentDay = "";
                                string currentMonth = "";
                                string currentDate = "";

                                //選択セルがnull以外の場合
                                if (cell.Value != null)
                                {
                                    currentCellName = cell.Value.ToString();
                                    currentDay = dgv[cell.ColumnIndex, cell.RowIndex - 1].Value.ToString();
                                    currentMonth = String.Format("{0:D2}", Convert.ToInt32(tabControl1.SelectedIndex) + 1);
                                    currentDate = year + currentMonth + String.Format("{0:D2}", Convert.ToInt32(currentDay));
                                    DateTime ymd = new DateTime(Convert.ToInt32(year), month, Convert.ToInt32(currentDay));
                                    int week = (int)ymd.DayOfWeek; //曜日をint型にキャストする。土曜なら「6」、日曜なら「0」

                                    dateHoliday.AsEnumerable().Where(listHoliday => dateHoliday.Length >= 1).ToList()
                                    .ForEach(listHoliday =>
                                    {
                                        
                                        //データベースの祝日名と選択セルの祝日名が一致、かつ会社の祝日の場合
                                        if (listHoliday.Name.Equals(cell.Value) & listHoliday.kbn.Equals(companyHoliday))
                                        {
                                            Holiday holiday = new Holiday(currentCellName, currentDate, companyHoliday, deleteStatus);
                                            torokuList.Add(holiday);
                                            cell.Value = "";
                                            cell.ReadOnly = true;
                                            //土曜日の場合
                                            if (week == 6)
                                            {
                                                //日付部の文字色を青色にする
                                                dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Blue;
                                            }
                                            //日曜日の場合
                                            else if (week == 0)
                                            {
                                                //日付部の文字色を赤色にする
                                                dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Red;
                                            }
                                            else
                                            {
                                                //日付部の文字色を黒色にする
                                                dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Black;
                                            }

                                            changeFlg = true;
                                        }
                                        //データベースの祝日名と選択セルの祝日名が一致、かつ国民の祝日の場合
                                        else if (listHoliday.Name.Equals(cell.Value) & listHoliday.kbn.Equals(nationalHoliday))
                                        {
                                            MessageBox.Show("国民の祝日は変更できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            companyflg = false;
                                        }
                                    });


                                    //foreach (Holiday listHoliday in dateHoliday)
                                    //{
                                    //    //データベースの祝日名と選択セルの祝日名が一致、かつ国民の祝日の場合
                                    //    if (listHoliday.Name.Equals(cell.Value) & listHoliday.kbn.Equals(nationalHoliday))
                                    //    {
                                    //        MessageBox.Show("国民の祝日は変更できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //        companyflg = false;
                                    //        break;
                                    //    }
                                    //    //データベースの祝日名と選択セルの祝日名が一致、かつ会社の祝日の場合
                                    //    else if (listHoliday.Name.Equals(cell.Value) & listHoliday.kbn.Equals(companyHoliday))
                                    //    {
                                    //        Holiday holiday = new Holiday(currentCellName, currentDate, companyHoliday, deleteStatus);
                                    //        torokuList.Add(holiday);
                                    //        cell.Value = "";
                                    //        cell.ReadOnly = true;
                                    //        //土曜日の場合
                                    //        if (week == 6)
                                    //        {
                                    //            //日付部の文字色を青色にする
                                    //            dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Blue;
                                    //        }
                                    //        //日曜日の場合
                                    //        else if (week == 0)
                                    //        {
                                    //            //日付部の文字色を赤色にする
                                    //            dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Red;
                                    //        }
                                    //        else
                                    //        {
                                    //            //日付部の文字色を黒色にする
                                    //            dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Black;
                                    //        }

                                    //        changeFlg = true;
                                    //        break;
                                    //    }
                                    //}
                                }
                                else
                                {
                                    //日付がライトグレイまたは日付が空白の場合
                                    if (dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor == Color.LightGray
                                    || dgv[cell.ColumnIndex, cell.RowIndex - 1].Value == null)
                                    {
                                        cell.ReadOnly = true;
                                        break;
                                    }
                                    else
                                    {
                                        currentDay = dgv[cell.ColumnIndex, cell.RowIndex - 1].Value.ToString();
                                        currentMonth = String.Format("{0:D2}", Convert.ToInt32(tabControl1.SelectedIndex) + 1);
                                        currentDate = year + currentMonth + String.Format("{0:D2}", Convert.ToInt32(currentDay));
                                        DateTime ymd = new DateTime(Convert.ToInt32(year), month, Convert.ToInt32(currentDay));
                                        int currentWeek = (int)ymd.DayOfWeek; //曜日をint型にキャストする。土曜なら「6」、日曜なら「0」

                                        Holiday holiday = new Holiday(currentCellName, currentDate, companyHoliday, deleteStatus);
                                        torokuList.Add(holiday);
                                        cell.Value = "";
                                        cell.ReadOnly = true;
                                        //選択した曜日が土曜日の場合
                                        if (currentWeek == 6)
                                        {
                                            //日付部の文字色を青色にする
                                            dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Blue;
                                        }
                                        //選択した曜日が日曜の場合
                                        else if (currentWeek == 0)
                                        {
                                            //日付部の文字色を赤色にする
                                            dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Red;
                                        }
                                        else
                                        {
                                            //日付部の文字色を黒色にする
                                            dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Black;
                                        }
                                    }

                                    changeFlg = true;
                                }
                            }
                        }
                    }
                });

            //for (int m = 1; m < 13; m++)
            //{
            //    if (flg)
            //    {
            //        Control[] cs = Controls.Find("dgvCalender" + m.ToString(), true);

            //        DataGridView dgv = (DataGridView)cs[0];

            //        foreach (DataGridViewCell cell in dgv.SelectedCells)
            //        {
            //            if (cell.RowIndex % 2 == 1)
            //            {
            //                string currentCellName = "";
            //                string currentDay = "";
            //                string tab = "";
            //                string currentDate = "";

            //                if (cell.Value != null)
            //                {
            //                    currentCellName = cell.Value.ToString();
            //                    currentDay = dgv[cell.ColumnIndex, cell.RowIndex - 1].Value.ToString();
            //                    tab = String.Format("{0:D2}", Convert.ToInt32(tabControl1.SelectedIndex) + 1);
            //                    currentDate = year + tab + String.Format("{0:D2}", Convert.ToInt32(currentDay));
            //                    DateTime ymd = new DateTime(Convert.ToInt32(year), m, Convert.ToInt32(currentDay));
            //                    int week = (int)ymd.DayOfWeek; //曜日をint型にキャストする。土曜なら「6」、日曜なら「0」

            //                    foreach (Holiday listHoliday in dateHoliday)
            //                    {
            //                        if (listHoliday.Name.Equals(cell.Value) & listHoliday.kbn.Equals("1"))
            //                        {
            //                            MessageBox.Show("国民の祝日は変更できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                            flg = false;
            //                            break;
            //                        }
            //                        else if (listHoliday.Name.Equals(cell.Value) & listHoliday.kbn.Equals("2"))
            //                        {
            //                            Holiday holiday = new Holiday(currentCellName, currentDate, "2", "2");
            //                            torokuList.Add(holiday);
            //                            cell.Value = "";
            //                            cell.ReadOnly = true;
            //                            if (week == 6)
            //                            {
            //                                dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Blue;
            //                            }
            //                            else if (week == 0)
            //                            {
            //                                //日付部の文字色を赤色にする
            //                                dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Red;
            //                            }
            //                            else
            //                            {
            //                                dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Black;
            //                            }

            //                            changeFlg = true;
            //                            break;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    currentDay = dgv[cell.ColumnIndex, cell.RowIndex - 1].Value.ToString();
            //                    tab = String.Format("{0:D2}", Convert.ToInt32(tabControl1.SelectedIndex) + 1);
            //                    currentDate = year + tab + String.Format("{0:D2}", Convert.ToInt32(currentDay));
            //                    DateTime ymd = new DateTime(Convert.ToInt32(year), m, Convert.ToInt32(currentDay));
            //                    int week = (int)ymd.DayOfWeek; //曜日をint型にキャストする。土曜なら「6」、日曜なら「0」

            //                    Holiday holiday = new Holiday(currentCellName, currentDate, "2", "2");
            //                    torokuList.Add(holiday);
            //                    cell.Value = "";
            //                    cell.ReadOnly = true;
            //                    if (week == 6)
            //                    {
            //                        dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Blue;
            //                    }
            //                    else if (week == 0)
            //                    {
            //                        //日付部の文字色を赤色にする
            //                        dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Red;
            //                    }
            //                    else
            //                    {
            //                        dgv[cell.ColumnIndex, cell.RowIndex - 1].Style.ForeColor = Color.Black;
            //                    }

            //                    changeFlg = true;
            //                }
            //            }
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //登録件数が0件の場合
            if (torokuList.Count == 0)
            {
                MessageBox.Show("更新対象がありませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlTransaction transaction = null;
                if (!comU.CConnect(ref transaction, ref command)) return;

                Processing(torokuList, transaction);
                transaction.Commit();
                MessageBox.Show("処理が完了しました");
                changeFlg = false;
                torokuList.Clear();
            }
        }
        #endregion
    }

    /// <summary>
    /// 祝日を表現したクラス
    /// </summary>
    public class Holiday
    {
        private string _name;
        private string _date;
        private string _kbn;
        private string _status;

        /// <summary>
        /// 祝日の名前
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// 祝日の日付
        /// </summary>
        public string Date
        {
            get { return _date; }
        }

        /// <summary>
        /// 区分
        /// </summary>
        public string kbn
        {
            get { return _kbn; }
        }

        /// <summary>
        /// ステータス
        /// </summary>
        public string status
        {
            get { return _status; }
        }

        /// <summary>
        /// Holidayのコンストラクタ
        /// </summary>
        /// <param name="holidayName">祝日の名前</param>
        /// <param name="holidayDate">祝日の日付</param>
        public Holiday(string holidayName, string holidayDate, string kbn)
        {
            _name = holidayName;
            _date = holidayDate;
            _kbn = kbn;
        }

        /// <summary>
        /// Holidayのコンストラクタ
        /// </summary>
        /// <param name="holidayName">祝日の名前</param>
        /// <param name="holidayDate">祝日の日付</param>
        public Holiday(string holidayName, string holidayDate, string kbn, string status)
        {
            _name = holidayName;
            _date = holidayDate;
            _kbn = kbn;
            _status = status;
        }
    }
}
