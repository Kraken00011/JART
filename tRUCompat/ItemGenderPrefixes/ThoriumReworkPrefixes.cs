using Terraria.Localization;
using Terraria.ModLoader;
using System.Collections.Generic;
using JAtRT.Core.Config;

internal class ThoriumReworkPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("ThoriumRework") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.ThoriumReworkLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        if (!ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru))
            return;

        if (!ModLoader.TryGetMod("ThoriumRework", out Mod thRew))
            return;

        tru.Call("AddFeminineItems", thRew, new string[]
        {
            "BandofCratons",
            "BandofCratonsCosmetic",
            "BannerofWar",
            "BannerofWarCosmetic",
            "BeholderBlade",
            "EaterPiper",
            "FlyingFlute",
            "GildedFlyingFlute",
            "HandheldRocket",
            "HelheimSoul",
            "FluteofCurses",
            "KingTrumpet",
            "Kusarigama",
            "LodeStoneMagnetMace",
            "RedCresent",
            "MagicalHarp",
            "Oneirophobia",
            "QueenJellyPin",
            "QueenJellyPinCosmetic",
            "Shellxophone",
            "ShoulderBlade",
            "SierraChimera",
            "StriderMouthguard",
            "StriderMouthguardCosmetic",
            "ThoriumBludgeon",
            "ThoriumHeavyScythe",
            "UndyingGaze",
            "UndyingGazeCosmetic",
            "ValadiumHeavyScythe",
            "ZephyrsRuin"
        });

        tru.Call("AddNeuterItems", thRew, new string[]
        {
            "BeholderHeart",
            "ChironsCure",
            "LichWhip"
        });

        tru.Call("AddPluralItems", thRew, new string[]
        {
            "BeholderTentacles",
            "BeholderTentaclesCosmetic",
            "CrystallizedFinality",
            "DuelistSheath",
            "FanDonations",
            "HolySheath",
            "ZephyrWings",
            "ZephyrWingsCosmetic"
        });

        tru.Call("RegisterPrefixes", ThoriumRework);
    }

    private static readonly List<string[]> ThoriumRework = new()
    {
        new[] { "Беспечный", "Беспечная", "Беспечное", "Беспечные" },
        new[] { "Запутанный", "Запутанная", "Запутанное", "Запутанные" },
        new[] { "Благодатный", "Благодатная", "Благодатное", "Благодатные" },
        new[] { "Рискованный", "Рискованная", "Рискованное", "Рискованные" },
        new[] { "Простенький", "Простенькая", "Простенькое", "Простенькие" },
        new[] { "Самоубийственный", "Самоубийственная", "Самоубийственное", "Самоубийственные" }
    };
}