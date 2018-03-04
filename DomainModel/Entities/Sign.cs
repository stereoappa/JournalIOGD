using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace DomainModel.Entities
{
    public class Sign
    {
        public int Id { get; set; }
        public Employee  Owner { get; set; }
        public byte[] SignImage { get; set; }
        public bool IsActive { get; set; }

        public Bitmap GetBitmapSign()
        {
            using (var ms = new MemoryStream(SignImage))
            {
                return new Bitmap(ms);
            }
        }
    }
}
