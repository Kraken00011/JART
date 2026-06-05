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

public class TheConfectionRebirthClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("TheConfectionRebirth") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "NeapoliniteMask"
            };

            string[] Ranger =
            {
                "AncientNeapoliniteHelmet",
                "NeapoliniteHelmet"
            };

            string[] Sorcerer =
            {
                "AncientNeapoliniteHeadgear",
                "NeapoliniteHeadgear"
            };

            string[] Summoner =
            {
                "AncientNeapoliniteHat",
                "NeapoliniteHat"
            };

            if (ModLoader.HasMod("TheConfectionRebirth"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "TheConfectionRebirth"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "TheConfectionRebirth"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "TheConfectionRebirth"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "TheConfectionRebirth"));
            }

            return result;
        }
    }
}