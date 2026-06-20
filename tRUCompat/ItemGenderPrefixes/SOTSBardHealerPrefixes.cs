using Terraria.Localization;
using Terraria.ModLoader;
using System.Collections.Generic;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

internal class SOTSBardHealerPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("SOTSBardHealer") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.SOTSBardHealerLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        if (!ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru))
            return;

        if (!ModLoader.TryGetMod("SOTSBardHealer", out Mod sotsBardHealer))
            return;

        tru.Call("AddFeminineItems", sotsBardHealer, new string[]
        {
            "AncientHarp",
            "BladedSnowflake",
            "GoopwoodWiggle",
            "SerpentFangScythe"
        });

        tru.Call("AddNeuterItems", sotsBardHealer, new string[]
        {
            "AbsoLute",
            "PromiseofDemise",
            "RingofRest",
            "TwilightAscendance"
        });

        tru.Call("AddPluralItems", sotsBardHealer, new string[]
        {
            "DeathThroesThrows"
        });

        tru.Call("RegisterPrefixes", SOTSBardHealer);
    }

    private static readonly List<string[]> SOTSBardHealer = new()
    {
        new[] { "Истощённый", "Истощённая", "Истощённое", "Истощённые" },
        new[] { "Могущественный", "Могущественная", "Могущественное", "Могущественные" },
        new[] { "Хтонический", "Хтоническая", "Хтоническое", "Хтонические" },
        new[] { "Всемогущий", "Всемогущая", "Всемогущее", "Всемогущие" },
        new[] { "Презренный", "Презренная", "Презренное", "Презренные" }
    };
}