using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamityRuTranslate.Core.Config;
using JAtRT.Core.Config;
using Terraria.ID;

public class PrimeReworkGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("PrimeRework") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.PrimeReworkLocalization && Language.ActiveCulture.Name == "ru-RU";

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            // Замена текста предосмотра для баффнутой брони
            if (TRuConfig.Instance.ArmorSetBonusPreview && tooltip.Name == "ArmorSetBonusInfo" && tooltip.Mod == "CalamityRuTranslate")
            {
                if (item.type == ItemID.AdamantiteHeadgear && item.type == ItemID.AdamantiteHelmet && item.type == ItemID.AdamantiteMask)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.PrimeRework.ItemDescriptions.AdamantiteArmor");

                if (item.type == ItemID.CobaltHelmet && item.type == ItemID.CobaltMask && && item.type == ItemID.CobaltNaginata)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.PrimeRework.ItemDescriptions.CobaltArmor");

                if (item.type == ItemID.HallowedHood && item.type == ItemID.AncientHallowedHood)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.PrimeRework.ItemDescriptions.HallowedSummonerArmor");

                if (item.type == ItemID.MythrilHat && item.type == ItemID.MythrilHood && && item.type == ItemID.MythrilHelmet)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.PrimeRework.ItemDescriptions.MythrilArmor");
            }
        }
    }
}