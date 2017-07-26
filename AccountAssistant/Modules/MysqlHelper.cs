using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountAssistant.Modules
{
    public class MySQLHelper : ISQLHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string ConnString;

        public MySQLHelper(string serverIP, int serverPort, string dbUser, string dbPassword, string dbName)
        {
            ConnString = string.Format("server={0};port={1};uid={2};pwd={3};database={4};", serverIP, serverPort, dbUser, dbPassword, dbName);
        }

        /// <summary>
        /// 创建数据库表格
        /// </summary>
        public void CreateTables()
        {
        }

        public void AddAccountInfo(AccountInfo info)
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();

                string sqlText = "INSERT INTO Acc_AccountInfoTable (Name,Sum,AddTime) ";
                sqlText += "VALUES (@Name,@Sum,@AddTime)";
                using (MySqlCommand cmd = new MySqlCommand(sqlText, conn))
                {
                    cmd.Parameters.AddWithValue("Name", info.Name);
                    cmd.Parameters.AddWithValue("Sum", info.Sum);
                    cmd.Parameters.AddWithValue("AddTime", info.AddTime);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateAccountInfo(AccountInfo info)
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();

                string sqlText = "Update Acc_AccountInfoTable set Name=@Name,Sum=@Sum where ID=@ID";
                using (MySqlCommand cmd = new MySqlCommand(sqlText, conn))
                {
                    cmd.Parameters.AddWithValue("Name", info.Name);
                    cmd.Parameters.AddWithValue("Sum", info.Sum);
                    cmd.Parameters.AddWithValue("ID", info.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateAccountInfo(AccountInfo[] items)
        {
            foreach (var info in items)
            {
                UpdateAccountInfo(info);
            }
        }

        public void DeleteAccountInfo(int id)
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Acc_AccountInfoTable where ID=@ID", conn))
                {
                    cmd.Parameters.AddWithValue("ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AccountInfo[] GetAccountInfoList()
        {
            List<AccountInfo> classList = new List<AccountInfo>();

            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT ID,Name,Sum,AddTime from Acc_AccountInfoTable", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AccountInfo info = new AccountInfo();
                            int index = 0;
                            info.ID = reader.GetInt32(index++);
                            info.Name = reader.GetString(index++);
                            info.Sum = reader.GetDouble(index++);
                            info.AddTime = reader.GetDateTime(index++);

                            classList.Add(info);
                        }
                    }
                }
            }

            return classList.ToArray();
        }

        public void AddBalanceInfo(BalanceInfo info)
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();

                string sqlText = "INSERT INTO Acc_BalanceInfoTable (AccountID,Sum,AddTime) ";
                sqlText += "VALUES (@AccountID,@Sum,@AddTime)";
                using (MySqlCommand cmd = new MySqlCommand(sqlText, conn))
                {
                    cmd.Parameters.AddWithValue("AccountID", info.AccountID);
                    cmd.Parameters.AddWithValue("Sum", info.Sum);
                    cmd.Parameters.AddWithValue("AddTime", info.AddTime);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddBalanceInfo(AccountInfo[] items)
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();

                var dtNow = DateTime.Now;
                string sqlText = "INSERT INTO Acc_BalanceInfoTable (AccountID,Sum,AddTime) VALUES ";
                List<string> myList = new List<string>();
                foreach (var item in items)
                {
                    myList.Add(string.Format("({0},{1},'{2}')", item.ID, item.Sum, dtNow));
                }
                sqlText += string.Join(",", myList);

                using (MySqlCommand cmd = new MySqlCommand(sqlText, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBalanceInfo(BalanceInfo info)
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();

                string sqlText = "Update Acc_BalanceInfoTable set AccountID=@AccountID,Sum=@Sum where ID=@ID";
                using (MySqlCommand cmd = new MySqlCommand(sqlText, conn))
                {
                    cmd.Parameters.AddWithValue("AccountID", info.AccountID);
                    cmd.Parameters.AddWithValue("Sum", info.Sum);
                    cmd.Parameters.AddWithValue("ID", info.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBalanceInfo(int id)
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Acc_BalanceInfoTable where ID=@ID", conn))
                {
                    cmd.Parameters.AddWithValue("ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public BalanceInfo[] GetBalanceInfoList()
        {
            List<BalanceInfo> classList = new List<BalanceInfo>();

            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT ID,AccountID,Sum,AddTime from Acc_BalanceInfoTable", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BalanceInfo info = new BalanceInfo();
                            int index = 0;
                            info.ID = reader.GetInt32(index++);
                            info.AccountID = reader.GetInt32(index++);
                            info.Sum = reader.GetDouble(index++);
                            info.AddTime = reader.GetDateTime(index++);

                            classList.Add(info);
                        }
                    }
                }
            }

            return classList.ToArray();
        }
    }
}
