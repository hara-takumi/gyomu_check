using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GYOMU_CHECK
{
    public partial class GC0020 : Form
    {
        // APIを呼び出すため、対象のＤＬＬをインポート
        [DllImport("USER32.DLL")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, UInt32 bRevert);

        [DllImport("USER32.DLL")]
        private static extern UInt32 RemoveMenu(IntPtr hMenu, UInt32 nPosition, UInt32 wFlags);

        // 定数定義
        private const UInt32 SC_CLOSE = 0x0000F060;
        private const UInt32 MF_BYCOMMAND = 0x00000000;

        private User user;
        public GC0020(User user)
        {
            this.user = user;
            InitializeComponent();

            // コントロールボックスの［閉じる］ボタンの無効化
            // システムメニュー（フォームの）ハンドル取得する
            IntPtr hMenu = GetSystemMenu(this.Handle, 0);
            // [×]ボタンを無効化する。
            RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);
        }

        private void GC0020_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 業務進捗ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProgress_Click(object sender, EventArgs e)
        {
            GC0030 Gc0030 = new GC0030(user);
            Gc0030.Show();
        }

        /// <summary>
        /// パスワード変更ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            MS0010 Ms0010 = new MS0010(user);
            Ms0010.Show();
        }



        /// <summary>
        /// ログアウト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            GC0010 frm = new GC0010();
            frm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MS0020 Ms0020 = new MS0020(user);
            Ms0020.Show();
        }
    }
}
