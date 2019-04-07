using DomainModel.Entities;
using LoadOfSql.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoadOfSql.Infrastructure.Controls
{
    public static class LinkLabelTools
    {
        public static void SetLingvaDefinitionFor(this LinkLabel linkLabel, List<Document> docs)
        {
            //docs = docs.Where(d => d.Type == DocType.Permission).ToList();

            if (docs == null)
            {
                linkLabel.Visible = false;
                return;
            }

            string strCount = "";
            if (docs.Count == 1)
                strCount = " документ";
            else if (docs.Count % 10 > 1 & docs.Count % 10 < 5)
                strCount = " документа";
            else strCount = " документов";

            linkLabel.Text = docs.Count.ToString() + strCount;
            linkLabel.Visible = true;
        }
        public static void HideDefinition(this LinkLabel linkLabel)
        {
            linkLabel.Visible = false;
        }
    }
}
