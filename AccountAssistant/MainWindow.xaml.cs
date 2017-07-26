using AccountAssistant.Modules;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.Charts;
using Microsoft.Research.DynamicDataDisplay.DataSources;
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
using System.Windows.Navigation;

namespace AccountAssistant
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Properties.Settings mSettings = Properties.Settings.Default;
        private AccountInfo[] AccountItems;
        private BalanceInfo[] BalanceItems;
        private HorizontalDateTimeAxis dateAxis;

        public MainWindow()
        {
            InitializeComponent();

            this.WindowState = mSettings.MainWindowState;
            this.Left = mSettings.MainWindowBounds.Left;
            this.Top = mSettings.MainWindowBounds.Top;
            this.Width = mSettings.MainWindowBounds.Width;
            this.Height = mSettings.MainWindowBounds.Height;

            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectToDBServer();
                AccountItems = App.mSQLHelper.GetAccountInfoList();
                BalanceItems = App.mSQLHelper.GetBalanceInfoList();

                dateAxis = new HorizontalDateTimeAxis();
                plotter.MainHorizontalAxis = dateAxis;
                int index = 0;
                foreach (var item in AccountItems)
                {
                    var pts = BalanceItems.Where(s => s.AccountID == item.ID);
                    plotter.AddLineGraph(CreateDataSource(pts), AppBase.GetRandomColor(index++), 2, item.Name);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mSettings.MainWindowState = this.WindowState;
            mSettings.MainWindowBounds = this.RestoreBounds;
            mSettings.Save();
        }

        private void menuAddAccountInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WinAddEditAccountInfo win = new WinAddEditAccountInfo();
                win.Owner = this;
                if (win.ShowDialog() == true)
                {

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 连接到数据库服务器
        /// </summary>
        private void ConnectToDBServer()
        {
            Debug.Assert(App.UserSettings.DataBbaseType.Equals(DBType.MySQL));
            App.mSQLHelper = new MySQLHelper(App.UserSettings.MySqlServerIP, App.UserSettings.MySqlPort,
                App.UserSettings.MySqlUser, App.UserSettings.MySqlPassword, App.UserSettings.MySqlDBName);
        }

        private void menuAccountList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WinAccountList win = new WinAccountList();
                win.Owner = this;
                win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                if (win.ShowDialog() == true)
                {

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void menuSetting_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WinSetting win = new WinSetting();
                win.Owner = this;
                if (win.ShowDialog() == true)
                {
                    if (App.mSQLHelper == null)
                    {
                        ConnectToDBServer();
                    }
                    this.Topmost = App.UserSettings.Topmost;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void menuAddBalanceInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WinAddBalanceInfo win = new WinAddBalanceInfo();
                win.Owner = this;
                win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                if (win.ShowDialog() == true)
                {

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private EnumerableDataSource<BalanceInfo> CreateDataSource(IEnumerable<BalanceInfo> rates)
        {
            EnumerableDataSource<BalanceInfo> ds = new EnumerableDataSource<BalanceInfo>(rates);
            ds.SetXMapping(ci => dateAxis.ConvertToDouble(ci.AddTime));
            ds.SetYMapping(ci => ci.Sum);
            return ds;
        }
    }
}
