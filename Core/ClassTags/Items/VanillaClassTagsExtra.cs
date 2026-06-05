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

public class VanillaClassTagsExtra : ItemTagsAdder
{
    public bool IsEnabled => Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName)> TaggedItems
    {
        get
        {
            var result = new List<(int, string)>();

            // Class Tags
            int[] Warrior =
            {
                ItemID.Ale,
                ItemID.SharpeningStation,
                ItemID.Sake,
                ItemID.BerserkerGlove,
                ItemID.AncientHallowedMask,
                ItemID.BrokenHeroSword,
                // Warrior-Ranger
                ItemID.FrostHelmet,
                ItemID.FrostBreastplate,
                ItemID.FrostLeggings,
                // Warrior-Summoner
                ItemID.SquireGreatHelm,
                ItemID.SquirePlating,
                ItemID.SquireGreaves,
                ItemID.SquireAltHead,
                ItemID.SquireAltShirt,
                ItemID.SquireAltPants
            };

            foreach (int warrior in Warrior) result.Add((warrior, "WarriorTag"));

            int[] Ranger =
            {
                ItemID.AmmoBox,
                ItemID.ReconScope,
                ItemID.MoltenQuiver,
                ItemID.StalkersQuiver,
                ItemID.AncientHallowedHelmet,
                // Warrior-Ranger
                ItemID.FrostHelmet,
                ItemID.FrostBreastplate,
                ItemID.FrostLeggings,
                // Ranger-Summoner
                ItemID.HuntressWig,
                ItemID.HuntressJerkin,
                ItemID.HuntressPants,
                ItemID.HuntressAltHead,
                ItemID.HuntressAltShirt,
                ItemID.HuntressAltPants
            };

            foreach (int ranger in Ranger) result.Add((ranger, "RangerTag"));

            int[] Sorcerer =
            {
                ItemID.ManaCrystal,
                ItemID.ArcaneCrystal,
                ItemID.LesserManaPotion,
                ItemID.ManaPotion,
                ItemID.GreaterManaPotion,
                ItemID.SuperManaPotion,
                ItemID.CrystalBall,
                ItemID.ManaHairDye,
                ItemID.ManaCloak,
                ItemID.MagnetFlower,
                ItemID.ArcaneFlower,
                ItemID.NebulaPickup1,
                ItemID.NebulaPickup2,
                ItemID.NebulaPickup3,
                ItemID.AmethystRobe,
                ItemID.TopazRobe,
                ItemID.SapphireRobe,
                ItemID.EmeraldRobe,
                ItemID.RubyRobe,
                ItemID.DiamondRobe,
                ItemID.AmberRobe,
                ItemID.AncientHallowedHeadgear,
                // Sorcerer-Summoner
                ItemID.AncientBattleArmorHat,
                ItemID.AncientBattleArmorShirt,
                ItemID.AncientBattleArmorPants,
                ItemID.ApprenticeHat,
                ItemID.ApprenticeRobe,
                ItemID.ApprenticeTrousers,
                ItemID.ApprenticeAltHead,
                ItemID.ApprenticeAltShirt,
                ItemID.ApprenticeAltPants
            };

            foreach (int sorcerer in Sorcerer) result.Add((sorcerer, "SorcererTag"));

            int[] Summoner =
            {
                ItemID.SummoningPotion,
                ItemID.WarTable,
                ItemID.BewitchingTable,
                ItemID.ApprenticeScarf,
                ItemID.SquireShield,
                ItemID.HuntressBuckler,
                ItemID.MonkBelt,
                ItemID.HallowedHood,
                ItemID.AncientHallowedHood,
                ItemID.FlinxFurCoat,
                // Warrior-Summoner & Rogue (if Calamity enabled)
                ItemID.FlaskofPoison,
                ItemID.FlaskofVenom,
                ItemID.FlaskofCursedFlames,
                ItemID.FlaskofFire,
                ItemID.FlaskofGold,
                ItemID.FlaskofIchor,
                ItemID.FlaskofNanites,
                // Sorcerer-Summoner
                ItemID.AncientBattleArmorHat,
                ItemID.AncientBattleArmorShirt,
                ItemID.AncientBattleArmorPants,
                ItemID.ApprenticeHat,
                ItemID.ApprenticeRobe,
                ItemID.ApprenticeTrousers,
                ItemID.ApprenticeAltHead,
                ItemID.ApprenticeAltShirt,
                ItemID.ApprenticeAltPants,
                // Warrior-Summoner
                ItemID.SquireGreatHelm,
                ItemID.SquirePlating,
                ItemID.SquireGreaves,
                ItemID.SquireAltHead,
                ItemID.SquireAltShirt,
                ItemID.SquireAltPants,
                // Ranger-Summoner
                ItemID.HuntressWig,
                ItemID.HuntressJerkin,
                ItemID.HuntressPants,
                ItemID.HuntressAltHead,
                ItemID.HuntressAltShirt,
                ItemID.HuntressAltPants,
                // Summoner-Rogue
                ItemID.MonkBrows,
                ItemID.MonkShirt,
                ItemID.MonkPants,
                ItemID.MonkAltHead,
                ItemID.MonkAltShirt,
                ItemID.MonkAltPants
            };

            foreach (int summoner in Summoner) result.Add((summoner, "SummonerTag"));

            int[] Rogue =
            {
                ItemID.GladiatorHelmet,
                ItemID.GladiatorBreastplate,
                ItemID.GladiatorLeggings,
                // Warrior-Summoner & Rogue (if Calamity enabled)
                ItemID.FlaskofPoison,
                ItemID.FlaskofVenom,
                ItemID.FlaskofCursedFlames,
                ItemID.FlaskofFire,
                ItemID.FlaskofGold,
                ItemID.FlaskofIchor,
                ItemID.FlaskofNanites,
                // Summoner-Rogue
                ItemID.MonkBrows,
                ItemID.MonkShirt,
                ItemID.MonkPants,
                ItemID.MonkAltHead,
                ItemID.MonkAltShirt,
                ItemID.MonkAltPants,
            };

            foreach (int rogue in Rogue) result.Add((rogue, "RogueTag"));

            // Mod-dependant tags

            // With Thrower Unification
            if (ModLoader.HasMod("ThrowerUnification"))
            {
                int[] Thrower =
                {
                    ItemID.Bone
                };

                foreach (int thrower in Thrower) result.Add((thrower, "ThrowerTag"));
            }

            // With Jungle Bosses Rework
            if (ModLoader.HasMod("GolemRework"))
            {
                int[] Healer =
                {
                    ItemID.ShinyStone
                };
                
                foreach (int healer in Healer) result.Add((healer, "HealerTag"));
            }

            // Special Tags
            int[] OmniShield =
            {
                ItemID.AnkhShield
            };

            foreach (int omniShield in OmniShield) result.Add((omniShield, "OmniShieldTag"));

            return result;
        }
    }
}

