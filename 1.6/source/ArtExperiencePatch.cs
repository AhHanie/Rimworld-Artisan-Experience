using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace Artisan_Experience
{
    [HarmonyPatch(typeof(CompArt), nameof(CompArt.JustCreatedBy))]
    public static class ArtExperiencePatch
    {
        public static void Postfix(Pawn pawn)
        {
            JobDriver curDriver = pawn.jobs.curDriver;
            if (curDriver is JobDriver_DoBill || curDriver is JobDriver_ConstructFinishFrame)
            {
                pawn.skills.Learn(SkillDefOf.Artistic, ModSettings.ExperiencePerArt);
            }
        }
    }
}
