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
using PinnacleReforges;

public partial class PinnacleReforgesGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("PinnacleReforges") && JARTLocalizationConf.Instance.PinnacleReforgesLocalization;
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            if (tooltip.Mod == "PinnacleReforges" && tooltip.Name == "PrefixExtra")
            {
                if (item.prefix == 6 || item.prefix == 38 || item.prefix == 81)
                    tooltip.Text = "+3 ед. к пробиванию брони";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Accurate").Type)
                    tooltip.Text = "+5% к точности";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Automatic").Type)
                    tooltip.Text = "Полная автоматизация\nОружие может атаковать самостоятельно";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Burst").Type)
                {
                    string[] parts = tooltip.Text.Split(' ');
                    string burstPrefixTooltip = parts[4];
                    if (int.TryParse(burstPrefixTooltip, out int value))
                    {
                        string valueSuffix = LocalizedText.ApplyPluralization("{^0:атаке;атаки;атак}", value);
                        tooltip.Text = $"Атакует очередями по {item.useAnimation / item.useTime} {valueSuffix} в каждой";
                    }
                }

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Candid").Type)
                    tooltip.Text = "Не выпускает снаряды";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Consistent").Type)
                    tooltip.Text = "Атакует последнего поражённого врага";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Desperate").Type)
                    tooltip.Text = "Враги, поражённые меткой призывателя, постепенно теряют здоровье";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Disciplined").Type)
                    tooltip.Text = "+1 к максимальному количеству стражей";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Disruptive").Type)
                {
                    if (tooltip.Text == "Full auto")
                        tooltip.Text = "Автоатака";

                    if (tooltip.Text == "Weapon needs to rev in order to fire")
                        tooltip.Text = "Перед началом атаки оружие должно разогреться";
                }

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Efficient").Type)
                    tooltip.Text = "+1 к дальности";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Energetic").Type)
                    tooltip.Text = "Постоянное нанесение урона увеличивает скорость восстановления маны";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Explosive").Type)
                    tooltip.Text = "Атаки и снаряды взрываются при попадании по врагу";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Extended").Type)
                    tooltip.Text = "+3 к дальности";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Fatal").Type)
                {
                    if (tooltip.Text == "+7 armor penetration\nDeal more damage against enemies that are low on health")
                        tooltip.Text = "+7 ед. к пробиванию брони\nНаносит больше урона врагам с пониженным здоровьем";

                    if (tooltip.Text == "Does not work on bosses")
                        tooltip.Text = "Не работает на боссах";
                }

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Inaccurate").Type)
                    tooltip.Text = "-30% к точности";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Inefficient").Type)
                    tooltip.Text = "-1 к дальности";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Juxtaposing").Type)
                {
                    if (tooltip.Text == "Occasionally fires three projectiles at once")
                        tooltip.Text = "Иногда выстреливает тремя снарядами за раз";

                    if (tooltip.Text == "Uses more mana during triple shot")
                        tooltip.Text = "Во время тройного выстрела используется больше маны";
                }

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Long").Type)
                    tooltip.Text = "+4 к дальности";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Meditating").Type)
                    tooltip.Text = "+1 ед. к скорости регенерации маны";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Modified").Type)
                    tooltip.Text = "Атаки иногда выстреливают ракетой";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Monstrous").Type)
                    tooltip.Text = "+5 ед. к пробиванию брони";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Optimized").Type)
                    tooltip.Text = "+2 к дальности";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Protective").Type)
                    tooltip.Text = "Увеличивает защиту соразмерно количеству активных стражей";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Rejuvenating").Type)
                    tooltip.Text = "+1 ед. к скорости регенерации здоровья";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Scoped").Type)
                    tooltip.Text = "Нажмите ПКМ, чтобы отдалить\nЧем дольше вы отдаляете перед выстрелом, тем больше увеличивается урон, точность и ускорение снаряда";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Sentient").Type)
                {
                    if (tooltip.Text == "Weapon can attack on its own")
                        tooltip.Text = "Оружие атакует самостоятельно";

                    if (tooltip.Text == "You cannot use the weapon manually")
                        tooltip.Text = "Вы не можете использовать оружие как обычно";
                }

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Unrelenting").Type)
                    tooltip.Text = "Постоянное нанесение урона увеличивает скорость регенерации здоровья";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Unstoppable").Type)
                    tooltip.Text = "Постоянное нанесение урона увеличивает защиту";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Worthless").Type)
                    tooltip.Text = "Этот предмет бесполезен";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Vorpal").Type)
                    tooltip.Text = "Увеличенный урон против боссов";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Zany").Type)
                    tooltip.Text = "Не использует ману";

                if (item.prefix == ModContent.Find<ModPrefix>("PinnacleReforges/Unerring").Type)
                    tooltip.Text = "+100% к точности";
            }
        }

        ItemHelper.ReplaceTooltip(tooltips, "PinnacleReforges", "PrefixExtra", afterMod: "Terraria");
    }
}