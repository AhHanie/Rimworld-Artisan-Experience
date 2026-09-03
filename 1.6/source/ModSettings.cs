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
        public static int ExperiencePerArt = 1000;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref ExperiencePerArt, "experiencePerArt", 1000);
        }
    }
}
