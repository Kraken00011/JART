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
                ItemID.GrapplingHook,
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

        if (ModLoader.HasMod("CalamityMod") && TRuConfig.Instance.CalamityModLocalization)
        {
            tru.Call("AddFeminineItems", new string[]
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

            tru.Call("AddNeuterItems", new string[]
            {
                // Петы
                "ForgottenDragonEgg",
                "JoyfulHeart",
                "RottingEyeball"
            });
        }
    }
}