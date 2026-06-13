using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

public class InterestingPrefixPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return ModLoader.HasMod("InterestingPrefix") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.ToolsPrefixesFix && Language.ActiveCulture.Name == "ru-RU";
    }
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);

        RegisterInterestingPrefix(tru);
    }

    private void RegisterInterestingPrefix(Mod tru)
    {
        ModLoader.TryGetMod("InterestingPrefix", out _);

        tru.Call("RegisterPrefixes", InterestingPrefixes);

        tru.Call("AddVanillaFeminineItems", new int[]
        {
            ItemID.WoodFishingPole,
            ItemID.ReinforcedFishingPole,
            ItemID.ScarabFishingRod,
            ItemID.FiberglassFishingPole,
            ItemID.MechanicsRod,
            ItemID.SittingDucksFishingRod,
            ItemID.HotlineFishingHook,
            ItemID.GoldenFishingRod
        });

        if (ModLoader.TryGetMod("CalamityMod", out Mod cl))
        {
            tru.Call("AddFeminineItems", cl, new[]
            {
                "WulfrumRod",
                "NavyFishingRod",
                "HeronRod",
                "SlurperPole",
                "VerstaltiteFishingRod",
                "FeralDoubleRod",
                "RiftReeler",
                "EarlyBloomRod"
            });
        }

        if (ModLoader.TryGetMod("ThoriumMod", out Mod th))
        {
            tru.Call("AddFeminineItems", th, new[]
            {
                "GraniteControlRod"
            });
        }
    }

    private static readonly List<string[]> InterestingPrefixes = new()
    {
        new[] { "Бесконечный", "Бесконечная", "Бесконечное", "Бесконечные" },
        new[] { "Ящиколовный", "Ящиколовная", "Ящиколовное", "Ящиколовные" },
        new[] { "Двойной", "Двойная", "Двойное", "Двойные" },
        new[] { "Лёгкий", "Лёгкая", "Лёгкое", "Лёгкие" },
        new[] { "Сардинный", "Сардинная", "Сардинное", "Сардинные" },
        new[] { "Квестоловный", "Квестоловная", "Квестоловное", "Квестоловные" },
        new[] { "Воднословлённый", "Воднословлённая", "Воднословлённое", "Воднословлённые" },
        new[] { "Приманивающий", "Приманивающая", "Приманивающее", "Приманивающие" },
        new[] { "Мастерский", "Мастерская", "Мастерское", "Мастерские" },
        new[] { "Сокрушающий", "Сокрушающая", "Сокрушающее", "Сокрушающие" },
        new[] { "Эффективный", "Эффективная", "Эффективное", "Эффективные" },
        new[] { "Исследовательский", "Исследовательская", "Исследовательское", "Исследовательские" },
        new[] { "Удлинённый", "Удлинённая", "Удлинённое", "Удлинённые" },
        new[] { "Расхищающий", "Расхищающая", "Расхищающее", "Расхищающие" }
    };
}
