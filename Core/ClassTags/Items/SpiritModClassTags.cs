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

public class SpiritModClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("SpiritMod") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "CleftHorn",
                "CursedPendant",
                "FrostGiantBelt",
                "IchorPendant",
                "FrigidGloves",
                "LeatherGlove",
                "ToxicTooth",
                "WheezerScale",
                "CryoliteBody",
                "CryoliteHead",
                "CryoliteLegs",
                "FloranCharm",
                "SpiritBodyArmor",
                "SpiritHeadgear",
                "SpiritLeggings",
                // Warrior-Sorcerer
                "PrimalstoneBreastplate",
                "PrimalstoneFaceplate",
                "PrimalstoneLeggings",
            };

            string[] Ranger =
            {
                "AssassinMagazine",
                "Rangefinder",
                "ShurikenLauncher",
                "LeatherHood",
                "LeatherLegs",
                "LeatherPlate",
                "StarLegs",
                "StarMask",
                "StarPlate",
                "StarPotion",
                // Ranger-Sorcerer
                "TalonHeaddress",
                "TalonGarb",
                "DuskHood",
                "DuskLeggings",
                "DuskPlate",
                "DuskPendant"
            };

            string[] Sorcerer =
            {
                "CultistScarf",
                "FallenAngel",
                "HellEater",
                "ArcaneNecklace",
                "ManaShield",
                "SeraphimBulwark",
                "RuneWizardScroll",
                "TimScroll",
                "DaybloomBody",
                "DaybloomHead",
                "DaybloomLegs",
                "JellynautBubble",
                "RunePotion",
                "ManaCandy",
                "EyeOfTheSorcererItem",
                "RunicGreaves",
                "RunicHood",
                "RunicPlate",
                "SeraphArmor",
                "SeraphHelm",
                "SeraphLegs",
                "StreamSurferChestplate",
                "StreamSurferHelmet",
                "StreamSurferLeggings",
                // Sorcerer-Summoner
                "DarkfeatherVisage",
                // Warrior-Sorcerer
                "PrimalstoneBreastplate",
                "PrimalstoneFaceplate",
                "PrimalstoneLeggings",
                // Ranger-Sorcerer
                "TalonHeaddress",
                "TalonGarb",
                "DuskHood",
                "DuskLeggings",
                "DuskPlate",
                "DuskPendant"
            };

            string[] Summoner =
            {
                "Strikeshield",
                "Moonlight_Sack",
                "MimeMask",
                "InfernalBreastplate",
                "InfernalGreaves",
                "InfernalVisor",
                "ObsidiusGreaves",
                "ObsidiusHelm",
                "ObsidiusPlate",
                // Sorcerer-Summoner
                "DarkfeatherVisage"
            };

            if (ModLoader.HasMod("SpiritBardHealer"))
            {
                string[] Thrower =
                {
                    "RogueHood",
                    "RoguePants",
                    "RoguePlate"
                };

                string[] Bard =
                {
                    "ElectricGuitar",
                    "WayfarerBody",
                    "WayfarerHead",
                    "WayfarerLegs"
                };

                string[] Healer =
                {
                    "FrigidChestplate",
                    "FrigidHelm",
                    "FrigidLegs"
                };

                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Thrower, "ThrowerTag", "SpiritMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Bard, "BardTag", "SpiritMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Healer, "HealerTag", "SpiritMod"));
            }

            if (ModLoader.HasMod("SpiritMod"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "SpiritMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "SpiritMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "SpiritMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "SpiritMod"));
            }

            return result;
        }
    }
}