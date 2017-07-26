using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using CnsosNet;
using System.Collections;

namespace AccountAssistant
{
    [DataContract]
    public class AppSettings : ApplicationSettings
    {
        public const string ConfigFileName = "config.ini";

        public override Hashtable LoadSettings()
        {
            return ConfigCtl.LoadAppConfig(ConfigFileName);
        }

        public override void SaveSettings(Hashtable settings)
        {
            ConfigCtl.SaveAppConfig(ConfigFileName, settings);
        }

        const string DataBbaseTypeKeyName = "DataBbaseType";
        const string DataBbaseTypeDefault = DBType.MySQL;
        /// <summary>
        /// 数据库类型
        /// </summary>
        [DataMember]
        public string DataBbaseType
        {
            get
            {
                return GetValueOrDefault<string>(DataBbaseTypeKeyName, DataBbaseTypeDefault);
            }
            set
            {
                if (AddOrUpdateValue(DataBbaseTypeKeyName, value))
                {
                    Save();
                }
            }
        }

        const string MySqlServerIPKeyName = "MySqlServerIP";
        const string MySqlServerIPDefault = "127.0.0.1";
        /// <summary>
        /// MySql数据库IP地址
        /// </summary>
        [DataMember]
        public string MySqlServerIP
        {
            get
            {
                return GetValueOrDefault<string>(MySqlServerIPKeyName, MySqlServerIPDefault);
            }
            set
            {
                if (AddOrUpdateValue(MySqlServerIPKeyName, value))
                {
                    Save();
                }
            }
        }

        const string MySqlPortKeyName = "MySqlPort";
        const int MySqlPortDefault = 3306;
        /// <summary>
        /// MySql数据库连接端口
        /// </summary>
        [DataMember]
        public int MySqlPort
        {
            get
            {
                return GetValueOrDefault<int>(MySqlPortKeyName, MySqlPortDefault);
            }
            set
            {
                if (AddOrUpdateValue(MySqlPortKeyName, value))
                {
                    Save();
                }
            }
        }

        const string MySqlUserKeyName = "MySqlUser";
        const string MySqlUserDefault = "root";
        /// <summary>
        /// MySql数据库登陆用户名
        /// </summary>
        [DataMember]
        public string MySqlUser
        {
            get
            {
                return GetValueOrDefault<string>(MySqlUserKeyName, MySqlUserDefault);
            }
            set
            {
                if (AddOrUpdateValue(MySqlUserKeyName, value))
                {
                    Save();
                }
            }
        }

        const string MySqlPasswordKeyName = "MySqlPassword";
        const string MySqlPasswordDefault = "";
        /// <summary>
        /// MySql数据库登陆密码
        /// </summary>
        [DataMember]
        public string MySqlPassword
        {
            get
            {
                return GetValueOrDefault<string>(MySqlPasswordKeyName, MySqlPasswordDefault);
            }
            set
            {
                if (AddOrUpdateValue(MySqlPasswordKeyName, value))
                {
                    Save();
                }
            }
        }

        const string MySqlDBNameKeyName = "MySqlDBName";
        const string MySqlDBNameDefault = "";
        /// <summary>
        /// MySql数据库的库名称
        /// </summary>
        [DataMember]
        public string MySqlDBName
        {
            get
            {
                return GetValueOrDefault<string>(MySqlDBNameKeyName, MySqlDBNameDefault);
            }
            set
            {
                if (AddOrUpdateValue(MySqlDBNameKeyName, value))
                {
                    Save();
                }
            }
        }

        const string CloseToMinKeyName = "CloseToMin";
        const bool CloseToMinDefault = false;
        /// <summary>
        /// 关闭时最小化窗体
        /// </summary>
        [DataMember]
        public bool CloseToMin
        {
            get
            {
                return GetValueOrDefault<bool>(CloseToMinKeyName, CloseToMinDefault);
            }
            set
            {
                if (AddOrUpdateValue(CloseToMinKeyName, value))
                {
                    Save();
                }
            }
        }

        const string TopmostKeyName = "Topmost";
        const bool TopmostDefault = false;
        /// <summary>
        /// 窗体置顶
        /// </summary>
        [DataMember]
        public bool Topmost
        {
            get
            {
                return GetValueOrDefault<bool>(TopmostKeyName, TopmostDefault);
            }
            set
            {
                if (AddOrUpdateValue(TopmostKeyName, value))
                {
                    Save();
                }
            }
        }
    }
}
