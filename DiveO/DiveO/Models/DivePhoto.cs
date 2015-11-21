using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace DiveO.Models
{
    public class DivePhoto
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public string Description { get; set; }
    }
}