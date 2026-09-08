using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace JAtRT.Core.Config;

public class JARTLocalizationConf : ModConfig
{
    public static JARTLocalizationConf Instance = ModContent.GetInstance<JARTLocalizationConf>();

    public override ConfigScope Mode => ConfigScope.ClientSide;

    [Header("BigMod")]

    // Corruption Core Boss
    [ReloadRequired]
    [DefaultValue(true)]
    public bool CorruptionBossLocalization;

    // Infernal Eclipse of Ragnarok
    [ReloadRequired]
    [DefaultValue(true)]
    public bool InfernalEclipseLocalization;

    // Mech Bosses Rework
    [ReloadRequired]
    [DefaultValue(true)]
    public bool PrimeReworkLocalization;

    // Thorium Helheim
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ThoriumReworkLocalization;

    [Header("MediumMod")]

    // 7 Useful Items from Minecraft
    [ReloadRequired]
    [DefaultValue(true)]
    public bool SevenItemsFromMinecraftLocalization;

    // Calamity Simple Whips Addon
    [ReloadRequired]
    [DefaultValue(true)]
    public bool CalamitySimpleWhipAddonLocalization;

    // Enchanted Moons
    [ReloadRequired]
    [DefaultValue(true)]
    public bool BlueMoonLocalization;

    // Evil Bosses Rework
    [ReloadRequired]
    [DefaultValue(true)]
    public bool EvilBossesReworkLocalization;

    // Fargo Rush Mod
    [ReloadRequired]
    [DefaultValue(true)]
    public bool SoulsBossRushLocalization;

    // HP Awareness
    [ReloadRequired]
    [DefaultValue(true)]
    public bool HPAwareLocalization;

    // Infernal Arsenal
    [ReloadRequired]
    [DefaultValue(true)]
    public bool InfernalEclipseWeaponsDLCLocalization;

    // Jungle Bosses Rework
    [ReloadRequired]
    [DefaultValue(true)]
    public bool GolemReworkLocalization;

    // Ophioid Mod
    [ReloadRequired]
    [DefaultValue(true)]
    public bool OphioidLocalization;

    // Revengeance+
    [ReloadRequired]
    [DefaultValue(true)]
    public bool RevengeancePlusLocalization;

    // Unofficial Calamity Bard & Healer
    [ReloadRequired]
    [DefaultValue(true)]
    public bool CalamityBardHealerLocalization;

    // Unofficial SOTS Bard, Thrower & Healer
    [ReloadRequired]
    [DefaultValue(true)]
    public bool SOTSBardHealerLocalization;

    [Header("SmallMod")]

    // Abyssal Subworld
    [ReloadRequired]
    [DefaultValue(true)]
    public bool HomewardSubworldLocalization;

    // Accessory Hearts
    [ReloadRequired]
    [DefaultValue(true)]
    public bool AccessoryHeartsLocalization;

    // Activate Windows Mod
    /*[ReloadRequired]
    [DefaultValue(true)]
    public bool ActivateWindowsLocalization;*/

    // Additional Relics
    [ReloadRequired]
    [DefaultValue(true)]
    public bool AdditionalRelicsLocalization;

    // Armor and Accessory Prefixes
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ArmorAndAccessoryPrefixesLocalization;

    // Armor Buffs
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ArmorBuffsLocalization;

    // Beam Stops Spread
    [ReloadRequired]
    [DefaultValue(true)]
    public bool BeamStopsSpreadLocalization;

    // Better Zenith in Calamity
    [ReloadRequired]
    [DefaultValue(true)]
    public bool CalamityZenithLocalization;

    // Boss Cursor
    [ReloadRequired]
    [DefaultValue(true)]
    public bool BossCursorLocalization;

    // Calamity Crossmod Vulnerabilities
    [ReloadRequired]
    [DefaultValue(true)]
    public bool CalamityCrossmodVulnerabilitiesLocalization;

    // Calamity Future Bosses Revived
    [ReloadRequired]
    [DefaultValue(true)]
    public bool FutureBossesLocalization;

    // Calamity Overdrive
    [ReloadRequired]
    [DefaultValue(true)]
    public bool WulfrumExpansionLocalization;

    // Calamity Treads
    [ReloadRequired]
    [DefaultValue(true)]
    public bool CalamityShoesLocalization;

    // Celestial Shield
    [ReloadRequired]
    [DefaultValue(true)]
    public bool CelestialShieldLocalization;

    // Cinematic Boss Intros
    [ReloadRequired]
    [DefaultValue(true)]
    public bool BossNameDisplayLocalization;

    // Clamity Music
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ClamityMusicLocalization;

