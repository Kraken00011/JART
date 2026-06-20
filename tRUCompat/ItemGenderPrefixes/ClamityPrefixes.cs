using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

internal class ClamityPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("Clamity") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.ClamityFix && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("Clamity", out Mod clamity);

        if (tru != null && clamity != null)
        {
            tru.Call("AddFeminineItems", clamity, new string[]
            {
                "CyanPearl",
                "SeaShell",
                "SoulOfPyrogen",
                "RGBMurasama",
                "Disease",
                "DepthsEchoRifle",
                "WitheredBoneBow",
                "StarfishFromTheDepth",
                "PlagueStation"
            });

            tru.Call("AddNeuterItems", clamity, new string[]
            {
                "TheSubcommunity",
                "IcicleRing",
                "HellFlare",
                "HeavyMetalTrashCan"
            });
            
            tru.Call("AddPluralItems", clamity, new string[]
            {
                "MetalWings",
                "MoonstoneKnives",
                "EtherealKnives"
            });
        }
    }
}