using DiveO.Models;
using DiveO.Models.Model_Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static DiveO.Models.Model_Attributes.Certification;

namespace DiveO.ViewModels
{
    public class DiverViewModel
    {
        public string Name { get; set; }
        public byte[] ProfilePic { get; set; }
        public string HomeBase { get; set; }
        public string Description { get; set; }
        public string Certification { get; set; }
        public virtual ICollection<Dive> Dives { get; set; }
        public IEnumerable<ApplicationUser> Friends { get; set; }
    }
}