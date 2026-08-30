using System;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;
using CalamityRuTranslate.Core.Config;

internal class MulticlassArmorsSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.MulticlassArmorsLocalization && TRuConfig.Instance.ArmorSetBonusPreview;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("MulticlassArmors", out Mod multiclass);

        if (tru != null && multiclass != null)
        {
            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("HeatVoltConductorHelmet").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.HeatVoltConductorHelmet.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("CavernaryFlameHeadgear").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.CavernaryFlameHeadgear.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("CavernaryFlameHelm").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.CavernaryFlameHelm.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("ElderMagesHat").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.ElderMagesHat.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("AshensteelHood").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.AshensteelHood.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("AshensteelHelm").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.AshensteelHelm.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("VacuumHood").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.VacuumHood.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("MechanicalBeastHelmet").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.MechanicalBeastHelmet.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("NaturePurifierHelm").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.NaturePurifierHelm.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("TwinSunsHelmet").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.TwinSunsHelmet.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("PumpkinLordHood").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.PumpkinLordHood.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("PumpkinLordHead").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.PumpkinLordHead.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", multiclass.Find<ModItem>("CelestiteHelm").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.MulticlassArmors.Items.CelestiteHelm.SetBonus")
            ));
        }
    }
}