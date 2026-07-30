using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class HolosparkBootsPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.HolosparkBootsLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("HolosparkBoots", out Mod hohloSpark);

        if (tru != null && hohloSpark != null)
        {
            tru.Call("AddPluralItems", hohloSpark, new string[]
            {
                "HolosparkBoots"
            });
        }
    }
}