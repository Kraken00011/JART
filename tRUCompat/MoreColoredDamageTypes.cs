using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamityRuTranslate.Core.Config;

public class MoreColoredDamageTypes : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityRuTranslate") && Language.ActiveCulture.Name == "ru-RU";

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            if (tooltip.Name == "Damage" && TRuConfig.Instance.ColoredDamageTypes)
            {
                // IEoR
                if (ModLoader.HasMod("InfernalEclipseAPI"))
                {
                    ModContent.TryFind<DamageClass>("InfernalEclipseAPI/LegendaryMelee", out var legendaryMelee);
                    ModContent.TryFind<DamageClass>("InfernalEclipseAPI/LegendaryRanged", out var legendaryRanged);
                    ModContent.TryFind<DamageClass>("InfernalEclipseAPI/LegendaryMagic", out var legendaryMagic);
                    ModContent.TryFind<DamageClass>("InfernalEclipseAPI/LegendarySummon", out var legendarySummon);
                    ModContent.TryFind<DamageClass>("InfernalEclipseAPI/LegendarySummonMeleeSpeed", out var legendarySummonMeleeSpeed);

                    if (item.DamageType == legendaryMelee || item.DamageType == legendaryRanged || item.DamageType == legendaryMagic || item.DamageType == legendarySummon || item.DamageType == legendarySummonMeleeSpeed)
                        tooltip.OverrideColor = new Color(255, 211, 0);

                    ModContent.TryFind<DamageClass>("InfernalEclipseAPI/MythicMelee", out var mythicMelee);
                    ModContent.TryFind<DamageClass>("InfernalEclipseAPI/MythicRanged", out var mythicRanged);
                    ModContent.TryFind<DamageClass>("InfernalEclipseAPI/MythicMagic", out var mythicMagic);
                    ModContent.TryFind<DamageClass>("InfernalEclipseAPI/MythicSummon", out var mythicSummon);

                    if (item.DamageType == mythicMelee || item.DamageType == mythicRanged || item.DamageType == mythicMagic || item.DamageType == mythicSummon)
                        tooltip.OverrideColor = new Color(0, 250, 154);

                    if (ModContent.TryFind<DamageClass>("InfernalEclipseAPI/VoidRogue", out var voidRogue) && item.DamageType == voidRogue)
                        tooltip.OverrideColor = new Color(119, 70, 215);
                }

                // SOTS
                if (ModLoader.HasMod("SOTS"))
                {
                    ModContent.TryFind<DamageClass>("SOTS/VoidMelee", out var voidMelee);
                    ModContent.TryFind<DamageClass>("SOTS/VoidRanged", out var voidRanged);
                    ModContent.TryFind<DamageClass>("SOTS/VoidMagic", out var voidMagic);
                    ModContent.TryFind<DamageClass>("SOTS/VoidSummon", out var voidSummon);

                    if (item.DamageType == voidMelee)
                    {
                        string[] parts = tooltip.Text.Split(' ');

                        if (tooltip.Text.Contains("пустотного урона и") && tooltip.Text.Contains("ближнего боя"))
                        {
                            tooltip.Text = $"[c/7746d7:{parts[0]} ед. пустотного урона и] [c/ff5555:урона ближнего боя]";
                        }
                    }

                    if (item.DamageType == voidRanged)
                    {
                        string[] parts = tooltip.Text.Split(' ');

                        if (tooltip.Text.Contains("пустотного и") && tooltip.Text.Contains("стрелкового урона"))
                        {
                            tooltip.Text = $"[c/7746d7:{parts[0]} ед. пустотного и] [c/50fa7b:стрелкового] [c/7746d7:урона]";
                        }
                    }

                    if (item.DamageType == voidMagic)
                    {
                        string[] parts = tooltip.Text.Split(' ');

                        if (tooltip.Text.Contains("пустотного и") && tooltip.Text.Contains("магического урона"))
                        {
                            tooltip.Text = $"[c/7746d7:{parts[0]} ед. пустотного урона и] [c/bd93f9:магического] [c/7746d7:урона]";
                        }
                    }

                    if (item.DamageType == voidSummon)
                    {
                        string[] parts = tooltip.Text.Split(' ');

                        if (tooltip.Text.Contains("пустотного урона и") && tooltip.Text.Contains("урона призывателя") && item.type != ModContent.Find<ModItem>("SOTS/Tesseract").Type)
                        {
                            tooltip.Text = $"[c/7746d7:{parts[0]} ед. пустотного урона и] [c/f1fa8c:урона призывателя]";
                        }
                    }

                    if (item.type == ModContent.Find<ModItem>("SOTS/TwilightBeads").Type)
                    {
                        if (tooltip.Name == "Tooltip0")
                            tooltip.OverrideColor = new Color(119, 70, 215);
                    }
                }

                // SOTS Bard and Healer
                if (ModLoader.HasMod("SOTSBardHealer"))
                {
                    ModContent.TryFind<DamageClass>("SOTSBardHealer/VoidThrowing", out var voidThrowing);
                    ModContent.TryFind<DamageClass>("SOTSBardHealer/VoidRadiant", out var voidRadiant);
                    ModContent.TryFind<DamageClass>("SOTSBardHealer/VoidSymphonic", out var voidSymphonic);

                    if (item.DamageType == voidThrowing)
                    {
                        string[] parts = tooltip.Text.Split(' ');

                        if (tooltip.Text.Contains("пустотного и") && tooltip.Text.Contains("метательного урона"))
                        {
                            tooltip.Text = $"[c/7746d7:{parts[0]} ед. пустотного и] [c/ffb86c:метательного] [c/7746d7:урона]";
                        }
                    }

                    if (item.DamageType == voidRadiant)
                    {
                        string[] parts = tooltip.Text.Split(' ');

                        if (tooltip.Text.Contains("пустотного и") && tooltip.Text.Contains("лучезарного урона"))
                        {
                            tooltip.Text = $"[c/7746d7:{parts[0]} ед. пустотного и] [c/ff8af8:лучезарного] [c/7746d7:урона]";
                        }
                    }

                    if (item.DamageType == voidSymphonic)
                    {
                        string[] parts = tooltip.Text.Split(' ');

                        if (tooltip.Text.Contains("пустотного и") && tooltip.Text.Contains("симфонического урона"))
                        {
                            tooltip.Text = $"[c/7746d7:{parts[0]} ед. пустотного и] [c/ff8af8:симфонического] [c/7746d7:урона]";
                        }
                    }

                    if (item.DamageType == voidThrowing ||
                        item.DamageType == voidRadiant ||
                        item.DamageType == voidSymphonic)
                    {
                        tooltip.OverrideColor = new Color(119, 70, 215);
                    }
                }

                // Cerebral
                if (ModLoader.HasMod("CerebralMod"))
                {
                    ModContent.TryFind<DamageClass>("CerebralMod/SentryDamage", out var sentryDamage);
                    if (item.DamageType == sentryDamage)
                        tooltip.OverrideColor = new Color(205, 133, 63);

                    ModContent.TryFind<DamageClass>("CerebralMod/TelekineticDamage", out var telekineticDamage);
                    if (item.DamageType == telekineticDamage)
                        tooltip.OverrideColor = new Color(218, 112, 214);

                    ModContent.TryFind<DamageClass>("CerebralMod/MelodicDamage", out var melodicDamage);
                    if (item.DamageType == melodicDamage)
                        tooltip.OverrideColor = new Color(94, 196, 205);
                }

                // Martin's Order
                if (ModLoader.HasMod("MartainsOrder"))
                {
                    ModContent.TryFind<DamageClass>("MartainsOrder/ArtistClass", out var artistClass);
                    ModContent.TryFind<DamageClass>("MartainsOrder/ArtistClassNoSpeed", out var artistClass2);
                    ModContent.TryFind<DamageClass>("MartainsOrder/ArtistClassTempera", out var artistClass3);

                    if (item.DamageType == artistClass ||
                        item.DamageType == artistClass2 ||
                        item.DamageType == artistClass3)
                    {
                        tooltip.OverrideColor = new Color(255, 160, 122);
                    }
                }

                // Demolisher Class
                if (ModLoader.HasMod("DemolisherClass"))
                {
                    if (item.DamageType == ModContent.Find<DamageClass>("DemolisherClass/DemolisherDamage")
                    || item.DamageType == ModContent.Find<DamageClass>("DemolisherClass/ExplosiveMeleeDamage")
                    || item.DamageType == ModContent.Find<DamageClass>("DemolisherClass/ExplosiveRangedDamage")
                    || item.DamageType == ModContent.Find<DamageClass>("DemolisherClass/ExplosiveMagicDamage")
                    || item.DamageType == ModContent.Find<DamageClass>("DemolisherClass/ExplosiveSummonDamage"))
                    {
                        tooltip.OverrideColor = new Color(188, 47, 54);
                    }
                }

                // RoA
                if (ModLoader.HasMod("RoA"))
                {
                    if (item.DamageType == ModContent.Find<DamageClass>("RoA/DruidClass"))
                        tooltip.OverrideColor = new Color(0, 191, 50);
                }

                // Bombus Apis
                if (ModLoader.HasMod("BombusApisBee"))
                {
                    if (item.DamageType == ModContent.Find<DamageClass>("BombusApisBee/BeekeeperDamageClass"))
                        tooltip.OverrideColor = new Color(255, 215, 0);
                }

                // Split
                if (ModLoader.HasMod("Split"))
                {
                    if (item.DamageType == ModContent.Find<DamageClass>("Split/HeavyMeleeDamageClass"))
                        tooltip.OverrideColor = new Color(255, 85, 85);
                }

                // Orchid
                /*if (ModLoader.HasMod("OrchidMod"))
                {
                    if (item.DamageType == ModContent.Find<DamageClass>("OrchidMod/GuardianDamageClass"))
                    {
                        tooltip.OverrideColor = new Color(238, 232, 170);
                    }

                    if (item.DamageType == ModContent.Find<DamageClass>("OrchidMod/ShapeshifterDamageClass"))
                    {
                        tooltip.OverrideColor = new Color(60, 179, 113);
                    }

                    if (item.DamageType == ModContent.Find<DamageClass>("OrchidMod/GamblerDamageClass"))
                    {
                        tooltip.OverrideColor = new Color(255, 127, 80);
                    }

                    if (item.DamageType == ModContent.Find<DamageClass>("OrchidMod/GamblerChipDamageClass"))
                    {
                        tooltip.OverrideColor = new Color(255, 127, 80);
                    }

                    if (item.DamageType == ModContent.Find<DamageClass>("OrchidMod/AlchemistDamageClass"))
                    {
                        tooltip.OverrideColor = new Color(54, 215, 146);
                    }

                    if (item.DamageType == ModContent.Find<DamageClass>("OrchidMod/DancerDamageClass"))
                    {
                        tooltip.OverrideColor = new Color(239, 108, 154);
                    }
                }
                */
            }

            if (TRuConfig.Instance.ColoredDamageTypes)
            {
                // Calamity Bard Healer
                if (ModLoader.HasMod("CalamityBardHealer") && (item.type == ModContent.Find<ModItem>("CalamityBardHealer/YharimsJam").Type || item.type == ModContent.Find<ModItem>("CalamityBardHealer/ScreamingClam").Type
                || item.type == ModContent.Find<ModItem>("CalamityBardHealer/NoisebringerGoliath").Type) && tooltip.Name == "Tooltip0")
                {
                    tooltip.OverrideColor = new Color(255, 138, 248);
                }

                // Consolaria
                if (ModLoader.HasMod("Consolaria") && item.type == ModContent.Find<ModItem>("Consolaria/ShadowboundExoskeleton").Type && tooltip.Name == "Tooltip0")
                {
                    tooltip.OverrideColor = new Color(255, 85, 85);
                }
            }
        }
    }
}