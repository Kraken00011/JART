using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Accessories;
using ContinentOfJourney.Items;
using ContinentOfJourney.Items.Accessories;
using ContinentOfJourney.Items.Accessories.SummonerRings;
using ContinentOfJourney.Items.ThrowerWeapons;
using ContinentOfJourney;

public partial class HomewardRagnarokGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("HomewardRagnarok");
    
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        if (item.type == ModContent.ItemType<MapleMushroom>() || item.type == ModContent.ItemType<HoneyMushroom>() 
        || item.type == ModContent.ItemType<JellyMushroom>() || item.type == ModContent.ItemType<FungusDeluxe>()
        || item.type == ModContent.ItemType<SpikyCover>())
            tooltips.RemoveAll((TooltipLine t) => t.Name == "Tooltip0");
            
        // Gray Rook
        if (item.type == ModContent.ItemType<GrayRook>())
        {
            ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "Bard", afterName: "Tooltip5");
            ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "Healer", afterName: "Bard");
            ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "Rogue", afterName: "Healer");
            ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "Rebalance1", afterName: "Rogue");
        }

        // Cactus Ball
        if (item.type == ModContent.ItemType<ItemCactusBall>())
        {
            ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "PoisonEffect", afterName: "Tooltip0");
        }

        // Star Eater Staff
        if (item.type == ModContent.ItemType<StarEaterStaff>())
        {
            ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "HolyFlamesEffect", afterName: "Tooltip0");
        }

        // Fission
        if (item.type == ModContent.ItemType<Fission>())
        {
            ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "Vaporfied", afterMod: "Terraria");
        }

        // Batter and Batter Cap
        if (item.type == ModContent.ItemType<TheBatter>()
        || item.type == ModContent.ItemType<BatterCap>() || item.type == ModContent.ItemType<SteadyCap>()
        || item.type == ModContent.ItemType<CatchersGlove>() || item.type == ModContent.ItemType<RunnersLegging>() || item.type == ModContent.ItemType<Epsilon>()
        || item.type == ModContent.ItemType<Alpha>() || item.type == ModContent.ItemType<Omega>()
        || item.type == ModContent.ItemType<TheHolyTrinity>() || item.type == ModContent.ItemType<FatherAndSon>() || item.type == ModContent.ItemType<RedCube>())
        {
            ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "Terraria", tooltip =>
            {
                tooltip.Text = tooltip.Text.Replace("расходуемых дистанционных", "метательных");
                tooltip.Text = tooltip.Text.Replace("Уменьшает", "Снижает");
                tooltip.Text = tooltip.Text.Replace("дистанционные", "метательные");
                tooltip.Text = tooltip.Text.Replace("дистанционный", "метательный");
                tooltip.Text = tooltip.Text.Replace("расходуемые оружия дальнего боя", "метательное оружие");
                tooltip.Text = tooltip.Text.Replace("метательные дистанционные", "метательные");
                tooltip.Text = tooltip.Text.Replace("дистанционное", "метательное");
                tooltip.Text = tooltip.Text.Replace("оружия дальнего боя", "метательные оружия");
            });
        }

        if (ModLoader.HasMod("ThoriumMod"))
        {
            // Alloy Cross
            if (item.type == ModContent.ItemType<AlloyCross>())
            {
                tooltips.RemoveAll((TooltipLine l) => l.Text.Contains("Восстанавливает здоровье члена вашей команды с наименьшим здоровьем на 11") || l.Text.Contains("после каждой седьмой магической атаки") || l.Text.Contains("Уменьшает магический урон на 22%"));
                ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "AlloyCrossPatch1", afterMod: "Terraria");
            }

            // Biomatter Cross
            if (item.type == ModContent.ItemType<BiomatterCross>())
            {
                tooltips.RemoveAll((TooltipLine l) => l.Text.Contains("Уменьшает магический урон на 20%") || l.Text.Contains("Восстанавливает здоровье члена вашей команды с наименьшим здоровьем на 5") || l.Text.Contains("после каждой четвертой магической атаки"));
                ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "BiomatterCrossPatch1", afterMod: "Terraria");
            }

            // Cross of the Flaming Swords
            if (item.type == ModContent.ItemType<CrossOfTheFlamingSwords>())
            {
                tooltips.RemoveAll((TooltipLine l) => l.Text.Contains("Уменьшает магический урон на 10%") || l.Text.Contains("после каждой десятой магической атаки") || l.Text.Contains("Восстанавливает здоровье члена вашей команды с наименьшим здоровьем на 10"));
                ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "FlamingCrossPatch1", afterMod: "Terraria");
            }

            // Mythril Cross
            if (item.type == ModContent.ItemType<MythrilCross>())
            {
                tooltips.RemoveAll((TooltipLine l) => l.Text.Contains("Уменьшает магический урон на 15%") || l.Text.Contains("после каждой седьмой магической атаки") || l.Text.Contains("Восстанавливает здоровье члена вашей команды с наименьшим здоровьем на 8"));
                ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "MythrilCrossPatch1", afterMod: "Terraria");
            }

            // Orichalcum Cross
            if (item.type == ModContent.ItemType<OrichalcumCross>())
            {
                tooltips.RemoveAll((TooltipLine l) => l.Text.Contains("Уменьшает магический урон на 14%") || l.Text.Contains("после каждой седьмой магической атаки") || l.Text.Contains("Восстанавливает здоровье члена вашей команды с наименьшим здоровьем на 8"));
                ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "OrichalcumCrossPatch", afterMod: "Terraria");
            }

            // Undying Cross
            if (item.type == ModContent.ItemType<UndyingCross>())
            {
                tooltips.RemoveAll((TooltipLine l) => l.Text.Contains("Уменьшает магический урон на 30%") || l.Text.Contains("после каждой пятой магической атаки") || l.Text.Contains("Восстанавливает здоровье члена вашей команды с наименьшим здоровьем на 8") || l.Text.Contains("Дает невосприимчивость к Священному огню"));
                ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "UndyingCrossPatch1", afterMod: "Terraria");
            }

            // Tungsten Cross
            if (item.type == ModContent.ItemType<TungstenCross>())
            {
                tooltips.RemoveAll((TooltipLine l) => l.Text.Contains("Уменьшает магический урон на 7%") || l.Text.Contains("после каждой шестой магической атаки") || l.Text.Contains("Восстанавливает здоровье члена вашей команды с наименьшим здоровьем на 8"));
                ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "TungstenCrossPatch1", afterMod: "Terraria");
            }

            // Silver Cross
            if (item.type == ModContent.ItemType<SilverCross>())
            {
                tooltips.RemoveAll((TooltipLine l) => l.Text.Contains("Уменьшает магический урон на 8%") || l.Text.Contains("после каждой восьмой магической атаки") || l.Text.Contains("Восстанавливает здоровье члена вашей команды с наименьшим здоровьем на 6"));
                ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "SilverCrossPatch1", afterMod: "Terraria");
            }

            // Wooden Cross
            if (item.type == ModContent.ItemType<WoodenCross>())
            {
                tooltips.RemoveAll((TooltipLine l) => l.Text.Contains("Уменьшает магический урон на 5%") || l.Text.Contains("после каждой восьмой магической атаки") || l.Text.Contains("Восстанавливает здоровье члена вашей команды с наименьшим здоровьем на 4"));
                ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "WoodenCrossPatch1", afterMod: "Terraria");
            }

            // Rejuvenated Cross
            if (item.type == ModContent.ItemType<RejuvenatedCross>())
            {
                tooltips.RemoveAll((TooltipLine l) => l.Text.Contains("Уменьшает магический урон на 20%") || l.Text.Contains("после каждой пятой магической атаки") || l.Text.Contains("Дает регенерацию члену вашей команды с наименьшим здоровьем"));
                ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "RejuvenatedCrossPatch1", afterMod: "Terraria");
            }

            // Fungus Deluxe
            ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "ThoriumHealerBonus", afterMod: "Terraria");
        }

        // Not Consumable
        if (item.type == ModContent.ItemType<PurpleFlareGun>() || item.type == ModContent.ItemType<MaliciousPacket>()
        || item.type == ModContent.ItemType<CannedSoulofFlight>() || item.type == ModContent.ItemType<UnstableGlobe>()
        || item.type == ModContent.ItemType<MetalSpine>() || item.type == ModContent.ItemType<UltimateTorch>() || item.type == ModContent.ItemType<SunlightCrown>())
        {
            ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "NonConsumableInfo", "Не расходуется", afterMod: "Terraria");
        }

        // Spiky Cover
        if (item.type == ModContent.ItemType<SpikyCover>())
        {
            ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "SpikyCoverRework", afterMod: "Terraria");
        }

        // Battalion Backup
        if (item.type == ModContent.ItemType<BattalionsBackup>())
        {
            ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "Terraria", tooltip =>
            {
                tooltip.Text = tooltip.Text.Replace("и защиту на 2", "и защиту на 1");
                tooltip.Text = tooltip.Text.Replace("получаемого урона на 70%", "получаемого урона 20%");
                tooltip.Text = tooltip.Text.Replace("30", "15");
            });
        }

        // Whale Bone Charm
        ItemHelper.ReplaceTooltip(tooltips, "HomewardRagnarok", "WhaleBoneCharmRebalance", "Работает только во время битвы с Вечно падающим китом или Часовым", afterMod: "Terraria");
    }
}
