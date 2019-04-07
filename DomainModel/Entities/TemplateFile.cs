using DomainModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Entities
{
    public class TemplateFile
    {
        public byte[] FileData { get; set; }
        public string HashMd5 { get; set; }
        public DateTime LoadedDate { get; set; }
        public TemplateType TemplateType { get; set; }
        public Employee WhoUpload { get; set; }

        public string CalculateHash()
        {
            return Md5Helper.GetMd5Hash(FileData);
        }
    }

    public class TemplateType
    {
        public TemplateTypeId TypeId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    public enum TemplateTypeId
    {
        InformationIssueTemplate = 1
    }
}
