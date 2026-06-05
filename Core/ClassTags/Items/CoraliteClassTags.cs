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

public class CoraliteClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("Coralite") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "AncientGemNecklace",
                "SkyRing",
                "AlloySpring",
                "AmberAmulet",
                "BeetleLimbStrap",
                "ChlorophyteMedal",
                "ChronoHeart",
                "DemonsProtection",
                "EtheriaLegacy",
                "FlamingLamps",
                "FloralHarmonyMedallion",
                "FlyingShieldBattleGuide",
                "FLyingShieldCore",
                "FlyingShieldMaintenanceGuide",
                "FlyingShieldTerminalChip",
                "FlyingShieldToolbox",
                "FlyingShieldToolboxProMax",
                "FlyingShieldVarnish",
                "ForbiddenLamp",
                "GravitationalCatapult",
                "HeavyWedges",
                "HolyCharm",
                "JungleTurtleShell",
                "LavaLamp",
                "LevitationBlossom",
                "NanoAmplifier",
                "OldClockwork",
                "OniMask",
                "PiezoArmorPanel",
                "PossessedChest",
                "KamonFlag",
                "PowerliftExoskeleton",
                "ShieldbearersBand",
                "ShieldSpring",
                "SnowflakeCharm",
                "SolarPanel",
                "SolarTwinkle",
                "StretchGlue",
                "Terracrest",
                "B9LaserMask",
                "SteelHelmet",
                // Warrior-Summoner
                "FlaskOfThunder"
            };

            string[] Ranger =
            {
                "GoldCrystalRing",
                "MedusaLightArmor",
                "MedusaMask",
                "MedusaSlippers",
                "MidasGunpowder",
                "PollenGunpowder",
                "RoseGunpowder",
                "WindrangerQuiver",
                "WindSpeedArrows",
                "B9MonitorHead",
                "SteelCanHead"
            };

            string[] Sorcerer =
            {
                "BubblePearlNecklace",
                "SpectreBoulder",
                "ConchHat",
                "ConchRobe",
                "ShadowHead",
                "ShadowBreastplate",
                "ShadowLegs",
                "B9SpaceHelmet",
                "SteelMask",
                // Sorcerer-Summoner
                "GoldCrystalNecklace"
            };

            string[] Summoner =
            {
                "LeafeoBoots",
                "LeafeoHelmet",
                "LeafeoLightArmor",
                "B9PlaneHead",
                "SteelBucketHead",
                // Warrior-Summoner
                "FlaskOfThunder",
                // Sorcerer-Summoner
                "GoldCrystalNecklace"
            };

            if (ModLoader.HasMod("Coralite"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "Coralite"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "Coralite"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "Coralite"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "Coralite"));
            }

            return result;
        }
    }
}