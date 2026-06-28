using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class TheDepthsClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("TheDepths") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "AquaGlove",
                "AquaStone",
                // Warrior-Summoner
                "FlaskofMercury"
            };

            string[] Ranger = { "AquaQuiver" };

            string[] Sorcerer =
            {
                "CharredCrown",
                "CrystalCrown",
                "OnyxRobe"
            };

            string[] Summoner =
            {
                "GeodeChestplate",
                "GeodeHelmet",
                "GeodeLeggings",
                "QuartzHood",
                "QuartzLeggings",
                "QuartzWinterCoat",
                // Warrior-Summoner
                "FlaskofMercury"
            };

            if (ModLoader.HasMod("TheDepths"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "TheDepths"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "TheDepths"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "TheDepths"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "TheDepths"));
            }

            return result;
        }
    }
}