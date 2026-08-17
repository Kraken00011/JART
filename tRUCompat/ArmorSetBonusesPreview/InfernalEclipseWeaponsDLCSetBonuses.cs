using System;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class InfernalEclipseWeaponsDLCSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.InfernalEclipseWeaponsDLCLocalization;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("InfernalEclipseWeaponsDLC", out Mod infernal);

        if (tru != null && infernal != null)
        {
            tru.Call("AddArmorSetBonusPreview", infernal.Find<ModItem>("EclipseHelm").Type, (Func<string>)(() =>
            {
                string setBonusExtra = Language.GetTextValue("Mods.InfernalEclipseWeaponsDLC.Items.EclipseHelm.SetBonusExtra");

                if (ModLoader.HasMod("InfernalEclipseAPI") || ModLoader.HasMod("WHummusMultiModBalancing"))
                {
                    return Language.GetTextValue("Mods.InfernalEclipseWeaponsDLC.Items.EclipseHelm.SetBonus") + "\n" + setBonusExtra;
                }
                else
                    return Language.GetTextValue("Mods.InfernalEclipseWeaponsDLC.Items.EclipseHelm.SetBonus");
            }));

            tru.Call("AddArmorSetBonusPreview", infernal.Find<ModItem>("NecrosingerSkull").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.InfernalEclipseWeaponsDLC.Items.NecrosingerSkull.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", infernal.Find<ModItem>("SuperCellCirclet").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.InfernalEclipseWeaponsDLC.Items.SuperCellCirclet.SetBonus")
            ));
        }
    }
}