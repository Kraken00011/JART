using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class calamityzeithClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("calamityzeith") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior = "ZenithSeal";

            if (ModLoader.HasMod("calamityzeith"))
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "calamityzeith"));

            return result;
        }
    }
}