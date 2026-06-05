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

public class SpookyClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("Spooky") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "GourdBody",
                "GourdHead",
                "GourdLegs",
                "AutumnLeaf"
            };

            string[] Ranger =
            {
                "RootBody",
                "RootHead",
                "RootLegs",
                "EggCarton"
            };

            string[] Sorcerer =
            {
                "YuletideBody",
                "YuletideHead",
                "YuletideLegs",
                "WizardGangsterBody",
                "WizardGangsterHead",
                "WizardGangsterHead2",
                "WizardGangsterLegs",
                "CreepyCandle"
            };

            string[] Summoner =
            {
                "BroccoliBody",
                "BroccoliHead",
                "BroccoliLegs",
                "HazmatBody",
                "HazmatHead",
                "HazmatLegs",
                "CandyBag",
                "WarlockRobe",
                "EyeBody",
                "EyeHead",
                "EyeLegs"
            };

            if (ModLoader.HasMod("Spooky"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "Spooky"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "Spooky"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "Spooky"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "Spooky"));
            }

            return result;
        }
    }
}