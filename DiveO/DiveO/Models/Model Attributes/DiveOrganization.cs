using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DiveO.Models.Model_Attributes
{
    public class Organization
    {
        public enum DiveOrganization
        {
            [Description("PADI")]
            Padi = 0,
            [Description("SSI")]
            Ssi = 1,
            [Description("NAUI")]
            Naui = 2
        }
    }
}