    // Cleffy
    [ReloadRequired]
    [DefaultValue(true)]
    public bool CleffyLocalization;

    // Community Slot
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ComSlotLocalization;

    // Consolaria Legacy Items
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ConsolariaLegecyItemsLocalization;

    // Cosmic Elemental Returns
    [ReloadRequired]
    [DefaultValue(true)]
    public bool CosmicElementalPetLocalization;

    // Crown Set Bonuses
    [ReloadRequired]
    [DefaultValue(true)]
    public bool CrownSetsLocalization;

    // Discordya
    [ReloadRequired]
    [DefaultValue(true)]
    public bool DiscordyaLocalization;

    // Expanded Inventory
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ExpandedInventoryLocalization;

    // Experimental Infernum Extension
    [ReloadRequired]
    [DefaultValue(true)]
    public bool InfernumFablesLocalization;

    // Extra Beginnings
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ExtraBeginningsLocalization;

    // Extra World Sizes
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ExtraWorldSizesLocalization;

    // Fancy Whips
    [ReloadRequired]
    [DefaultValue(true)]
    public bool FancyWhipsLocalization;

    // Heart Crystal & Life Fruit Glow
    [ReloadRequired]
    [DefaultValue(true)]
    public bool LifeSourcesLightLocalization;

    // Holospark Boots
    [ReloadRequired]
    [DefaultValue(true)]
    public bool HolosparkBootsLocalization;

    // Hollow Knight!
    [ReloadRequired]
    [DefaultValue(true)]
    public bool HollowKnightLocalization;

    // Homeward Crossmod WorldGen Fix
    [ReloadRequired]
    [DefaultValue(true)]
    public bool HomewardWorldGenFixLocalization;

    // Hypnos in Calamity Mod
    [ReloadRequired]
    [DefaultValue(true)]
    public bool HypnosModLocalization;

    // Infernum Master Patch
    [ReloadRequired]
    [DefaultValue(true)]
    public bool InfernumMasterPatchLocalization;

    // InfiniteInteger's Mage Tweaks
    [ReloadRequired]
    [DefaultValue(true)]
    public bool MageTweaksLocalization;

    // Inspiration Potions
    [ReloadRequired]
    [DefaultValue(true)]
    public bool InspirationPotionsLocalization;

    // Item Relics
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ItemRelicsLocalization;

    // Javyz' Music Mod
    [ReloadRequired]
    [DefaultValue(true)]
    public bool FargosAltMusicModLocalization;

    // Mana Fruit
    [ReloadRequired]
    [DefaultValue(true)]
    public bool MLManaFruitLocalization;

    // Masochist Mode EX
    [ReloadRequired]
    [DefaultValue(true)]
    public bool MasomodeEXLocalization;

    // Miscellanaria
    [ReloadRequired]
    [DefaultValue(true)]
    public bool MiscellanariaLocalization;

    // More Beams
    [ReloadRequired]
    [DefaultValue(true)]
    public bool MoreBeamsLocalization;

    // More Pylons
    [ReloadRequired]
    [DefaultValue(true)]
    public bool EvilPylonLocalization;

    // Movement Speed Fixed
    [ReloadRequired]
    [DefaultValue(true)]
    public bool MoveSpeedFixLocalization;

    // Multiclass Armors
    [ReloadRequired]
    [DefaultValue(true)]
    public bool MulticlassArmorsLocalization;

    // Munchies
    [ReloadRequired]
    [DefaultValue(true)]
    public bool MunchiesLocalization;

    // Munchies - Calamity Addon
    [ReloadRequired]
    [DefaultValue(true)]
    public bool MunchiesCalamityAddonLocalization;

    // Munchies Crossmod Addon
    [ReloadRequired]
    [DefaultValue(true)]
    public bool MunchiesAuricSoulsAddonLocalization;

    // Music Box Slot
    [ReloadRequired]
    [DefaultValue(true)]
    public bool MusicBoxSlotLocalization;

    // Ore Helmets for Summoner
    [ReloadRequired]
    [DefaultValue(true)]
    public bool HMOreSummonerHelmetsLocalization;

    // Petrified Voodoo Doll
    [ReloadRequired]
    [DefaultValue(true)]
    public bool PetrifiedVoodooDollLocalization;

    // Pinnacle Reforges
    [ReloadRequired]
    [DefaultValue(true)]
    public bool PinnacleReforgesLocalization;

    // Playthrough Modlist Loader
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ModlistIncompatibilitySolverLocalization;

    // Polyphemalus
    [ReloadRequired]
    [DefaultValue(true)]
    public bool PolyphemalusLocalization;

    // Potion Slots
    [ReloadRequired]
    [DefaultValue(true)]
    public bool PotionSlotsLocalization;

