using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class ConsolariaLegecyItemsPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("ConsolariaLegecyItems") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.ConsolariaLegecyItemsLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("ConsolariaLegecyItems", out Mod consolLegacy);

        if (tru != null && consolLegacy != null)
        {
            tru.Call("AddNeuterItems", consolLegacy, new string[]
            {
                "AncientTonbogiri"
            });
        }
    }
}