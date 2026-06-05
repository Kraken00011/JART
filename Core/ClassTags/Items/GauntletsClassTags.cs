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

public class GauntletsClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("Gauntlets") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Summoner =
            {
                "CarapaceBattlegrips",
                "DungeonGlove",
                "FortifiedKnockers",
                "GhostlyGrip",
                "GleamingGauntlets",
                "HolyGauntlet",
                "LeatherGlove",
                "ObsidianGlove",
                "StellarGloves",
                "WoodenBracers"
            };

            if (ModLoader.HasMod("Gauntlets"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "Gauntlets"));
            }

            return result;
        }
    }
}