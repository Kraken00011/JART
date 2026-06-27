using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class CatalystModClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("CatalystMod") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Sorcerer =
            {
                "AstraJelly",
                "Lean"
            };

            if (ModLoader.HasMod("CatalystMod"))
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "CatalystMod"));

            return result;
        }
    }
}

public class CatalystModClassTagsRemover : ItemTagsRemover
{
    public bool IsEnabled => ModLoader.HasMod("CatalystMod") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName, string ModName)> RemovedItems
    {
        get
        {
            var result = new List<(int, string, string)>();

            // Class Tags
            string[] RemoveTrueWarrior = "IntergelacticHeadMelee";

            if (ModLoader.HasMod("CatalystMod"))
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(RemoveTrueWarrior, "TrueWarriorTag", "CatalystMod", "JAtRT"));

            return result;
        }
    }
}