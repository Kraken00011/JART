using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using JAtRT.Core.Config;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameInput;
using Microsoft.Xna.Framework;
using Polyphemalus;
using Polyphemalus.Content.Items;
using Polyphemalus.Content.Items.Magic;
using System.Security;

public class PolyphemalusGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("Polyphemalus") && JARTLocalizationConf.Instance.PolyphemalusLocalization;
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        if (item.type == ModContent.ItemType<PolypebralShield>())
        {
            foreach (TooltipLine tooltip in tooltips)
            {
                if (tooltip.Mod == "Terraria" && tooltip.Name == "Tooltip0")
                {
                    string[] parts = tooltip.Text.Split(' ');
                    if (tooltip.Text == $"Press {parts[1]} to perform a omnidirectional dash that can be used to bonk enemies.\nHas a long cooldown. \nInitiating another dash right before hitting an enemy will allow you to control your ricochet"
                        && tooltip.Text != $"Press [NONE] to perform a omnidirectional dash that can be used to bonk enemies.\nHas a long cooldown. \nInitiating another dash right before hitting an enemy will allow you to control your ricochet")
                    {
                        tooltip.Text = $"Нажмите {parts[1]}, чтобы совершить всенаправленный рывок, наносящий урон\nРывок имеет долгую перезарядку\nПопытка совершения ещё одного рывка в момент попадания по врагу позволит вам управлять отскоком от него";
                    }

                    else
                        tooltip.Text = $"Нажмите [Не назначено], чтобы совершить всенаправленный рывок, наносящий урон\nРывок имеет долгую перезарядку\nПопытка совершения ещё одного рывка в момент попадания по врагу позволит вам управлять отскоком от него";
                }
            }
        }
    }
    public override void UpdateInventory(Item item, Player player)
    {
        if (item.type == ModContent.ItemType<chainSaw>())
        {
            PolyPlayer modPlayer = player.GetModPlayer<PolyPlayer>();

            float percent = 100f * modPlayer.ChainSawCharge / modPlayer.ChainSawChargeMax;

            item.SetNameOverride($"Бензо-пила ({Math.Round(percent)}%)");
        }
    }
}
