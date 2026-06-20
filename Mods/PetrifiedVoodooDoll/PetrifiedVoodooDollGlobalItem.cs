using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

public partial class PetrifiedVoodooDollGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("PetrifiedVoodooDoll") && JARTLocalizationConf.Instance.PetrifiedVoodooDollLocalization;
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            if (tooltip.Mod == "PetrifiedVoodooDoll")
            {
                tooltips.RemoveAll((TooltipLine t) => t.Text.Contains("Summons Wall of Flesh if thrown into lava in the underworld while the Guide is alive"));

                tooltips.RemoveAll((TooltipLine t) => t.Text.Contains("While equipped, summons Skeletron when the Clothier is killed during nighttime\nEnrages during the day"));
            }
        }
    }
}