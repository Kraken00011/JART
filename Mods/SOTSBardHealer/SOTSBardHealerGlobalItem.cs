using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using JAtRT.Core.Config;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using SOTSBardHealer.Items;

public partial class SOTSBardHealerGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("SOTSBardHealer") && JARTLocalizationConf.Instance.SOTSBardHealerLocalization;
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        if (item.DamageType == ModContent.Find<DamageClass>("SOTSBardHealer/VoidThrowing"))
        {
            tooltips.RemoveAll((TooltipLine l) => l.Text == "-Воин-" || l.Text == "-Истинный воин-" || l.Text == "-Тяжёлый воин-" || l.Text == "-Друид-" || l.Text == "-Ритуалист-");
        }

        if (ModLoader.HasMod("InfernalEclipseAPI") && ModContent.TryFind<DamageClass>("InfernalEclipseAPI/VoidRogue", out var voidRogue))
        {
            if (item.DamageType == voidRogue)
            {
                tooltips.RemoveAll((TooltipLine l) => l.Text == "-Воин-" || l.Text == "-Истинный воин-" || l.Text == "-Тяжёлый воин-" || l.Text == "-Друид-" || l.Text == "-Ритуалист-");
            }
        }
    }
}