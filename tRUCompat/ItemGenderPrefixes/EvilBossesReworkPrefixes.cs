using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class EvilBossesReworkPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("EvilBossesRework") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.EvilBossesReworkLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("EvilBossesRework", out Mod evilBoss);

        if (tru != null && evilBoss != null)
        {
            tru.Call("AddFeminineItems", evilBoss, new string[]
            {
                "DevilsRifle",
                "SpoonfulofDarkness"
            });
        }
    }
}