using System.Collections.Generic;
using Microsoft.Xna.Framework;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using ThrowerUnification;
using CalamityRuTranslate.Core.Config;

public partial class ThrowerUnificationGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("ThrowerUnification") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.ThrowerUnificationFix;
    
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
                    string num = tooltip.Text.Split(' ')[0];
                    if (TRuConfig.Instance.ColoredDamageTypes)
                    {
                        if (tooltip.Text.Contains("пустотного и"))
                            tooltip.Text = $"[c/7746d7:{num} ед. пустотного и] [c/ffb86c:метательного] [c/7746d7:урона]";
                    }
                    else
                    {
                        if (tooltip.Text.Contains("пустотного и"))
                            tooltip.Text = $"{num} ед. пустотного и метательного урона";
                    }
                });
            }

            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Rogue)
            {
                ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "Terraria" && l.Name == "Damage", tooltip =>
                {
                    string num = tooltip.Text.Split(' ')[0];
                    if (TRuConfig.Instance.ColoredDamageTypes)
                    {
                        if (tooltip.Text.Contains("пустотного и"))
                            tooltip.Text = $"[c/7746d7:{num} ед. пустотного и] [c/ffb86c:разбойного] [c/7746d7:урона]";
                    }
                    else
                    {
                        if (tooltip.Text.Contains("пустотного и"))
                            tooltip.Text = $"{num} ед. пустотного и разбойного урона";
                    }
                });
            }

            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Malevolent)
            {
                ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "Terraria" && l.Name == "Damage", tooltip =>
                {
                    string num = tooltip.Text.Split(' ')[0];
                    if (TRuConfig.Instance.ColoredDamageTypes)
                    {
                        if (tooltip.Text.Contains("пустотного и"))
                            tooltip.Text = $"[c/7746d7:{num} ед. пустотного и] [c/ffb86c:вероломного] [c/7746d7:урона]";
                    }
                    else
                    {
                        if (tooltip.Text.Contains("пустотного и"))
                            tooltip.Text = $"{num} ед. пустотного и вероломного урона";
                    }
                });
            }

            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Kinetic)
            {
                ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "Terraria" && l.Name == "Damage", tooltip =>
                {
                    string num = tooltip.Text.Split(' ')[0];
                    if (TRuConfig.Instance.ColoredDamageTypes)
                    {
                        if (tooltip.Text.Contains("пустотного и"))
                            tooltip.Text = $"[c/7746d7:{num} ед. пустотного и] [c/ffb86c:кинетического] [c/7746d7:урона]";
                    }
                    else
                    {
                        if (tooltip.Text.Contains("пустотного и"))
                            tooltip.Text = $"{num} ед. пустотного и кинетического урона";
                    }
                });
            }

            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Custom)
            {
                ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "Terraria" && l.Name == "Damage", tooltip =>
                {
                    string num = tooltip.Text.Split(' ')[0];
                    string custom = ThrowerModConfig.Instance.CustomTooltipOverride.ToLower();
                    if (TRuConfig.Instance.ColoredDamageTypes)
                    {
                        if (tooltip.Text.Contains("пустотного и"))
                            tooltip.Text = $"[c/7746d7:{num} ед. пустотного и] [c/ffb86c:{custom}] [c/7746d7:урона]";
                    }
                    else
                    {
                        if (tooltip.Text.Contains("пустотного и"))
                            tooltip.Text = $"{num} ед. пустотного и {custom} урона";
                    }
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

