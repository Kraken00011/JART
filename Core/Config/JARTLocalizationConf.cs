using System.ComponentModel;
using System.Data.Common;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace JAtRT.Core.Config;

public class JARTLocalizationConf : ModConfig
{
    public static JARTLocalizationConf Instance = ModContent.GetInstance<JARTLocalizationConf>();

    public override ConfigScope Mode => ConfigScope.ClientSide;

    [Header("BigMod")]

    [ReloadRequired]
    [DefaultValue(true)]
    public bool CorruptionBossLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool InfernalEclipseLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool PrimeReworkLocalization;

    [Header("MediumMod")]

    [ReloadRequired]
    [DefaultValue(true)]
    public bool SevenItemsFromMinecraftLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool BlueMoonLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool CalamitySimpleWhipAddonLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool EvilBossesReworkLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool SoulsBossRushLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool HomewardRagnarokLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool HPAwareLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool GolemReworkLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool OphioidLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool RevengeancePlusLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool SOTSBardHealerLocalization;

    [ReloadRequired]
    [Label("Unofficial Calamity Bard & Healer")]
    [Tooltip("Включает/Выключает перевод мода Unofficial Calamity Bard & Healer.")]
    [DefaultValue(true)]
    public bool CalamityBardHealerLocalization;

    [Header("SmallMod")]

    [ReloadRequired]
    [Label("Accessory Hearts")]
    [Tooltip("Включает/Выключает перевод мода Accessory Hearts.")]
    [DefaultValue(true)]
    public bool AccessoryHeartsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool HomewardSubworldLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ArmorAndAccessoryPrefixesLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ArmorBuffsLocalization;

    [ReloadRequired]
    [Label("Beam Stops Spread")]
    [Tooltip("Включает/Выключает перевод мода Beam Stops Spread.")]
    [DefaultValue(true)]
    public bool BeamStopsSpreadLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool BossCursorLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool CalamityShoesLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool CalamityZenithLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ClamityMusicLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool CalamityCrossmodVulnerabilitiesLocalization;

    [ReloadRequired]
    [Label("Celestial Shield")]
    [Tooltip("Включает/Выключает перевод мода Celestial Shield.")]
    [DefaultValue(true)]
    public bool CelestialShieldLocalization;

    [ReloadRequired]
    [Label("Cleffy")]
    [Tooltip("Включает/Выключает перевод мода Cleffy.")]
    [DefaultValue(true)]
    public bool CleffyLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ConsolariaLegecyItemsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool CosmicElementalPetLocalization;

    [ReloadRequired]
    [Label("Crown Set bonuses")]
    [Tooltip("Включает/Выключает перевод мода Crown Set bonuses.")]
    [DefaultValue(true)]
    public bool CrownSetsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool DiscordyaLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool EvilPylonLocalization;

    [ReloadRequired]
    [Label("Experimental Infernum Extension")]
    [Tooltip("Включает/Выключает перевод мода Experimental Infernum Extension.")]
    [DefaultValue(true)]
    public bool InfernumFablesLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ExtraBeginningsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ExtraWorldSizesLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool FancyWhipsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool FutureBossesLocalization;

    [ReloadRequired]
    [Label("InfiniteInteger's Mage Tweaks")]
    [Tooltip("Включает/Выключает перевод мода InfiniteInteger's Mage Tweaks.")]
    [DefaultValue(true)]
    public bool MageTweaksLocalization;

    [ReloadRequired]
    [Label("Inspiration Potions")]
    [Tooltip("Включает/Выключает перевод мода Inspiration Potions.")]
    [DefaultValue(true)]
    public bool InspirationPotionsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool FargosAltMusicModLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool LifeSourcesLightLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool HolosparkBootsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool HomewardWorldGenFixLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool HollowKnightLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool HypnosModLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool InfernalEclipseBalanceLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool InfernumMasterPatchLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ItemRelicsLocalization;

    [ReloadRequired]
    [Label("Mana Fruit")]
    [Tooltip("Включает/Выключает перевод мода Mana Fruit.")]
    [DefaultValue(true)]
    public bool MLManaFruitLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool MasomodeEXLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool MiscellanariaLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool MoreBeamsLocalization;

