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
        public DateTime Time { get; set; }
        public string Duration { get; set; }
        public string Depth { get; set; }
        public string Description { get; set; }
        public ICollection<DivePhoto> Photos { get; set; }
    }
}