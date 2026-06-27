using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class SynergiaClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("Synergia") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "BloodstainedGlove",
                "MortalStones",
                "CoreburnedBreastplate",
                "CoreburnedHelmet",
                "CoreburnedLeggings",
                "ThunderBody",
                "ThunderHead",
                "ThunderLegs"
            };

            string[] Sorcerer =
            {
                "BronzeAcolyteHat",
                "BronzeAcolyteJacket",
                "BronzeAcolyteLeggings",
                "FadingHellChestplate",
                "FadingHellHat",
                "FadingHellPants",
                // Sorcerer-Summoner
                "Jeweler"
            };

            string[] Summoner =
            {
                "Gutshelmet",
                "Gutslegs",
                "Gutsplate",
                // Sorcerer-Summoner
                "Jeweler"
            };

            string[] Thrower =
            {
                "CaesiumRing",
                "CaesiumSkull",
                "CorrodeCrossShield",
                "CursedThrowerEmblem",
                "EverwoodNecklace",
                "PreciousSkull",
                "RingofVengeanceseeker",
                "StonedSkull",
                "CorrodeVisage",
                "DreadArmor",
                "DreadHelmet",
                "DreadLeggings",
                "ShardflingPotion"
            };

            if (ModLoader.HasMod("Synergia"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "Synergia"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "Synergia"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "Synergia"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Thrower, "ThrowerTag", "Synergia"));
            }

            return result;
        }
    }
}