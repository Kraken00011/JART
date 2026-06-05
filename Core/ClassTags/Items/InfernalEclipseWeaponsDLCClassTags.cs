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

public class InfernalEclipseWeaponsDLCClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("InfernalEclipseWeaponsDLC") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "ArcticSpearTip",
                "SearingSpearTip"
            };

            string[] Rogue =
            {
                "SuperCellCirclet",
                "SuperCellGuard",
                "SuperCellSabatons"
            };

            string[] TrueWarrior =
            {
                "BlightedBadge"
            };

            string[] Healer =
            {
                "EclipseBreastplate",
                "EclipseGreaves",
                "EclipseHelm",
                "NeonRipper",
                "TwoPaths",
                "SwordofaThousandTruths"
            };

            string[] Bard =
            {
                "DeepSeaDrawlShard1",
                "DeepSeaDrawlShard2",
                "DeepSeaDrawlShard3"
            };

            if (ModLoader.HasMod("InfernalEclipseWeaponsDLC"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "InfernalEclipseWeaponsDLC"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Rogue, "RogueTag", "InfernalEclipseWeaponsDLC"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(TrueWarrior, "TrueWarriorTag", "InfernalEclipseWeaponsDLC"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Healer, "HealerTag", "InfernalEclipseWeaponsDLC"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Bard, "BardTag", "InfernalEclipseWeaponsDLC"));
            }

            return result;
        }
    }
}