using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class GauntletsPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("Gauntlets") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.GauntletsLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("Gauntlets", out Mod gaunt);

        if (tru != null && gaunt != null)
        {
            tru.Call("AddFeminineItems", gaunt, new string[]
            {
                "DungeonGlove",
                "HolyGauntlet",
                "LeatherGlove",
                "ObsidianGlove"
            });
            
            tru.Call("AddPluralItems", gaunt, new string[]
            {
                "CarapaceBattlegrips",
                "FortifiedKnockers",
                "GleamingGauntlets",
                "StellarGloves",
                "WoodenBracers"
            });
        }
    }
}