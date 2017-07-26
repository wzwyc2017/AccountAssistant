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
    /// WinSetting.xaml 的交互逻辑
    /// </summary>
    public partial class WinSetting : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Properties.Settings mSettings = Properties.Settings.Default;

        public WinSetting()
        {
            InitializeComponent();

            tbMySqlIPAddr.Text = App.UserSettings.MySqlServerIP;
            tbMySqlPort.Text = App.UserSettings.MySqlPort.ToString();
            tbMySqlUser.Text = App.UserSettings.MySqlUser;
            tbMySqlPassword.Text = App.UserSettings.MySqlPassword;
            tbMySqlDbName.Text = App.UserSettings.MySqlDBName;

            rbSQLite.IsEnabled = false;

            if (App.UserSettings.DataBbaseType.Equals(DBType.SQLite))
            {
                rbSQLite.IsChecked = true;
                groupBoxMySQL.IsEnabled = false;
            }
            else
            {
                rbMySQL.IsChecked = true;
            }

            chkTopmost.IsChecked = App.UserSettings.Topmost;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rbSQLite.IsChecked == true)
                {
                    App.UserSettings.DataBbaseType = DBType.SQLite;
                }
                else
                {
                    App.UserSettings.DataBbaseType = DBType.MySQL;
                }

                App.UserSettings.MySqlServerIP = tbMySqlIPAddr.Text;
                App.UserSettings.MySqlPort = Convert.ToInt32(tbMySqlPort.Text);
                App.UserSettings.MySqlUser = tbMySqlUser.Text;
                App.UserSettings.MySqlPassword = tbMySqlPassword.Text;
                App.UserSettings.MySqlDBName = tbMySqlDbName.Text;
                App.UserSettings.Topmost = (chkTopmost.IsChecked == true);

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void rbSQLite_Checked(object sender, RoutedEventArgs e)
        {
            groupBoxMySQL.IsEnabled = false;
        }

        private void rbMySQL_Checked(object sender, RoutedEventArgs e)
        {
            groupBoxMySQL.IsEnabled = true;
        }
    }
}
