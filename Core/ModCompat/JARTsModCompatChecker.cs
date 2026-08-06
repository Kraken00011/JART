/*using System;
using System.Collections.Generic;
using JAtRT.Core.Config;
using CalamityRuTranslate.Core.ModCompatibilities;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.UI;

namespace JAtRT.Core.ModCompat;

[Autoload(Side = ModSide.Client)]
public class JARTsModCompatibilityChecker : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("CalamityRuTranslate") && JARTClientCfg.Instance.CheckModCompatibility;

    public UserInterface CompatibilityUIManager;
    public ModCompatUI ModCompatUI { get; private set; }

    private ModCompatibilityInfo[] _modCompatibilityInfo;

    public override void Load()
    {
        _modCompatibilityInfo =
        [
            new("AccessoryHearts",              new Version(0, 4),       JARTLocalizationConf.Instance.AccessoryHeartsLocalization),
            new("AlternativeCompat",            new Version(1, 1, 2),    JARTLocalizationConf.Instance.AlternativeCompatLocalization),
            new("ArmorAndAccessoryPrefixes",    new Version(1, 0, 3),    JARTLocalizationConf.Instance.ArmorAndAccessoryPrefixesLocalization),
            new("ArmorBuffs",                   new Version(1, 1, 0, 2), JARTLocalizationConf.Instance.ArmorBuffsLocalization),
            new("BeamStopsSpread",              new Version(1, 2),       JARTLocalizationConf.Instance.BeamStopsSpreadLocalization),
            new("BlueMoon",                     new Version(2, 0, 2, 1), JARTLocalizationConf.Instance.BlueMoonLocalization),
            new("BossCursor",                   new Version(3, 0, 1),    JARTLocalizationConf.Instance.BossCursorLocalization),
            new("CalamityBardHealer",           new Version(0, 13, 6),   JARTLocalizationConf.Instance.CalamityBardHealerLocalization),
            new("CalamityCrossmodVulnerabilities", new Version(1, 3),    JARTLocalizationConf.Instance.CalamityCrossmodVulnerabilitiesLocalization), // кто блять такие названия придумывает
            new("CalamityHunt",                 new Version(1, 2, 3),    JARTLocalizationConf.Instance.CalamityHuntFix),
            new("CalamityShoes",                new Version(1, 5),       JARTLocalizationConf.Instance.CalamityShoesLocalization),
            new("CalamitySimpleWhipAddon",      new Version(1, 15, 5),   JARTLocalizationConf.Instance.CalamitySimpleWhipAddonLocalization),
            new("calamityzeith",                new Version(0, 6),       JARTLocalizationConf.Instance.CalamityZenithLocalization),
            new("CelestialShield",              new Version(1, 3),       JARTLocalizationConf.Instance.CelestialShieldLocalization),
            new("Clamity",                      new Version(1, 0, 4, 2), JARTLocalizationConf.Instance.ClamityFix),
            new("ClamityMusic",                 new Version(1, 0, 3, 4), JARTLocalizationConf.Instance.ClamityMusicLocalization),
            new("Cleffy",                       new Version(0, 2),       JARTLocalizationConf.Instance.CleffyLocalization),
            new("ColouredModsRelics",           new Version(0, 4, 5),    JARTLocalizationConf.Instance.ColouredModsRelicsLocalization),
            new("CompactMods",                  new Version(1, 1, 2),    JARTLocalizationConf.Instance.CompactModsFix),
            new("ConsolariaLegecyItems",        new Version(0, 1, 1),    JARTLocalizationConf.Instance.ConsolariaLegecyItemsLocalization),
            new("CorruptionBoss",               new Version(2, 0, 0, 4), JARTLocalizationConf.Instance.CorruptionBossLocalization),
            new("CosmicElementalPet",           new Version(1, 0, 1),    JARTLocalizationConf.Instance.CosmicElementalPetLocalization),
            new("CrownSets",                    new Version(1, 1, 1),    JARTLocalizationConf.Instance.CrownSetsLocalization),
            new("Discordya",                    new Version(1, 0, 6, 5), JARTLocalizationConf.Instance.DiscordyaLocalization),
            new("EvilBossesRework",             new Version(0, 3, 4),    JARTLocalizationConf.Instance.EvilBossesReworkLocalization),
            new("EvilPylon",                    new Version(2, 2),       JARTLocalizationConf.Instance.EvilPylonLocalization),
            new("ExtraBeginnings",              new Version(1, 0, 1),    JARTLocalizationConf.Instance.ExtraBeginningsLocalization),
            new("FancyWhips",                   new Version(1, 1),       JARTLocalizationConf.Instance.FancyWhipsLocalization),
            new("FargoAltMusicMod",             new Version(1, 6, 1, 3), JARTLocalizationConf.Instance.FargosAltMusicModLocalization),
            new("FargoUnofficialPets",          new Version(0, 3, 1, 1), JARTLocalizationConf.Instance.FargoUnofficialPetsLocalization),
            new("FargowiltasCrossmod",          new Version(1, 2, 0, 26),JARTLocalizationConf.Instance.FargowiltasCrossmodFix),
            new("FlinxHat",                     new Version(0, 4),       JARTLocalizationConf.Instance.FlinxHatFix),
            new("FutureBosses",                 new Version(1, 0, 2),    JARTLocalizationConf.Instance.FutureBossesLocalization),
            new("Gauntlets",                    new Version(1, 4, 0),    JARTLocalizationConf.Instance.GauntletsLocalization),
            new("GolemRework",                  new Version(0, 12, 6),   JARTLocalizationConf.Instance.GolemReworkLocalization),
            new("HMOreSummonerHelmets",         new Version(1, 1),       JARTLocalizationConf.Instance.HMOreSummonerHelmetsLocalization),
            new("HolosparkBoots",               new Version(1, 1, 0),    JARTLocalizationConf.Instance.HolosparkBootsLocalization),
            new("HomewardSubworld",             new Version(1, 0, 0, 4), JARTLocalizationConf.Instance.HomewardSubworldLocalization),
            new("HomewardWorldGenFix",          new Version(0, 2, 1),    JARTLocalizationConf.Instance.HomewardWorldGenFixLocalization),
            new("HPAware",                      new Version(1, 0, 6, 0), JARTLocalizationConf.Instance.HPAwareLocalization),
            new("HypnosMod",                    new Version(1, 0, 6),    JARTLocalizationConf.Instance.HypnosModLocalization),
            new("InfernalEclipseAPI",           new Version(0, 10, 6, 4),JARTLocalizationConf.Instance.InfernalEclipseLocalization),
            new("InfernumFables",               new Version(0, 0, 1),    JARTLocalizationConf.Instance.InfernumFablesLocalization),
            new("InfernumMasterPatch",          new Version(1, 2, 1),    JARTLocalizationConf.Instance.InfernumMasterPatchLocalization),
            new("InspirationPotions",           new Version(0, 1, 1),    JARTLocalizationConf.Instance.InspirationPotionsLocalization),
            new("InterestingPrefix",            new Version(0, 3),       JARTLocalizationConf.Instance.ToolsPrefixesFix),
            new("ItemRelics",                   new Version(1, 0, 1),    JARTLocalizationConf.Instance.ItemRelicsLocalization),
            new("LifeSourcesLight",             new Version(1, 3, 0),    JARTLocalizationConf.Instance.LifeSourcesLightLocalization),
            new("MageTweaks",                   new Version(1, 0, 2),    JARTLocalizationConf.Instance.MageTweaksLocalization),
            new("MasomodeEX",                   new Version(1, 12, 3),   JARTLocalizationConf.Instance.MasomodeEXLocalization),
            new("Miscellanaria",                new Version(1, 0, 5),    JARTLocalizationConf.Instance.MiscellanariaLocalization),
            new("MLManaFruit",                  new Version(0, 1, 2),    JARTLocalizationConf.Instance.MLManaFruitLocalization),
            new("ModlistIncompatibilitySolver", new Version(0, 5),       JARTLocalizationConf.Instance.ModlistIncompatibilitySolverLocalization),
            new("MoreBeams",                    new Version(0, 6, 3),    JARTLocalizationConf.Instance.MoreBeamsLocalization),
            new("MoveSpeedFix",                 new Version(1, 2, 2),    JARTLocalizationConf.Instance.MoveSpeedFixLocalization),
            new("MudgysHollowKnightMod",        new Version(0, 13, 3),   JARTLocalizationConf.Instance.HollowKnightLocalization),
            new("MulticlassArmors",             new Version(1, 1),       JARTLocalizationConf.Instance.MulticlassArmorsLocalization),
            new("Munchies",                     new Version(1, 4, 2),    JARTLocalizationConf.Instance.MunchiesLocalization),
            new("Munchies_CalamityAddon",       new Version(1, 3, 1),    JARTLocalizationConf.Instance.MunchiesCalamityAddonLocalization),
            new("MunchiesAuricSoulsAddon",      new Version(2, 2),       JARTLocalizationConf.Instance.MunchiesAuricSoulsAddonLocalization),
            new("MusicBoxSlotNew",              new Version(1, 1),       JARTLocalizationConf.Instance.MusicBoxSlotLocalization),
            new("NightshadeVanityCursors",      new Version(1, 1, 0),    JARTLocalizationConf.Instance.NightshadeVanityCursorsLocalization),
            new("OphioidMod",                   new Version(2, 33),      JARTLocalizationConf.Instance.OphioidLocalization),
            new("PetrifiedVoodooDoll",          new Version(1, 2, 1),    JARTLocalizationConf.Instance.PetrifiedVoodooDollLocalization),
            new("PinnacleReforges",             new Version(0, 2),       JARTLocalizationConf.Instance.PinnacleReforgesLocalization),
            new("Polyphemalus",                 new Version(1, 1),       JARTLocalizationConf.Instance.PolyphemalusLocalization),
            new("PotionSlots",                  new Version(0, 7),       JARTLocalizationConf.Instance.PotionSlotsLocalization),
            new("PrimeRework",                  new Version(5, 0, 15),   JARTLocalizationConf.Instance.PrimeReworkLocalization),
            new("QualityOfGuida",               new Version(0, 1111),    JARTLocalizationConf.Instance.SevenItemsFromMinecraftLocalization),
            new("Reforged",                     new Version(1, 2, 3),    JARTLocalizationConf.Instance.ReforgedLocalization),
            new("RevengeancePlus",              new Version(0, 6, 1),    JARTLocalizationConf.Instance.RevengeancePlusLocalization),
            new("RobesOfCalamity",              new Version(0, 1),       JARTLocalizationConf.Instance.RobesOfCalamityLocalization),
            new("ShimmerGun",                   new Version(0, 2, 2),    JARTLocalizationConf.Instance.ShimmerGunLocalization),
            new("Shroomaria",                   new Version(1, 7),       JARTLocalizationConf.Instance.ShroomariaLocalization),
            new("SolynWeapon",                  new Version(1, 0, 3),    JARTLocalizationConf.Instance.SolynWeaponLocalization),
            new("SOTSBardHealer",               new Version(0, 3, 1),    JARTLocalizationConf.Instance.SOTSBardHealerLocalization),
            new("SoulsBossRush",                new Version(0, 1, 1),    JARTLocalizationConf.Instance.SoulsBossRushLocalization),
            new("SpiritofOverseer",             new Version(0, 2, 1),    JARTLocalizationConf.Instance.SpiritofOverseerLocalization),
            new("starforgedclassic",            new Version(1, 4),       JARTLocalizationConf.Instance.starforgedclassicLocalization),
            new("StartingWeapons",              new Version(1, 1, 0),    JARTLocalizationConf.Instance.StartingWeaponsLocalization),
            new("FixedAchievements",            new Version(1, 5, 2),    JARTLocalizationConf.Instance.FixedAchievementsLocalization),
            new("SWBADTs",                      new Version(3, 5, 2),    JARTLocalizationConf.Instance.SWBADTsLocalization),
            new("TalismanofFriendship",         new Version(1, 0, 2),    JARTLocalizationConf.Instance.TalismanofFriendshipLocalization),
            new("TheDepths",                    new Version(1, 0, 5, 7), JARTLocalizationConf.Instance.TheDepthsFix),
            new("ThoriumClassTagsConsistency",  new Version(1, 0, 3),    JARTLocalizationConf.Instance.ThoriumClassTagsConsistencyLocalization),
            new("ThrowerUnification",           new Version(0, 3, 15, 3),JARTLocalizationConf.Instance.ThrowerUnificationFix),
            new("TurtleBoulder",                new Version(3, 0),       JARTLocalizationConf.Instance.TurtleBoulderLocalization),
            new("UIS",                          new Version(0, 0, 0, 4), JARTLocalizationConf.Instance.UISLocalization),
            new("UnCalamityModMusic",           new Version(2, 1, 2),    JARTLocalizationConf.Instance.UnCalamityMusicLocalization),
            new("WHummusMultiModBalancing",     new Version(1, 6, 3, 1), JARTLocalizationConf.Instance.WHummusMultiModBalancingLocalization),
            new("WingSlot",                     new Version(2, 0, 4),    JARTLocalizationConf.Instance.WingSlotLocalization),
            new("WoTE",                         new Version(1, 0, 3),    JARTLocalizationConf.Instance.WoTELocalization),
            new("YouBoss",                      new Version(1, 0, 14),   JARTLocalizationConf.Instance.YouBossLocalization)
        ];

        CompatibilityUIManager = new UserInterface();
        ModCompatUI = new ModCompatUI();
        ModCompatUI.Activate();
    }

    public override void OnWorldLoad()
    {
        ValidateModVersions();
    }

    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
        if (mouseTextIndex != -1)
        {
            layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                "JAtRT: ModCompatUI",
                delegate
                {
                    if (CompatibilityUIManager?.CurrentState != null)
                    {
                        CompatibilityUIManager.Update(Main._drawInterfaceGameTime);
                        ModCompatUI.Draw(Main.spriteBatch);
                    }
                    return true;
                },
                InterfaceScaleType.UI));
        }
    }

    private void ValidateModVersions()
    {
        bool anyIncompatible = false;

        foreach (ModCompatibilityInfo info in _modCompatibilityInfo)
        {
            if (!ModLoader.TryGetMod(info.InternalName, out Mod modInstance))
                continue;

            if (modInstance.Version == info.ExpectedVersion || !info.ModLocalization)
                continue;

            string warning = CreateVersionWarningMessage(
                modInstance.DisplayName,
                modInstance.Version,
                info.ExpectedVersion);

            if (string.IsNullOrEmpty(warning))
                continue;

            ModCompatUI.Enqueue(warning, modInstance.DisplayName);
            anyIncompatible = true;
        }

        if (anyIncompatible)
            CompatibilityUIManager?.SetState(ModCompatUI);
    }

    private string CreateVersionWarningMessage(string modName, Version current, Version expected)
    {
        if (current > expected)
            return $"У вас установлена более новая версия [c/FFF783:{modName}]." + "\n" +
                   $"Ваша текущая версия: [c/FF0000:{current}]." + "\n" +
                   $"Последняя поддерживаемая версия: [c/FF0000:{expected}]." + "\n" +
                   $"Для корректной работы JART рекомендуется" + "\n" +
                   $"Отключить перевод этого мода в конфигурации," + "\n" +
                   $"Либо просто дождаться выхода обновления, где эта проблема будет исправлена";

        if (current < expected)
            return $"У вас установлена устаревшая версия [c/FFF783:{modName}]. " + "\n" +
                   $"Ваша текущая версия: [c/FF0000:{current}]. " + "\n" +
                   $"Для корректной работы JART рекомендуется обновить " + "\n" +
                   $"[c/FFF783:{modName}] до версии [c/00FF09:{expected}].";

        return string.Empty;
    }
}
*/