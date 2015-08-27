using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiveO.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<byte> Photos { get; set; } 
        public virtual ICollection<Diver> Divers { get; set; }
        public virtual ICollection<Dive> Dives  { get; set; }
    }
}