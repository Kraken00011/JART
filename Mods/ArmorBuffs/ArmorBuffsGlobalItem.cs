using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamityRuTranslate.Core.Config;
using JAtRT.Core.Config;
using Terraria.ID;

public class ArmorBuffsGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("ArmorBuffs") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.ArmorBuffsLocalization && Language.ActiveCulture.Name == "ru-RU";

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            // Замена текста предосмотра для баффнутой брони
            if (TRuConfig.Instance.ArmorSetBonusPreview && tooltip.Name == "ArmorSetBonusInfo" && tooltip.Mod == "CalamityRuTranslate")
            {
                if (item.type == ItemID.CopperHelmet)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ArmorBuffs.Sets.Copper");

                if (item.type == ItemID.TinHelmet)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ArmorBuffs.Sets.Tin");

                if (item.type == ItemID.IronHelmet)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ArmorBuffs.Sets.Iron");

                if (item.type == ItemID.LeadHelmet)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ArmorBuffs.Sets.Lead");

                if (item.type == ItemID.SilverHelmet)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ArmorBuffs.Sets.Silver");

                if (item.type == ItemID.TungstenHelmet)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ArmorBuffs.Sets.Tungsten");

                if (item.type == ItemID.GoldHelmet)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ArmorBuffs.Sets.Gold");

                if (item.type == ItemID.EskimoHood || item.type == ItemID.PinkEskimoHood)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ArmorBuffs.Sets.Snow");

                if (item.type == ItemID.NinjaHood || item.type == ItemID.CrystalNinjaHelmet)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ArmorBuffs.Sets.Ninja");

                if (item.type == ItemID.NecroHelmet)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ArmorBuffs.Sets.Necro");

                if (item.type == ItemID.FossilHelm)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ArmorBuffs.Sets.Fossil");

                if (item.type == ItemID.CrimsonHelmet)
                    tooltip.Text += "\n" + Language.GetTextValue("Mods.ArmorBuffs.Sets.Crimson");
            }
        }
    }
}