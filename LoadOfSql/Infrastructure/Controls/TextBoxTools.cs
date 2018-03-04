using LoadOfSql.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoadOfSql.Infrastructure.Controls
{
    public static class TextBoxTools
    {
        public static void FillSumsOfTextBoxes(this List<CostFillingModel> costModels)
        {
            using (SqlConnection connect = new SqlConnection(GlobalSettings.ConnectionString))
            {
                connect.Open();
                foreach (var model in costModels)
                {
                    SqlCommand cmd = SqlQueryBuilder.SumByDateQuery(model.SumType, model.From, model.By, connect);
                    try
                    {
                        model.TBox.Text = cmd.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        model.TBox.Text = "Ошибка вызова функции";
                    }
                }
            }
        }
    }
}
