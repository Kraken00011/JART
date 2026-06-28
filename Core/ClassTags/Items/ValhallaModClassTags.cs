using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class ValhallaModClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("ValhallaMod") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "BeeNecklace",
                "BerserkNeck",
                "CorrodeHelmet",
                "EvilLegs",
                // Warrior-Ranger
                "LostPegleg",
                // Warrior-Summoner
                "EvilBody"
            };

            string[] Ranger =
            {
                "NightScope",
                "CorrodeMask",
                "SniperBody",
                "SniperHead",
                "SniperLegs",
                "DartPotion",
                // Warrior-Ranger
                "LostPegleg"
            };

            string[] Sorcerer =
            {
                "CrystalSkull",
                "ManaForDummies",
                "SkullCuffs",
                "TinOfTuna",
                "UniversalMagnifyingGlass",
                "CorrodeHood",
                "InfiniteManaPotion"
            };

            string[] Summoner =
            {
                "JadeElephant",
                "NutfulNecklace",
                "SquareRoot",
                "BeeHelmet",
                "BeeMask",
                "CorrodeHead",
                "EvilHead",
                "FlinxFurBolero",
                "HiveHead",
                "HiveLegs",
                "HiveMask",
                "AuraPlusPotion",
                "SentryPlusPotion",
                // Warrior-Summoner
                "EvilBody"
            };

            string[] Thrower =
            {
                "BouncyLubricant",
                "SwiftSwatter",
                "VulturesPlume",
                "GreediestBody",
                "GreediestHead",
                "GreediestLegs"
            };

            if (ModLoader.HasMod("ValhallaMod"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "ValhallaMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "ValhallaMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "ValhallaMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "ValhallaMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Thrower, "ThrowerTag", "ValhallaMod"));
            }

            return result;
        }
    }
}