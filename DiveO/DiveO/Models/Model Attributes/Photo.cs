using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiveO.Models.Model_Attributes
{
    public class Photo
    {
        public int Id { get; set; } 
        public int DiveId { get; set; }
        public byte[] PhotoBytes { get; set; }
    }
}