    // Rainbow Master
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ColouredModsRelicsLocalization;

    // Reforged
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ReforgedLocalization;

    // Robes of Calamity
    [ReloadRequired]
    [DefaultValue(true)]
    public bool RobesOfCalamityLocalization;

    // Shimmer Gun
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ShimmerGunLocalization;

    // Shoe Slot
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ShoeSlotLocalization;

    // Shroomaria
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ShroomariaLocalization;

    // Some Worm Bosses Actually Destroys Tiles
    [ReloadRequired]
    [DefaultValue(true)]
    public bool SWBADTsLocalization;

    // Spirit Classic Bosses Rework
    [ReloadRequired]
    [DefaultValue(true)]
    public bool SpiritofOverseerLocalization;

    // Starforged [OLD]
    [ReloadRequired]
    [DefaultValue(true)]
    public bool starforgedclassicLocalization;

    // Starting Weapons Reborn
    [ReloadRequired]
    [DefaultValue(true)]
    public bool StartingWeaponsLocalization;

    // Steam Achievement Fix
    [ReloadRequired]
    [DefaultValue(true)]
    public bool FixedAchievementsLocalization;

    // Talisman of Friendship
    [ReloadRequired]
    [DefaultValue(true)]
    public bool TalismanofFriendshipLocalization;

    // Thorium Class Tags Consistency
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ThoriumClassTagsConsistencyLocalization;

    // Thrower Unification
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ThrowerUnificationLocalization;

    // Turtle Boulder & Friends
    [ReloadRequired]
    [DefaultValue(true)]
    public bool TurtleBoulderLocalization;

    // Ultimate Infinite Star
    [ReloadRequired]
    [DefaultValue(true)]
    public bool UISLocalization;

    // Unofficial Alternative Biomes Compatibility
    [ReloadRequired]
    [DefaultValue(true)]
    public bool AlternativeCompatLocalization;

    // Unofficial Fargo's Souls Pets
    [ReloadRequired]
    [DefaultValue(true)]
    public bool FargoUnofficialPetsLocalization;

    // Vanilla Calamity Mod Music
    [ReloadRequired]
    [DefaultValue(true)]
    public bool UnCalamityMusicLocalization;

    // Vanity + Dyable Cursors API
    [ReloadRequired]
    [DefaultValue(true)]
    public bool NightshadeVanityCursorsLocalization;

    // What Ammo Does This Use?
    [ReloadRequired]
    [DefaultValue(true)]
    public bool WADTULocalization;

    // Whip Accessories
    [ReloadRequired]
    [DefaultValue(true)]
    public bool GauntletsLocalization;

    // WHummus' Calamity/Thorium Balancing
    [ReloadRequired]
    [DefaultValue(true)]
    public bool WHummusMultiModBalancingLocalization;

    // Wing Slot
    [ReloadRequired]
    [DefaultValue(true)]
    public bool WingSlotLocalization;

    // Wrath of the Beams
    [ReloadRequired]
    [DefaultValue(true)]
    public bool SolynWeaponLocalization;

    // Wrath of the Empress
    [ReloadRequired]
    [DefaultValue(true)]
    public bool WoTELocalization;

    // You
    [ReloadRequired]
    [DefaultValue(true)]
    public bool YouBossLocalization;

    [Header("Fix")]

    // Calamity - Fargo's Souls DLC
    [ReloadRequired]
    [DefaultValue(true)]
    public bool FargowiltasCrossmodFix;

    // Calamity: Hunt of the Old God
    [ReloadRequired]
    [DefaultValue(true)]
    public bool CalamityHuntFix;

    // Cataclysm Mod
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ClamityFix;

    // Compact Mods
    [ReloadRequired]
    [DefaultValue(true)]
    public bool CompactModsFix;

    // Flinx Ushanka
    [ReloadRequired]
    [DefaultValue(true)]
    public bool FlinxHatFix;

    // Infernum Difficulties and Generation Patch
    [ReloadRequired]
    [DefaultValue(true)]
    public bool InfernumLegendAndMasFix;

    // The Depths
    [ReloadRequired]
    [DefaultValue(true)]
    public bool TheDepthsFix;

    // Tools Prefixes
    [ReloadRequired]
    [DefaultValue(true)]
    public bool ToolsPrefixesFix;
}

public class JARTClientCfg : ModConfig
{
    public static JARTClientCfg Instance = ModContent.GetInstance<JARTClientCfg>();

    public override ConfigScope Mode => ConfigScope.ClientSide;

    [Header("Misc")]

    [DefaultValue(true)]
    public bool ExtraClassTags;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool CBuffsForOtherMods;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool CheckModCompatibility;
}