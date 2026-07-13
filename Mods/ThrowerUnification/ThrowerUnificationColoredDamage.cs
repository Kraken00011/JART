using System.Collections.Generic;
using Microsoft.Xna.Framework;
using JAtRT.Core.Config;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using ThrowerUnification;
using CalamityRuTranslate.Core.Config;

public class ThrowerUnificationColoredDamageTypes : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityRuTranslate") && Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("ThrowerUnification");

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            if (tooltip.Name == "Damage" && TRuConfig.Instance.ColoredDamageTypes && item.DamageType == ModContent.Find<DamageClass>("ThrowerUnification/UnitedModdedThrower"))
                tooltip.OverrideColor = new Color((int)ThrowerModConfig.Instance.R, (int)ThrowerModConfig.Instance.G, (int)ThrowerModConfig.Instance.B);
        }
    }
}