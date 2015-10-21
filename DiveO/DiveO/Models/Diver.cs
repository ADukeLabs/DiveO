﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
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
        public Certification.Cert Certification { get; set; }
        public DateTime CertDate { get; set; }
        public virtual ICollection<Dive> Dives { get; set; }
    }
}