using System.Collections.Generic;
using System.Reflection;
using System.Globalization;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

public partial class Patches : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU";

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            // Патч для Thorium
            if (ModLoader.HasMod("ThoriumMod"))
            {
                if (tooltip.Name == "ScytheSoulCharge")
                {
                    string[] parts = tooltip.Text.Split(' ');
                    string scytheSoulCharge = parts[1];
                    if (int.TryParse(scytheSoulCharge, out int value))
                    {
                        string valueSuffix = LocalizedText.ApplyPluralization("{^0:эссенцию;эссенции;эссенций}", value);
                        tooltip.Text = $"Даёт {scytheSoulCharge} {valueSuffix} души при прямом попадании";
                    }
                }

                if (tooltip.Name == "HealerAmount")
                {
                    if (!ModLoader.HasMod("NoxusBossRu")) // Почему-то именно с RUnion тут конфликт
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
                    }
                }

                if (tooltip.Name == "HealerTag" && (tooltip.Text == "-Healer Class-" || tooltip.Text == "-Целитель-"))
                    tooltip.Text = "-Целитель-";

                if (tooltip.Name == "ThrowerTag" && (tooltip.Text == "-Thrower Class-" || tooltip.Text == "-Метатель-"))
                    tooltip.Text = "-Метатель-";
            }

            // Патч для ??? (При включении какого-то из модов у реликвий добавился этот текст в строке Master и я решил его перевести)
            if (tooltip.Name == "Master" && tooltip.Text.Contains("Мастер or Revengeance"))
                tooltip.Text = "Мастер или Месть";

            // Патч для Thorium Class Tags
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
        }

        // Ещё один патч тегов для Thorium Class Tags, меняющий их местоположение в тултипе
        if (ModLoader.HasMod("ThoriumClassTagsConsistency"))
        {
            if (item.type == ItemID.FlaskofPoison || item.type == ItemID.FlaskofVenom || item.type == ItemID.FlaskofCursedFlames ||
            item.type == ItemID.FlaskofFire || item.type == ItemID.FlaskofGold || item.type == ItemID.FlaskofIchor || item.type == ItemID.FlaskofNanites)
                ItemHelper.ReplaceTooltip(tooltips, "ThoriumClassTagsConsistency", "ClassTag", afterName: "ItemName");
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

        // Патч тегов для Unofficial Calamity Bard & Healer
        if (ModLoader.HasMod("CalamityBardHealer"))
        {
            bool rogueThrowerMerge = true;

            if (ModLoader.TryGetMod("CalamityBardHealer", out var calamityBard))
            {
                var configType = calamityBard.Code.GetType("BalanceConfig");
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

                ItemHelper.TranslateTooltip(tooltips, l => l.Text == "-Rogue Class-", tooltip =>
                    tooltip.Text = tooltip.Text.Replace("-Rogue Class-", "-Разбойник-"));
            }
        }

        ItemHelper.ReplaceTooltip(tooltips, "JAtRT", "VoidTag", afterName: "ItemName");
    }
}
