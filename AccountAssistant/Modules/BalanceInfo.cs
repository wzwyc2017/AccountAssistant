using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountAssistant
{
    public class BalanceInfo : NotifyPropertyClass
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

        private int _AccountID;
        public int AccountID
        {
            get { return _AccountID; }
            set
            {
                if (_AccountID != value)
                {
                    NotifyPropertyChanging("AccountID");
                    _AccountID = value;
                    NotifyPropertyChanged("AccountID");
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
