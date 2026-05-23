using System;
using osu.Framework.Allocation;
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
                    drawableHishigataNote.Spin(hishigataNote.TimePreempt + (hishigataNote.IsFeign ? 200 : 0), RotationDirection.Clockwise);
                }
            };
        }
    }
}
