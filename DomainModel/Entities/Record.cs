using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Entities
{
    public class Record
    {
        public int IdRecord { get; set; }
        public RecordType RecordType { get; set; }
        public DateTime CreatedDate { get; set; }
        //public Organization Organization { get; set; }
        public Employee Owner { get; set; }
        public Client Client { get; set; }
        public string Memo { get; set; }
        public InfoType InfoType { get; set; }
        public int Cost { get; set; }
        public bool RequireConfirmAct { get; set; }
    }

    public class InfoType
    {
        public int IdInfoType {get;set;}
        public string NameInfoType { get; set; }
    }

    public class Client
    {
        public int IdClient { get; set; }
        public string ClientName { get; set; }

        public Organization ClientOrganization { get; set; }

        public IdentityDocument IdentityDocument { get; set; }    
    }

    public class IdentityDocument
    {
        public int TypeIdentity{ get; set; }
        public string Requisites { get; set; }

        public string ScanLink { get; set; }
    }

    public class Employee
    {
        public int IdEmployee { get;set;}
        public string FirstName { get;set;}
        public string SecondName { get;set;}
        public string ThirdName { get;set;}
        public string Post { get;set;}
        public string ShortName { get; set; }
    }

    public class Organization
    {
        public int IdOrganization { get;set;}
        public string OrganizationName { get;set;}
        public int MainClientId {get;set;}
        public int MapCasesCount {get;set;}
    }

    public class RecordType
    {
        public int IdDocumentType { get; set; }
        public string DescriptionDocumentType { get; set; }
    }
}
   
