using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class starforgedclassicClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("starforgedclassic") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Sorcerer = { "EphemeralAmulet" };

            if (ModLoader.HasMod("starforgedclassic"))
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "starforgedclassic"));

            return result;
        }
    }
}