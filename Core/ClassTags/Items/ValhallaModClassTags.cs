using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class ValhallaModClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("ValhallaMod") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "",
                "",
                "",
                ""
            };

            string[] Ranger =
            {
                "",
                "",
                "",
                ""
            };

            string[] Sorcerer =
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                ""
            };

            string[] Summoner =
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                ""
            };

            if (ModLoader.HasMod("ValhallaMod"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "ValhallaMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "ValhallaMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "ValhallaMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "ValhallaMod"));
            }

            return result;
        }
    }
}