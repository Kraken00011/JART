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

public class ClamityClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("Clamity") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                // Warrior-Rogue
                "SoulOfPyrogen"
            };

            string[] Sorcerer =
            {
                "IcicleRing"
            };

            string[] Summoner =
            {
                "BlightedSpyglass",
                "CyanPearl"
            };

            string[] Rogue =
            {
                "DraculasCharm",
                // Warrior-Rogue
                "SoulOfPyrogen"
            };

            string[] TrueWarrior =
            {
                "FrozenHellstoneChestplate",
                "FrozenHellstoneGreaves",
                "FrozenHellstoneVisor"
            };

            if (ModLoader.HasMod("Clamity"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "Clamity"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "Clamity"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "Clamity"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Rogue, "RogueTag", "Clamity"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(TrueWarrior, "TrueWarriorTag", "Clamity"));
            }

            return result;
        }
    }
}