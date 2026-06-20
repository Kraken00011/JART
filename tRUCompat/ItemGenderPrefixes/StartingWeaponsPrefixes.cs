using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

internal class StartingWeaponsPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("StartingWeapons") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.StartingWeaponsLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("StartingWeapons", out Mod startWeap);

        if (tru != null && startWeap != null)
        {
            tru.Call("AddFeminineItems", startWeap, new string[]
            {
                "StickGunItem",
                "WoodenStickItem"
            });
        }
    }
}