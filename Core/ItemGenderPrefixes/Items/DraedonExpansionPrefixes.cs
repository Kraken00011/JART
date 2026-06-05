using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

namespace JAtRT.Core.ItemGenderPrefixes.Items
{
    internal class DraedonExpansionPrefixes : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.HasMod("DraedonExpansion") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.DraedonExpansionFix && Language.ActiveCulture.Name == "ru-RU";
        }
        public override void PostSetupContent()
        {
            ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
            ModLoader.TryGetMod("DraedonExpansion", out Mod draedon);

            if (tru != null && draedon != null)
            {
                tru.Call("AddFeminineItems", draedon, new string[]
                {
                    "SolarPanel",
                    "MechanicalDrill"
                });
            }
        }
    }
}