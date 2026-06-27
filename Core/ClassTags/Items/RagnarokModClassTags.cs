using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class RagnarokModClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("RagnarokMod") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            string[] Summoner =
            {
                "SquirrelScarf",
                "TrueSquirrelScarf"
            };

            string[] Bard =
            {
                "AerospecBard",
                "VictideHeadBard",
                "FanDonations",
                "ImpulseAmplifier",
                "InspirationRegenerationPotion",
                "Loudener",
                "PickShapedPebble",
                "SealedContract",
                "TitanHat"
            };

            string[] Healer =
            {
                "AerospecHealer",
                "BloodflareHeadHealer",
                "DaedalusHeadHealer",
                "SilvaHeadHealer",
                "TarragonCowl",
                "VictideHeadHealer",
                "StatigelHeadHealer",
                "IntergelacticRamhelm"
            };

            if (ModLoader.HasMod("RagnarokMod"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "RagnarokMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Bard, "BardTag", "RagnarokMod"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Healer, "HealerTag", "RagnarokMod"));
            }

            return result;
        }
    }
}