using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class CalamitySimpleWhipAddonClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("CalamitySimpleWhipAddon") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Summoner =
            {
                "AirflowGrip",
                "BleachedJellyChargedBattery",
                "BleachedNuclearFuelRod",
                "BleachedNucleogenesis",
                "BleachedStarbusterCore",
                "BleachedStarTaintedGenerator",
                "BleachedStatisCurse",
                "BleachedTheFirstShadowflame",
                "BleachedVoltaicJelly",
                "BuddyEmblem",
                "CommanderGrip",
                "EmperorsGrip",
                "LeatherGrip",
                "LightSpiritGrip",
                "MagneticGrip",
                "NecromanticGrip",
                "RubberGrip",
                "SilkGrip",
                "StrikerEmblem",
                "WulfrumWhipMagnet"
            };

            if (ModLoader.HasMod("CalamitySimpleWhipAddon"))
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "CalamitySimpleWhipAddon"));

            return result;
        }
    }
}