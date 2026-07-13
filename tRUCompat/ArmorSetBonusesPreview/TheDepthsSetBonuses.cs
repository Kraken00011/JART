using System;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class TheDepthsSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.TheDepthsFix;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("TheDepths", out Mod theDepths);

        if (tru != null && theDepths != null)
        {
            tru.Call("AddArmorSetBonusPreview", theDepths.Find<ModItem>("GeodeHelmet").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.TheDepths.SetBonus.GeodeHelmet")
            ));

            tru.Call("AddArmorSetBonusPreview", theDepths.Find<ModItem>("MercuryHelmet").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.TheDepths.SetBonus.MercuryHelmet")
            ));

            tru.Call("AddArmorSetBonusPreview", theDepths.Find<ModItem>("NightwoodHelmet").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.TheDepths.SetBonus.NightwoodHelmet")
            ));

            tru.Call("AddArmorSetBonusPreview", theDepths.Find<ModItem>("QuartzHood").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.TheDepths.SetBonus.QuartzArmor")
            ));

            tru.Call("AddArmorSetBonusPreview", theDepths.Find<ModItem>("PetrifiedWoodHelmet").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.TheDepths.SetBonus.PetrifiedWoodHelmet")
            ));
        }
    }
}