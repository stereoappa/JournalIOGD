using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoadOfSql.Infrastructure.Controls;

namespace LoadOfSql.Infrastructure.Controls
{
    public static class ToolStripStatusLabelExtensions
    {
        public static void ShowAttention(this ToolStripStatusLabel statusLabel, List<string> blankRows, Label attensionInfoLabel)
        {
            if (blankRows.Count > 0)
            {
                statusLabel.Visible = true;
                statusLabel.Text = "Есть частично заполненные записи: " + blankRows.Count + " шт.";

               // attensionInfoLabel.Visible = true;
                attensionInfoLabel.Text = string.Empty;
                foreach (string info in blankRows)
                {
                    attensionInfoLabel.Text += info + Environment.NewLine;
                }

                MoveControl.DestructOlder(attensionInfoLabel); //Если ранее был привязан лэйбл с перетаскиванием, то отключим его
                MoveControl.EnableMove(attensionInfoLabel);
            }
            else
            {
                statusLabel.Visible = false;
                attensionInfoLabel.Visible = false;
                statusLabel.Text = "";
            }
        }
    }
}
