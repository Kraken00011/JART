using System.Collections.Generic;
using Microsoft.Xna.Framework;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using ThrowerUnification;

public partial class ThrowerUnificationGlobalItem : GlobalItem
{
    [JITWhenModsEnabled(new string[] { "ThrowerUnification" })]
    public override bool IsLoadingEnabled(Mod mod)
    {
        return Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.ThrowerUnificationFix && ModLoader.HasMod("ThrowerUnification");
    }
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "ThrowerUnification" && l.Name == "ThrowerTag", tooltip =>
        {
            if (tooltip.Text == "-Thrower-")
            {
                tooltip.Text = "-Метатель-";
            }
        });

        ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "ThrowerUnification" && l.Name == "ThrowerTag", tooltip =>
        {
            if (tooltip.Text == "-Rogue-")
            {
                tooltip.Text = "-Разбойник-";
            }
        });

        ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "ThrowerUnification" && l.Name == "ThrowerTag", tooltip =>
        {
            if (tooltip.Text == "-Malevolent-")
            {
                tooltip.Text = "-Веролом-";
            }
        });

        ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "ThrowerUnification" && l.Name == "ThrowerTag", tooltip =>
        {
            if (tooltip.Text == "-Kinetic-")
            {
                tooltip.Text = "-Кинетик-";
            }
        });

        if (ModLoader.HasMod("SOTSBardHealer"))
        {
            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Thrower)
            {
                ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "Terraria" && l.Name == "Damage", tooltip =>
                {
                    tooltip.Text = tooltip.Text.Replace(" ед. пустотного и разбойного урона", " ед. пустотного и метательного урона");
                });
            }

            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Rogue)
            {
                ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "Terraria" && l.Name == "Damage", tooltip =>
                {
                    tooltip.Text = tooltip.Text.Replace(" ед. пустотного и метательного урона", " ед. пустотного и разбойного урона");
                });
            }

            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Malevolent)
            {
                ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "Terraria" && l.Name == "Damage", tooltip =>
                {
                    tooltip.Text = tooltip.Text.Replace(" ед. пустотного и разбойного урона", " ед. пустотного и вероломного урона");
                    tooltip.Text = tooltip.Text.Replace(" ед. пустотного и метательного урона", " ед. пустотного и вероломного урона");
                });
            }

            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Kinetic)
            {
                ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "Terraria" && l.Name == "Damage", tooltip =>
                {
                    tooltip.Text = tooltip.Text.Replace(" ед. пустотного и разбойного урона", " ед. пустотного и кинетического урона");
                    tooltip.Text = tooltip.Text.Replace(" ед. пустотного и метательного урона", " ед. пустотного и кинетического урона");
                });
            }

            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Custom)
            {
                ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "Terraria" && l.Name == "Damage", tooltip =>
                {
                    tooltip.Text = tooltip.Text.Replace(" ед. пустотного и разбойного урона", $" ед. пустотного и {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()} урона");
                    tooltip.Text = tooltip.Text.Replace(" ед. пустотного и метательного урона", $" ед. пустотного и {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()} урона");
                });
            }
        }

        // Теги моего мода
        if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Thrower)
        {
            ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "JAtRT" && (l.Name == "ThrowerTag" || l.Name == "RogueTag"), tooltip =>
            {
                tooltip.Text = "-Метатель-";
                tooltip.OverrideColor = new Color((int)ThrowerModConfig.Instance.TagR, (int)ThrowerModConfig.Instance.TagG, (int)ThrowerModConfig.Instance.TagB);
            });
        }

        if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Rogue)
        {
            ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "JAtRT" && (l.Name == "ThrowerTag" || l.Name == "RogueTag"), tooltip =>
            {
                tooltip.Text = "-Разбойник-";
                tooltip.OverrideColor = new Color((int)ThrowerModConfig.Instance.TagR, (int)ThrowerModConfig.Instance.TagG, (int)ThrowerModConfig.Instance.TagB);
            });
        }

        if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Malevolent)
        {
            ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "JAtRT" && (l.Name == "ThrowerTag" || l.Name == "RogueTag"), tooltip =>
            {
                tooltip.Text = "-Веролом-";
                tooltip.OverrideColor = new Color((int)ThrowerModConfig.Instance.TagR, (int)ThrowerModConfig.Instance.TagG, (int)ThrowerModConfig.Instance.TagB);
            });
        }

        if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Kinetic)
        {
            ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "JAtRT" && (l.Name == "ThrowerTag" || l.Name == "RogueTag"), tooltip =>
            {
                tooltip.Text = "-Кинетик-";
                tooltip.OverrideColor = new Color((int)ThrowerModConfig.Instance.TagR, (int)ThrowerModConfig.Instance.TagG, (int)ThrowerModConfig.Instance.TagB);
            });
        }

        if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Custom)
        {
            ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "JAtRT" && (l.Name == "ThrowerTag" || l.Name == "RogueTag"), tooltip =>
            {
                tooltip.Text = $"-{ThrowerModConfig.Instance.CustomTooltipOverride}-";
                tooltip.OverrideColor = new Color((int)ThrowerModConfig.Instance.TagR, (int)ThrowerModConfig.Instance.TagG, (int)ThrowerModConfig.Instance.TagB);
            });
        }
    }
}

