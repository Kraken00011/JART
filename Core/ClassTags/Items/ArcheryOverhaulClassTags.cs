using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class ArcheryOverhaulClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("ArcheryOverhaul") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Ranger =
            {
                "ArcherEmblem",
                "ArcherMark",
                "ArrowCarver",
                "Flint",
                "HomingSensor",
                "FireQuiver",
                "FreezeflameQuiver",
                "HunterQuiver",
                "IceQuiver",
                "MechQuiver",
                "MysticQuiver",
                "Quiver",
                "StrangeQuiver",
                "SturdyQuiver",
                "SherwoodBracer",
                "SteelTarget",
                "Target",
                "ApolloChest",
                "ApolloHelmet",
                "ApolloLegs",
                "ArcherCloak",
                "ArcherHelmet",
                "ArcherPants",
                "RobinHelmet",
                "RobinPants",
                "RobinTunic",
                "ArrowBag",
                "ArrowBag2",
                "ArrowBag3",
                "ArrowBag4",
                "ArrowBag5",
                "IceBag",
                "JungleBag",
                "StarterBag",
                "BrokenBow",
                "DaoShard",
                "DemonicString",
                "DwarfAlloy",
                "MysticString",
                "ReinforcedString",
                "SilkString",
                "ArrowPotion"
            };

            if (ModLoader.HasMod("ArcheryOverhaul"))
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "ArcheryOverhaul"));

            return result;
        }
    }
}