using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class GolemReworkPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("GolemRework") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.GolemReworkLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("GolemRework", out Mod jungleRew);

        if (tru != null && jungleRew != null)
        {
            tru.Call("AddNeuterItems", jungleRew, new string[]
            {
                "Sunbracers"
            });
            
            tru.Call("AddPluralItems", jungleRew, new string[]
            {
                "GraspofGrass"
            });
        }
    }
}