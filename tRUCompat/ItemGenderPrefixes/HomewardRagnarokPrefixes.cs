using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

internal class HomewardRagnarokPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityRuTranslate") && ModLoader.HasMod("HomewardRagnarok") && JARTLocalizationConf.Instance.HomewardRagnarokLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("HomewardRagnarok", out Mod homewardRagnarok);

        if (tru != null && homewardRagnarok != null)
        {
            tru.Call("AddFeminineItems", homewardRagnarok, new string[]
            {
                "TheBibleOfTheThrowerVol4",
                "EvilFlask"
            });
            
            tru.Call("AddNeuterItems", homewardRagnarok, new string[]
            {
                "BabyOil"
            });
        }
    }
}