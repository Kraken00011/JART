using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class WulfrumExpansionPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("WulfrumExpansion") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.WulfrumExpansionLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("WulfrumExpansion", out Mod wulfrum);

        if (tru != null && wulfrum != null)
        {
            tru.Call("AddFeminineItems", wulfrum, new string[]
            {
                "WulfrumSapper",
                "WulfrumChainsaw",
                "WulfrumHealthKit",
                "ReactivePlating"
            });
            
            tru.Call("AddNeuterItems", wulfrum, new string[]
            {
                "PlasmaCore"
            });
        }
    }
}