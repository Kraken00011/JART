using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class FargowiltasSoulsClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("FargowiltasSouls") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Warrior =
            {
                "BarbariansEssence",
                "BerserkerSoul",
                "BrokenBlade",
                "BrokenHilt",
                "BrokenSpearhead",
                "SolarBooster"
            };

            string[] Ranger =
            {
                "SharpshootersEssence",
                "SnipersSoul",
                "VortexBooster",
                "BrokenSpearhead"
            };

            string[] Sorcerer =
            {
                "ApprenticesEssence",
                "ArchWizardsSoul",
                "NebulaBooster"
            };

            string[] Summoner =
            {
                "OccultistsEssence",
                "ConjuristsSoul",
                "StardustBooster"
            };

            if (ModLoader.HasMod("FargowiltasSouls"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "FargowiltasSouls"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "FargowiltasSouls"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "FargowiltasSouls"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "FargowiltasSouls"));
            }

            return result;
        }
    }
}