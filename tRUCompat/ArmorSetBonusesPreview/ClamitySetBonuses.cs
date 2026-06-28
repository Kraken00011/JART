using System;
using Terraria.Localization;
using Terraria.ModLoader;
using CalamityMod;
using JAtRT.Core.Config;

internal class ClamitySetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.ClamityFix;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("Clamity", out Mod clam);

        if (tru != null && clam != null)
        {
            tru.Call("AddArmorSetBonusPreview", clam.Find<ModItem>("FrozenHellstoneVisor").Type, (Func<string>)(() =>
            {
                string hotkey = CalamityUtils.TooltipHotkeyString(CalamityKeybinds.ArmorSetBonusHotKey);
                return Language.GetTextValue("Mods.Clamity.Items.Armor.FrozenHellstone.FrozenHellstoneVisor.SetBonus", hotkey);
            }));

            tru.Call("AddArmorSetBonusPreview", clam.Find<ModItem>("ClamitasShellmet").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.Clamity.Items.Armor.Clamitas.ClamitasShellmet.SetBonus")
            ));
        }
    }
}