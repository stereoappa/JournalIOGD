using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoadOfSql.Infrastructure.DAL
{
   public static class MapCasesManager
    {
        public static bool SetDBMapCasesSumm(string organization, int mapCasesCount)
        {
            bool summingInPositiveSumDiapason = true;
            int actual_sum = GetMapCasesSum(organization);
            if ((mapCasesCount <= 0) && (actual_sum + mapCasesCount <= 0))
            {
                mapCasesCount = -actual_sum;
                summingInPositiveSumDiapason = false;
            }

            using (SqlConnection cn = new SqlConnection(GlobalSettings.ConnectionString))
            {
                cn.Open();
                SqlCommand setCountCmd = cn.CreateCommand();      //Делаем выбор последнего элемента ID
                setCountCmd.CommandText = "UPDATE Организации SET ВыданоПланшетов = ISNULL(ВыданоПланшетов, 0) + " + mapCasesCount + " WHERE Название = '" + organization + "'";
                try
                {
                    setCountCmd.Transaction = cn.BeginTransaction(IsolationLevel.Serializable);
                    setCountCmd.ExecuteNonQuery();
                    setCountCmd.Transaction.Commit();
                }
                catch
                {
                    setCountCmd.Transaction.Rollback();
                    cn.Close();
                    MessageBox.Show("Не получилось внести количество планшетов в БД. \nОбратитесь к администратору.", "Системный сбой", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                cn.Close();
            }
            return summingInPositiveSumDiapason;
        }

        public static int GetMapCasesSum(string organiztion)
        {
            int mapCases = 0;
            using (SqlConnection cn = new SqlConnection(GlobalSettings.ConnectionString))
            {
                cn.Open();
                using (SqlCommand command = cn.CreateCommand())
                {
                    SqlCommand getCount = cn.CreateCommand();
                    getCount.CommandText = "Select TOP 1 Организации.ВыданоПланшетов From Организации Where Организации.Название = " + "'" + organiztion + "'";
                    try
                    {
                        mapCases = (int)getCount.ExecuteScalar();
                    }
                    catch
                    {
                        cn.Close();
                        return 0;
                    }
                }
                cn.Close();
            }
            return mapCases;
        }

        internal static int GetActualRequireAct(int id)
        {
            using (SqlConnection cn = new SqlConnection(GlobalSettings.ConnectionString))
            {
                int result = 0;
                cn.Open();
                using (SqlCommand command = cn.CreateCommand())
                {
                    SqlCommand requireActToDel = cn.CreateCommand();
                    requireActToDel.CommandText = "Select TOP 1 Журнал.RequireConfirmAct From Журнал Where ID = " + id;
                    try
                    {
                        result = (int)requireActToDel.ExecuteScalar();
                    }
                    catch
                    {
                        cn.Close();
                    }
                }
                cn.Close();
                return result;
            }

        }
    }
}
