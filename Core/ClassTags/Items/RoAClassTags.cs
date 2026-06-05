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

public class RoAClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("RoA") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            if (ModContent.TryFind<DamageClass>("RoA/DruidClass", out var druid))
            {
                foreach (var item in ContentSamples.ItemsByType.Values)
                {
                    if (item.CountsAsClass(druid))
                        result.Add((item.type, "DruidTag"));
                }
            }

            string[] Ranger =
            {
                "SentinelBreastplate",
                "SentinelHelmet",
                "SentinelLeggings",
                "SentinelTaurusMask"
            };

            string[] Sorcerer =
            {
                "CosmicHat",
                "CopperAcolyteHat",
                "CopperAcolyteJacket",
                "CopperAcolyteLeggings",
                "FlametrackerHat",
                "FlametrackerJacket",
                "FlametrackerPants",
                "TinAcolyteHat",
                "TinAcolyteJacket",
                "TinAcolyteLeggings"
            };

            string[] Summoner =
            {
                "FlinxFurUshanka",
                "WorshipperBonehelm",
                "WorshipperGarb",
                "WorshipperMantle"
            };

            string[] Druid =
            {
                "BandOfNature",
                "BandOfPurity",
                "DoubleFocusCharm",
                "FeathersInABalloon",
                "FeathersInABottle",
                "FireflyPin",
                "GiantTreeSapling",
                "Herbarium",
                "MercuriumCenser",
                "SoulOfTheWoods",
                "AshwalkerHood",
                "AshwalkerLeggings",
                "AshwalkerRobe",
                "DreadheartCorruptionChestplate",
                "DreadheartCorruptionHelmet",
                "DreadheartCorruptionLeggings",
                "DreadheartCrimsonChestplate",
                "DreadheartCrimsonHelmet",
                "DreadheartCrimsonLeggings",
                "LivingBorealWoodChestplate",
                "LivingBorealWoodGreaves",
                "LivingBorealWoodHelmet",
                "LivingElderwoodBreastplate",
                "LivingElderwoodCrown",
                "LivingElderwoodGreaves",
                "LivingMahoganyChestplate",
                "LivingMahoganyGreaves",
                "LivingMahoganyHelmet",
                "LivingPalmChestplate",
                "LivingPalmGreaves",
                "LivingPalmHelmet",
                "LivingWoodChestplate",
                "LivingWoodGreaves",
                "LivingWoodHelmet",
                "BeachWreath",
                "BeachWreath2",
                "FenethsBlazingWreath",
                "ForestWreath",
                "ForestWreath2",
                "JungleWreath",
                "JungleWreath2",
                "SnowWreath",
                "SnowWreath2",
                "TwigWreath",
                "ResiliencePotion",
                "WillpowerPotion",
                "DeerSkull"
            };


            if (ModLoader.HasMod("RoA"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "RoA"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "RoA"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "RoA"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Druid, "DruidTag", "RoA"));
            }

            return result;
        }
    }
}
