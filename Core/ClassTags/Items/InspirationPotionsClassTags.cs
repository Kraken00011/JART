using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class InspirationPotionsClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("InspirationPotions") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Bard =
            {
                "InspirationFlower",
                "GreaterInspirationPotion",
                "InspirationPotion",
                "LesserInspirationPotion",
                "SuperInspirationPotion",
                "SupremeInspirationPotion"
            };

            if (ModLoader.HasMod("InspirationPotions"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Bard, "BardTag", "InspirationPotions"));
            }

            return result;
        }
    }
}