using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class InfernalEclipseWeaponsDLCPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.InfernalEclipseWeaponsDLCLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("InfernalEclipseWeaponsDLC", out Mod infernal);

        if (tru != null && infernal != null)
        {
            tru.Call("AddFeminineItems", infernal, new string[]
            {
                "BlightedBadge",
                "BlazeScourgeBag",
                "AllSeersGlass",
                "BellBallad",
                "BrimstoneHarp",
                "DeusFlute",
                "DukeSynth",
                "GlowstringBiwa",
                "PlasmaOcarina",
                "SandSlasher",
                "SulphuricShanty",
                "TheParallel",
                "BottleOfSouls",
                "CorrodedCane",
                "TheBlight",
                "DivineAxe",
                "Stick",
                "CataclysmicGauntletVoid",
                "CataclysmicGauntlet",
                "GauntletofAnnihilationVoid",
                "GauntletofAnnihilation",
                "ThunderboltActionSniperVoid",
                "ThunderboltActionSniper"
            });

            tru.Call("AddNeuterItems", infernal, new string[]
            {
                "ImagiknightHeraldry",
                "RingofTix",
                "TheChickenWing",
                "ShatteredSubcommunity",
                "BlixerCore"
            });

            tru.Call("AddPluralItems", infernal, new string[]
            {
                "TwoPaths",
                "TerraSheath",
                "GarudaWings",
                "MagicPurpleBouncyBalls"
            });
        }
    }
}