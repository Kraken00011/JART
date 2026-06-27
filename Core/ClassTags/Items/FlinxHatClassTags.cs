using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class FlinxHatClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("FlinxHat") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Summoner =
            {
                "FlinxFurUshanka"
            };

            if (ModLoader.HasMod("FlinxHat"))
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "FlinxHat"));

            return result;
        }
    }
}