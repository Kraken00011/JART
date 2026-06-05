using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

namespace JAtRT.Core.ItemGenderPrefixes.Items
{
    internal class ConsolariaLegecyItemsPrefixes : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.HasMod("ConsolariaLegecyItems") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.ConsolariaLegecyItemsLocalization && Language.ActiveCulture.Name == "ru-RU";
        }
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
}