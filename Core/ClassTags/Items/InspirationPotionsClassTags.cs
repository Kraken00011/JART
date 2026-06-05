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