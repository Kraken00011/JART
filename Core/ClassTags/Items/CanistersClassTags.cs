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

public class CanistersClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("Canisters") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Ranger =
            {
                "SunBlessedTech",
                "ArcticCoolant",
                "CryoPumpAssembly",
                "PneumaticPump",
                "SolarSigil"
            };

            if (ModLoader.HasMod("Canisters"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "Canisters"));
            }

            return result;
        }
    }
}