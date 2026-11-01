using Microsoft.Xna.Framework;
using Terraria.ID;

namespace JAtRT.Core.ChatTags.BuffTags
{
    public class InfernalEclipseWeaponsDLCBuffs : BuffInfoModule
    {
        public override string ModName => "InfernalEclipseWeaponsDLC";

        public override void Register()
        {
            // баффы

            // предметы)
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "ExecutionersSword").Enemy("CalamityMod", "HolyFlames");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "DeepSeaDrawl").Enemy("CalamityMod", "RiptideDebuff");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "BirbSaxophone").Enemy("CalamityMod", "VermillionFlux");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "OcramKnife").Enemy(BuffID.CursedInferno);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "AcidBelcher").Enemy("CalamityMod", "Irradiated");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "DukeSynth").Enemy("CalamityMod", "Irradiated").Enemy(BuffID.Poisoned);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "GammaKnife").Enemy("CalamityMod", "Irradiated");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "TwoPaths").Enemy(("ThoriumMod", "Wither"), ("ThoriumMod", "LightCurse"));
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "Infrariff").Enemy(BuffID.ShadowFlame);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "StormCarver").Enemy(BuffID.Electrified);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "Defibrillanator").Enemy(BuffID.Electrified);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "Legacy").Enemy(BuffID.CursedInferno);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "FroststeelGong").Enemy(BuffID.Frostburn, BuffID.Frozen).Enemy("ThoriumMod", "Freezing");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "PocketConcert").Enemy(BuffID.ShadowFlame, BuffID.Ichor, BuffID.Electrified).Enemy(("CalamityMod", "Plague"), ("CalamityMod", "BrimstoneFlames"));
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "RestoredDeepSeaDrawl").Enemy("CalamityMod", "CrushDepth");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "SulphuricShanty").Enemy("CalamityMod", "Irradiated");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "TheParallel").Enemy("CalamityMod", "WhisperingDeath");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "BarrenGarden").Enemy(BuffID.Frostburn, BuffID.Frozen);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "CorrodedCane").Enemy("CalamityMod", "Irradiated");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "ListoftheDamned").Enemy(BuffID.Frostburn, BuffID.OnFire3);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "DeepseaTrident").Enemy("CalamityMod", "RiptideDebuff").Enemy(BuffID.Wet);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "TheBlight").Enemy(BuffID.CursedInferno);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "SwordofaThousandTruths").Enemy("CalamityMod", "Voidfrost");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "Stick").Enemy(BuffID.OnFire3);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "CataclysmicGauntletVoid").Enemy(("CalamityMod", "BrimstoneFlames"), ("CalamityMod", "VulnerabilityHex"));
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "AirPodShawty").Enemy("CalamityMod", "ElementalMix");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "ThunderboltActionSniperVoid").Enemy(BuffID.Electrified).Enemy("CalamityMod", "StaticDischarge");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "BrimstoneHarp").Enemy("CalamityMod", "BrimstoneFlames");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "GodsPitch").Enemy("CalamityMod", "AuricRebuke");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "SearingSpearTip").Enemy("CalamityMod", "CrushDepth").Enemy(BuffID.OnFire3);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "ArcticSpearTip").Enemy(BuffID.Frostburn);
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "DeusFlute").Enemy("CalamityMod", "AstralInfectionDebuff");
            BuffInfoRegistry.RegisterItem("InfernalEclipseWeaponsDLC", "BellBallad").Enemy(BuffID.Frostburn2).Enemy(("CalamityMod", "BrimstoneFlames"), ("CalamityMod", "Crumbling"));
        }
    }
}