using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

internal class BlueMoonPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return ModLoader.HasMod("BlueMoon") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.BlueMoonLocalization && Language.ActiveCulture.Name == "ru-RU";
    }
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("BlueMoon", out Mod bMoon);

        if (tru != null && bMoon != null)
        {
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
}