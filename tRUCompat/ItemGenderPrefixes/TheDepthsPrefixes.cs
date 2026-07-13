using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class TheDepthsPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("TheDepths") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.TheDepthsFix && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("TheDepths", out Mod depths);

        if (tru != null && depths != null)
        {
            tru.Call("AddFeminineItems", depths, new string[]
            {
                "AquaGlove",
                "AzuriteRose",
                "CrystalHorseshoe",
                "QuicksilverproofTackleBag",
                "QuickSilverSurfboard",
                "StoneRose",
                "WhiteLightning",
                "SapphireShovel",
                "NightFury",
                "QuartzCannon",
                "SilverStar",
                "ShadowSphere",
                "BlueSphere",
                "MercuryPickaxe"
            });
            
            tru.Call("AddNeuterItems", depths, new string[]
            {
                "Silverado",
                "ShadeBlade"
            });

            tru.Call("AddPluralItems", depths, new string[]
            {
                "CrystalWaterWalkingBoots",
                "NightmareFlareTreads",
                "ShalestoneShackle",
                "SilverSlippers",
                "ShadowClaw"
            });
        }
    }
}