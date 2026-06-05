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

public class ConsolariaClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("Consolaria") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "AncientDragonBreastplate",
                "AncientDragonGreaves",
                "AncientDragonMask",
                "DragonBreastplate",
                "DragonGreaves",
                "DragonMask",
                "ShadowboundExoskeleton"
            };

            string[] Ranger =
            {
                "AncientTitanHelmet",
                "AncientTitanLeggings",
                "AncientTitanMail",
                "TitanHelmet",
                "TitanLeggings",
                "TitanMail"
            };

            string[] Sorcerer =
            {
                "AncientPhantasmalHeadgear",
                "AncientPhantasmalRobe",
                "AncientPhantasmalSubligar",
                "PhantasmalHeadgear",
                "PhantasmalRobe",
                "PhantasmalSubligar"
            };

            string[] Summoner =
            {
                "AncientWarlockHood",
                "AncientWarlockLeggings",
                "AncientWarlockRobe",
                "WarlockHood",
                "WarlockLeggings",
                "WarlockRobe"
            };

            if (ModLoader.HasMod("ThrowerUnification"))
            {
                string[] UnifiedThrower =
                {
                    "OldViperChestplate",
                    "OldViperHelmet",
                    "OldViperLegs",
                    "ViperChestplate",
                    "ViperHelmet",
                    "ViperLegs"
                };
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(UnifiedThrower, "ThrowerTag", "Consolaria"));
            }

            if (ModLoader.HasMod("Consolaria"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "Consolaria"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "Consolaria"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "Consolaria"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "Consolaria"));
            }

            return result;
        }
    }
}