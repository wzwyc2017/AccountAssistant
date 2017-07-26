using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountAssistant
{
    public class AccountInfo : NotifyPropertyClass
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    NotifyPropertyChanging("ID");
                    _ID = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _Name;
        /// <summary>
        /// 账户名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    NotifyPropertyChanging("Name");
                    _Name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private double _Sum;
        public double Sum
        {
            get { return _Sum; }
            set
            {
                if (_Sum != value)
                {
                    NotifyPropertyChanging("Sum");
                    _Sum = value;
                    NotifyPropertyChanged("Sum");
                }
            }
        }

        private DateTime _AddTime;
        public DateTime AddTime
        {
            get { return _AddTime; }
            set
            {
                if (_AddTime != value)
                {
                    NotifyPropertyChanging("AddTime");
                    _AddTime = value;
                    NotifyPropertyChanged("AddTime");
                }
            }
        }
    }
}
