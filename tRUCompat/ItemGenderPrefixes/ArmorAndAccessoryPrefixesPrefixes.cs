using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

public class ArmorAndAccessoryPrefixesPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return ModLoader.HasMod("ArmorAndAccessoryPrefixes") && ModLoader.HasMod("CalamityRuTranslate") && JARTLocalizationConf.Instance.ArmorAndAccessoryPrefixesLocalization && Language.ActiveCulture.Name == "ru-RU";
    }
    public override void PostSetupContent()
    {
        if (!ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru))
            return;

        RegisterArmorAndAccessoryPrefixes(tru);
    }

    private void RegisterArmorAndAccessoryPrefixes(Mod tru)
    {
        if (!ModLoader.TryGetMod("ArmorAndAccessoryPrefixes", out _))
            return;

        tru.Call("RegisterPrefixes", ArmorAndAccessoryPrefixes);
    }

    private static readonly List<string[]> ArmorAndAccessoryPrefixes = new()
    {
        new[] { "Заколдованный", "Заколдованная", "Заколдованное", "Заколдованные" },
        new[] { "Расширенный", "Расширенная", "Расширенное", "Расширенные" },
        new[] { "Экономный", "Экономная", "Экономное", "Экономные" },
        new[] { "Стойкий", "Стойкая", "Стойкое", "Стойкие" },
        new[] { "Колоссальный", "Колоссальная", "Колоссальное", "Колоссальные" },
        new[] { "Удлинённый", "Удлинённая", "Удлинённое", "Удлинённые" },
        new[] { "Достающий", "Достающая", "Достающее", "Достающие" },
        new[] { "Притягивающий", "Притягивающая", "Притягивающее", "Притягивающие" },
        new[] { "Магнитный", "Магнитная", "Магнитное", "Магнитные" },
        new[] { "Скоростной", "Скоростная", "Скоростное", "Скоростные" },
        new[] { "Раскопочный", "Раскопочная", "Раскопочное", "Раскопочные" },
        new[] { "Жизненный", "Жизненная", "Жизненное", "Жизненные" },
        new[] { "Сердечный", "Сердечная", "Сердечное", "Сердечные" },
        new[] { "Благословлённый", "Благословлённая", "Благословлённое", "Благословлённые" },
        new[] { "Благородный", "Благородная", "Благородное", "Благородные" },
        new[] { "Гневный", "Гневная", "Гневное", "Гневные" },
        new[] { "Сонный", "Сонная", "Сонное", "Сонные" },
        new[] { "Божественный", "Божественная", "Божественное", "Божественные" },
        new[] { "Освящённый", "Освящённая", "Освящённое", "Освящённые" },
        new[] { "Прыгучий", "Прыгучая", "Прыгучее", "Прыгучие" },
        new[] { "Скачущий", "Скачущая", "Скачущее", "Скачущие" },
        new[] { "Пробивной", "Пробивная", "Пробивное", "Пробивные" },
        new[] { "Кромсающий", "Кромсающая", "Кромсающее", "Кромсающие" },
        new[] { "Заклинающий", "Заклинающая", "Заклинающее", "Заклинающие" },
        new[] { "Страждущий", "Страждущая", "Страждущее", "Страждущие" },
        new[] { "Укреплённый", "Укреплённая", "Укреплённое", "Укреплённые" },
        new[] { "Твёрдый", "Твёрдая", "Твёрдое", "Твёрдые" },
        new[] { "Летучий", "Летучая", "Летучее", "Летучие" },
        new[] { "Парящий", "Парящая", "Парящее", "Парящие" },
        new[] { "Лечащий", "Лечащая", "Лечащее", "Лечащие" },
        new[] { "Целебный", "Целебная", "Целебное", "Целебные" }
    };
}