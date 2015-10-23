using System;
using System.ComponentModel;
using System.Reflection;

namespace DiveO.Models.Model_Attributes
{
    public static class Certification
    {
        public enum CertificationLevel
        {
            [Description("PADI Open Water Diver (OWD)")]
            PadiOpenWaterDiver,

            [Description("SSI Open Water Diver (OWD)")]
            SsiOpenWaterDiver,

            [Description("NAUI Scuba Diver")]
            NauiScubaDiver,

            [Description("PADI Advanced Open Water Diver (AOWD)")]
            PadiAdvancedOpenWaterDiver,

            [Description("SSI Advanced Open Water Diver (AOWD)")]
            SsiAdvancedOpenWaterDiver,

            [Description("NAUI Advanced Scuba Diver (ASD)")]
            NauiAdvancedScubaDiver,

            [Description("PADI Rescue Diver (RS)")]
            PadiRescueDiver,

            [Description("SSI Diver Stress & Rescue")]
            SSIDiverStressRescue,

            [Description("NAUI Scuba Rescue Diver")]
            NauiScubaRescueDiver,

            [Description("PADI Divemaster (DM)")]
            PadiDiveMaster,

            [Description("SSI Dive Guide (DG)")]
            SsiDiveGuide,

            [Description("NAUI Divemaster (DM)")]
            NauiDiveMaster,

            [Description("PADI Open Water Instructor")]
            PadiOpenWaterInstructor,

            [Description("SSI Open Water Instructor(OWI)")]
            SsiOpenWaterInstructor,
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}