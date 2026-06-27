using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class HMOreSummonerHelmetsClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("HMOreSummonerHelmets") && Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Summoner =
            {
                "PalladiumHelm",
                "AdamantiteHelm",
                "CobaltKabuto",
                "MythrilCrown",
                "OrichalcumCrown",
                "TitaniumGrowth"
            };

            if (ModLoader.HasMod("HMOreSummonerHelmets"))
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "HMOreSummonerHelmets"));

            return result;
        }
    }
}