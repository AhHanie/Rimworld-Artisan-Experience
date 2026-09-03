using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace Artisan_Experience
{
    [HarmonyPatch(typeof(CompArt), nameof(CompArt.JustCreatedBy))]
    public static class ArtExperiencePatch
    {
        public static void Postfix(CompArt __instance, Pawn pawn)
        {
            JobDriver curDriver = pawn.jobs.curDriver;
            if (curDriver is JobDriver_DoBill || curDriver is JobDriver_ConstructFinishFrame)
            {
                pawn.skills.Learn(SkillDefOf.Artistic, GetExperienceFor(__instance.parent));
            }
        }

        private static int GetExperienceFor(Thing thing)
        {
            if (!thing.TryGetQuality(out QualityCategory quality))
            {
                return ModSettings.ExperienceExcellentOrBelow;
            }

            switch (quality)
            {
                case QualityCategory.Legendary:
                    return ModSettings.ExperienceLegendary;
                case QualityCategory.Masterwork:
                    return ModSettings.ExperienceMasterwork;
                default:
                    return ModSettings.ExperienceExcellentOrBelow;
            }
        }
    }
}
