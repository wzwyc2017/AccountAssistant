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
    /// WinAccountList.xaml 的交互逻辑
    /// </summary>
    public partial class WinAccountList : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private AccountInfo[] AccountItems;

        public WinAccountList()
        {
            InitializeComponent();

            this.Loaded += WinAccountList_Loaded;
        }

        private void WinAccountList_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshAccountList();
        }

        private void menuAddAccountInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WinAddEditAccountInfo win = new WinAddEditAccountInfo();
                win.Owner = this;
                if (win.ShowDialog() == true)
                {
                    RefreshAccountList();
                }
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
