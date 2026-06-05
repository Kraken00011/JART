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

public class CalamityModClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("CalamityMod") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            if (ModContent.TryFind<DamageClass>("CalamityMod/RogueDamageClass", out var rogue) && !ModLoader.HasMod("ThrowerUnification"))
            {
                foreach (var item in ContentSamples.ItemsByType.Values)
                {
                    if (item.CountsAsClass(rogue))
                        result.Add((item.type, "RogueTag"));
                }
            }

            if (ModContent.TryFind<DamageClass>("CalamityMod/TrueMeleeDamageClass", out var trueMelee)
            && ModContent.TryFind<DamageClass>("CalamityMod/TrueMeleeNoSpeedDamageClass", out var trueMeleeNoSpeed))
            {
                foreach (var item in ContentSamples.ItemsByType.Values)
                {
                    if ((item.CountsAsClass(trueMelee) || item.CountsAsClass(trueMeleeNoSpeed)) && (item.pick <= 0 && item.axe <= 0 && item.hammer <= 0))
                        result.Add((item.type, "TrueWarriorTag"));
                }
            }

            string[] Warrior =
            {
                "BadgeofBravery",
                "BloodyWormScarf",
                "BloodyWormTooth",
                "ElementalGauntlet",
                "AerospecHeadMelee",
                "AuricTeslaHeadMelee",
                "BloodflareHeadMelee",
                "DaedalusHeadMelee",
                "GodSlayerHeadMelee",
                "HydrothermicHeadMelee",
                "StatigelHeadMelee",
                "TarragonHeadMelee",
                "VictideHeadMelee",
                // Warrior-Summoner-Rogue
                "FlaskOfBrimstone",
                "FlaskOfCrumbling",
                "FlaskOfHolyFlames"
            };

            string[] Ranger =
            {
                "DaawnlightSpiritOrigin",
                "DeadshotBrooch",
                "DynamoStemCells",
                "PlanebreakersPouch",
                "ProtolithBangle",
                "QuiverofNihility",
                "AerospecHeadRanged",
                "AuricTeslaHeadRanged",
                "BloodflareHeadRanged",
                "DaedalusHeadRanged",
                "GodSlayerHeadRanged",
                "HydrothermicHeadRanged",
                "LunicCorpsBoots",
                "LunicCorpsHelmet",
                "LunicCorpsVest",
                "PlagueReaperMask",
                "PlagueReaperStriders",
                "PlagueReaperVest",
                "SnowRuffianChestplate",
                "SnowRuffianGreaves",
                "SnowRuffianMask",
                "StatigelHeadRanged",
                "TarragonHeadRanged",
                "VictideHeadRanged",
                "GrapeBeer",
                "ScionsCurio"
            };

            string[] Sorcerer =
            {
                "EtherealTalisman",
                "SigilofCalamitas",
                "AerospecHeadMagic",
                "AuricTeslaHeadMagic",
                "BloodflareHeadMagic",
                "BrimflameBoots",
                "BrimflameCowl",
                "BrimflameRobes",
                "DaedalusHeadMagic",
                "HydrothermicHeadMagic",
                "PrismaticGreaves",
                "PrismaticHelmet",
                "PrismaticRegalia",
                "SilvaHeadMagic",
                "StatigelHeadMagic",
                "TarragonHeadMagic",
                "CometShard",
                "EtherealCore",
                "PhantomHeart",
                "VictideHeadMagic",
                "BatholithBangle",
                "ChaosStone",
                "ManaPolarizer",
                "EnchantedStarfish",
                "StarBeamRye",
                "SupremeManaPotion",
                "AureusCell",
                "AstralInjection"
            };

            string[] Summoner =
            {
                "AlchemicalDecanter",
                "HallowedRune",
                "JellyChargedBattery",
                "PhantomicArtifact",
                "SpiritGlyph",
                "StarbusterCore",
                "StarTaintedGenerator",
                "StatisBlessing",
                "StatisCurse",
                "TheFirstShadowflame",
                "VoltaicJelly",
                "AerospecHeadSummon",
                "BloodflareHeadSummon",
                "DaedalusHeadSummon",
                "AuricTeslaHeadSummon",
                "FathomSwarmerBoots",
                "FathomSwarmerBreastplate",
                "FathomSwarmerVisage",
                "HydrothermicHeadSummon",
                "PlaguebringerCarapace",
                "PlaguebringerPistons",
                "PlaguebringerVisor",
                "SilvaHeadSummon",
                "StatigelHeadSummon",
                "TarragonHeadSummon",
                "NuclearFuelRod",
                "Nucleogenesis",
                "VictideHeadSummon",
                "WulfrumHat",
                "WulfrumJacket",
                "WulfrumOveralls",
                "AuricSoulArtifact",
                "Rum",
                "WulfrumBattery",
                // Warrior-Summoner-Rogue
                "FlaskOfBrimstone",
                "FlaskOfCrumbling",
                "FlaskOfHolyFlames"
            };

            string[] Rogue =
            {
                "BloodstainedGlove",
                "BlunderBooster",
                "CoinofDeceit",
                "DarkMatterSheath",
                "DragonScales",
                "EclipseMirror",
                "ElectriciansGlove",
                "EtherealExtorter",
                "FeatherCrown",
                "FilthyGlove",
                "GloveOfPrecision",
                "GloveOfRecklessness",
                "MirageMirror",
                "MoonstoneCrown",
                "Nanotech",
                "PlaguedFuelPack",
                "RaidersTalisman",
                "RogueEmblem",
                "RottenDogtooth",
                "RuinMedallion",
                "SandCloak",
                "ScuttlersJewel",
                "SilencingSheath",
                "SpectralVeil",
                "VampiricTalisman",
                "VeneratedLocket",
                "BloodflareHeadRogue",
                "DaedalusHeadRogue",
                "DesertProwlerHat",
                "DesertProwlerPants",
                "DesertProwlerShirt",
                "EmpyreanCloak",
                "EmpyreanCuisses",
                "EmpyreanMask",
                "GodSlayerHeadRogue",
                "HydrothermicHeadRogue",
                "StatigelHeadRogue",
                "SulphurousBreastplate",
                "SulphurousHelmet",
                "SulphurousLeggings",
                "TarragonHeadRogue",
                "TitanHeartBoots",
                "TitanHeartMantle",
                "TitanHeartMask",
                "UmbraphileBoots",
                "UmbraphileHood",
                "UmbraphileRegalia",
                "VictideHeadRogue",
                "AbyssalMirror",
                "InkBomb",
                "AerospecHeadRogue",
                "AuricTeslaHeadRogue",
                "PurpleHaze",
                "StealthHairDye",
                "ShadowPotion",
                // Warrior-Summoner-Rogue
                "FlaskOfBrimstone",
                "FlaskOfCrumbling",
                "FlaskOfHolyFlames"
            };

            string[] TrueWarrior =
            {
                "HideofAstrumDeus"
            };

            if (ModLoader.HasMod("CalamityMod"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "CalamityMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "CalamityMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "CalamityMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "CalamityMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Rogue, "RogueTag", "CalamityMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(TrueWarrior, "TrueWarriorTag", "CalamityMod"));
            }

            return result;
        }
    }
}

public class CalamityModModClassTagsRemover : ItemTagsRemover
{
    public bool IsEnabled => ModLoader.HasMod("CalamityMod") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName, string ModName)> RemovedItems
    {
        get
        {
            var result = new List<(int, string, string)>();

            string[] RemoveWarrior =
            {
                "ShieldoftheHighRuler"
            };

            if (ModLoader.HasMod("CalamityMod"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(RemoveWarrior, "WarriorTag", "CalamityMod", "ThoriumClassTagsConsistency"));
            }

            return result;
        }
    }
}