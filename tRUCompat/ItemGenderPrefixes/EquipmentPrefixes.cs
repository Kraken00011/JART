using System.Collections.Generic;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;
using CalamityRuTranslate.Core.Config;
using Microsoft.Xna.Framework;

public class EquipmentPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("EquipmentReforge") && ModLoader.HasMod("CalamityRuTranslate") && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);

        if (TRuConfig.Instance.VanillaLocalization)
        {
            tru.Call("AddVanillaFeminineItems", new int[]
            {
                // Петы
                ItemID.ShadowOrb,
                ItemID.Carrot,
                ItemID.Fish,
                ItemID.ZephyrFish,
                ItemID.BoneRattle,
                ItemID.CelestialWand,
                ItemID.SharkBait,
                ItemID.BirdieRattle,
                ItemID.ExoticEasternChewToy,
                ItemID.FullMoonSqueakyToy,
                ItemID.LightningCarrot,
                ItemID.TwinsPetItem,
                ItemID.DukeFishronPetItem,
                ItemID.MoonLordPetItem,
                ItemID.PumpkingPetItem,
                ItemID.EverscreamPetItem,
                ItemID.IceQueenPetItem,
                ItemID.DD2OgrePetItem,
                ItemID.BerniePetItem,
                ItemID.ChesterPetItem,
                ItemID.JunimoPetItem,
                ItemID.DirtiestBlock,
                // Маунты
                ItemID.Minecart,
                ItemID.FuzzyCarrot,
                ItemID.MinecartMech,
                ItemID.DesertMinecart,
                ItemID.FishMinecart,
                ItemID.BeeMinecart,
                ItemID.LadybugMinecart,
                ItemID.PigronMinecart,
                ItemID.SunflowerMinecart,
                ItemID.HellMinecart,
                ItemID.WitchBroom,
                ItemID.ShroomMinecart,
                ItemID.AmethystMinecart,
                ItemID.TopazMinecart,
                ItemID.SapphireMinecart,
                ItemID.EmeraldMinecart,
                ItemID.RubyMinecart,
                ItemID.DiamondMinecart,
                ItemID.AmberMinecart,
                ItemID.BeetleMinecart,
                ItemID.MeowmereMinecart,
                ItemID.PartyMinecart,
                ItemID.SteampunkMinecart,
                ItemID.CoffinMinecart,
                ItemID.DiggingMoleMinecart,
                ItemID.PirateShipMountItem,
                ItemID.SpookyWoodMountItem,
                ItemID.SuperheatedBlood,
                ItemID.FartMinecart,
                ItemID.TerraFartMinecart,
                // Крюки
                ItemID.SkeletronHand
            });

            tru.Call("AddVanillaNeuterItems", new int[]
            {
                // Петы
                ItemID.LizardEgg,
                ItemID.SpiderEgg,
                ItemID.MagicalPumpkinSeed,
                ItemID.CrimsonHeart,
                ItemID.SuspiciousLookingTentacle,
                ItemID.DD2PetGato,
                ItemID.DD2PetGhost,
                ItemID.DD2PetDragon,
                ItemID.KingSlimePetItem,
                ItemID.FairyQueenPetItem,
                ItemID.DD2BetsyPetItem,
                ItemID.QueenSlimePetItem,
                ItemID.PigPetItem,
                ItemID.BlueEgg,
                // Маунты
                ItemID.SlimySaddle,
                ItemID.HardySaddle,
                ItemID.BlessedApple,
                ItemID.PaintedHorseSaddle,
                ItemID.MajesticHorseSaddle,
                ItemID.DarkHorseSaddle,
                ItemID.QueenSlimeMountSaddle,
                ItemID.WolfMountItem
            });

            tru.Call("AddVanillaPluralItems", new int[]
            {
                // Петы
                ItemID.Seaweed,
                ItemID.ToySled,
                ItemID.EaterOfWorldsPetItem,
                // Маунты
                ItemID.ReindeerBells,
                ItemID.HoneyedGoggles,
                ItemID.GolfCart
            });
        }

        if (ModLoader.TryGetMod("CalamityMod", out Mod cal) && TRuConfig.Instance.CalamityModLocalization)
        {
            tru.Call("AddFeminineItems", cal, new[]
            {
                // Петы
                "AbyssShellFossil",
                "BloodyVein",
                "BrimstoneJewel",
                "CharredRelic",
                "ChromaticOrb",
                "CosmicPlushie",
                "EnchantedButterfly",
                "Levi",
                "RomajedaOrchid",
                "StrangeOrb",
                "TrashmanTrashcan",
                // Маунты
                "Brimrose",
                "TheCartofGods"
            });

            tru.Call("AddNeuterItems", cal, new[]
            {
                // Петы
                "ForgottenDragonEgg",
                "JoyfulHeart",
                "RottingEyeball"
            });
        }

        if (ModLoader.TryGetMod("ThoriumMod", out Mod th) && TRuConfig.Instance.ThoriumModLocalization)
        {
            tru.Call("AddFeminineItems", th, new[]
            {
                // Петы
                "CloudyChewToy",
                "DiscardedCloth",
                "AncientDrachma",
                "Twinkle",
                "FishEgg",
                "DoomSayersPenny",
                "BloodSausage",
                "FrozenTiara",
                "SimpleBroom",
                "SubterraneanBulb",
                "SweetBeet",
                "WhisperingShell",
                // Маунты
                "GoldenScale",
                "CyberneticSphere",
                "MassiveCrabClaw",
                "OtherworldlyRune",
                "SuperAnvil",
                "FakeCoin",
                "AquamarineMinecart",
                "OpalMinecart",
                "RocketCart",
                // Крюки
                "ZephyrsGrip"
            });

            tru.Call("AddNeuterItems", th, new[]
            {
                // Петы
                "AromaticBiscuit",
                "RottenMeat",
                "StormCloud",
                "ForgottenLetter",
                "PurifiersRing",
                "EmptyWormholePotion",
                "PinkSlimeEgg",
                "ExoticMynaEgg",
                // Маунты
                "Nimbus",
                "DesecratedHeart",
                "AmphibianEgg"
            });

            tru.Call("AddPluralItems", th, new[]
            {
                // Петы
                "AlienResearchNotes"
            });
        }

        if (ModLoader.TryGetMod("Redemption", out Mod red) && TRuConfig.Instance.RedemptionLocalization)
        {
            tru.Call("AddFeminineItems", red, new[]
            {
                // Петы
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                // Маунты
                "",
                ""
            });

            tru.Call("AddNeuterItems", red, new[]
            {
                // Петы
                "",
                "",
                ""
            });
        }

        if (ModLoader.TryGetMod("TheDepths", out Mod depths) && JARTLocalizationConf.Instance.TheDepthsFix)
        {
            tru.Call("AddFeminineItems", depths, new[]
            {
                // Петы
                "GeodeLazerPointer",
                // Маунты
                "MidnightHorseshoe",
                "OnyxMinecart",
                "PhantomFirecart"
            });

            tru.Call("AddNeuterItems", depths, new[]
            {
                // Маунты
                "PurpleflameNecklace"
            });

            tru.Call("AddPluralItems", depths, new[]
            {
                // Петы
                "ShadePetItem"
            });
        }

        if (ModLoader.TryGetMod("SOTS", out Mod sots))
        {
            tru.Call("AddFeminineItems", sots, new[]
            {
                // Маунты
                "SpiritSurfer"
            });

            tru.Call("AddNeuterItems", sots, new[]
            {
                // Петы
                "OtherworldlyServiceDevice",
                // Маунты
                "CapturedHeart"
            });
        }
    }
}