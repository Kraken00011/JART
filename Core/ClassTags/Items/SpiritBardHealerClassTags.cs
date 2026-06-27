using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class SpiritBardHealerClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("SpiritBardHealer") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Healer =
            {
                "LavenderAcupuncture"
            };

            if (ModLoader.HasMod("SpiritBardHealer"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Healer, "HealerTag", "SpiritBardHealer"));
            }

            return result;
        }
    }
}