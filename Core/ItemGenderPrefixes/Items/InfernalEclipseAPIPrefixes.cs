using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

namespace JAtRT.Core.ItemGenderPrefixes.Items
{
    internal class InfernalEclipseAPIPrefixes : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.HasMod("InfernalEclipseAPI") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.InfernalEclipseLocalization && Language.ActiveCulture.Name == "ru-RU";
        }
        public override void PostSetupContent()
        {
            ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
            ModLoader.TryGetMod("InfernalEclipseAPI", out Mod eclipse);

            if (tru != null && eclipse != null)
            {
                tru.Call("AddFeminineItems", eclipse, new string[]
                {
                    "NovaBomb",
                    "StellarSabre"
                });
                tru.Call("AddNeuterItems", eclipse, new string[] 
                { 
                    "CelestialIllumination",
                    "RingofTix",
                    "ExoSights"
                });
            }
        }
    }
}