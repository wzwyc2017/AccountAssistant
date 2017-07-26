using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountAssistant.Modules
{
    public interface ISQLHelper
    {
        /// <summary>
        /// 创建数据库表格
        /// </summary>
        void CreateTables();

        void AddAccountInfo(AccountInfo info);

        void UpdateAccountInfo(AccountInfo info);

        void UpdateAccountInfo(AccountInfo[] items);

        void DeleteAccountInfo(int id);

        AccountInfo[] GetAccountInfoList();

        void AddBalanceInfo(BalanceInfo info);

        void AddBalanceInfo(AccountInfo[] info);

        void UpdateBalanceInfo(BalanceInfo info);

        void DeleteBalanceInfo(int id);

        BalanceInfo[] GetBalanceInfoList();
    }
}
