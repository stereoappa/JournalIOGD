using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoadOfSql.Domain
{
    public class CostFillingModel
    {
        public CostFillingModel(TextBox tBox, SummingType type, DateTime from, DateTime by)
        {
            TBox = tBox;
            SumType = type;
            From = from;
            By = by;
        }
        public SummingType SumType { get; private set; }
        public TextBox TBox { get; private set; }
        public DateTime From { get; private set; }
        public DateTime By { get; private set; }
    }
}
