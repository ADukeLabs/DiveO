using System.ComponentModel;

namespace DiveO.Models.Model_Attributes
{
    public class CertificationLevel
    {
        public enum BeginnerCertification
        {
            [Description("PADI Open Water Diver (OWD)")]
            PadiOpenWaterDiver = 0,
            [Description("SSI Open Water Diver (OWD)")]
            SsiOpenWaterDiver = 1,
            [Description("NAUI Scuba Diver")]
            NauiScubaDiver = 2
        }

        public enum AdvancedCertification
        {
            [Description("PADI Advanced Open Water Diver (AOWD)")]
            PadiAdvancedOpenWaterDiver = 0,
            [Description("SSI Advanced Open Water Diver (AOWD)")]
            SsiAdvancedOpenWaterDiver = 1,
            [Description("NAUI Advanced Scuba Diver (ASD)")]
            NauiAdvancedScubaDiver = 2
        }

        public enum RescueCertification
        {
            [Description("PADI Rescue Diver (RS)")]
            PadiRescueDiver = 0,
            [Description("SSI Diver Stress & Rescue")]
            SSIDiverStressRescue = 1,
            [Description("NAUI Scuba Rescue Diver")]
            NauiScubaRescueDiver = 2
        }

        public enum DiveGuideCertification
        {
            [Description("PADI Divemaster (DM)")]
            PadiDiveMaster = 0,
            [Description("SSI Dive Guide (DG)")]
            SsiDiveGuide = 1,
            [Description("NAUI Divemaster (DM)")]
            NauiDiveMaster = 2
        }

        public enum DiveInstructorCertification
        {
            [Description("PADI Open Water Instructor")]
            PadiOpenWaterInstructor = 0,
            [Description("SSI Open Water Instructor(OWI)")]
            SsiOpenWaterInstructor = 1,
            [Description("NAUI Divemaster (DM)")]
            NauiDiveMaster = 2
        }
    }
}