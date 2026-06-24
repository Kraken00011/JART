using System;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

internal class HMOreSummonerHelmetsSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.HMOreSummonerHelmetsLocalization;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("HMOreSummonerHelmets", out Mod hmOreHelms);

        if (tru != null && hmOreHelms != null)
        {
            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("AdamantiteHelm").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.JAtRT.HMOreSummonerHelmets.ArmorSetBonuses.AdamantiteHelm")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("OrichalcumCrown").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.JAtRT.HMOreSummonerHelmets.ArmorSetBonuses.OrichalcumCrown")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("CobaltKabuto").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.JAtRT.HMOreSummonerHelmets.ArmorSetBonuses.CobaltKabuto")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("MythrilCrown").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.JAtRT.HMOreSummonerHelmets.ArmorSetBonuses.MythrilCrown")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("PalladiumHelm").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.JAtRT.HMOreSummonerHelmets.ArmorSetBonuses.PalladiumHelm")
            ));

            tru.Call("AddArmorSetBonusPreview", hmOreHelms.Find<ModItem>("TitaniumGrowth").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.JAtRT.HMOreSummonerHelmets.ArmorSetBonuses.TitaniumGrowth")
            ));
        }
    }
}