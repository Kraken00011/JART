using System.Collections.Generic;
using JAtRT.Core.Config;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

public partial class AccessoryHeartsGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("AccessoryHearts") && JARTLocalizationConf.Instance.AccessoryHeartsLocalization;
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            if (tooltip.Mod == "AccessoryHearts")
            {
                if (tooltip.Name == "AccessorySlotText")
                {
                    if (item.type == ModContent.Find<ModItem>("AccessoryHearts/CelestialHeart").Type
                    || item.type == ModContent.Find<ModItem>("AccessoryHearts/HeartOfNature").Type
                    || item.type == ModContent.Find<ModItem>("AccessoryHearts/YharonsHeart").Type)
                    {
                        tooltip.Text = "Навсегда увеличивает количество слотов для аксессуаров";
                    }

                    if (item.type == ModContent.Find<ModItem>("AccessoryHearts/HeartOfTerraria").Type)
                        tooltip.Text = "Навсегда увеличивает количество слотов для аксессуаров на 5";
                }

                if (tooltip.Name == "FlavorText")
                {
                    if (item.type == ModContent.Find<ModItem>("AccessoryHearts/CelestialHeart").Type)
                        tooltip.Text = "Фрагмент космоса, бьющийся с невероятной силой.";

                    if (item.type == ModContent.Find<ModItem>("AccessoryHearts/HeartOfNature").Type)
                        tooltip.Text = "Жизненная сила джунглей так и сочится из него.";

                    if (item.type == ModContent.Find<ModItem>("AccessoryHearts/HeartOfTerraria").Type)
                        tooltip.Text = "Настоящее испытание силы воли";

                    if (item.type == ModContent.Find<ModItem>("AccessoryHearts/YharonsHeart").Type)
                        tooltip.Text = "Оно пылает яростью дракона, обманувшего смерть.";
                }

                if (tooltip.Name == "ConditionText" && item.type == ModContent.Find<ModItem>("AccessoryHearts/HeartOfTerraria").Type)
                {
                    if (tooltip.Text == "A heart has been consumed. How virtueless...")
                        tooltip.Text = "Сердце было использовано. Похоже вам всё-таки не хватило силы воли...";

                    if (tooltip.Text == "Your virtue is truly remarkable")
                        tooltip.Text = "Ваша сила воли действительно поражает.";
                }
            }
        }
    }
}