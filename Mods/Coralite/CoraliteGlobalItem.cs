using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Coralite.Content.Items.Gels;

namespace JAtRT.Mods.Coralite
{
    public class CoralitePatch : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.HasMod("Coralite") && Language.ActiveCulture.Name == "ru-RU";
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltip in tooltips)
            {
                if (tooltip.Name == "Damage")
                {
                    if (item.DamageType == DamageClass.Melee || item.DamageType == DamageClass.MeleeNoSpeed)
                    {
                        tooltip.Text = tooltip.Text.Replace(" [c/5cd7f9:Холод] ед.", " ед. [c/5cd7f9:холодного] урона ближнего боя");
                        tooltip.Text = tooltip.Text.Replace(" [c/f0d0b7:Вкусно] ед.", " ед. [c/f0d0b7:вкусного] урона ближнего боя");
                        tooltip.Text = tooltip.Text.Replace(" ед.", " ед. урона ближнего боя");
                    }

                    if (item.DamageType == DamageClass.Ranged)
                    {
                        tooltip.Text = tooltip.Text.Replace(" [c/5cd7f9:Холод] ед.", " ед. [c/5cd7f9:холодного] стрелкового урона");
                        tooltip.Text = tooltip.Text.Replace(" [c/f0d0b7:Вкусно] ед.", " ед. [c/f0d0b7:вкусного] стрелкового урона");
                        tooltip.Text = tooltip.Text.Replace(" ед.", " ед. стрелкового урона");
                    }

                    if (item.DamageType == DamageClass.Magic)
                    {
                        tooltip.Text = tooltip.Text.Replace(" [c/5cd7f9:Холод] ед.", " ед. [c/5cd7f9:холодного] магического урона");
                        tooltip.Text = tooltip.Text.Replace(" [c/f0d0b7:Вкусно] ед.", " ед. [c/f0d0b7:вкусного] магического урона");
                        tooltip.Text = tooltip.Text.Replace(" ед.", " ед. магического урона");
                    }

                    if (item.DamageType == DamageClass.Summon || item.DamageType == DamageClass.SummonMeleeSpeed)
                    {
                        tooltip.Text = tooltip.Text.Replace(" [c/5cd7f9:Холод] ед.", " ед. [c/5cd7f9:холодного] урона призывателя");
                        tooltip.Text = tooltip.Text.Replace(" [c/f0d0b7:Вкусно] ед.", " ед. [c/f0d0b7:вкусного] урона призывателя");
                        tooltip.Text = tooltip.Text.Replace(" ед.", " ед. урона призывателя");
                    }

                    if (item.DamageType == DamageClass.Generic)
                    {
                        tooltip.Text = tooltip.Text.Replace(" [c/5cd7f9:Холод] ед.", " ед. [c/5cd7f9:холодного] базового урона");
                        tooltip.Text = tooltip.Text.Replace(" [c/f0d0b7:Вкусно] ед.", " ед. [c/f0d0b7:вкусного] базового урона");
                        tooltip.Text = tooltip.Text.Replace(" ед.", " ед. базового урона");
                    }

                    if (item.DamageType == DamageClass.Default)
                    {
                        tooltip.Text = tooltip.Text.Replace(" [c/5cd7f9:Холод] ед.", " ед. [c/5cd7f9:холодного] урона");
                        tooltip.Text = tooltip.Text.Replace(" [c/f0d0b7:Вкусно] ед.", " ед. [c/f0d0b7:вкусного] урона");
                        tooltip.Text = tooltip.Text.Replace(" ед.", " ед. урона");
                    }

                    if (item.DamageType == ModContent.Find<DamageClass>("Coralite/FairyDamage"))
                    {
                        tooltip.Text = tooltip.Text.Replace(" [c/5cd7f9:Холод] Урон", " ед. [c/5cd7f9:холодного] урона фей");
                        tooltip.Text = tooltip.Text.Replace(" [c/f0d0b7:Вкусно] Урон", " ед. [c/f0d0b7:вкусного] урона фей");
                        tooltip.Text = tooltip.Text.Replace(" Урон", " ед. урона фей");
                    }

                    if (item.DamageType == ModContent.Find<DamageClass>("Coralite/MagikeDamage"))
                    {
                        tooltip.Text = tooltip.Text.Replace(" [c/5cd7f9:Холод] Урон", " ед. [c/5cd7f9:холодного] урона магики");
                        tooltip.Text = tooltip.Text.Replace(" [c/f0d0b7:Вкусно] Урон", " ед. [c/f0d0b7:вкусного] урона магики");
                        tooltip.Text = tooltip.Text.Replace(" Урон", " ед. урона магики");
                    }

                    if (item.DamageType == ModContent.Find<DamageClass>("Coralite/RangedNoAttackSpeed"))
                    {
                        tooltip.Text = tooltip.Text.Replace(" [c/5cd7f9:Холод] Ranged", " ед. [c/5cd7f9:холодного] стрелкового урона");
                        tooltip.Text = tooltip.Text.Replace(" [c/f0d0b7:Вкусно] Ranged", " ед. [c/f0d0b7:вкусного] стрелкового урона");
                        tooltip.Text = tooltip.Text.Replace(" Ranged", " ед. стрелкового урона");
                    }

                    if (ModLoader.HasMod("CalamityMod"))
                    {
                        if (item.DamageType == ModContent.Find<DamageClass>("CalamityMod/TrueMeleeDamageClass") 
                        || item.DamageType == ModContent.Find<DamageClass>("CalamityMod/TrueMeleeNoSpeedDamageClass"))
                        {
                            tooltip.Text = tooltip.Text.Replace(" [c/5cd7f9:Холод] ед.", " ед. [c/5cd7f9:холодного] урона истинного ближнего боя");
                            tooltip.Text = tooltip.Text.Replace(" [c/f0d0b7:Вкусно] ед.", " ед. [c/f0d0b7:вкусного] урона истинного ближнего боя");
                            tooltip.Text = tooltip.Text.Replace(" ед.", " ед. урона истинного ближнего боя");
                        }

                        if (item.DamageType == ModContent.Find<DamageClass>("CalamityMod/RogueDamageClass"))
                        {
                            tooltip.Text = tooltip.Text.Replace(" ед.", " ед. разбойного урона");
                        }
                    }

                    if (ModLoader.HasMod("ThoriumMod"))
                    {
                        if (item.DamageType == ModContent.Find<DamageClass>("ThoriumMod/BardDamage"))
                            tooltip.Text = tooltip.Text.Replace(" ед.", " ед. симфонического урона");

                        if (item.DamageType == ModContent.Find<DamageClass>("ThoriumMod/HealerDamage"))
                            tooltip.Text = tooltip.Text.Replace(" ед.", " ед. лучезарного урона");
                    }

                    if (ModLoader.HasMod("SOTS"))
                    {
                        if (item.DamageType == ModContent.Find<DamageClass>("SOTS/VoidMelee"))
                            tooltip.Text = tooltip.Text.Replace(" ед.", " ед. пустотного урона и урона ближнего боя");

                        if (item.DamageType == ModContent.Find<DamageClass>("SOTS/VoidRanged"))
                            tooltip.Text = tooltip.Text.Replace(" ед.", " ед. пустотного и стрелкового урона");

                        if (item.DamageType == ModContent.Find<DamageClass>("SOTS/VoidMagic"))
                            tooltip.Text = tooltip.Text.Replace(" ед.", " ед. пустотного и магического урона");

                        if (item.DamageType == ModContent.Find<DamageClass>("SOTS/VoidSummon"))
                            tooltip.Text = tooltip.Text.Replace(" ед.", " ед. пустотного урона и урона призывателя");
                    }
                }

                if (tooltip.Name == "ItemName" && item.type == ModContent.ItemType<EmperorSlimeBoots>())
                {
                    tooltip.Text = tooltip.Text.Replace("Сверх Прыгучие императорские ботинки", "Сверхпрыгучие императорские ботинки");
                }
            }
        }
    }
}
