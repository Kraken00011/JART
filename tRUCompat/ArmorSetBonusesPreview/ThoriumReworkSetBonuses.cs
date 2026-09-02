using System;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;
using CalamityRuTranslate.Core.Config;

internal class ThoriumReworkSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.ThoriumReworkLocalization && TRuConfig.Instance.ArmorSetBonusPreview;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("ThoriumRework", out Mod thRew);

        if (tru != null && thRew != null)
        {
            string titanRework = Language.GetTextValue("Mods.ThoriumRework.ItemDescriptions.TitanArmor");

            tru.Call("AddArmorSetBonusPreview", thRew.Find<ModItem>("TitanHat").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.ThoriumMod.Items.TitanHelmet.SetBonus", 18) + "\n" + titanRework
            ));

            tru.Call("AddArmorSetBonusPreview", thRew.Find<ModItem>("TitanHood").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.ThoriumMod.Items.TitanHelmet.SetBonus", 18) + "\n" + titanRework
            ));

            tru.Call("AddArmorSetBonusPreview", thRew.Find<ModItem>("TitanVisage").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.ThoriumMod.Items.TitanHelmet.SetBonus", 18) + "\n" + titanRework
            ));

            tru.Call("AddArmorSetBonusPreview", thRew.Find<ModItem>("TitanVisor").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.ThoriumMod.Items.TitanHelmet.SetBonus", 18) + "\n" + titanRework
            ));

            tru.Call("AddArmorSetBonusPreview", thRew.Find<ModItem>("WhistlersHat").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.ThoriumRework.Items.WhistlersHat.SetBonus")
            ));
        }
    }
}