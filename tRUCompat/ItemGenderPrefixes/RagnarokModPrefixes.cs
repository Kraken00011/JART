using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class RagnarokModPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.RagnarokModLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("RagnarokMod", out Mod ragMod);

        if (tru != null && ragMod != null)
        {
            tru.Call("AddFeminineItems", ragMod, new string[]
            {
                ""
            });
            
            tru.Call("AddNeuterItems", ragMod, new string[]
            {
                ""
            });

            tru.Call("AddPluralItems", ragMod, new string[]
            {
                ""
            });
        }
    }
}