using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiveO.ViewModels
{
    public class DiveViewModel
    {
        public string DiveSite { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Duration { get; set; }
        public string Depth { get; set; }
        public string Description { get; set; }
        public List<byte[]> Photos { get; set; }
    }
}