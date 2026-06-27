using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class InfernalEclipseAPIClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("InfernalEclipseAPI") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Summoner = "SplitFirebrand";

            // Special Tags
            string[] Void =
            {
                "RuinousPlasmaInjection",
                "SingularityCore"
            };

            if (ModLoader.HasMod("InfernalEclipseAPI"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "InfernalEclipseAPI"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Void, "VoidTag", "InfernalEclipseAPI"));
            }

            return result;
        }
    }
}