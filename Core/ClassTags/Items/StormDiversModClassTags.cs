using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class StormDiversModClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("StormDiversMod") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "BeetleBoot",
                "BloodBHelmet",
                "BloodChainmail",
                "BloodGreaves",
                "GraniteBMask",
                "GraniteChestplate",
                "GraniteGreaves",
                "HellSoulBMask",
                "BeetlePotion",
                // Warrior-Summoner
                "ClawsBone",
                "ClawsFrost",
                "ClawsSpooky",
                "AFlaskExplosive",
                "AFlaskFrost"
            };

            string[] Ranger =
            {
                "ShockQuiver",
                "ShroomAccessory",
                "ShroomAccessorySnipe",
                "HellSoulBHelmet",
                "MushroomBMask",
                "MushroomChestplate",
                "MushroomGreaves",
                "SantankBMask",
                "SantankChestplate",
                "SantankGreaves",
                "GunPotion",
                "ShroomitePotion",
                // Warrior-Ranger
                "LostPegleg"
            };

            string[] Sorcerer =
            {
                "SpectreAccessory",
                "SpectreAccessoryMagnet",
                "HellSoulBHood",
                "SpectrePotion",
                // Sorcerer-Summoner
                "ContestArmourBHelmet",
                "ContestArmourChestplate",
                "ContestArmourLeggings"
            };

            string[] Summoner =
            {
                "FrostCube",
                "DerplingBHeadgear",
                "HellSoulBCrown",
                "ShadowFlameBMask",
                "ShadowFlameChestplate",
                "ShadowFlameGreaves",
                "SkyKnightBMask",
                "SkyKnightChest",
                "SkyKnightGreaves",
                "TempleBMask",
                "TempleChest",
                "TempleLegs",
                "SpookyPotion",
                // Warrior-Summoner
                "ClawsBone",
                "ClawsFrost",
                "ClawsSpooky",
                "AFlaskExplosive",
                "AFlaskFrost",
                // Sorcerer-Summoner
                "ContestArmourBHelmet",
                "ContestArmourChestplate",
                "ContestArmourLeggings"
            };

            if (ModLoader.HasMod("StormDiversMod"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "StormDiversMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "StormDiversMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "StormDiversMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "StormDiversMod"));
            }

            return result;
        }
    }
}