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
using SolynWeapon.Content.Items.Weapons;
using SolynWeapon.Content.Items.Weapons.Magic;
using Terraria;

public partial class SolynWeapon : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("SolynWeapon") && JARTLocalizationConf.Instance.SolynWeaponLocalization;
    }
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        if (item.type == ModContent.ItemType<CosmicDestroyer>())
        {
            ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "SolynWeapon" && l.Name == "BigCosmicLaserBeam", tooltip =>
            {
                tooltip.Text = "Удерживайте ЛКМ, чтобы зарядить и выпустить огромный космический луч";
            });
        }

        if (item.type == ModContent.ItemType<ExoElectricDisintegrator>())
        {
            ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "SolynWeapon" && l.Name == "BigCosmicLaserBeam", tooltip =>
            {
                tooltip.Text = "Удерживайте ЛКМ, чтобы зарядить и выпустить огромный красный луч";
            });
        }

        ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "SolynWeapon" && l.Name == "SolynUsage", tooltip =>
        {
            tooltip.Text = "Удерживайте ЛКМ, чтобы зарядить и выпустить луч";
        });

        ItemHelper.TranslateTooltip(tooltips, l => l.Mod == "SolynWeapon" && l.Name == "SolynFlight", tooltip =>
        {
            tooltip.Text = "Удерживайте ПКМ, чтобы летать с помощью Солин";
        });
    }
}