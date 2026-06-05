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

public class ThoriumReworkClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("ThoriumRework") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Summoner =
            {
                "TitanVisor"
            };

            string[] Thrower =
            {
                "TitanHood"
            };

            string[] Bard =
            {
                "ConcussiveInstrument",
                "DeathsingerPotion",
                "FanDonations",
                "ImpulseAmplifier",
                "InspirationRegenerationPotion",
                "Loudener",
                "PickShapedPebble",
                "SealedContract",
                "TitanHat"
            };

            string[] Healer =
            {
                "ExecutionersContract",
                "LunateCharm",
                "TitanVisage"
            };

            if (ModLoader.HasMod("ThoriumRework"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "ThoriumRework"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Thrower, "ThrowerTag", "ThoriumRework"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Bard, "BardTag", "ThoriumRework"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Healer, "HealerTag", "ThoriumRework"));
            }

            return result;
        }
    }
}