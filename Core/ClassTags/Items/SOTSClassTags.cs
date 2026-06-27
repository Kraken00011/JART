using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class SOTSClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("SOTS") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            ModContent.TryFind<DamageClass>("SOTS/VoidMelee", out var voidMelee);
            ModContent.TryFind<DamageClass>("SOTS/VoidRanged", out var voidRanged);
            ModContent.TryFind<DamageClass>("SOTS/VoidMagic", out var voidMagic);
            ModContent.TryFind<DamageClass>("SOTS/VoidSummon", out var voidSummon);

            if (voidMelee != null || voidRanged != null || voidMagic != null || voidSummon != null)
            {
                foreach (var item in ContentSamples.ItemsByType.Values)
                {
                    if (item.CountsAsClass(voidMelee) || item.CountsAsClass(voidRanged) || item.CountsAsClass(voidMagic) || item.CountsAsClass(voidSummon))
                        result.Add((item.type, "VoidTag"));
                }
            }


            string[] Warrior =
            {
                "EarthDrive",
                "SerpentSpine",
                "ParticleRelocator",
                "RockCandy",
                "EndothermicAfterburner",
                "FrigidGreaves",
                "ZombieHand",
                // Void-Warrior
                "Hyperdrive",
                "CircuitBoard",
                "CrushingAmplifier",
                "CrushingCapacitor",
                "CrushingResistor",
                "CrushingTransformer",
                "SupernovaEmblem",
                // Void-Warrior-Summoner
                "ElementalBreastplate",
                "ElementalHelmet",
                "ElementalLeggings",
                "TwilightAssassinsChestplate",
            };

            string[] Ranger =
            {
                "BagOfAmmoGathering",
                "InfinityPouch",
                "BlazingQuiver",
                // Void-Ranger
                "VibrantChestplate",
                "VibrantHelmet",
                "VibrantLeggings"
            };

            string[] Sorcerer =
            {
                "WishingStar",
                "Starbelt",
                // Void-Sorcerer
                "CursedHood",
                "CursedRobe",
                "VoidenBracelet",
                "PlasmaShrimp"
            };

            string[] Summoner =
            {
                "FortressGenerator",
                "NatureLeggings",
                "NatureShirt",
                "NatureWreath",
                "PlatformGenerator",
                "PatchLeatherHat",
                "PatchLeatherPants",
                "PatchLeatherTunic",
                // Void-Warrior-Summoner
                "ElementalBreastplate",
                "ElementalHelmet",
                "ElementalLeggings",
                "TwilightAssassinsChestplate"
            };

            if (ModLoader.HasMod("SOTSBardHealer"))
            {
                string[] Healer = { "HarvestersScythe" };

                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Healer, "HealerTag", "SOTS"));
            }

            // Special Tags
            string[] Void =
            {
                "ExcavatorBreastplate",
                "ExcavatorHelmet",
                "ExcavatorLeggings",
                "MrBurns",
                "RockingHorse",
                "RotHeart",
                "VisionAmulet",
                "VoidspaceBreastplate",
                "VoidspaceEmblem",
                "VoidspaceLeggings",
                "VoidspaceMask",
                "SpiritSymphony",
                "VoidmageIncubator",
                "SyntheticLiver",
                "WishingStar",
                "InfinityPouch",
                "VoidAnomaly",
                "ExoticPolarizer",
                "InfiniteVoid",
                "FlowerCrown",
                "VesperaBreastplate",
                "VesperaLeggings",
                "VesperaMask",
                "VoidTablet",
                "OlympianAegis",
                "GoldBattery",
                "PlatinumBattery",
                "FrigidHourglass",
                "SkywareBattery",
                "VibrancyModule",
                "TwilightBeads",
                "SoulAccessPotion",
                "SpiritShield",
                "TheDarkEye",
                "AlmondMilk",
                "AvocadoSoup",
                "Chocolate",
                "CoconutMilk",
                "CookedMushroom",
                "CursedCaviar",
                "DigitalCornSyrup",
                "JumboSurpriseEgg",
                "PetalSalad",
                "ScarletStar",
                "SoulHeart",
                "StrawberryIcecream",
                "Taco",
                "VioletStar",
                "VoidenAnkh",
                "GildedBladeWings",
                "FoulConcoction",
                "MachinaBooster",
                // Void-Warrior
                "Hyperdrive",
                "CircuitBoard",
                "CrushingAmplifier",
                "CrushingCapacitor",
                "CrushingResistor",
                "CrushingTransformer",
                "SupernovaEmblem",
                // Void-Warrior-Summoner
                "ElementalBreastplate",
                "ElementalHelmet",
                "ElementalLeggings",
                "TwilightAssassinsChestplate",
                // Void-Ranger
                "VibrantChestplate",
                "VibrantHelmet",
                "VibrantLeggings",
                // Void-Sorcerer
                "CursedHood",
                "CursedRobe",
                "VoidenBracelet",
                "PlasmaShrimp",
                "TinyPlanetoid"
            };

            if (ModLoader.HasMod("SOTS"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "SOTS"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "SOTS"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "SOTS"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "SOTS"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Void, "VoidTag", "SOTS"));
            }

            return result;
        }
    }
}