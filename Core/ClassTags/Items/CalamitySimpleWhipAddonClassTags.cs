using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using JAtRT.Core.ClassTags;

namespace JAtRT.Core.ClassTags.Items;

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
                "StrikerEmblem"
            };

            if (ModLoader.HasMod("CalamitySimpleWhipAddon"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "CalamitySimpleWhipAddon"));
            }

            return result;
        }
    }
}