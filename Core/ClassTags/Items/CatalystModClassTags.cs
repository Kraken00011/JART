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
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "CatalystMod"));
            }

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
            string[] RemoveTrueWarrior =
            {
                "IntergelacticHeadMelee"
            };

            if (ModLoader.HasMod("CatalystMod"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(RemoveTrueWarrior, "TrueWarriorTag", "CatalystMod", "JAtRT"));
            }

            return result;
        }
    }
}