    [ReloadRequired]
    [Label("Movement Speed Fix")]
    [Tooltip("Включает/Выключает перевод мода Movement Speed Fix.")]
    [DefaultValue(true)]
    public bool MoveSpeedFixLocalization;

    [ReloadRequired]
    [Label("Multiclass Armors")]
    [Tooltip("Включает/Выключает перевод мода Multiclass Armors.")]
    [DefaultValue(true)]
    public bool MulticlassArmorsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool MunchiesLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool MunchiesCalamityAddonLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool MunchiesAuricSoulsAddonLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool MusicBoxSlotLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool HMOreSummonerHelmetsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool PetrifiedVoodooDollLocalization;

    [ReloadRequired]
    [Label("Pinnacle Reforges")]
    [Tooltip("Включает/Выключает перевод мода Pinnacle Reforges.")]
    [DefaultValue(true)]
    public bool PinnacleReforgesLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool PolyphemalusLocalization;

    [ReloadRequired]
    [Label("Potion Slot")]
    [Tooltip("Включает/Выключает перевод мода Potion Slot.")]
    [DefaultValue(true)]
    public bool PotionSlotsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ModlistIncompatibilitySolverLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ColouredModsRelicsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ReforgedLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool RobesOfCalamityLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ShimmerGunLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ShoeSlotLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ShroomariaLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool SWBADTsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool SpiritofOverseerLocalization;

    [ReloadRequired]
    [Label("Starforged [Classic]")]
    [Tooltip("Включает/Выключает перевод мода Starforged.")]
    [DefaultValue(true)]
    public bool starforgedclassicLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool StartingWeaponsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool FixedAchievementsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool TalismanofFriendshipLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ThoriumClassTagsConsistencyLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool TurtleBoulderLocalization;

    [ReloadRequired]
    [Label("Ultimate Infinite Star")]
    [Tooltip("Включает/Выключает перевод мода Ultimate Infinite Star.")]
    [DefaultValue(true)]
    public bool UISLocalization;

    [ReloadRequired]
    [Label("Unofficial Alternative Biomes Compatibility")]
    [Tooltip("Включает/Выключает перевод мода Unofficial Alternative Biomes Compatibility.")]
    [DefaultValue(true)]
    public bool AlternativeCompatLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool FargoUnofficialPetsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool UnCalamityMusicLocalization;

    [ReloadRequired]
    [Label("Vanity + Dyable Cursors API")]
    [Tooltip("Включает/Выключает перевод мода Vanity + Dyable Cursors API.")]
    [DefaultValue(true)]
    public bool NightshadeVanityCursorsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool WADTULocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool GauntletsLocalization;

    [ReloadRequired]
    [Label("WHummus' Calamity/Thorium Balancing")]
    [Tooltip("Включает/Выключает перевод мода WHummus' Calamity/Thorium Balancing.")]
    [DefaultValue(true)]
    public bool WHummusMultiModBalancingLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool WingSlotLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool SolynWeaponLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool WoTELocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool YouBossLocalization;

    [Header("Fix")]

    [ReloadRequired]
    [DefaultValue(true)]
    public bool FargowiltasCrossmodFix;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool CalamityHuntFix;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ClamityFix;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool CompactModsFix;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool FlinxHatFix;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool InfernumLegendAndMasFix;

    [ReloadRequired]
    [Label("The Depths")]
    [Tooltip("Включает/Выключает фикс перевода мода The Depths.")]
    [DefaultValue(true)]
    public bool TheDepthsFix;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ThrowerUnificationFix;

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
    [Label("Иконки баффов/дебаффов")]
    [Tooltip("Внедряет систему иконок баффов/дебаффов, добавляемую Calamity, в описания предметов из пары других модов, не связанных с Calamity.\n[c/DAA520:Для работы требует Calamity Mod и Project tRU.]")]
    [DefaultValue(true)]
    public bool CBuffsForOtherMods;

    [ReloadRequired]
    [Label("Проверка совместимости модов")]
    [Tooltip("Включает/Выключает проверку переведённых модов на совместимость версий как это делает Project tRU.\n[c/DAA520:Для работы требует Project tRU.]")]
    [DefaultValue(true)]
    public bool CheckModCompatibility;
}
