using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DiveO.Models
{
    public class Dive
    {
        public int Id { get; set; }
        public string DiveSite { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public string Duration { get; set; }
        public string Depth { get; set; }
        public string Description { get; set; }
        public virtual List<byte[]> Photos { get; set; }
        public virtual Diver Diver { get; set; }
    }
}