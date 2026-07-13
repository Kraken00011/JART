using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class MulticlassArmorsClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("MulticlassArmors") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "AshensteelHelm",
                "CavernaryFlameHelm",
                // Warrior-Sorcerer
                "NaturePurifierBoots",
                "NaturePurifierChestplate",
                "NaturePurifierHelm"
            };

            string[] Ranger =
            {
                "CavernaryFlameTorchbelt",
                "HeatVoltConductorVest",
                // Ranger-Sorcerer
                "VacuumBreastplate",
                "VacuumHood",
                "VacuumLeggings",
                // Ranger-Summoner
                "MechanicalBeastBreastplate",
                "MechanicalBeastHelmet",
                "MechanicalBeastLeggings"
            };

            string[] Sorcerer =
            {
                "AshensteelHood",
                "HeatVoltConductorHelmet",
                // Warrior-Sorcerer
                "NaturePurifierBoots",
                "NaturePurifierChestplate",
                "NaturePurifierHelm",
                // Ranger-Sorcerer
                "VacuumBreastplate",
                "VacuumHood",
                "VacuumLeggings",
                // Sorcerer-Summoner
                "ElderMagesHat"
            };

            string[] Summoner =
            {
                "AshensteelBoots",
                "CavernaryFlameHeadgear",
                // Ranger-Summoner
                "MechanicalBeastBreastplate",
                "MechanicalBeastHelmet",
                "MechanicalBeastLeggings",
                // Sorcerer-Summoner
                "ElderMagesHat"
            };

            if (ModLoader.HasMod("MulticlassArmors"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "MulticlassArmors"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "MulticlassArmors"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "MulticlassArmors"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "MulticlassArmors"));
            }

            return result;
        }
    }
}