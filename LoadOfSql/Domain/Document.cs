using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoadOfSql.Domain
{
    public interface ITicket 
    {
        int? FidJournal { get; set; }
        string TicketNumber { get; set; }
        DateTime? TicketDate { get; set; }
        DocType Type { get; }
    }
    public interface IPermission 
    {
        int? FidJournal { get; set; }
        string NumRazresh { get; set; }
        DateTime? DateRazresh { get; set; }
        string TicketNumber { get; set; }
        DateTime? TicketDate { get; set; }
        DocType Type { get; }
    }
    public class Document : ITicket, IPermission
    {
        public Document(DocType type)
        {
            Type = type;
        }
        public int? FidJournal { get; set; }
        public string NumRazresh { get; set; }
        public DateTime? DateRazresh { get; set; }
        public string TicketNumber { get; set; }
        public DateTime? TicketDate { get; set; }
        public DocType Type { get; private set; }
        public DateTime? ChargeDate { get; set; }
    }
    public class ObserveList<T> : List<T>
    {
        public event EventHandler OnAdd;
        public event EventHandler OnClear;

        public void Add(T item)
        {
            if (OnAdd != null)
            {
                OnAdd(this, null);
            }
            base.Add(item);
        }
        public void Clear()
        {
            if (OnClear != null)
            {
                OnClear(this, null);
            }
            base.Clear();
        }
    }
}
