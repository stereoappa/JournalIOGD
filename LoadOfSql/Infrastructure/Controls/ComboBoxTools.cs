using LoadOfSql.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoadOfSql.Infrastructure.Controls
{
    static class ComboBoxTools
    {
        public static void FillOrganizations(this ComboBox cb)
        {
            using (SqlConnection cn = new SqlConnection(GlobalSettings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(@"Select Название from Организации where ID not in (33) ORDER BY Название", cn);
                DataTable table = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    da.Fill(table);
                }
                catch
                {
                    MessageBox.Show("Внутренняя ошибка метода заполнения организаций");
                }

                // bs = new BindingSource();
                //bs.DataSource = table;
                cb.DataSource = table;
                cb.DisplayMember = "Название";
            }
        }
        /// <summary>
        ///  Заполнит таблицу Организаций и инстанцировать BS (для живого поиска)
        /// </summary>
        /// <param name="cb">comboBox</param>
        /// <param name="bs">binding source</param>
        public static bool FillOrganizations(this ComboBox cb, BindingSource bs)
        {
            using (SqlConnection cn = new SqlConnection(GlobalSettings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(@"Select ID, Название from Организации /*where ID not in (33)*/ ORDER BY Название", cn);
                DataTable table = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    da.Fill(table);
                }
                catch
                {
                    MessageBox.Show("Внутренняя ошибка метода заполнения организаций");
                    return false;
                }
                cb.ValueMember = "ID";
                cb.DisplayMember = "Название";
                bs.DataSource = table;
                cb.DataSource = table;
                return true;
            }
        }
        public static void FillClients(this ComboBox clCB, BindingSource bs, int orgId)
        {
            using (SqlConnection cn = new SqlConnection(GlobalSettings.ConnectionString))
            {
                // string selectClient = "SELECT ClientName FROM Клиенты WHERE Org_ID = (SELECT MIN(ID) FROM Организации WHERE Организации.Название ='" + orgName + "') ORDER BY ID ";
                string selectClient = @"SELECT cl.ID as CLIENT_ID, cl.ClientName + 
                                               '  ('+ idntype.SHORT_IDENTITY_TYPE
                                               +' – '+ cl.REQUISITES +')' AS ClientInfo
                                               FROM Клиенты cl 
                                               JOIN IDENTITY_TYPES idntype 
                                               on cl.FID_DOCTYPE = idntype.ID
                                               WHERE cl.Org_ID =" + orgId +
                                               " ORDER BY cl.ID";
                DataTable ClientNameOfOrg = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(selectClient, cn);
                try
                {
                    da.Fill(ClientNameOfOrg);
                }
                catch
                {
                    MessageBox.Show("Внутренняя ошибка метода заполнения списка клиентов.");
                }
                clCB.ValueMember = "CLIENT_ID";
                clCB.DisplayMember = "ClientInfo";
                bs.DataSource = ClientNameOfOrg;
                clCB.DataSource = ClientNameOfOrg;
            }
        }
        public static int FillClients(this ComboBox cb, BindingSource bs, int orgId, bool withTopClient)
        {
            cb.FillClients(bs, orgId);

            if (withTopClient)
                if (orgId > 0)
                    using (SqlConnection cn = new SqlConnection(GlobalSettings.ConnectionString))
                    {
                        cn.Open();
                        SqlCommand baseClient = new SqlCommand("SELECT ID FROM Клиенты WHERE ID=(Select ОсновнойКлиент FROM Организации WHERE ID = " + orgId + ")", cn);
                        object baseClientId = baseClient.ExecuteScalar();
                        if (baseClientId != null)
                        {
                            try
                            {
                                cb.SelectedValue = (int)baseClientId;
                            }
                            catch { }
                            return (int)baseClientId;
                        }
                        else
                        {
                            return -1;
                        }
                    }
            return -1;
        }

        public static void FillUnidentifiedClient(this ComboBox clCB, int clientId)
        {
            using (SqlConnection cn = new SqlConnection(GlobalSettings.ConnectionString))
            {
                string unidentifyClient = "SELECT ID as CLIENT_ID, ClientName as ClientInfo FROM Клиенты WHERE ID =" + clientId;
                DataTable unidentifyClientTable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(unidentifyClient, cn);
                try
                {
                    da.Fill(unidentifyClientTable);
                }
                catch
                {
                    MessageBox.Show("Внутренняя ошибка метода заполнения списка клиентов.");
                }
                clCB.ValueMember = "CLIENT_ID";
                clCB.DisplayMember = "ClientInfo";
                clCB.DataSource = unidentifyClientTable;
            }
        }
        public static void FillEmployes(this ComboBox cb)
        {
            using (SqlConnection cn = new SqlConnection(GlobalSettings.ConnectionString))
            {
                string fillEmploy = "Select Фамилия from Сотрудники";

                DataTable table3 = new DataTable();

                SqlDataAdapter da3 = new SqlDataAdapter(fillEmploy, cn);
                da3.Fill(table3);

                cb.DataSource = table3;
                cb.DisplayMember = "Фамилия";
            }
        }

        public static void FillTypeDocs(this ComboBox cb)
        {

            string connStr = GlobalSettings.ConnectionString;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                string fillDocType = "Select Name from ТипДокумента order by ID";
                DataTable table2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(fillDocType, cn);
                da2.Fill(table2);

                cb.DisplayMember = "Name";
                cb.SelectedIndex = -1;
                cb.DataSource = table2;
            }

        }
    }
}
