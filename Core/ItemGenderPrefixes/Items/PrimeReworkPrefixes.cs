using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

namespace JAtRT.Core.ItemGenderPrefixes.Items
{
    internal class PrimeReworkPrefixes : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.HasMod("PrimeRework") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.PrimeReworkLocalization && Language.ActiveCulture.Name == "ru-RU";
        }
        public override void PostSetupContent()
        {
            ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
            ModLoader.TryGetMod("PrimeRework", out Mod pr);

            if (tru != null && pr != null)
            {
                tru.Call("AddFeminineItems", pr, new string[]
                {
                    "Avalanche",
                    "DoubleTrouble",
                    "EnergyHilt",
                    "Exitium",
                    "HandPrime",
                    "Jumboshark",
                    "LaserStar",
                    "MechclopsMask",
                    "SwarmGrenade",
                    "TheSnake",
                    "TheSpur"
                });
                tru.Call("AddNeuterItems", pr, new string[] 
                { 
                    "HydraulicPressManual",
                    "RepurposedEyeRemote"
                });
                tru.Call("AddPluralItems", pr, new string[] 
                { 
                    "Beforeshock",
                    "BloodStainedPocketWatch",
                    "RepurposedBeeRemote",
                    "SiegeDowner"
                });
            }
        }
    }
}