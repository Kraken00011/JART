using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class PolyphemalusPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("Polyphemalus") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.PolyphemalusLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("Polyphemalus", out Mod poly);

        if (tru != null && poly != null)
        {
            tru.Call("AddFeminineItems", poly, new string[]
            {
                "chainSaw",
                "Heterochromia",
                "Homochromia",
                "Prismachromancy",
                "Tetrachromancy"
            });
        }
    }
}