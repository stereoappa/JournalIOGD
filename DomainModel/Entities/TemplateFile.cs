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

        public string GetActualHash()
        {
            return null;
        }
    }

    public class TemplateType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
