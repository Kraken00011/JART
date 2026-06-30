using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class FargoswiltasCrossmodPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("FargowiltasCrossmod") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.FargowiltasCrossmodFix && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("FargowiltasCrossmod", out Mod fargosCrossmod);

        if (tru != null && fargosCrossmod != null)
        {
            tru.Call("AddFeminineItems", fargosCrossmod, new string[]
            {
                "OutlawsEssence",
                "VagabondsSoul",
                "GaleForce",
                "ElementsForce"
            });

            tru.Call("AddNeuterItems", fargosCrossmod, new string[]
            {
                "BrandoftheBrimstoneWitch",
                "AerospecEnchant",
                "MarniteEnchant",
                "DesertProwlerEnchant",
                "WulfrumEnchant",
                "SnowRuffianEnchant",
                "DaedalusEnchant",
                "ReaverEnchant",
                "HydrothermicEnchant",
                "UmbraphileEnchant",
                "TitanHeartEnchant",
                "StatigelEnchant",
                "SulphurEnchant",
                "VictideEnchant",
                "EmpyreanEnchant"
            });
        }
    }
}