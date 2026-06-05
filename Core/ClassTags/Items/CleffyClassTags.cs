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

public class CleffyClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("Cleffy") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Bard =
            {
                "CleffyItem"
            };

            if (ModLoader.HasMod("Cleffy"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Bard, "BardTag", "Cleffy"));
            }

            return result;
        }
    }
}