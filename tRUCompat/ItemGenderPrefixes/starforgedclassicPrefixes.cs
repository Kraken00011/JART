using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class starforgedclassicPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.starforgedclassicLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("starforgedclassic", out Mod sfc);

        if (tru != null && sfc != null)
            tru.Call("AddFeminineItems", sfc, new string[] { "SunplateGlove" });
    }
}