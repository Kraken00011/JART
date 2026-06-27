using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class SplitClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("Split") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            if (ModContent.TryFind<DamageClass>("Split/HeavyMeleeDamageClass", out var heavyWarrior))
            {
                foreach (var item in ContentSamples.ItemsByType.Values)
                {
                    if (item.CountsAsClass(heavyWarrior)) 
                        result.Add((item.type, "HeavyWarriorTag"));
                }
            }

            string[] Warrior =
            {
                "SportsBag",
                "BoilingPoint",
                "DragonShield",
                "KnightmareShield",
                "HuskSkull",
                "PossessedBreastplate",
                "PossessedLeggings",
                "PossessedHelmet",
                "RimebreakerBreastplate",
                "RimebreakerHelmet",
                "RimebreakerLeggings"
            };

            string[] Ranger =
            {
                "AstroQuiver",
                "EnchantedArrow",
                "MagnetQuiver",
                "StarRangerCoat",
                "StarRangerHat",
                "StarRangerPants"
            };

            string[] Sorcerer =
            {
                "CelestialGlobe",
                "DiscourteousFullMoon",
                "DiscourteousNewMoon",
                "LunarSmirkCharm",
                "MoonHand",
                "NightoSphere",
                "WitchAmberHat",
                "WitchAmethystHat",
                "WitchDiamondHat",
                "WitchEmeraldHat",
                "WitchRubyHat",
                "WitchSapphireHat",
                "WitchTopazHat",
                "StargazerHat",
                "StargazerRobe",
                "OverloadingCrystal",
                "GelidManaPotion"
            };

            string[] Summoner =
            {
                "PrimordialEbonstone",
                "AlluringSkull",
                "AvengerMask",
                "BrightstoneChunk",
                "BrokenOverclocker",
                "ClockworkShield",
                "MalachiteCasket",
                "MaskOfEvil",
                "MyceliumFortress",
                "SagesHead",
                "Starshroom",
                "ArachnidLegs",
                "ContraptionistBoots",
                "ContraptionistHat",
                "ContraptionistChestplate",
                "CrabBreastplate",
                "CrabHelmet",
                "CrabLeggings",
                "GravekeeperHood",
                "GravekeeperJacket",
                "GravekeeperLeggings",
                "JellyGelmet",
                "JellySlimeplate",
                "JellyWobblers",
                "PossessedLeggings",
                "WarlochBreastplate",
                "WarlochHat",
                "WarlochLeggings",
                "WarlochSetItem"
            };

            string[] HeavyWarrior =
            {
                "MementoVivere",
                "ToughstoneShield",
                "StrikersHelmet"
            };

            if (ModLoader.HasMod("Split"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "Split"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "Split"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "Split"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "Split"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(HeavyWarrior, "HeavyWarriorTag", "Split"));
            }

            return result;
        }
    }
}

public class SplitClassTagsRemover : ItemTagsRemover
{
    public bool IsEnabled => ModLoader.HasMod("Split") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName, string ModName)> RemovedItems
    {
        get
        {
            var result = new List<(int, string, string)>();
            
            if (ModContent.TryFind<DamageClass>("Split/HeavyMeleeDamageClass", out var heavyMelee))
            {
                foreach (var item in ContentSamples.ItemsByType.Values)
                {
                    if (item.CountsAsClass(heavyMelee))
                        result.Add((item.type, "ClassTag", "ThoriumClassTagsConsistency"));
                }
            }

            return result;
        }
    }
}