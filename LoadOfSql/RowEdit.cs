using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoadOfSql
{
    static class RowEdit
    {
        public static void ChangeRow(DataRow editRow)
        {
            string connStr = GlobalSettings.ConnectionString;

            StringBuilder builder = new StringBuilder();
            string commandString = "UPDATE Журнал " +
                                   "SET Memo = @Memo, " +
                                   "Empl_ID = (SELECT Сотрудники.ID FROM Сотрудники WHERE Сотрудники.Фамилия = @Empl_ID), " +
                                   "Organ_ID = @Организация, " +
                                   "TypeDoc = (Select ТипДокумента.ID from ТипДокумента where ТипДокумента.Name = @TypeDoc), " +                                   
                                   "Date = @Date, " +
                                   "in_id = (SELECT Info_Type.ID from Info_type WHERE Info_type.in_type = @in_type), " +
                                   "Client_ID = @Client_ID, " +
                                   "Cost = @Cost, " +
                                   "MapCasesCount = @MapCasesCount, " +
                                   "RequireConfirmAct = @RequireConfirmAct " +
                                   " WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(commandString, connection);
                cmd.Parameters.AddWithValue("ID", editRow[0]);
                cmd.Parameters.AddWithValue("Memo", editRow[6]);
               // cmd.Parameters.AddWithValue("NumRazresh", editRow[9]);
                cmd.Parameters.AddWithValue("Empl_ID", editRow[4]);
                cmd.Parameters.AddWithValue("Организация", editRow[3]);
                cmd.Parameters.AddWithValue("TypeDoc", editRow[1]);
               // cmd.Parameters.AddWithValue("DateRazresh", editRow[8]);
                cmd.Parameters.AddWithValue("Date", editRow[2]);
                cmd.Parameters.AddWithValue("in_type", editRow[7]);
                cmd.Parameters.AddWithValue("ClientName", editRow[5]);
                cmd.Parameters.AddWithValue("Cost", editRow[8]);
                cmd.Parameters.AddWithValue("MapCasesCount", editRow[9]);
                cmd.Parameters.AddWithValue("RequireConfirmAct", editRow[10]);
                cmd.Parameters.AddWithValue("Client_ID", editRow[11]);
                try
                {
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    editRow.AcceptChanges();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    MessageBox.Show(e.Message, "Критическая ошибка ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
     

        public static void DeleteRow(DataRow deleteRow)
        {
            string connStr = GlobalSettings.ConnectionString;

            StringBuilder builder = new StringBuilder();

            string commandString = "DELETE Журнал " +
                                   "WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(commandString, connection);
                cmd.Parameters.AddWithValue("ID", deleteRow[0, DataRowVersion.Original]);
                try
                {
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    MessageBox.Show("Транзакция отменена. "+e.Message);
                }
            }
        }
    }
}
