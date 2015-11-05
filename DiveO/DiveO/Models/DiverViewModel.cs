﻿using DiveO.Models;
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
        public string Location { get; set; }
        public string Description { get; set; }
        public string Certification { get; set; }
        public string CertDate { get; set; }
        public virtual ICollection<Dive> Dives { get; set; }

        public DiverViewModel(Diver diver)
        {
            Name = diver.Name;
            ProfilePic = diver.ProfilePic;
            Location = diver.Location;
            Description = diver.Description;
            Certification = diver.Certification.GetDescription();
            CertDate = diver.CertDate.Date.ToString();
        }
    }
}