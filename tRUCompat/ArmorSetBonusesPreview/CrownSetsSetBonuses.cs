using System;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using JAtRT.Core.Config;
using CalamityRuTranslate.Core.Config;

internal class CrownSetsSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.CrownSetsLocalization && TRuConfig.Instance.ArmorSetBonusPreview;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("CrownSets", out Mod crown);

        if (tru != null && crown != null)
        {
            tru.Call("AddArmorSetBonusPreview", (int)ItemID.GoldCrown, (Func<string>)(() =>
                Language.GetTextValue("Mods.CrownSets.SetBonus.GoldCrown")
            ));

            tru.Call("AddArmorSetBonusPreview", (int)ItemID.PlatinumCrown, (Func<string>)(() =>
                Language.GetTextValue("Mods.CrownSets.SetBonus.PlatinumCrown")
            ));

            if (ModLoader.HasMod("Avalon"))
            {
                ModLoader.TryGetMod("Avalon", out Mod avalon);

                tru.Call("AddArmorSetBonusPreview", avalon.Find<ModItem>("BismuthCrown").Type, (Func<string>)(() =>
                    Language.GetTextValue("Mods.CrownSets.SetBonus.BismuthCrown")
                ));
            }
        }
    }
}