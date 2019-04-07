using DomainModel.Entities;
using LoadOfSql.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LoadOfSql.Infrastructure
{
    static class SqlQueryBuilder
    {
        public static SqlCommand SumByDateQuery(SummingType type, DateTime from, DateTime by, SqlConnection connect)
        {
            string sqlFrom = from.ToString("yyyy-MM-dd");
            string sqlBy = by.AddDays(1).ToString("yyyy-MM-dd"); //HH:mm:ss

            return new SqlCommand(@"SELECT SUM(Cost) FROM Журнал WHERE Date >=" + sqlFrom.BeQuoted() +
                                    " AND Date < " + sqlBy.BeQuoted() + GenerateInfTypeQueryPart(type), connect);
        }

        static string GenerateInfTypeQueryPart(SummingType type)
        {
            if (type == SummingType.MapCases)
                return " AND MapCasesCount > 0";
            else if (type == SummingType.OtherInformation)
                return " AND MapCasesCount = 0";
            else return "";
        }

        public static SqlCommand Select(string field, string tableName, string columnName, string value, SqlConnection connect)
        {
            return new SqlCommand(@"SELECT " + field + " from " + tableName + " WHERE " + columnName + "=" + value.BeQuoted(), connect);
        }

        public static SqlCommand GetOrgId(string orgName, SqlConnection connect)
        {
            return new SqlCommand("SELECT MIN(ID) FROM Организации WHERE Организации.Название =" + orgName.BeQuoted() + "", connect);
        }
        public static SqlCommand SelectClientID(string clientName, int orgId, SqlConnection connect)
        {
            return new SqlCommand("SELECT ID FROM Клиенты WHERE ClientName = " + clientName.BeQuoted() + " AND Org_ID =" + orgId, connect);
        }

        public static SqlCommand LastId(SqlConnection conn)
        {
            return new SqlCommand("SELECT TOP 1 ID FROM Журнал ORDER BY ID DESC", conn);
        }

        internal static SqlCommand SelectOrgName(int orgId, SqlConnection cn)
        {
            return new SqlCommand("SELECT Название FROM Организации WHERE ID = " + orgId, cn);
        }

        public static SqlCommand InsertDoc(Document doc, SqlConnection cn)
        {
            return new SqlCommand("INSERT INTO DOCUMENTS (FID_JOURNAL, FID_TYPE_DOC, NUM_RAZRESH, DATE_RAZRESH, TICKET_NUMBER, TICKET_DATE, CHARGE_DATE) VALUES (" +
                doc.FidJournal + "," +
                (int)doc.Type + "," +
                doc.NumRazresh.BeQuotedFromNullVariation() + "," +
                doc.DateRazresh.ToSqlDateTime().BeQuotedFromNullVariation() + "," +
                doc.TicketNumber.BeQuotedFromNullVariation() + "," +
                doc.TicketDate.ToSqlDateTime().BeQuotedFromNullVariation() + "," +
                doc.ChargeDate.ToSqlDateTime().BeQuotedFromNullVariation() + ")", cn);
        }

        internal static SqlCommand SelectIdentityClientName(int clientId, SqlConnection dBConnection)
        {
            return new SqlCommand(@"SELECT cl.ClientName + 
                                        ' ('+ idntype.SHORT_IDENTITY_TYPE
                                        +' '+ cl.REQUISITES +')' AS ClientInfo
                                        FROM Клиенты cl 
                                        JOIN IDENTITY_TYPES idntype 
                                        on cl.FID_DOCTYPE = idntype.ID
										WHERE cl.ID =" + clientId, dBConnection);
        }

        internal static SqlCommand SelectClientName(int clientId, SqlConnection dBConnection)
        {
            return new SqlCommand("SELECT ClientName FROM Клиенты WHERE ID =" + clientId, dBConnection);
        }

        public static SqlCommand InsertOrganization(string name, SqlConnection cn)
        {
            if (!string.IsNullOrWhiteSpace(name))
                return new SqlCommand("INSERT INTO Организации(Название, ВыданоПланшетов) VALUES(" + name.BeQuoted() + ", 0)", cn);
            else return null;
        }

        //internal static SqlCommand InsertIdentityDoc(ClientInfo doc, SqlConnection cn)
        //{
        //    return new SqlCommand(@"INSERT INTO IDENTITY_DOCS (FID_CLIENT, DOCTYPE, REQUISITES, SCAN_LINK) VALUES (" +
        //                            doc.Id + "," +
        //                            (int)doc.FidDocType + "," +
        //                            doc.Requisites.BeQuotedFromNullVariation() + "," +
        //                            doc.ServerScanLink.BeQuotedFromNullVariation() + ")"
        //                            , cn);
        //}
        public static SqlCommand DeleteDocsForId(int? fidJournal, SqlConnection cn)
        {
            if (fidJournal == null)
                return null;

            return new SqlCommand("DELETE FROM DOCUMENTS WHERE FID_JOURNAL = " + fidJournal, cn);
        }
        public static SqlCommand SelectBidsJournal(DateTime? firstDate, int? id, int startNum, SqlConnection cn)
        {
            int seed = startNum;
            if (firstDate != null && id == null)
                return new SqlCommand("SELECT " +
                                   "ROW_NUMBER() over(order by d.FID_JOURNAL) + " + (seed - 1) + " AS " + "Номер п/п".BeQuoted() +
                                   ",j.Date AS " + "Дата записи".BeQuoted() +
                                   ",CASE WHEN org.ID = 33 THEN c.ClientName ELSE org.Название END AS" + "Заявитель".BeQuoted() +
                                   "," + "№ ".BeQuoted() + "+ TICKET_NUMBER+" + " от ".BeQuoted() + "+Convert(varchar, TICKET_DATE, 104) AS " + "Исходящий номер и дата письма".BeQuoted() +
                                   ",Convert(varchar,j.ID) +ISNULL('; оплата '+Convert(varchar, CHARGE_DATE, 104), '') AS " + "Примечание (Номер в эл. журнале и дата оплаты)".BeQuoted() +
                                   " from Журнал j join DOCUMENTS d on j.ID = d.FID_JOURNAL " +
                                   " join Организации org on org.ID = j.Organ_ID " +
                                   " join Клиенты c on c.ID = j.Client_ID  " +
                                   " WHERE j.Date >=" + firstDate.ToSqlDateTime().BeQuoted() +
                                   " order by d.FID_JOURNAL", cn);
            else
                return new SqlCommand("SELECT " +
                                   "ROW_NUMBER() over(order by d.FID_JOURNAL) + " + (seed - 1) + " AS " + "Номер п/п".BeQuoted() +
                                   ",j.Date AS " + "Дата записи".BeQuoted() +
                                   ",CASE WHEN org.ID = 33 THEN c.ClientName ELSE org.Название END AS" + "Заявитель".BeQuoted() +
                                   "," + "№ ".BeQuoted() + "+ TICKET_NUMBER+" + " от ".BeQuoted() + "+Convert(varchar, TICKET_DATE, 104) AS " + "Исходящий номер и дата письма".BeQuoted() +
                                   ",Convert(varchar,j.ID)+ISNULL('; оплата '+Convert(varchar, CHARGE_DATE, 104), '') AS " + "Примечание (Номер в эл. журнале и дата оплаты)".BeQuoted() +
                                   " from Журнал j join DOCUMENTS d on j.ID = d.FID_JOURNAL " +
                                   " join Организации org on org.ID = j.Organ_ID " +
                                   " join Клиенты c on c.ID = j.Client_ID  " +
                                   " WHERE j.ID >=" + id +
                                   " order by d.FID_JOURNAL", cn);
        }

        internal static SqlCommand DeleteIdentityDocuments(int currentClientId, SqlConnection cn)
        {
            return new SqlCommand("DELETE FROM IDENTITY_DOCS WHERE FID_CLIENT = " + currentClientId, cn);
        }

        internal static SqlCommand UpdateClient(int clientId, string clientName, int docType, string requisites, string url, SqlConnection cn)
        {
            if (string.IsNullOrWhiteSpace(clientName) | string.IsNullOrWhiteSpace(requisites) /*| string.IsNullOrWhiteSpace(url)*/)
                return null;

            return new SqlCommand(@"UPDATE Клиенты SET 
                                    ClientName = " + clientName.BeQuoted() + "," +
                                    "FID_DOCTYPE = " + docType + "," +
                                    "REQUISITES = " + requisites.BeQuoted() + "," +
                                    "SCAN_LINK = " + url.BeQuotedFromNullVariation() +
                                    " WHERE ID = " + clientId, cn);
        }

        internal static SqlCommand SelectShortIdentityTypes(SqlConnection dBConnection)
        {
            return new SqlCommand("SELECT [SHORT_IDENTITY_TYPE] FROM [IDENTITY_TYPES]", dBConnection);
        }
        internal static SqlCommand SelectClientRow(int clientId, SqlConnection dBConnection)
        {
            return new SqlCommand(@"SELECT 
                                    [ClientName]
                                   ,[Org_ID]
                                   ,[FID_DOCTYPE]
                                   ,[REQUISITES]
                                   ,[SCAN_LINK]
                                    FROM [Журнал_Main].[dbo].[Клиенты] 
                                    WHERE ID =  " + clientId, dBConnection);
        }

        internal static SqlCommand InsertClient(int orgId, string clientName, int fidDoctype, string requisites, string scanLink, SqlConnection cn)
        {
            return new SqlCommand(@"INSERT INTO Клиенты  (ClientName, Org_ID, FID_DOCTYPE, REQUISITES, SCAN_LINK) 
                                    VALUES (" + clientName.BeQuoted() + ","
                                    + orgId + "," +
                                    fidDoctype + "," +                                   
                                    requisites.BeQuoted()+ "," + 
                                    scanLink.BeQuotedFromNullVariation() + ")"
                                    , cn);
        }

        internal static SqlCommand BlankItems(SqlConnection cn)
        {
            //нет ни одного прикрепленного документа
            return new SqlCommand(@"with fill as (select errorRows = CAST(j.ID as varchar) + 
                CASE 
                WHEN j.TypeDoc = 1 and (d.FID_JOURNAL is null) THEN ' - нет прикрепленных разрешений.' 
                WHEN j.TypeDoc = 2 and (d.FID_JOURNAL is null) THEN ' - нет прикрепленных обращений.' 
                WHEN d.FID_TYPE_DOC = 1 and ((d.TICKET_NUMBER is null OR d.TICKET_NUMBER = '12/') OR (d.TICKET_DATE is null AND j.Cost > 0)) THEN ' - у разрешения '+ d.NUM_RAZRESH +' введены не все реквизиты.'          
                WHEN d.FID_TYPE_DOC = 2 and (d.TICKET_NUMBER = '12/' and j.Cost > 0 and d.CHARGE_DATE is NULL) THEN ' - у обращения не указан номер и дата оплаты.'                
                WHEN d.FID_TYPE_DOC = 2 and (d.TICKET_NUMBER = '12/') THEN ' - у обращения не указан номер.'
                WHEN (j.Cost > 0 and d.CHARGE_DATE is NULL) THEN ' - не введена дата оплаты.'                               
                END 
                from Журнал j left join DOCUMENTS d 
                ON 
                j.ID = d.FID_JOURNAL 
                WHERE 
                j.ID > 17533) select distinct *  from fill where errorRows is not null", cn);
        }

        public static string BeQuoted(this String str)
        {
            return (str != null) ? " '" + str + "' " : null;
        }
        public static string ToSqlDateTime(this DateTime? date)
        {
            if (date != null)
                return date.Value.ToString("yyyy-MM-dd");
            else return null;
        }

        internal static SqlCommand CountOfOrganiztion(string name, SqlConnection dBConnection)
        {
            return new SqlCommand("SELECT COUNT(*) FROM Организации WHERE Название = " + name.BeQuoted(), dBConnection);
        }

        public static string BeQuotedFromNullVariation(this String str)
        {
            if (str != null & str != "")
                return str.BeQuoted();
            else return "NULL";
        }





    }
}
