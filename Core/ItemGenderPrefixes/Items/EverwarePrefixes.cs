using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

namespace JAtRT.Core.ItemGenderPrefixes.Items
{
    internal class EverwarePrefixes : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.HasMod("Everware") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.EverwareLocalization && Language.ActiveCulture.Name == "ru-RU";
        }
        public override void PostSetupContent()
        {
            ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
            ModLoader.TryGetMod("Everware", out Mod Everware);

            if (tru != null && Everware != null)
            {
                tru.Call("AddFeminineItems", Everware, new string[]
                {
                    "BookOfBoulders"
                });
            }
        }
    }
}