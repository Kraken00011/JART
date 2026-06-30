using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class BlueMoonPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("BlueMoon") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.BlueMoonLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("BlueMoon", out Mod bMoon);
        
        tru.Call("AddNeuterItems", bMoon, new string[]
        {
            "TopazRing",
            "SapphireRing",
            "EmeraldRing",
            "AmethystRing",
            "MoonsRing"
        });
    }
}