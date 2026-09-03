using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Artisan_Experience
{
    public static class ModSettingsWindow
    {
        private const float RowWidth = 650f;
        private const float LabelPct = 0.35f;
        private const float MaxExperiencePerArt = 4000f;
        private const float ExperiencePerArtIncrement = 10f;

        public static void Draw(Rect parent)
        {
            Listing_Standard listing = new Listing_Standard();
            listing.Begin(parent);

            ModSettings.ExperienceExcellentOrBelow = DrawExperienceRow(listing, "ArtisanExperience.ExperienceExcellentOrBelow", ModSettings.ExperienceExcellentOrBelow);
            ModSettings.ExperienceMasterwork = DrawExperienceRow(listing, "ArtisanExperience.ExperienceMasterwork", ModSettings.ExperienceMasterwork);
            ModSettings.ExperienceLegendary = DrawExperienceRow(listing, "ArtisanExperience.ExperienceLegendary", ModSettings.ExperienceLegendary);

            listing.Gap(listing.verticalSpacing);
            listing.End();
        }

        private static int DrawExperienceRow(Listing_Standard listing, string translationKey, int currentValue)
        {
            string label = string.Format("{0}: {1}", translationKey.Translate(), currentValue);

            Rect rowRect = listing.GetRect(30f);
            rowRect.width = RowWidth;

            TextAnchor previousAnchor = Text.Anchor;
            Text.Anchor = TextAnchor.MiddleLeft;
            Widgets.Label(rowRect.LeftPart(LabelPct), label);
            Text.Anchor = previousAnchor;

            float sliderValue = Widgets.HorizontalSlider(rowRect.RightPart(1f - LabelPct), currentValue, 0f, MaxExperiencePerArt, middleAlignment: true, roundTo: ExperiencePerArtIncrement);
            return Mathf.RoundToInt(sliderValue);
        }
    }
}
