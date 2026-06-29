using System;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class MulticlassArmorsSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.MulticlassArmorsLocalization;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("MulticlassArmors", out Mod hmOreHelms);

        if (tru != null && hmOreHelms != null)
        {
            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("HeatVoltConductorHelmet").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.HeatVoltConductorHelmet.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("CavernaryFlameHeadgear").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.CavernaryFlameHeadgear.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("CavernaryFlameHelm").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.CavernaryFlameHelm.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("ElderMagesHat").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.ElderMagesHat.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("AshensteelHood").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.AshensteelHood.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("AshensteelHelm").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.AshensteelHelm.SetBonus")
            ));
        }
    }
}