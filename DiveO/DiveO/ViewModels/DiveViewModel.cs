using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiveO.Models;
using DiveO.Models.Model_Attributes;

namespace DiveO.ViewModels
{
    public class DiveViewModel
    {
        public Dive Dive { get; set; }
        public IEnumerable<Dive> DiveList { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
    }
}