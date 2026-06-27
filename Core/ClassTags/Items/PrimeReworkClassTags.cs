using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class PrimeReworkClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("PrimeRework") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior = "EnergyHilt";

            string[] Sorcerer = "PortableEnergyConverter";

            if (ModLoader.HasMod("ThrowerUnification") || ModLoader.HasMod("ThoriumMod"))
            {
                string[] Thrower =
                {
                    "LaserStar",
                    "SwarmGrenade"
                };

                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Thrower, "ThrowerTag", "PrimeRework"));
            }

            if (ModLoader.HasMod("PrimeRework"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "PrimeRework"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "PrimeRework"));
            }

            return result;
        }
    }
}