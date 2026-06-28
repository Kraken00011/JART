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
                "CavernaryFlameHelm"
            };

            string[] Ranger =
            {
                "CavernaryFlameTorchbelt",
                "HeatVoltConductorVest"
            };

            string[] Sorcerer =
            {
                "AshensteelHood",
                "HeatVoltConductorHelmet",
                // Sorcerer-Summoner
                "ElderMagesHat"
            };

            string[] Summoner =
            {
                "AshensteelBoots",
                "CavernaryFlameHeadgear",
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