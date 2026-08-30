using System;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;
using CalamityRuTranslate.Core.Config;

internal class FlinxHatSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.FlinxHatFix && TRuConfig.Instance.ArmorSetBonusPreview;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("FlinxHat", out Mod FlinxHat);

        if (tru != null && FlinxHat != null)
        {
            tru.Call("AddArmorSetBonusPreview", FlinxHat.Find<ModItem>("FlinxFurUshanka").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.FlinxHat.Items.FlinxFurUshanka.SetBonus")
            ));
        }
    }
}