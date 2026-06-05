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

public class CelestialShieldClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("CelestialShield") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] OmniShield =
            {
                "CelestialShield"
            };

            if (ModLoader.HasMod("CelestialShield"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(OmniShield, "OmniShieldTag", "CelestialShield"));
            }

            return result;
        }
    }
}