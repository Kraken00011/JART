using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class InfernalEclipseAPIPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("InfernalEclipseAPI") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.InfernalEclipseLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("InfernalEclipseAPI", out Mod eclipse);

        if (tru != null && eclipse != null)
        {
            tru.Call("AddFeminineItems", eclipse, new string[]
            {
                "NovaBomb",
                "StellarSabre"
            });

            tru.Call("AddNeuterItems", eclipse, new string[]
            {
                "CelestialIllumination",
                "RingofTix",
                "TheChickenWing",
                "ShatteredSubcommunity"
            });
            
            tru.Call("AddPluralItems", eclipse, new string[]
            {
                "The454CasullandTheJackal"
            });
        }
    }
}