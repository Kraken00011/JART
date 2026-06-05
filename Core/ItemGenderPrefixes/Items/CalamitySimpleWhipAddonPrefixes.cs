using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

namespace JAtRT.Core.ItemGenderPrefixes.Items
{
    internal class CalamitySimpleWhipAddonPrefixes : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.HasMod("CalamitySimpleWhipAddon") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.CalamitySimpleWhipAddonLocalization && Language.ActiveCulture.Name == "ru-RU";
        }
        public override void PostSetupContent()
        {
            ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
            ModLoader.TryGetMod("CalamitySimpleWhipAddon", out Mod calSimWhips);

            if (tru != null && calSimWhips != null)
            {
                tru.Call("AddFeminineItems", calSimWhips, new string[] 
                { 
                    "BuddyEmblem",
                    "DestructionChain",
                    "Ectopia",
                    "Necropsia",
                    "Gelxyribose",
                    "KusariGama",
                    "MermaidsTear",
                    "ResonantVoid",
                    "SkybreakerCoil",
                    "RapierWhip"
                });
                tru.Call("AddNeuterItems", calSimWhips, new string[] 
                { 
                    "BleachedStrabusterCore",
                    "BleachedStatisCurse",
                    "BleachedVoltaicJelly"
                });
                tru.Call("AddPluralItems", calSimWhips, new string[] 
                { 
                    "AncientBonds", 
                    "ExistenceBonds",
                    "PrimalBonds"
                });
            }
        }
    }
}