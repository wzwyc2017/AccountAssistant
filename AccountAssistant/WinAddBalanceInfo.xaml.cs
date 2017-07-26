using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// WinAddBalanceInfo.xaml 的交互逻辑
    /// </summary>
    public partial class WinAddBalanceInfo : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Properties.Settings mSettings = Properties.Settings.Default;
        private AccountInfo[] AccountItems;

        public WinAddBalanceInfo()
        {
            InitializeComponent();

            colName.Width = mSettings.ColumNameWidth;
            colSum.Width = mSettings.ColumSumWidth;

            this.Loaded += WinAddBalanceInfo_Loaded;
            this.Closing += WinAddBalanceInfo_Closing;
        }

        private void WinAddBalanceInfo_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mSettings.ColumNameWidth = colName.Width;
            mSettings.ColumSumWidth = colSum.Width;
            mSettings.Save();
        }

        private void WinAddBalanceInfo_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshAccountList();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.mSQLHelper.UpdateAccountInfo(AccountItems);
                App.mSQLHelper.AddBalanceInfo(AccountItems);

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshAccountList()
        {
            AccountItems = App.mSQLHelper.GetAccountInfoList();
            ShowAccountList();
        }

        private void ShowAccountList()
        {
            AccountList.ItemsSource = AccountItems;
        }
    }
}
