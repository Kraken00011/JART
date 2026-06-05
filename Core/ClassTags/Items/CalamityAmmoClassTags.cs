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

public class CalamityAmmoClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("CalamityAmmo") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Ranger =
            {
                "ArcaneQuiver",
                "AutoCalculationCoil",
                "FastHolster",
                "FrigidCoil",
                "InfectedCrabGill",
                "MarvelousMycelium",
                "ModifiedCoil",
                "MushroomUnitedNations",
                "ScorchingCoil",
                "TransformerCoil",
                "WulfrumCoil",
                "ChewingGum"
            };

            if (ModLoader.HasMod("CalamityAmmo"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "CalamityAmmo"));
            }

            return result;
        }
    }
}