using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class HomewardRagnarokClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("HomewardRagnarok") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "HerbalistPouch"
            };

            string[] Ranger =
            {
                "EvilFlask"
            };

            string[] Summoner =
            {
                "RiftGenerator"
            };

            string[] Rogue =
            {
                "RogueBadge",
                "TheBibleOfTheThrowerVol4"
            };

            string[] Healer =
            {
                "DeluxeDewCollector",
                "ClericBadge"
            };

            string[] Bard =
            {
                "BardBadge"
            };

            if (ModLoader.HasMod("HomewardRagnarok"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "HomewardRagnarok"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "HomewardRagnarok"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "HomewardRagnarok"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Rogue, "RogueTag", "HomewardRagnarok"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Healer, "HealerTag", "HomewardRagnarok"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Bard, "BardTag", "HomewardRagnarok"));
            }

            return result;
        }
    }
}