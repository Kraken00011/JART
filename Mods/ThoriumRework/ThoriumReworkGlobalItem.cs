using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamityRuTranslate.Core.Config;
using JAtRT.Core.Config;

public class ThoriumReworkGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("ThoriumRework") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.ThoriumReworkLocalization && Language.ActiveCulture.Name == "ru-RU";

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            // Замена текста предосмотра для реворкнутой ториумной брони
            if (TRuConfig.Instance.ArmorSetBonusPreview && tooltip.Name == "ArmorSetBonusInfo" && tooltip.Mod == "CalamityRuTranslate")
            {
                if (item.type == ModContent.Find<ModItem>("ThoriumMod/TitanHeadgear").Type || item.type == ModContent.Find<ModItem>("ThoriumMod/TitanHelmet").Type || item.type == ModContent.Find<ModItem>("ThoriumMod/TitanMask").Type)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ThoriumRework.ItemDescriptions.TitanArmor");

                if (item.type == ModContent.Find<ModItem>("ThoriumMod/ThoriumHelmet").Type)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ThoriumRework.ItemDescriptions.ThoriumArmor");

                if (item.type == ModContent.Find<ModItem>("ThoriumMod/OrnateHat").Type)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ThoriumRework.ItemDescriptions.OrnateArmor");
            }
        }
    }
}