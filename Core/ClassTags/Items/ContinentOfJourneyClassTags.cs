using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class ContinentOfJourneyClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("ContinentOfJourney") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            /// Homeward Ragnarok Dependant Class Tags
            string[] WarriorOrSummoner = { "CommandersGaunlet" };

            string[] RangerOrRogue =
            {
                "Alpha",
                "BatterCap",
                "CatchersGlove",
                "Epsilon",
                "FatherAndSon",
                "GrandSlam",
                "Omega",
                "RedCube",
                "TheBatter",
                "TheHolyTrinity",
                "RunnersLegging",
                "AffluenceTicket",
                "DebtTicket",
                "FortuneTicket",
                "JackpotTicket",
                "LegacyTicket",
                "LuckTicket",
                "WealthTicket",
                "WindfallTicket",
                "SteadyCap"
            };

            string[] SorcererOrHealer =
            {
                "AlloyCross",
                "BiomatterCross",
                "CrossOfTheFlamingSwords",
                "FungusDeluxe",
                "HoneyMushroom",
                "JellyMushroom",
                "MapleMushroom",
                "MythrilCross",
                "OrichalcumCross",
                "RejuvenatedCross",
                "SilverCross",
                "TungstenCross",
                "UndyingCross",
                "WoodenCross"
            };

            string[] Rogue =
            {
                // Warrior-Summoner & Rogue (if Homeward Ragnarok enabled)
                "DivineFireFlask",
                "ForceBreakFlask",
                "PlagueFlask",
                "SteelFlask"
            };

            // Homeward Ragnarok Dependant Special Tags
            string[] OmniShield =
            {
                "VanguardBreastpiece"
            };
            ///

            // Class Tags
            string[] Warrior =
            {
                "DivineEmblem",
                "DivineTouch",
                "PhilosophersStone",
                "RadiativeStone",
                "RunedStone",
                "ShiningOil",
                "ChampionBelt",
                "DeepseaOil",
                "FlowerOil",
                "FortressBelt",
                "GhostOil",
                "GrindStone",
                "LeafOil",
                "SparkleOil",
                "SwordsmanBelt",
                "WarriorBelt",
                "SwordmasterBadge",
                "BadgeMolten",
                "EquilibriumBreastplate",
                "EquilibriumLeggings",
                "EquilibriumMask",
                "ReflectorBreastplate",
                "ReflectorHelmet",
                "ReflectorLeggings",
                "SwordmanBelt",
                // Warrior-Summoner & Rogue (if Homeward Ragnarok enabled)
                "DivineFireFlask",
                "ForceBreakFlask",
                "PlagueFlask",
                "SteelFlask"
            };

            string[] Ranger =
            {
                "AirborneGoogles",
                "ArrowCase",
                "BlackholeInABottle",
                "JarOfSchrodinger",
                "KippsApparatus",
                "STPFlack",
                "BowTrigger",
                "Cardiotachometer",
                "CherryOnFire",
                "BullseyeBadge",
                "CrossbowScope",
                "DemolitionistsLuckyClover",
                "FlareInABottle",
                "MachinaScope",
                "MetalNozzle",
                "PeachOnFire",
                "RobinHat",
                "RunnersLeggings",
                "StarQuiver",
                //
                "BurningWrap",
                "CursedWrap",
                "DivineWrap",
                "IchorWrap",
                "NanoWrap",
                "PlagueWrap",
                "PoisonedWrap",
                "VenomWrap",
                "TrashBag",
                //
                "WalnutOnFire",
                "BiologicalBreastplate",
                "BiologicalHelmet",
                "BiologicalLeggings",
                "Edgewalker",
                "GunBoot",
                "Mantreads",
                "ForestBreastplate",
                "ForestHelmet",
                "ForestLeggings",
                "IndividualCombatHelmet",
                "IndividualCombatLeggings",
                "IndividualCombatVest",
                "LibraMedal",
                "CleanTestTube"
            };

            string[] Sorcerer =
            {
                "ArchmageBadge",
                "EruditeBookmark",
                "IntellectualBookmark",
                "MagicalBookmark",
                "SpellPage_Blight",
                "SpellPage_Death",
                "SpellPage_Blood",
                "SpellPage_Eclipse",
                "SpellPage_Finale",
                "SpellPage_Freeze",
                "SpellPage_Fright",
                "SpellPage_Growth",
                "SpellPage_Hive",
                "SpellPage_Life",
                "SpellPage_Light",
                "SpellPage_Mana",
                "SpellPage_Matter",
                "SpellPage_Might",
                "SpellPage_Mirage",
                "SpellPage_Moon",
                "SpellPage_Night",
                "SpellPage_Nothingness",
                "SpellPage_Rainbow",
                "SpellPage_Scatter",
                "SpellPage_Shadow",
                "SpellPage_Sight",
                "SpellPage_Skyfire",
                "SpellPage_Sun",
                "SpellPage_Thriving",
                "SpellPage_Time",
                "SpellPage_Tornado",
                "SpellPage_Water",
                "MartyrsCrown",
                "NaturalEssence",
                "SaviorsHeart",
                "AggressiveSymbol",
                "AudaciousSymbol",
                "BattlesomeSymbol",
                "BleedingSymbol",
                "BoastfulSymbol",
                "CholericSymbol",
                "FastSymbol",
                "HiddenSymbol",
                "LoyalSymbol",
                "LuminousSymbol",
                "MysteriousSymbol",
                "PersistantSymbol",
                "SilentSymbol",
                "SolidSymbol",
                "TemperamentalSymbol",
                "VengefulSymbol",
                "Starflower",
                "StarImage",
                "GreatCrystal",
                "OnyxRobe",
                "PerpetualHelmet",
                "PerpetualLeggings",
                "PerpetualPlate",
                "WatchmanDress",
                "WatchmanHat",
                "WatchmanShirt",
                "UltraManaPotion"
            };

            string[] Summoner =
            {
                "AlienTech",
                "ArmillarySphere",
                "BatNecklace",
                "BatSignal",
                "BattalionsBackup",
                "BuffBanner",
                "Concheror",
                "ConstructionPDA",
                "CounsellorBadge",
                "CounsellorsFan",
                "DivineNecklace",
                "FastAidKit",
                "GrayRook",
                "GuerrillaTune",
                "LampreyScarf",
                "ChipInterface",
                "MechanicalBackpack",
                "MortiseStructure",
                "Pterothorax",
                "OneGiantLeap",
                "SpikyCover",
                "SurvivalCrisis",
                "AuroraBoots",
                "AuroraHeadwear",
                "AuroraRobe",
                "BoxOfMystery",
                "HeliologyMask",
                "AuroraMask",
                "FlinxFurHat",
                "FungusHat",
                "FungusJacket",
                "FungusTrousers",
                "HeliologyHelmet",
                "HeliologyLeggings",
                "HeliologyPlate",
                "SpiderHelmet",
                "SpookyHeadwear",
                "TikiHelmet",
                // Warrior-Summoner & Rogue (if Homeward Ragnarok enabled)
                "DivineFireFlask",
                "ForceBreakFlask",
                "PlagueFlask",
                "SteelFlask"
            };

            if (ModLoader.HasMod("ContinentOfJourney"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "ContinentOfJourney"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "ContinentOfJourney"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "ContinentOfJourney"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "ContinentOfJourney"));

                if (!ModLoader.HasMod("HomewardRagnarok"))
                {
                    result.AddRange(ClassTagsAdderHelper.GetTaggedItems(WarriorOrSummoner, "WarriorTag", "ContinentOfJourney"));
                    result.AddRange(ClassTagsAdderHelper.GetTaggedItems(RangerOrRogue, "RangerTag", "ContinentOfJourney"));
                    result.AddRange(ClassTagsAdderHelper.GetTaggedItems(SorcererOrHealer, "SorcererTag", "ContinentOfJourney"));
                    result.AddRange(ClassTagsAdderHelper.GetTaggedItems(OmniShield, "OmniShieldTag", "ContinentOfJourney"));
                }

                else
                {
                    result.AddRange(ClassTagsAdderHelper.GetTaggedItems(WarriorOrSummoner, "SummonerTag", "ContinentOfJourney"));
                    result.AddRange(ClassTagsAdderHelper.GetTaggedItems(RangerOrRogue, "RogueTag", "ContinentOfJourney"));
                    result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Rogue, "RogueTag", "ContinentOfJourney"));
                    result.AddRange(ClassTagsAdderHelper.GetTaggedItems(SorcererOrHealer, "HealerTag", "ContinentOfJourney"));
                }
            }

            return result;
        }
    }
}