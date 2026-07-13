using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class CorruptionBossClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("CorruptionBoss") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Sorcerer =
            {
                "CrystallineUmbra",
                "ShadeSplinter",
                "SiphonStone"
            };

            if (ModLoader.HasMod("CorruptionBoss"))
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "CorruptionBoss"));

            return result;
        }
    }
}