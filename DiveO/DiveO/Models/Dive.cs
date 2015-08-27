using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiveO.Models
{
    public class Dive
    {
        public int Id { get; set; }
        public string DiveSite { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public double Duration { get; set; }
        public double Depth { get; set; }
        public string Description { get; set; }
        public virtual List<byte> Photos { get; set; } 
    }
}