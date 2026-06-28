using System.Collections.Generic;
using System.Globalization;
using JAtRT.Core.Config;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

public partial class FutureBossesGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("FutureBosses") && JARTLocalizationConf.Instance.FutureBossesLocalization;
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            if (tooltip.Name == "Expert" && item.type == ModContent.Find<ModItem>("FutureBosses/Revenge").Type)
                tooltip.Text = "";
        }
    }
}