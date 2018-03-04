using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoadOfSql.Domain
{
    public static class DomainExtensions
    {
        public static string ToStringName(this DocType type)
        {
            switch (type)
            {
                case DocType.Permission: return "Разрешение";
                case DocType.Ticket: return "Обращение";
                case DocType.Not: return "Нет";
            }
            return string.Empty;
        }
        public static DocType GetDocsType(this List<Document> docs)
        {
            if (docs != null)
            {
                if (docs.TrueForAll(d => d.Type == DocType.Permission))
                    return DocType.Permission;
                if (docs.TrueForAll(d => d.Type == DocType.Ticket))
                    return DocType.Ticket;

                throw new Exception("Последовательность документов содержит разнотипные элементы.");
            }
            return DocType.Not;
        }
    }
}
