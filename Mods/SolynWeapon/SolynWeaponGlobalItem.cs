using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

public partial class SolynWeapon : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("SolynWeapon") && JARTLocalizationConf.Instance.SolynWeaponLocalization;
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            if (tooltip.Mod == "SolynWeapon" && tooltip.Name == "BigCosmicLaserBeam" && item.type == ModContent.Find<ModItem>("SolynWeapon/CosmicDestroyer").Type)
            {
                tooltip.Text = "Удерживайте ЛКМ, чтобы зарядить и выпустить огромный космический луч";
            }

            if (tooltip.Mod == "SolynWeapon" && tooltip.Name == "BigCosmicLaserBeam" && item.type == ModContent.Find<ModItem>("SolynWeapon/ExoElectricDisintegrator").Type)
            {
                tooltip.Text = "Удерживайте ЛКМ, чтобы зарядить и выпустить огромный красный луч";
            }

            if (tooltip.Mod == "SolynWeapon" && tooltip.Name == "SolynUsage")
            {
                tooltip.Text = "Удерживайте ЛКМ, чтобы зарядить и выпустить луч";
            }

            if (tooltip.Mod == "SolynWeapon" && tooltip.Name == "SolynFlight")
            {
                tooltip.Text = "Удерживайте ПКМ, чтобы летать с помощью Солин";
            }
        }
    }
}