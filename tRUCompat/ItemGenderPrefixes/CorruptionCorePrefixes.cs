using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class CorruptionCorePrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CorruptionBoss") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.CorruptionBossLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("CorruptionBoss", out Mod coreBoss);

        if (tru != null && coreBoss != null)
        {
            tru.Call("AddFeminineItems", coreBoss, new string[]
            {
                "CrystallineUmbra",
                "CrimIron",
                "Bloodlust",
                "DefiledSpike",
                "CrownOfFearSoul",
                "CrownOfFearCrim",
                "CrownOfFear"
            });
            
            tru.Call("AddNeuterItems", coreBoss, new string[]
            {
                "Heartbreak",
                "PunishmentCore",
                "GoreGuanado",
                "MultiPetItem",
                "CorePetItemCrim",
                "CorePetItem",
                "ShadowRing",
                "BloodyRing",
                "SoulRing",
                "CorePetItemSoul"
            });
        }
    }
}