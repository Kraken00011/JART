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
    [Tooltip("Выключает перевод мода Unofficial Calamity Bard & Healer.")]
    [DefaultValue(true)]
    public bool CalamityBardHealerLocalization;

    [Header("SmallMod")]

    [ReloadRequired]
    [Label("Accessory Hearts")]
    [Tooltip("Выключает перевод мода Accessory Hearts.")]
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
    [Tooltip("Выключает перевод мода Celestial Shield.")]
    [DefaultValue(true)]
    public bool CelestialShieldLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ConsolariaLegecyItemsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool CosmicElementalPetLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool DiscordyaLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool EvilPylonLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool EverwareLocalization;

    [ReloadRequired]
    [Label("Experimental Infernum Extension")]
    [Tooltip("Выключает перевод мода Experimental Infernum Extension.")]
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
    [Tooltip("Выключает перевод мода Movement Speed Fix.")]
    [DefaultValue(true)]
    public bool MoveSpeedFixLocalization;

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
    [Tooltip("Выключает перевод мода Pinnacle Reforges.")]
    [DefaultValue(true)]
    public bool PinnacleReforgesLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool PolyphemalusLocalization;

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
    [DefaultValue(true)]
    public bool StartingWeaponsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool SteamFixerLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool TalismanofFriendshipLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ThoriumTagsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool TurtleBoulderLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool FargoUnofficialPetsLocalization;

    [ReloadRequired]
    [DefaultValue(true)]
    public bool UnCalamityMusicLocalization;

    [ReloadRequired]
    [Label("Vanity + Dyable Cursors API")]
    [Tooltip("Выключает перевод мода Vanity + Dyable Cursors API.")]
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
    [Tooltip("Выключает перевод мода WHummus' Calamity/Thorium Balancing.")]
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
    [Tooltip("Выключает фикс перевода мода The Depths.")]
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
}
