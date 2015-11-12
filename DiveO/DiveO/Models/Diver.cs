using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DiveO.Models.Model_Attributes;

namespace DiveO.Models
{
    public class Diver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] ProfilePic { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public Certification.CertificationLevel Certification { get; set; }
        public virtual ICollection<Dive> DiveLog { get; set; }
    }
}