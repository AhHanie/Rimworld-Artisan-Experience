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

            string label = string.Format("{0}: {1}", "ArtisanExperience.ExperiencePerArt".Translate(), ModSettings.ExperiencePerArt);

            Rect rowRect = listing.GetRect(30f);
            rowRect.width = RowWidth;

            TextAnchor previousAnchor = Text.Anchor;
            Text.Anchor = TextAnchor.MiddleLeft;
            Widgets.Label(rowRect.LeftPart(LabelPct), label);
            Text.Anchor = previousAnchor;

            float sliderValue = Widgets.HorizontalSlider(rowRect.RightPart(1f - LabelPct), ModSettings.ExperiencePerArt, 0f, MaxExperiencePerArt, middleAlignment: true, roundTo: ExperiencePerArtIncrement);
            ModSettings.ExperiencePerArt = Mathf.RoundToInt(sliderValue);

            listing.Gap(listing.verticalSpacing);
            listing.End();
        }
    }
}
