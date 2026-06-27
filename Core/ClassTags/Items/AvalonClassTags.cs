using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class AvalonClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("Avalon") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "FrostGauntlet",
                "SlitthroatNecklace",
                "BlackWhetstone",
                "BloodyWhetstone",
                "RubberGloves",
                "TopazAmulet",
                "CaesiumGalea",
                "CaesiumGreaves",
                "CaesiumPlateMail",
                "DurataniumHelmet",
                "NaquadahMask",
                "TroxiniumHelmet",
                "XanthophyteHelm",
                "RhodiumPlateMail",
                "AdvGauntletPotion",
                "GauntletPotion",
                "TaleoftheDolt",
                "SceneofCarnage",
                // Warrior-Summoner
                "FlaskOfPathogens"
            };

            string[] Ranger =
            {
                "ApollosQuiver",
                "EmeraldAmulet",
                "DurataniumHeadpiece",
                "NaquadahHeadguard",
                "TroxiniumHeadpiece",
                "XanthophyteMask",
                "IridiumHat",
                "IridiumPants",
                "IridiumPlateMail",
                "OsmiumHelmet",
                "OsmiumJerkin",
                "OsmiumTreads",
                "RhodiumHeadgear",
                "AdvAmmoReservationPotion",
                "AdvArcheryPotion",
                "AdvRoguePotion",
                "RoguePotion",
                "FlankersTome",
                "TaleoftheRedLotus",
                "TomeofDistance",
                "ThePlumHarvest"
            };

            string[] Sorcerer =
            {
                "GiftofStarpower",
                "ManaCompromise",
                "NaturesEndowment",
                "AmethystAmulet",
                "SapphireAmulet",
                "DurataniumHeadgear",
                "NaquadahHood",
                "TroxiniumHat",
                "XanthophyteHat",
                "PeridotRobe",
                "RhodiumGreaves",
                "TourmalineRobe",
                "ZirconRobe",
                "SpiritPoppy",
                "AdvBloodCastPotion",
                "AdvMagicPowerPotion",
                "AdvManaRegenerationPotion",
                "AdvWisdomPotion",
                "BloodCastPotion",
                "WisdomPotion",
                "EternitysMoon",
                "MediationsFlame",
                "ChantoftheWaterDragon",
                // Sorcerer-Summoner
                "TomeoftheRiverSpirits"
            };

            string[] Summoner =
            {
                "BacchusBoots",
                "DionysusAmulet",
                "SummonerScroll",
                "PygmyShield",
                "AncientBodyplate",
                "AncientHeadpiece",
                "AncientLeggings",
                "FleshCap",
                "FleshPants",
                "FleshWrappings",
                "CordycepsHat",
                "CordycepsLeggings",
                "CordycepsWrappings",
                "AeroforceGuardia",
                "AeroforceLeggings",
                "AeroforceProtector",
                "AdvSummoningPotion",
                "SoutheasternPeacock",
                "TomorrowsPhoenix",
                "TheOasisRemembered",
                // Warrior-Summoner
                "FlaskOfPathogens",
                // Sorcerer-Summoner
                "TomeoftheRiverSpirits"
            };

            if (ModLoader.HasMod("Avalon"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "Avalon"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "Avalon"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "Avalon"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "Avalon"));
            }

            return result;
        }
    }
}