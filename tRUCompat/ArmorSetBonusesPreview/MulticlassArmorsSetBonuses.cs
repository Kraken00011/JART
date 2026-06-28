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
            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("AdamantiteHelm").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.HeatVoltConductorHelmet.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("OrichalcumCrown").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.CavernaryFlameHeadgear.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("CobaltKabuto").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.CavernaryFlameHelm.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("MythrilCrown").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.ElderMagesHat.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("PalladiumHelm").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.AshensteelHood.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("TitaniumGrowth").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.AshensteelHelm.SetBonus")
            ));
        }
    }
}