using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class CelestialShieldClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("CelestialShield") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Special Tags
            string[] OmniShield =
            {
                "CelestialShield"
            };

            if (ModLoader.HasMod("CelestialShield"))
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(OmniShield, "OmniShieldTag", "CelestialShield"));

            return result;
        }
    }
}