using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class SOTSBardHealerClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("SOTSBardHealer") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            ModContent.TryFind<DamageClass>("SOTSBardHealer/VoidThrowing", out var voidThrowing);
            ModContent.TryFind<DamageClass>("SOTSBardHealer/VoidSymphonic", out var voidSymphonic);
            ModContent.TryFind<DamageClass>("SOTSBardHealer/VoidRadiant", out var voidRadiant);

            foreach (var item in ContentSamples.ItemsByType.Values)
            {
                if (item.CountsAsClass(voidThrowing) || item.CountsAsClass(voidSymphonic) || item.CountsAsClass(voidRadiant))
                    result.Add((item.type, "VoidTag"));
            }

            if (ModLoader.HasMod("ThrowerUnification"))
            {
                string[] UnifiedThrower =
                {
                    "DeathThroesThrows",
                    "ForbiddenMaelstrom",
                    "GoopwoodSplit",
                    "Serpentbite"
                };

                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(UnifiedThrower, "ThrowerTag", "SOTSBardHealer"));
            }

            string[] Healer =
            {
                "SerpentsTongue"
            };

            string[] Bard =
            {
                "HypersonicTuner",
                "RingofRest",
                "InfrasonicTuner",
                "SubsonicTuner",
                "TesseractTuner"
            };

            // Special Tags
            string[] VoidTag =
            {
                "DeathThroesThrows",
                "ForbiddenMaelstrom",
                "GoopwoodSplit",
                "Serpentbite",
                "SerpentsTongue",
                "HypersonicTuner",
                "RingofRest",
                "InfrasonicTuner",
                "SubsonicTuner",
                "TesseractTuner"
            };

            if (ModLoader.HasMod("SOTSBardHealer"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Healer, "HealerTag", "SOTSBardHealer"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Bard, "BardTag", "SOTSBardHealer"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(VoidTag, "VoidTag", "SOTSBardHealer"));
            }

            return result;
        }
    }
}