public class VanillaClassTagsRemover : ItemTagsRemover
{
    public bool IsEnabled => Language.ActiveCulture.Name == "ru-RU";
    public List<(int ItemType, string TagName, string ModName)> RemovedItems
    {
        get
        {
            var result = new List<(int, string, string)>();

            if (ModLoader.HasMod("CerebralMod"))
            {
                int[] RemoveSummoner =
                {
                    // Sorcerer-Summoner
                    ItemID.ApprenticeHat,
                    ItemID.ApprenticeRobe,
                    ItemID.ApprenticeTrousers,
                    ItemID.ApprenticeAltHead,
                    ItemID.ApprenticeAltShirt,
                    ItemID.ApprenticeAltPants,
                    // Warrior-Summoner
                    ItemID.SquireGreatHelm,
                    ItemID.SquirePlating,
                    ItemID.SquireGreaves,
                    ItemID.SquireAltHead,
                    ItemID.SquireAltShirt,
                    ItemID.SquireAltPants,
                    // Ranger-Summoner
                    ItemID.HuntressWig,
                    ItemID.HuntressJerkin,
                    ItemID.HuntressPants,
                    ItemID.HuntressAltHead,
                    ItemID.HuntressAltShirt,
                    ItemID.HuntressAltPants,
                    // Rogue-Summoner
                    ItemID.MonkBrows,
                    ItemID.MonkShirt,
                    ItemID.MonkPants,
                    ItemID.MonkAltHead,
                    ItemID.MonkAltShirt,
                    ItemID.MonkAltPants
                };

                foreach (int removeSummoner in RemoveSummoner)
                    result.Add((removeSummoner, "SummonerTag", "JAtRT"));
            }

            return result;
        }
    }
}