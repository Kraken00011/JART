using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

internal class HypnosPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("HypnosMod") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.HypnosModLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("HypnosMod", out Mod hypnos);

        if (tru != null && hypnos != null)
        {
            tru.Call("AddFeminineItems", hypnos, new string[]
            {
                "Neuraze",
            });
        }
    }
}