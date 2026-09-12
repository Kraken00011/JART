using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class BloodMoonEnemiesReworkPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.BloodMoonEnemiesReworkLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("BloodMoonEnemiesRework", out Mod bloodMoonRework);

        if (tru != null && bloodMoonRework != null)
        {
            tru.Call("AddFeminineItems", bloodMoonRework, new string[]
            {
                "Atlateel",
                "Hypertension",
                "RedTide"
            });

            tru.Call("AddNeuterItems", bloodMoonRework, new string[]
            {
                "HemogoblinSharkToothNecklace"
            });
        }
    }
}