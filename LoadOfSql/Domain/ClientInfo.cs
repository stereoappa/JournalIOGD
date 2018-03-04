using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoadOfSql.Domain
{
    public class ClientInfo
    {
        public int? Id { get; set; }
        public string ClientName { get; set; }
        public int Org_Id { get; set; }
        public IdentityDocType FidDocType { get; set; }
        public string Requisites { get; set; }
        public string ServerScanLink { get; set; }
        public string LocalScanLink { get; set; }
    }
}
