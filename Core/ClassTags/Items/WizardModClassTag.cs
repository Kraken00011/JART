using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class WizardModClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("WizardMod") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Sorcerer =
            {
                "ArcaneOrb",
                "CelestialHoop",
                "ClearCrystal",
                "ConjurerCrystal",
                "CorruptRing",
                "LunarLoop",
                "MoltenRing",
                "OvergrownPendant",
                "VampireRing",
                "InfusedCrystal",
                "StarterBag",
                "XionTomeDamaged",
                "WaterVial",
                "DeathEaterHat",
                "DeathEaterLegs",
                "DeathEaterRobe",
                "DeepslateChestplate",
                "DeepslateHood",
                "DeepslateLegs",
                "EnchantedHead",
                "EnchantedLegs",
                "EnchantedTunic",
                "LivingWoodLegs",
                "LivingWoodMask",
                "LivingWoodRobe",
                "DeepslateBar",
                "EnchantedBook",
                "FrozenShard",
                "InfusedStar",
                "LunarBar",
                "Scroll"
            };

            if (ModLoader.HasMod("WizardMod"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "WizardMod"));
            }

            return result;
        }
    }
}