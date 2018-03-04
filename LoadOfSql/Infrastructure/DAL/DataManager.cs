using LoadOfSql.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoadOfSql.Infrastructure.DAL
{
    public class DataManager : IDisposable
    {
        public DataManager()
        {
            DBConnection = new SqlConnection(GlobalSettings.ConnectionString);
            try
            {
                DBConnection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n\nПриложение будет закрыто.", "База данных недоступна", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(0);
            }
        }
        public SqlConnection DBConnection { get; private set; }
        public void Dispose()
        {
            if (DBConnection != null)
            {
                DBConnection.Close();
                DBConnection = null;
            }
        }
        public int GetClientId(string clientName, int orgId) 
        {
            if (clientName == null || clientName == "")
                throw new Exception("Переданно некорректное ФИО Клиента");
            if (orgId <= 0)
                throw new Exception("Переданно некорректный ID организации");

            var cmd = SqlQueryBuilder.SelectClientID(clientName, orgId, DBConnection);

            int clientId;
            bool parseOk = int.TryParse(cmd.ExecuteScalar().ToString(), out clientId);

            if (parseOk)
                return clientId;
            else throw new Exception("Переданно некорректное ФИО Клиента");
        }
        public string GetOrganizationName(int orgId)
        {
            if (orgId == 0 | orgId == -1)
                return "Ошибка заполнения организации.";
            var nameOrg = SqlQueryBuilder.SelectOrgName(orgId, DBConnection);
            return nameOrg.ExecuteScalar().ToString();
        }
        public string GetClientName(int clientId)
        {
            if (clientId == 0 | clientId == -1)
                return "Ошибка заполнения клиента.";
            var clientName = SqlQueryBuilder.SelectClientName(clientId, DBConnection);
            return clientName.ExecuteScalar().ToString();
        }
        public string GetIdentityClientName(int clientId)
        {
            if (clientId == 0 | clientId == -1)
                return "Ошибка заполнения клиента.";
            var identityClientName = SqlQueryBuilder.SelectIdentityClientName(clientId, DBConnection);
            var result = identityClientName.ExecuteScalar();
            if (result != null)
                return result.ToString();
            else
                return null;
        }
        public bool RenameOrganization(string oldName, string newName)
        {
            // var conflictCollectionsID = OrganizationCount(newName);
            if (OrganizationCount(newName) == 0)
            {
                SqlCommand renameCmd = new SqlCommand("UPDATE Организации SET Название = " + newName.BeQuoted() + " WHERE Название =" + oldName.BeQuoted(), DBConnection);

                try
                {
                    renameCmd.Transaction = DBConnection.BeginTransaction(IsolationLevel.Serializable);
                    renameCmd.ExecuteNonQuery();
                    renameCmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    renameCmd.Transaction.Rollback();
                    return false;
                }
            }
            else
                return false;

            return true;
        }

        public bool CreateDocuments(List<Document> docs)
        {
            if (docs == null | docs?.Count == 0)
                return false;

            foreach (Document doc in docs)
            {
                var query = SqlQueryBuilder.InsertDoc(doc, DBConnection);
                CommitDML(query);
                //try
                //{
                //    query.Transaction = DBConnection.BeginTransaction(IsolationLevel.Serializable);
                //    query.ExecuteNonQuery();
                //    query.Transaction.Commit();
                //}
                //catch (Exception e)
                //{
                //    query.Transaction.Rollback();
                //    MessageBox.Show("Ошибка в функции создания документа: " + e.Message);
                //    return false;
                //}
            }
            return true;
        }

        internal bool CreateClient(ClientInfo clInfo)
        {
            if (string.IsNullOrWhiteSpace(clInfo.ClientName) /*|| string.IsNullOrWhiteSpace(clInfo.ServerScanLink)*/ || string.IsNullOrWhiteSpace(clInfo.Requisites))
                return false;

            if (clInfo.LocalScanLink != null)
            {
                if (!Directory.Exists(GlobalSettings.ScanDirectory))
                    Directory.CreateDirectory(GlobalSettings.ScanDirectory);
                try
                {
                    File.Copy(clInfo.LocalScanLink, clInfo.ServerScanLink, false);
                }
                catch { return false; }
            }

            var createClient = SqlQueryBuilder.InsertClient(clInfo.Org_Id, clInfo.ClientName, (int)clInfo.FidDocType, clInfo.Requisites, clInfo.ServerScanLink, DBConnection);

            if (CommitDML(createClient))
                return true;
            else
            {
                File.Delete(clInfo.ServerScanLink);
                return false;
            }
        }
        //internal bool CreateIdentityDoc(List<ClientInfo> docs)
        //{
        //    if (docs == null | docs?.Count == 0)
        //        return false;

        //    bool res = true;
        //    foreach (ClientInfo doc in docs)
        //    {
        //        var insertIdDocs = SqlQueryBuilder.InsertIdentityDoc(doc, DBConnection);
        //        res &= CommitDML(insertIdDocs);
        //    }
        //    return res;
        //}

        public bool DeleteDocsForId(int? fidJournal)
        {
            var delete = SqlQueryBuilder.DeleteDocsForId(fidJournal, DBConnection);
            return CommitDML(delete);
        }
        public bool InsertDocuments(List<Document> docsAfterEdit)
        {
            if (docsAfterEdit == null)
                return false;

            bool result = true;

            foreach (Document doc in docsAfterEdit)
            {
                var insert = SqlQueryBuilder.InsertDoc(doc, DBConnection);
                result &= CommitDML(insert);
            }

            return result;
        }
        internal bool NewOrganization(string name)
        {
            var insertOrg = SqlQueryBuilder.InsertOrganization(name, DBConnection);
            return CommitDML(insertOrg);
        }

        internal List<string> GetIdentityTypes()
        {
            var getIdentTypes = SqlQueryBuilder.SelectShortIdentityTypes(DBConnection);
            return ExecuteDataList(getIdentTypes).Cast<string>().ToList();
        }

        internal bool DeleteIdentityDocuments(int currentClientId)
        {
            var delIdentDocs = SqlQueryBuilder.DeleteIdentityDocuments(currentClientId, DBConnection);
            return CommitDML(delIdentDocs);
        }

        //internal bool RenameClient(int currentClientId, string editClientName)
        //{
        //    var updateClient = SqlQueryBuilder.UpdateClient(currentClientId, editClientName, DBConnection);
        //    return CommitDML(updateClient);
        //}

        internal ClientInfo GetClientInfo(int clientId)
        {
            var getIdentType = SqlQueryBuilder.SelectClientRow(clientId, DBConnection);
            ClientInfo clientInfo = new ClientInfo();
            try
            {
                SqlDataReader reader = getIdentType.ExecuteReader();
                while (reader.Read())
                {
                    clientInfo = new ClientInfo
                    {
                        Id = clientId,
                        ClientName = reader[0].ToString(),
                        Org_Id = (int)reader[1],
                        FidDocType = reader[2] == null ? IdentityDocType.NULL : (IdentityDocType)reader[2],
                        Requisites = reader[3] == null ? null : reader[3].ToString(),
                        ServerScanLink = reader[4] == null ? null : reader[4].ToString(),
                    };
                }
                reader.Close();
                return clientInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось прочитать информацию о клиенте из базы данных." + ex.Message);
            }
        }

        internal bool UpdateClient(ClientInfo clInfo)
        {
            if (clInfo.Id == null)
                return false;
            
            //не null только тогда, когда пользователь выбрал новый файл со своего компьютера
            if (clInfo.LocalScanLink != null)
            {
                if (!Directory.Exists(GlobalSettings.ScanDirectory))
                    Directory.CreateDirectory(GlobalSettings.ScanDirectory);
                try
                {
                    File.Copy(clInfo.LocalScanLink, clInfo.ServerScanLink, false);
                }
                catch { return false; }
            }

            var updateClient = SqlQueryBuilder.UpdateClient((int)clInfo.Id, clInfo.ClientName, (int)clInfo.FidDocType, clInfo.Requisites, clInfo.ServerScanLink, DBConnection);
            if (CommitDML(updateClient))
                return true;
            else { File.Delete(clInfo.ServerScanLink); return false; }
        }

        List<object> ExecuteDataList(SqlCommand cmd)
        {
            List<object> ret = new List<object>();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(reader[0]);
                }
                reader.Close();
            }
            catch (Exception ex) { ret.Clear(); }
            return ret;
        }
        public DataTable GetBidsReportData(DateTime? firstDate, int? id, int startNum)
        {
            return GetData(SqlQueryBuilder.SelectBidsJournal(firstDate, id, startNum, DBConnection).CommandText);
        }
        public DataTable GetData(string selectCommand)
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, DBConnection);

                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);

                return table;
            }
            catch (SqlException)
            {
                MessageBox.Show("Ошибка обращения к базе данных.", "Системный сбой", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int OrganizationCount(string name)
        {
            //List<int> ret = new List<int>();
            SqlCommand cmd = SqlQueryBuilder.CountOfOrganiztion(name, DBConnection);
            //SqlCommand cmd = SqlQueryBuilder.Select("ID", "Организации", "Название", name, DBConnection);
            try
            {
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return 0; }
        }
        internal int FindFirstOrganizationId(string orgName)
        {
            var queryOrgID = SqlQueryBuilder.GetOrgId(orgName, DBConnection);
            try
            {
                return (int)queryOrgID.ExecuteScalar();
            }
            catch (Exception ex) { return -1; }
        }
        public List<string> GetBlankRows()
        {
            //SqlDataReader reader = SqlQueryBuilder.BlankItems(DBConnection).ExecuteReader();
            return ExecuteDataList(SqlQueryBuilder.BlankItems(DBConnection)).Cast<string>().ToList();
            // List<string> ret = new List<string>();
            //while (reader.Read())
            //{
            //    ret.Add(reader[0].ToString());
            //}
            //reader.Close();
            //return ret;
        }

        bool CommitDML(SqlCommand cmd)
        {
            if (cmd != null)
                try
                {
                    cmd.Transaction = DBConnection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    MessageBox.Show("Ошибка работы с базой данных при выполнении DML-комманды: " + e.Message);
                    return false;
                }
            else
                return false;
        }


    }
}

