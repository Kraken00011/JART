using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class CalamitySimpleWhipAddonPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.CalamitySimpleWhipAddonLocalization && Language.ActiveCulture.Name == "ru-RU";
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
                "RapierWhip",
                "StrikerEmblem",
                "LayeredPain",
                "NightButterfly",
                "ActiasAliena",
                "EtaCarinae",
                "LeatherGrip",
                "SilkGrip",
                "RubberGrip",
                "NecromanticGrip",
                "EmperorsGrip",
                "LightSpiritGrip",
                "AirflowGrip",
                "CommanderGrip",
                "MagneticGrip",
                "MassofWailing"
            });

            tru.Call("AddNeuterItems", calSimWhips, new string[]
            {
                "BleachedStrabusterCore",
                "BleachedStatisCurse",
                "BleachedVoltaicJelly",
                "AurelianSanctum",
                "KingsMajesty"
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