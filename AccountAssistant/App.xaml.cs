using AccountAssistant.Modules;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace AccountAssistant
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static AppSettings UserSettings;
        public static ISQLHelper mSQLHelper;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                UserSettings = new AppSettings();

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
