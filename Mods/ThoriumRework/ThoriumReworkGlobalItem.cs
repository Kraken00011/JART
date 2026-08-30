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
                string titanRework = Language.GetTextValue("Mods.ThoriumRework.ItemDescriptions.TitanArmor");
                string thoriumRework = Language.GetTextValue("Mods.ThoriumRework.ItemDescriptions.ThoriumArmor");
                string ornateRework = Language.GetTextValue("Mods.ThoriumRework.ItemDescriptions.OrnateArmor");

                if (item.type == ModContent.Find<ModItem>("ThoriumMod/TitanHeadgear").Type || item.type == ModContent.Find<ModItem>("ThoriumMod/TitanHelmet").Type
                ||  item.type == ModContent.Find<ModItem>("ThoriumMod/TitanMask").Type)
                {
                    tooltip.Text = tooltip.Text.Replace(
                        Language.GetTextValue("Mods.ThoriumMod.Items.TitanHelmet.SetBonus", 18),
                        Language.GetTextValue("Mods.ThoriumMod.Items.TitanHelmet.SetBonus", 18) + "\n" + titanRework);
                }

                if (item.type == ModContent.Find<ModItem>("ThoriumMod/ThoriumHelmet").Type)
                {
                    tooltip.Text = tooltip.Text.Replace(
                        Language.GetTextValue("Mods.ThoriumMod.Items.ThoriumHelmet.SetBonus", 10),
                        Language.GetTextValue("Mods.ThoriumMod.Items.ThoriumHelmet.SetBonus", 10) + "\n" + thoriumRework);
                }

                if (item.type == ModContent.Find<ModItem>("ThoriumMod/OrnateHat").Type)
                {
                    tooltip.Text = tooltip.Text.Replace(
                        Language.GetTextValue("Mods.ThoriumMod.Items.OrnateHat.SetBonus", 5),
                        Language.GetTextValue("Mods.ThoriumMod.Items.OrnateHat.SetBonus", 5) + "\n" + ornateRework);
                }
            }
        }
    }
}