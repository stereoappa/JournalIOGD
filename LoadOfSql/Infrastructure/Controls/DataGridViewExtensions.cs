using LoadOfSql.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoadOfSql.Infrastructure.Controls
{
    public static class DataGridViewExtensions
    {
        public static bool HasValue(this DataGridViewRow row, params int[] columnIndexes)
        {
            //Если нет номера ЗРки, то вся строка теряет смысл - возвращаем false
            if (row.Cells[0].Value == null) return false;
            else if (row.Cells[0].Value?.ToString().Replace(" ", "") == "") return false;

            for (int i = 0; i < columnIndexes.Length; i++)
            {
                if (row.Cells[columnIndexes[i]].CellHasValue() == false)
                    return false;
            }
            //foreach (DataGridViewCell cell in row.Cells)
            //{
            //    if (cell.CellHasValue() == false) return false;
            //}
            return true;
        }
        public static bool CellHasValue(this DataGridViewCell cell)
        {
            if (cell.Value == null)
                return false;

            DateTime parseDate = new DateTime();
            bool tryParseDate = DateTime.TryParse(cell.Value.ToString(), out parseDate);

            return (cell.Value != null) & (cell.Value.ToString() != "") | tryParseDate;
        }


        public static bool RemoveEndingItems(this DataGridViewRowCollection rows, int count)
        {
            if (rows.Count == count)
                return true;

            bool result = false;
            for (int i = rows.Count - 2; i >= count; i--)
            {
                rows.RemoveAt(i);
                result &= true;
            }
            return result;
        }

        public static void RemoveGrayColumn(this DataGridViewRow row)
        {
            //row.Cells.Cast<DataGridViewCell>().Where(c => c.Style.BackColor != System.Drawing.Color.White);
            row.Cells.RemoveAt(2);
            row.Cells.RemoveAt(3);
            //dgvDocs.Rows.Cast<DataGridViewRow>().Select(x => x.DefaultCellStyle.BackColor != System.Drawing.Color.White);
        }
        public static void DisableColumn(this DataGridView dgv, DataGridViewColumn dgvClmn)
        {
            if (dgv.Columns.Contains(dgvClmn))
            {
                int index = dgvClmn.Index;
                DisableColumn(dgv, index);
            }
        }
        public static void EnableColumn(this DataGridView dgv, DataGridViewColumn dgvClmn)
        {
            if (dgv.Columns.Contains(dgvClmn))
            {
                dgv.Columns[dgvClmn.Index].ReadOnly = false;
                dgv.SetColumnColor(dgvClmn.Index, System.Drawing.Color.White);
            }
        }
        public static void DisableColumn(this DataGridView dgv, int index)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[index].CellHasValue())
                {
                    row.Cells[index].Value = null;
                }
            }
            dgv.Columns[index].ReadOnly = true;
            dgv.SetColumnColor(index, System.Drawing.Color.FromArgb(240, 240, 240));
        }
        public static void EnableColumn(this DataGridView dgv, int index)
        {
            dgv.Columns[index].ReadOnly = false;
            dgv.SetColumnColor(index, System.Drawing.Color.White);
        }
       
        public static void SetColumnColor(this DataGridView dgv, int index, System.Drawing.Color color)
        {
            if (index < dgv.Columns.Count)
                dgv.Columns[index].DefaultCellStyle.BackColor = color;
        }
        public static void SortedOff(this DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
