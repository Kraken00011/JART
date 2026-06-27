using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class MLManaFruitClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("MLManaFruit") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Sorcerer =
            {
                "ManaFruit",
                "ManaFruitSnow"
            };

            if (ModLoader.HasMod("MLManaFruit"))
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "MLManaFruit"));

            return result;
        }
    }
}