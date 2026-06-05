using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using Terraria.ModLoader;

namespace JAtRT.Common;

public static class ModInstances
{
    public static Mod ArmorAndAccessoryPrefixes => ModLoader.TryGetMod("ArmorAndAccessoryPrefixes", out Mod armorAccsPrefixes) ? armorAccsPrefixes : null;
    public static Mod ArmorBuffs => ModLoader.TryGetMod("ArmorBuffs", out Mod armorBuffs) ? armorBuffs : null;
    public static Mod ArmorReforge => ModLoader.TryGetMod("ArmorReforge", out Mod armorReforge) ? armorReforge : null;
    public static Mod BetterDialogue => ModLoader.TryGetMod("BetterDialogue", out Mod bdialogue) ? bdialogue : null;
    public static Mod BlueMoon => ModLoader.TryGetMod("BlueMoon", out Mod bmoon) ? bmoon : null;
    public static Mod BossCursor => ModLoader.TryGetMod("BossCursor", out Mod bossCursor) ? bossCursor : null;
    public static Mod Calamity => ModLoader.TryGetMod("CalamityMod", out Mod cal) ? cal : null;
    public static Mod CalamityHunt => ModLoader.TryGetMod("CalamityHunt", out Mod calHunt) ? calHunt : null;
    public static Mod CalamityZenith => ModLoader.TryGetMod("calamityzeith", out Mod calZenith) ? calZenith : null;
    public static Mod Clamity => ModLoader.TryGetMod("Clamity", out Mod clamity) ? clamity : null;
    public static Mod ClamityMusic => ModLoader.TryGetMod("ClamityMusic", out Mod clamMusic) ? clamMusic : null;
    public static Mod ConsolariaLegacyItems => ModLoader.TryGetMod("ConsolariaLegacyItems", out Mod con) ? con : null;
    public static Mod Coralite => ModLoader.TryGetMod("Coralite", out Mod coral) ? coral : null;
    public static Mod CorruptionBoss => ModLoader.TryGetMod("CorruptionBoss", out Mod coreBoss) ? coreBoss : null;
    public static Mod Discordya => ModLoader.TryGetMod("Discordya", out Mod terrariaRPC) ? terrariaRPC : null;
    public static Mod DraedonExpansion => ModLoader.TryGetMod("DraedonExpansion", out Mod draex) ? draex : null;
    public static Mod DragonLens => ModLoader.TryGetMod("DragonLens", out Mod drglns) ? drglns : null;
    public static Mod EquipmentReforge => ModLoader.TryGetMod("EquipmentReforge", out Mod equipmentReforge) ? equipmentReforge : null;
    public static Mod EvilBossesRework => ModLoader.TryGetMod("EvilBossesRework", out Mod evil) ? evil : null;
    public static Mod EvilPylon => ModLoader.TryGetMod("EvilPylon", out Mod morePylons) ? morePylons : null;
    public static Mod ExtraWorldSizes => ModLoader.TryGetMod("ExtraWorldSizes", out Mod ews) ? ews : null;
    public static Mod FancyWhips => ModLoader.TryGetMod("FancyWhips", out Mod fWhips) ? fWhips : null;
    public static Mod FargoUnofficialPets => ModLoader.TryGetMod("FargoUnofficialPets", out Mod fargoPets) ? fargoPets : null;
    public static Mod FargowiltasCrossmod => ModLoader.TryGetMod("FargowiltasCrossmod", out Mod fargoCrossmod) ? fargoCrossmod : null;
    public static Mod Gauntlets => ModLoader.TryGetMod("Gauntlets", out Mod gau) ? gau : null;
    public static Mod GolemRework => ModLoader.TryGetMod("GolemRework", out Mod jungleBossesRew) ? jungleBossesRew : null;
    public static Mod HMOreHelmets => ModLoader.TryGetMod("HMOreSummonerHelmets", out Mod hmSumHelms) ? hmSumHelms : null;
    public static Mod HPAware => ModLoader.TryGetMod("HPAware", out Mod hpAware) ? hpAware : null;
    public static Mod Holospark => ModLoader.TryGetMod("HolosparkBoots", out Mod holosparkBoots) ? holosparkBoots : null;
    public static Mod HomewardRagnarok => ModLoader.TryGetMod("HomewardRagnarok", out Mod homewardRagnarok) ? homewardRagnarok : null;
    public static Mod HomewardJourney => ModLoader.TryGetMod("ContinentOfJourney", out Mod homewardJourney) ? homewardJourney : null;
    public static Mod Hypnos => ModLoader.TryGetMod("HypnosMod", out Mod hypnos) ? hypnos : null;
    public static Mod InfernalEclipse => ModLoader.TryGetMod("InfernalEclipseAPI", out Mod infernalEclipse) ? infernalEclipse : null;
    public static Mod InfernalEclipseWeapons => ModLoader.TryGetMod("InfernalEclipseWeaponsDLC", out Mod infernalEclipseWeapons) ? infernalEclipseWeapons : null;
    public static Mod InterestingPrefix => ModLoader.TryGetMod("InterestingPrefix", out Mod interstingPrefix) ? interstingPrefix : null;
    public static Mod ItemRelics => ModLoader.TryGetMod("ItemRelics", out Mod itemRelics) ? itemRelics : null;
    public static Mod JAtRT => ModLoader.TryGetMod("JAtRT", out Mod jaTrt) ? jaTrt : null;
    public static Mod MusicBoxSlotNew => ModLoader.TryGetMod("MusicBoxSlotNew", out Mod mbsn) ? mbsn : null;
    public static Mod ProjectTRu => ModLoader.TryGetMod("CalamityRuTranslate", out Mod projectTRu) ? projectTRu : null;
    public static Mod PegasusLib => ModLoader.TryGetMod("PegasusLib", out Mod pegas) ? pegas : null;
    public static Mod PetrifiedVoodooDoll => ModLoader.TryGetMod("PetrifiedVoodooDoll", out Mod petrVoodoo) ? petrVoodoo : null;
    public static Mod Polyphemalus => ModLoader.TryGetMod("Polyphemalus", out Mod polyphem) ? polyphem : null;
    public static Mod PrimeRework => ModLoader.TryGetMod("PrimeRework", out Mod primeRework) ? primeRework : null;
    public static Mod RUnion => ModLoader.TryGetMod("NoxusBossRu", out Mod runion) ? runion : null;
    public static Mod SOTS => ModLoader.TryGetMod("SOTS", out Mod sots) ? sots : null;
    public static Mod SOTSBardHealer => ModLoader.TryGetMod("SOTSBardHealer", out Mod sotsBardHealer) ? sotsBardHealer : null;
    public static Mod SolynWeapon => ModLoader.TryGetMod("SolynWeapon", out Mod swp) ? swp : null;
    public static Mod SpiritofOverseer => ModLoader.TryGetMod("SpiritofOverseer", out Mod spiritBossesRew) ? spiritBossesRew : null;
    public static Mod StartingWeaponsReborn => ModLoader.TryGetMod("StartingWeapons", out Mod startingWeapons) ? startingWeapons : null;
    public static Mod TCTC => ModLoader.TryGetMod("ThoriumClassTagsConsistency", out Mod tctc) ? tctc : null;
    public static Mod ThrowerUnification => ModLoader.TryGetMod("ThrowerUnification", out Mod throwerUnification) ? throwerUnification : null;
    public static Mod ThoriumMod => ModLoader.TryGetMod("ThoriumMod", out Mod thorium) ? thorium : null;
    public static Mod TRAEBossRework => ModLoader.TryGetMod("TRAEBossRework", out Mod traeBossRework) ? traeBossRework : null;
    public static Mod Vitality => ModLoader.TryGetMod("VitalityMod", out Mod vit) ? vit : null;
    public static Mod WADTU => ModLoader.TryGetMod("WhatAmmoDoesThisUse", out Mod wadtu) ? wadtu : null;

    // v1.3.1.0
    public static Mod MasomodeEX => ModLoader.TryGetMod("MasomodeEX", out Mod masomode) ? masomode : null;
    
    // v1.3.2.0
    public static Mod FargowiltasSouls => ModLoader.TryGetMod("FargowiltasSouls", out Mod fargosoul) ? fargosoul : null;
    public static Mod Shroomaria => ModLoader.TryGetMod("Shroomaria", out Mod shrom) ? shrom : null;
    public static Mod CalamitySimpleWhipAddon => ModLoader.TryGetMod("CalamitySimpleWhipAddon", out Mod calSimWhip) ? calSimWhip : null;
}