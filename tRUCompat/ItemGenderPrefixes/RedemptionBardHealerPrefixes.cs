using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class RedemptionBardHealerPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.RedemptionBardHealerLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("RedemptionBardHealer", out Mod redempBardHealer);

        if (tru != null && redempBardHealer != null)
        {
            tru.Call("AddFeminineItems", redempBardHealer, new string[]
            {
                "BlackPlague",
                "LeafLyre",
                "Milkomeda",
                "RadiumGuitar",
                "TheTwig"
            });
        }
    }
}