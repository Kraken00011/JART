using System;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class FlinxHatSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.FlinxHatFix;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("FlinxHat", out Mod FlinxHat);

        if (tru != null && FlinxHat != null)
        {
            tru.Call("AddArmorSetBonusPreview", FlinxHat.Find<ModItem>("FlinxFurUshanka").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.Items.FlinxFurUshanka.SetBonus")
            ));
        }
    }
}