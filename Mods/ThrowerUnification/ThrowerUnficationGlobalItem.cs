using System.Collections.Generic;
using Microsoft.Xna.Framework;
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
        foreach (TooltipLine tooltip in tooltips)
        {
            if (tooltip.Mod == "ThrowerUnification" && tooltip.Name == "ThrowerTag")
            {
                if (tooltip.Text == "-Thrower-")
                    tooltip.Text = "-Метатель-";

                if (tooltip.Text == "-Rogue-")
                    tooltip.Text = "-Разбойник-";

                if (tooltip.Text == "-Malevolent-")
                    tooltip.Text = "-Веролом-";

                if (tooltip.Text == "-Kinetic-")
                    tooltip.Text = "-Кинетик-";
            }

            if (ModLoader.HasMod("SOTSBardHealer"))
            {
                string RgbToHex(int r, int g, int b) => $"{r:X2}{g:X2}{b:X2}";
                string color = RgbToHex((int)ThrowerModConfig.Instance.R, (int)ThrowerModConfig.Instance.G, (int)ThrowerModConfig.Instance.B);

                if (item.DamageType == ModContent.Find<DamageClass>("SOTSBardHealer/VoidThrowing") || (ModLoader.HasMod("InfernalEclipseAPI") && item.DamageType == ModContent.Find<DamageClass>("InfernalEclipseAPI/VoidRogue")))
                {
                    if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Thrower && tooltip.Mod == "Terraria" && tooltip.Name == "Damage")
                    {
                        string num = tooltip.Text.Split(' ')[0];
                        if (TRuConfig.Instance.ColoredDamageTypes)
                        {
                            tooltip.Text = $"{num} ед. пустотного и [c/{color}:метательного] [c/7746d7:урона]";
                        }
                        else
                        {
                            tooltip.Text = $"{num} ед. пустотного и метательного урона";
                        }
                    }

                    if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Rogue && tooltip.Mod == "Terraria" && tooltip.Name == "Damage")
                    {
                        string num = tooltip.Text.Split(' ')[0];
                        if (TRuConfig.Instance.ColoredDamageTypes)
                        {
                            tooltip.Text = $"{num} ед. пустотного и [c/{color}:разбойного] [c/7746d7:урона]";
                        }
                        else
                        {
                            tooltip.Text = $"{num} ед. пустотного и разбойного урона";
                        }
                    }

                    if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Malevolent && tooltip.Mod == "Terraria" && tooltip.Name == "Damage")
                    {
                        string num = tooltip.Text.Split(' ')[0];
                        if (TRuConfig.Instance.ColoredDamageTypes)
                        {
                            tooltip.Text = $"{num} ед. пустотного и [c/{color}:вероломного] [c/7746d7:урона]";
                        }
                        else
                        {
                            tooltip.Text = $"{num} ед. пустотного и вероломного урона";
                        }
                    }

                    if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Kinetic && tooltip.Mod == "Terraria" && tooltip.Name == "Damage")
                    {
                        string num = tooltip.Text.Split(' ')[0];
                        if (TRuConfig.Instance.ColoredDamageTypes)
                        {
                            tooltip.Text = $"{num} ед. пустотного и [c/{color}:кинетического] [c/7746d7:урона]";
                        }
                        else
                        {
                            tooltip.Text = $"{num} ед. пустотного и кинетического урона";
                        }
                    }

                    if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Custom && tooltip.Mod == "Terraria" && tooltip.Name == "Damage")
                    {
                        string num = tooltip.Text.Split(' ')[0];
                        string custom = ThrowerModConfig.Instance.CustomTooltipOverride.ToLower();
                        if (TRuConfig.Instance.ColoredDamageTypes)
                        {
                            tooltip.Text = $"{num} ед. пустотного и [c/{color}:{custom}] [c/7746d7:урона]";
                        }
                        else
                        {
                            tooltip.Text = $"{num} ед. пустотного и {custom} урона";
                        }
                    }
                }
            }

            // Теги моего мода
            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Thrower)
            {
                if (tooltip.Mod == "JAtRT" && (tooltip.Name == "ThrowerTag" || tooltip.Name == "RogueTag"))
                {
                    tooltip.Text = "-Метатель-";
                    tooltip.OverrideColor = new Color((int)ThrowerModConfig.Instance.TagR, (int)ThrowerModConfig.Instance.TagG, (int)ThrowerModConfig.Instance.TagB);
                }
            }

            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Rogue)
            {
                if (tooltip.Mod == "JAtRT" && (tooltip.Name == "ThrowerTag" || tooltip.Name == "RogueTag"))
                {
                    tooltip.Text = "-Разбойник-";
                    tooltip.OverrideColor = new Color((int)ThrowerModConfig.Instance.TagR, (int)ThrowerModConfig.Instance.TagG, (int)ThrowerModConfig.Instance.TagB);
                }
            }

            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Malevolent)
            {
                if (tooltip.Mod == "JAtRT" && (tooltip.Name == "ThrowerTag" || tooltip.Name == "RogueTag"))
                {
                    tooltip.Text = "-Веролом-";
                    tooltip.OverrideColor = new Color((int)ThrowerModConfig.Instance.TagR, (int)ThrowerModConfig.Instance.TagG, (int)ThrowerModConfig.Instance.TagB);
                }
            }

            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Kinetic)
            {
                if (tooltip.Mod == "JAtRT" && (tooltip.Name == "ThrowerTag" || tooltip.Name == "RogueTag"))
                {
                    tooltip.Text = "-Кинетик-";
                    tooltip.OverrideColor = new Color((int)ThrowerModConfig.Instance.TagR, (int)ThrowerModConfig.Instance.TagG, (int)ThrowerModConfig.Instance.TagB);
                }
            }

            if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Custom)
            {
                if (tooltip.Mod == "JAtRT" && (tooltip.Name == "ThrowerTag" || tooltip.Name == "RogueTag"))
                {
                    tooltip.Text = $"-{ThrowerModConfig.Instance.CustomTooltipOverride}-";
                    tooltip.OverrideColor = new Color((int)ThrowerModConfig.Instance.TagR, (int)ThrowerModConfig.Instance.TagG, (int)ThrowerModConfig.Instance.TagB);
                }
            }
        }
    }
}