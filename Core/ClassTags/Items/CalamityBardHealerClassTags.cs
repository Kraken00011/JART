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

public class CalamityBardHealerClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("CalamityBardHealer") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Healer =
            {
                "AerospecBiretta",
                "AuricTeslaValkyrieVisage",
                "BloodflareRitualistMask",
                "BloomingSaintessStatue",
                "DaedalusCowl",
                "HydrothermicGasMask",
                "SilvaGuardianHelmet",
                "StatigelFoxMask",
                "TarragonParagonCrown",
                "AugmentedAuricTeslaValkyrieVisage",
                "IntergelacticProtectorHelm",
                "VoidFaquirBiretta"
            };

            string[] Bard =
            {
                "AerospecHeadphones",
                "AuricTeslaFeatheredHeadwear",
                "BloodflareSirenSkull",
                "DaedalusHat",
                "ElementalBloom",
                "HydrothermicHat",
                "NoisebringerGoliath",
                "OmniSpeaker",
                "ScreamingClam",
                "YharimsJam",
                "VictideAmmoniteHat",
                "StatigelEarrings",
                "TarragonChapeau",
                "TreeWhispererAmulet",
                "GodSlayerDeathsingerCowl",
                "AugmentedAuricTeslaFeatheredHeadwear",
                "IntergelacticCloche",
                "VoidFaquirChapeau"
            };

            if (ModLoader.HasMod("CalamityBardHealer"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Healer, "HealerTag", "CalamityBardHealer"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Bard, "BardTag", "CalamityBardHealer"));
            }

            return result;
        }
    }
}