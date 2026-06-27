using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class SpiritReforgedClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("SpiritReforged") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "FrostGiantBelt",
                "HideTunic",
                "BangleOfStrength",
                // Warrior-Summoner
                "FlaskOfFrost"
            };

            string[] Ranger =
            {
                "SleightOfHand",
                "BoomShroom"
            };

            string[] Sorcerer =
            {
                "SilkSirwal",
                "SilkTop",
                "SunEarrings",
                "ArcaneNecklaceGold",
                "ArcaneNecklacePlatinum"
            };

            string[] Summoner =
            {
                // Warrior-Summoner
                "FlaskOfFrost"
            };

            if (ModLoader.HasMod("SpiritReforged"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "SpiritReforged"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "SpiritReforged"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "SpiritReforged"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "SpiritReforged"));
            }

            return result;
        }
    }
}