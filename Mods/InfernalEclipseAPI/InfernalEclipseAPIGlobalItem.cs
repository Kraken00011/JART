using System.Collections.Generic;
using System.Globalization;
using JAtRT.Core.Config;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using InfernalEclipseAPI.Content.Items.Lore.Other;
using InfernalEclipseAPI.Content.Items.Accessories;

public partial class InfernalEclipseAPIGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("InfernalEclipseAPI") && JARTLocalizationConf.Instance.InfernalEclipseLocalization;
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            if (tooltip.Name == "CalamityMod:HoldShiftTooltip" && (item.type == ModContent.Find<ModItem>("InfernalEclipseAPI/SoltanBullyingSlip").Type || item.type == ModContent.Find<ModItem>("InfernalEclipseAPI/MysteriousDiary").Type))
            {
                tooltip.Text = "";
            }

            if (tooltip.Name == "CalamityMod:HoldShiftExtensionIndicator" && (item.type == ModContent.Find<ModItem>("InfernalEclipseAPI/SoltanBullyingSlip").Type || item.type == ModContent.Find<ModItem>("InfernalEclipseAPI/MysteriousDiary").Type))
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

            if (item.type == ModContent.Find<ModItem>("InfernalEclipseAPI/Catlight").Type)
                tooltips.RemoveAll((TooltipLine l) => l.Text == "-Воин-" || l.Text == "-Истинный воин-" || l.Text == "-Тяжёлый воин-" || l.Text == "-Друид-" || l.Text == "-Ритуалист-" || l.Text == "-Пустота-");

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