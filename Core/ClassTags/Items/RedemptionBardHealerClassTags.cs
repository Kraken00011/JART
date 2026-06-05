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

public class RedemptionBardHealerClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("RedemptionBardHealer") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Thrower =
            {
                "HardlightReticle",
                "MutagenThrower"
            };

            string[] Bard =
            {
                "HardlightVisage",
                "MutagenBard"
            };

            string[] Healer =
            {
                "HardlightMask",
                "MutagenHealer"
            };

            if (ModLoader.HasMod("RedemptionBardHealer"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Thrower, "ThrowerTag", "RedemptionBardHealer"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Bard, "BardTag", "RedemptionBardHealer"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Healer, "HealerTag", "RedemptionBardHealer"));
            }

            return result;
        }
    }
}