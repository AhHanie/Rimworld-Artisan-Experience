using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Artisan_Experience
{
    public class ModSettings : Verse.ModSettings
    {
        public static int ExperienceExcellentOrBelow = 100;
        public static int ExperienceMasterwork = 250;
        public static int ExperienceLegendary = 500;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref ExperienceExcellentOrBelow, "experienceExcellentOrBelow", 100);
            Scribe_Values.Look(ref ExperienceMasterwork, "experienceMasterwork", 250);
            Scribe_Values.Look(ref ExperienceLegendary, "experienceLegendary", 500);
        }
    }
}
