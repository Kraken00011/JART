using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class ThoriumModClassTagsExtra : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("ThoriumMod") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Special Tags
            if (ModLoader.HasMod("SOTSBardHealer"))
            {
                string[] Void = { "DemonTongue" };

                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Void, "VoidTag", "ThoriumMod"));
            }

            // Class Tags
            string[] Warrior =
            {
                "RubyRing",
                "GardenersSheath",
                "JetstreamSheath",
                "DreadChestPlate",
                "DreadGreaves",
                "DreadSkull",
                "TitanHelmet",
                "TideTurnerHelmet",
                // Warrior-Thrower
                "TideTurnerBreastplate",
                "TideTurnerGreaves"
            };

            string[] Ranger =
            {
                "EmeraldRing",
                "TitanMask"
            };

            string[] Sorcerer =
            {
                "ManaBauble",
                "MurkyCatalyst",
                "TideStone",
                "SapphireRing",
                "ManaInjectionKit",
                "HungeringBlossom",
                "SilkHat",
                "SilkLeggings",
                "SilkTabard",
                "AquamarineRobe",
                "OpalRobe",
                "TitanHeadgear",
                "PyromancerCowl",
                // Sorcerer-Summoner
                "PyromancerLeggings",
                "PyromancerTabard"
            };

            string[] Summoner =
            {
                "AmberRing",
                "ArtilleryPotion",
                "MagmaSeersMask",
                // Sorcerer-Summoner
                "PyromancerLeggings",
                "PyromancerTabard"
            };

            string[] Thrower =
            {
                "TopazRing",
                "AncientHallowedGuise",
                "HallowedGuise",
                "TideTurnersGaze",
                // Warrior-Thrower
                "TideTurnerBreastplate",
                "TideTurnerGreaves"
            };

            if (ModLoader.HasMod("ThrowerUnification"))
            {
                string[] UnifiedThrower =
                {
                    "ShinobiSigil",
                    "PiratesPurse",
                    "ThrowingGuide",
                    "ThrowingGuideVolume2",
                    "ThrowingGuideVolume3",
                    "PaddedGrip",
                    "PlagueLordFlask",
                    "BoneGrip",
                    "Canteen",
                    "DeadEyePatch",
                    "MagnetoGrip",
                    "MermaidCanteen",
                    "OlympicTorch",
                    "FlightBoots",
                    "FlightMail",
                    "FlightMask",
                    "SandStoneGreaves",
                    "SandStoneHelmet",
                    "SandStoneMail",
                    "FungusGuard",
                    "FungusHat",
                    "FungusLeggings",
                    "PlagueDoctorsGarb",
                    "PlagueDoctorsLeggings",
                    "PlagueDoctorsMask",
                    "ShadeMasterGarb",
                    "ShadeMasterMask",
                    "ShadeMasterTreads",
                    "SpartanSandles",
                    "ThiefsWallet",
                    "WhiteDwarfGreaves",
                    "WhiteDwarfGuard",
                    "WhiteDwarfMask",
                    "Wreath",
                    "BronzeHelmet",
                    "BronzeGreaves",
                    "BronzeBreastplate",
                    "LichCarapace",
                    "LichCowl",
                    "LichTalon",
                    "NinjaEmblem"
                };

                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(UnifiedThrower, "ThrowerTag", "ThoriumMod"));
            }

            string[] Bard =
            {
                "OpalRing",
                "MusiciansHandbook",
                "AncientHallowedChapeau",
                "HallowedChapeau"
            };

            string[] Healer =
            {
                "AquamarineRing",
                "Altar",
                "AncientHallowedCowl",
                "HallowedCowl"
            };

            if (ModLoader.HasMod("ThoriumMod"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "ThoriumMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "ThoriumMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "ThoriumMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "ThoriumMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Thrower, "ThrowerTag", "ThoriumMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Bard, "BardTag", "ThoriumMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Healer, "HealerTag", "ThoriumMod"));
            }

            return result;
        }
    }
}