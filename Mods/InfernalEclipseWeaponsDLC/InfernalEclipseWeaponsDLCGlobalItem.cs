using System.Collections.Generic;
using JAtRT.Core.Config;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

public partial class InfernalEclipseWeaponsDLCGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("InfernalEclipseWeaponsDLC"); //&& JARTLocalizationConf.Instance.InfernalEclipseWeaponsDLCLocalization;
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            if (item.type == ModContent.Find<ModItem>("InfernalEclipseWeaponsDLC/TerraSheath").Type)
                tooltip.Text = tooltip.Text.Replace("% basic damage", "% базового урона");
        }
    }
}