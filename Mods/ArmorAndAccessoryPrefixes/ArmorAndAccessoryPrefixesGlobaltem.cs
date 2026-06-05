using System.Collections.Generic;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace JAtRT.Mods.ArmorAndAccessoryPrefixes;

[JITWhenModsEnabled(new string[] { "ArmorAndAccessoryPrefixes" })]
public partial class ArmorAndAccessoryPrefixesGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("ArmorAndAccessoryPrefixes") && JARTLocalizationConf.Instance.ArmorAndAccessoryPrefixesLocalization;
    }
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "ArmorAndAccessoryPrefixes" && l.Name == "PrefixSpellbound", tooltip =>
        {
            string[] parts = tooltip.Text.Split(' ');
            if (tooltip.Text == $"Даёт {parts[1]} шанс не использовать боеприпасы")
            {
                tooltip.Text = $"+{parts[1]} к шансу не потратить боеприпасы";
            }
        });
    }
}