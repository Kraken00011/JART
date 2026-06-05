using System.Collections.Generic;
using System.Globalization;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using JAtRT;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using InfernalEclipseAPI.Content.Items.Lore.SOTS;
using InfernalEclipseAPI.Content.Items.Lore.Other;
using InfernalEclipseAPI.Content.Items.Lore.Thorium;
using InfernalEclipseAPI.Content.Items.Lore.InfernalEclipse;
using InfernalEclipseAPI.Content.Items.Accessories;

public partial class InfernalEclipseAPIGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("InfernalEclipseAPI") && JARTLocalizationConf.Instance.InfernalEclipseLocalization;
    }
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            if (tooltip.Name == "CalamityMod:HoldShiftTooltip" && (item.type == ModContent.ItemType<SoltanBullyingSlip>() || item.type == ModContent.ItemType<MysteriousDiary>()))
            {
                tooltip.Text = "";
            }

            if (tooltip.Name == "CalamityMod:HoldShiftExtensionIndicator" && (item.type == ModContent.ItemType<SoltanBullyingSlip>() || item.type == ModContent.ItemType<MysteriousDiary>()))
            {
                tooltip.Text = "";
            }

            if (ModLoader.HasMod("ThoriumMod"))
            {
                if (item.type == ModContent.Find<ModItem>("ThoriumMod/LifeQuartzClaymore").Type)
                {
                    tooltip.Text = tooltip.Text.Replace("Steals 3 life", "");
                    tooltip.Text = tooltip.Text.Replace("Крадёт 1 ед. здоровья", "Крадёт 3 ед. здоровья");
                }
            }

            if (ModLoader.HasMod("YouBoss") && item.type == ModContent.Find<ModItem>("YouBoss/FirstFractal").Type)
                tooltip.Text = tooltip.Text.Replace("-Сигнатурное оружие вашего отражения-", "-Ваше сигнатурное оружие-");

            if (ModLoader.HasMod("SOTS"))
            {
                if (item.type == ModContent.Find<ModItem>("SOTS/ChallengerRing").Type && tooltip.Name == "Tooltip5")
                {
                    if (tooltip.Text == "Убитые враги имеют 50% шанс оставить дополнительные сердца (100% при критическом ударе)\nСбор сердец продлевает действие активных баффов (вплоть до двойной длительности)")
                        tooltip.Text = "С убитых врагов с 50% шансом могут выпасть дополнительные сердца\nШанс увеличивается до 100%, если враг был убит критическим ударом";
                }
            }
        }
    }
}