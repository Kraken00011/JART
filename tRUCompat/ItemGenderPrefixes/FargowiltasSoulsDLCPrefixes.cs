using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class FargowiltasSoulsDLCPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.FargowiltasSoulsDLCLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("FargowiltasSoulsDLC", out Mod fargosExtras);

        if (tru != null && fargosExtras != null)
        {
            tru.Call("AddFeminineItems", fargosExtras, new string[]
            {
                "EternityForce"
            });

            tru.Call("AddNeuterItems", fargosExtras, new string[]
            {
                "NekomiEnchantment",
                "GaiaEnchantment",
                "EridanusEnchantment",
                "StyxEnchantment",
                "TrueMutantEnchantment"
            });
        }
    }
}