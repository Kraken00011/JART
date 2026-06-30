using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class FargowiltasCrossmodClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("FargowiltasCrossmod") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Rogue =
            {
                "OutlawsEssence",
                "VagabondsSoul"
            };

            if (ModLoader.HasMod("FargowiltasCrossmod"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Rogue, "RogueTag", "FargowiltasCrossmod"));
            }

            return result;
        }
    }
}