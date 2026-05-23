using System;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Hishigata.Localisation.Mods;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osuTK;
using osuTK.Graphics;
using ManagedBass.Fx;

namespace osu.Game.Rulesets.Hishigata.Mods
{
    public class HishigataModApproachDifferent : Mod, IApplicableToDrawableHitObject
    {
        public override string Name => "Approach Different";
        public override string Acronym => "AD";
        public override LocalisableString Description => HishigataModUntrustworthyStrings.ModDescription;
        public override double ScoreMultiplier => 1.0;
        public override ModType Type => ModType.Fun;
        //Mod Icon currently looks ugly and does not fit in properly with other Icons, so needs updating.
        //public override IconUsage? Icon => FontAwesome.Solid.Exclamation;
        //public override Type[] IncompatibleMods => new[] { typeof(HishigataModTrustworthy), typeof(HishigataModInvert) };

        public void ApplyToDrawableHitObject(DrawableHitObject drawableHitObject)
        {
            drawableHitObject.ApplyCustomUpdateState += (drawableHitObject, _) =>
            {
                if (drawableHitObject is DrawableHishigataNote drawableHishigataNote)
                {
                    HishigataNote hishigataNote = drawableHishigataNote.HitObject;
                    if (hishigataNote.IsFeign)
                    {
                        drawableHishigataNote.ClearTransforms();
                        drawableHishigataNote.RotateTo(0).FadeColour(Color4Extensions.FromHex("ff0064")).Then().RotateTo(90, hishigataNote.TimePreempt * .5).Delay(hishigataNote.TimePreempt * .5).Then().RotateTo(270, 200).FadeColour(Color4.White, 200).Delay(200).Then().RotateTo(360, hishigataNote.TimePreempt * .5);
                    }
                    else
                    {
                        drawableHishigataNote.RotateTo(180).Then().RotateTo(360, hishigataNote.TimePreempt);
                    }
                }
            };
        }
    }
}
