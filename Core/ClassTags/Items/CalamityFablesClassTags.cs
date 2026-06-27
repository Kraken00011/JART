using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;
public class CalamityFablesClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("CalamityFables") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "SeaRiderGreaves",
                "SeaRiderHelmet",
                "SeaRiderTunic"
            };

            string[] Ranger =
            {
                "DesertProwlerHat",
                "DesertProwlerPants",
                "DesertProwlerShirt",
                "OldHunterHat",
                "OldHunterPants",
                "OldHunterShirt"
            };

            string[] Summoner =
            {
                "WulfrumHat",
                "PontiffsPiper"
            };

            if (ModLoader.HasMod("CalamityFables"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "CalamityFables"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "CalamityFables"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "CalamityFables"));
            }

            return result;
        }
    }
}