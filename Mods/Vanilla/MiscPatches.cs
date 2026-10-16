using System.Collections.Generic;
using System.Reflection;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

public partial class MiscPatches : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU";

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            // Thorium
            if (ModLoader.HasMod("ThoriumMod"))
            {
                if (tooltip.Name == "HealerAmount")
                {
                    if (tooltip.Text.Contains("Heals ally life by "))
                        tooltip.Text = tooltip.Text.Replace("Heals ally life by ", "Лечит союзника на ") + " ед. здоровья";

                    if (tooltip.Text.Contains("Heals ally and player life by "))
                        tooltip.Text = tooltip.Text.Replace("Heals ally and player life by ", "Лечит союзника и игрока на ") + " ед. здоровья";

                    if (tooltip.Text.Contains("Steals "))
                    {
                        tooltip.Text = tooltip.Text.Replace("Steals ", "Крадёт ") + " ед. здоровья";
                        tooltip.Text = tooltip.Text.Replace(" life", "");
                    }

                    if (tooltip.Text.Contains("Heals ally life equal to your bonus healing"))
                        tooltip.Text = "Лечит здоровье союзников на величину, равную вашему бонусному исцелению";

                    if (tooltip.Text.Contains("Heals ally and player life equal ") && tooltip.Text.Contains(" Max)"))
                    {
                        tooltip.Text = tooltip.Text.Replace("Heals ally and player life equal to your bonus healing (", "Лечит союзника и игрока на величину, равную вашему бонусному исцелению (максимум ") + " ед.)";
                        tooltip.Text = tooltip.Text.Replace(" Max)", "");
                    }
                }

                if (tooltip.Name == "AccessoryDamage")
                {
                    tooltip.Text = tooltip.Text.Replace("% basic damage", "% базового урона");
                    tooltip.Text = tooltip.Text.Replace("basic damage", "ед. базового урона");
                }
            }

            // ??? (При включении какого-то из модов у реликвий добавился этот текст в строке Master и я решил его перевести)
            if (tooltip.Name == "Master" && tooltip.Text.Contains("Мастер or Revengeance"))
                tooltip.Text = "Мастер или Месть";

            // Thorium Class Tags
            if (ModLoader.HasMod("ThoriumClassTagsConsistency") && tooltip.Name == "ClassTag")
            {
                if (tooltip.Text == Language.GetTextValue("Mods.ThoriumClassTagsConsistency.Misc.WarriorClass"))
                    tooltip.Text = Language.GetTextValue("Mods.JAtRT.Tags.Class.Warrior");

                if (tooltip.Text == Language.GetTextValue("Mods.ThoriumClassTagsConsistency.Misc.RangerClass"))
                    tooltip.Text = Language.GetTextValue("Mods.JAtRT.Tags.Class.Ranger");

                if (tooltip.Text == Language.GetTextValue("Mods.ThoriumClassTagsConsistency.Misc.SorcererClass"))
                    tooltip.Text = Language.GetTextValue("Mods.JAtRT.Tags.Class.Sorcerer");

                if (tooltip.Text == Language.GetTextValue("Mods.ThoriumClassTagsConsistency.Misc.SummonerClass"))
                    tooltip.Text = Language.GetTextValue("Mods.JAtRT.Tags.Class.Summoner");
            }

            // Unofficial Calamity Bard & Healer
            if (ModLoader.HasMod("CalamityBardHealer"))
            {
                bool rogueThrowerMerge = true;

                if (ModLoader.TryGetMod("CalamityBardHealer", out var calBard))
                {
                    var configType = calBard.Code.GetType("BalanceConfig");
                    if (configType != null)
                    {
                        var instanceProp = configType.GetField("Instance", BindingFlags.Static | BindingFlags.Public);
                        var instance = instanceProp?.GetValue(null);

                        rogueThrowerMerge = (bool)(configType.GetField("rogueThrowerMerge")?.GetValue(instance) ?? true);
                    }
                }

                if (rogueThrowerMerge && item.defense <= 0 && !item.accessory && item.DamageType == ModContent.Find<DamageClass>("CalamityMod/RogueDamageClass"))
                {
                    tooltips.RemoveAll(l => l.Text == "-Метатель-");

                    if (tooltip.Text.Contains("-Rogue"))
                        tooltip.Text = "-Разбойник-";
                }
            }
        }

        // Ещё один патч тегов для Thorium Class Tags, меняющий их местоположение в описании
        if (ModLoader.HasMod("ThoriumClassTagsConsistency"))
        {
            if (item.type == ItemID.FlaskofPoison || item.type == ItemID.FlaskofVenom || item.type == ItemID.FlaskofCursedFlames ||
            item.type == ItemID.FlaskofFire || item.type == ItemID.FlaskofGold || item.type == ItemID.FlaskofIchor || item.type == ItemID.FlaskofNanites)
                ItemHelper.ReplaceTooltip(tooltips, mod: "ThoriumClassTagsConsistency", name: "ClassTag", afterName: "ItemName");
        }

        // Патч тегов для Calamity
        if (ModLoader.HasMod("CalamityMod") && ModLoader.HasMod("ThoriumClassTagsConsistency") && JARTClientCfg.Instance.ExtraClassTags)
        {
            if (item.DamageType == ModContent.Find<DamageClass>("CalamityMod/TrueMeleeDamageClass") || item.DamageType == ModContent.Find<DamageClass>("CalamityMod/TrueMeleeNoSpeedDamageClass"))
            {
                if (ModLoader.HasMod("CatalystMod") && item.type == ModContent.Find<ModItem>("CatalystMod/IntergelacticHeadMelee").Type)
                    return;

                else
                    tooltips.RemoveAll((TooltipLine l) => l.Text == Language.GetTextValue("Mods.ThoriumClassTagsConsistency.Misc.WarriorClass"));
            }
        }

        ItemHelper.ReplaceTooltip(tooltips, mod: "JAtRT", name: "VoidTag", afterName: "ItemName");

        if (JARTClientCfg.Instance.CoolerBuffs)
        {
            ItemHelper.ReplaceTooltip(tooltips, mod: "JAtRT", name: "BuffHint", afterMod: "Terraria");
            ItemHelper.ReplaceTooltip(tooltips, mod: "JAtRT", name: "BuffExpand", nameMode: MatchMode.StartsWith, afterMod: "Terraria");
        }
    }
}
