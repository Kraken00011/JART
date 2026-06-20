using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

internal class CalamityBardHealerPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityBardHealer") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.CalamityBardHealerLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("CalamityBardHealer", out Mod calamityBardHealer);

        if (tru != null && calamityBardHealer != null)
        {
            tru.Call("AddFeminineItems", calamityBardHealer, new string[]
            {
                "AnahitasArpeggio",
                "DeathAdder",
                "DesertedDrugDeal",
                "Disaster",
                "DryMouth",
                "Duality",
                "FeralKeytar",
                "FilthyFlute",
                "Gashadokuro",
                "HarmonyoftheOldGod",
                "HarpY",
                "IrradiatedKusarigama",
                "ScrapGuitar",
                "ScuffedKeytar",
                "Singularity",
                "SongoftheAncients",
                "SongoftheCosmos",
                "SongoftheElements",
                "Syzygy",
                "TheWindmill",
                "TidalForce",
                "TreeWhisperersHarp",
                "Trinity",
                "Violince",
                "WilloftheRagnarok"
            });

            tru.Call("AddNeuterItems", calamityBardHealer, new string[]
            {
                "ChristmasCarol",
                "PurgatoriumPandemonium",
                "ReturntoSludge",
                "SARS",
                "SlagFurysIntent",
                "StarCluster",
                "Supercluster"
            });
            
            tru.Call("AddPluralItems", calamityBardHealer, new string[]
            {
                "ArcticReinforcement",
                "BigBangCymbals",
                "DustDevilDrums",
                "InfestedCastanet",
                "SymphonicFabrications",
                "TectonicPlates"
            });
        }
    }
}