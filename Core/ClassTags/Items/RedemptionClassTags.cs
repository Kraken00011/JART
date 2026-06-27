using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using JAtRT.Core.ClassTags;

public class RedemptionClassTags : ItemTagsAdder
{
    public bool IsEnabled => ModLoader.HasMod("Redemption") && Language.ActiveCulture.Name == "ru-RU";

    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            if (ModContent.TryFind<DamageClass>("Redemption/RitualistClass", out var ritualist))
            {
                foreach (var item in ContentSamples.ItemsByType.Values)
                {
                    if (item.CountsAsClass(ritualist))
                        result.Add((item.type, "RitualistTag"));
                }
            }

            string[] Warrior =
            {
                "MechanicalSheath",
                "MutagenMelee",
                "LeatherSheath",
                "HardlightHelm",
                "ShinkiteChestplate",
                "ShinkiteHelmet",
                "ShinkiteLeggings",
                "CommonGuardGreaves",
                "CommonGuardHelm1",
                "CommonGuardHelm2",
                "CommonGuardPlateMail",
                // Warrior-Summoner
                "BileFlask"
            };

            string[] Ranger =
            {
                "MutagenRanged",
                "DurableBowString",
                "HardlightVisor"
            };

            string[] Sorcerer =
            {
                "MutagenMagic",
                "HardlightCowl",
                "VortiHat",
                "VortiPants",
                "VortiRobes",
                "ElderWoodBreastplate",
                "ElderWoodGreaves",
                "ElderWoodHelmet"
            };

            string[] Summoner =
            {
                "MutagenSummon",
                "HardlightHood",
                "LivingWoodHelmet",
                "LivingWoodBody",
                "LivingWoodLeggings",
                // Warrior-Summoner
                "BileFlask"
            };

            string[] Ritualist =
            {
                "RitualistEmblem",
                "MutagenRitualist",
                "HardlightCasque",
                "ShadeBody",
                "ShadeHead",
                "ShadeLeggings",
                "BlackholeFragment"
            };

            if (ModLoader.HasMod("Redemption"))
            {
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Warrior, "WarriorTag", "Redemption"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ranger, "RangerTag", "Redemption"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Sorcerer, "SorcererTag", "Redemption"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Summoner, "SummonerTag", "Redemption"));
                result.AddRange(ClassTagsAdderHelper.GetTaggedItems(Ritualist, "RitualistTag", "Redemption"));
            }

            return result;
        }
    }
}