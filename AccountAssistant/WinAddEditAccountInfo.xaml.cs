using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AccountAssistant
{
    /// <summary>
    /// WinAddEditAccountInfo.xaml 的交互逻辑
    /// </summary>
    public partial class WinAddEditAccountInfo : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private AccountInfo CurInfo;

        public WinAddEditAccountInfo(AccountInfo info = null)
        {
            InitializeComponent();

            CurInfo = info;
            if (CurInfo != null)
            {
                tbName.Text = CurInfo.Name;

                this.Title = "编辑账户";
            }

            tbName.Focus();
            tbName.SelectionStart = tbName.Text?.Length ?? 0;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = tbName.Text;

                if (string.IsNullOrEmpty(name))
                {
                    tbName.Focus();
                    return;
                }

                if (CurInfo != null)
                {
                    CurInfo.Name = name;
                    App.mSQLHelper.UpdateAccountInfo(CurInfo);
                }
                else
                {
                    AccountInfo info = new AccountInfo();
                    info.Name = name;
                    info.AddTime = DateTime.Now;
                    App.mSQLHelper.AddAccountInfo(info);
                }

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
