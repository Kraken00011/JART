using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using WhatAmmoDoesThisUse;
public partial class WhatAmmoDoesThisUseGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.WADTULocalization && ModLoader.HasMod("WhatAmmoDoesThisUse");
    }

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (TooltipLine tooltip in tooltips)
        {
            if (tooltip.Mod == "WhatAmmoDoesThisUse" && tooltip.Name == "UseAmmoLine")
            {
                tooltip.Text = tooltip.Text.Replace("Деревянная стрелаs", "деревянные стрелы");
                tooltip.Text = tooltip.Text.Replace("Мушкетная пуляs", "мушкетные пули");
                tooltip.Text = tooltip.Text.Replace("Семяs", "семена");
                tooltip.Text = tooltip.Text.Replace("Гельs", "гель");
                tooltip.Text = tooltip.Text.Replace("Песокs", "песок");
                tooltip.Text = tooltip.Text.Replace("Упавшая звездаs", "упавшие звёзды");
                tooltip.Text = tooltip.Text.Replace("Костьs", "кости");
                tooltip.Text = tooltip.Text.Replace("Паутинаs", "паутину");
                tooltip.Text = tooltip.Text.Replace("Сигнальная ракетаs", "сигнальные ракеты");
                tooltip.Text = tooltip.Text.Replace("Снежокs", "снежки");
                tooltip.Text = tooltip.Text.Replace("Гранатаs", "гранаты");
                tooltip.Text = tooltip.Text.Replace("Кэнди-корнs", "кэнди-корны");
                tooltip.Text = tooltip.Text.Replace("Колs", "колы");
                tooltip.Text = tooltip.Text.Replace("Ракета Is", "ракеты I");
                tooltip.Text = tooltip.Text.Replace("Гвоздьs", "гвозди");
                tooltip.Text = tooltip.Text.Replace("Зелёный растворs", "зелёный раствор");
                tooltip.Text = tooltip.Text.Replace("Жёлудьs", "жёлуди");
                tooltip.Text = tooltip.Text.Replace("Медная рудаs", "медную руду");
                tooltip.Text = tooltip.Text.Replace("Пушечное ядроs", "пушечные ядра");
                tooltip.Text = tooltip.Text.Replace("Взрывной светильник Джекаs", "взрывные светильники Джека");
                tooltip.Text = tooltip.Text.Replace("Динамитs", "динамит");
                tooltip.Text = tooltip.Text.Replace("Медная монетаs", "медные монеты");
                tooltip.Text = tooltip.Text.Replace("Болты Стингераs", "болты Стингера");
                tooltip.Text = tooltip.Text.Replace("Банка водыs", "банки воды");

                tooltip.Text = tooltip.Text.Replace("Руна кровиs", "руны крови");

                tooltip.Text = tooltip.Text.Replace("Мини-торпедаs", "мини-торпеды");
                tooltip.Text = tooltip.Text.Replace("Циркулярная пилаs", "циркулярные пилы");
                tooltip.Text = tooltip.Text.Replace("Пилюляs", "пилюли");
                tooltip.Text = tooltip.Text.Replace("Шприцs", "шприцы");
                tooltip.Text = tooltip.Text.Replace("Картофелинаs", "картофелины");
                tooltip.Text = tooltip.Text.Replace("Бейсбольный мячs", "бейсбольные мячи");
                tooltip.Text = tooltip.Text.Replace("Паровая батареяs", "паровые батареи");
                tooltip.Text = tooltip.Text.Replace("Сопливый шарs", "сопливые шары");
                tooltip.Text = tooltip.Text.Replace("Бурлящий зарядs", "бурлящие заряды");

                tooltip.Text = tooltip.Text.Replace("Батарея рельсотронаs", "батареи рельсотрона");

                tooltip.Text = tooltip.Text.Replace("Факельная бомбаs", "факельные бомбы");
                tooltip.Text = tooltip.Text.Replace("Арахисs", "арахис");

                tooltip.Text = tooltip.Text.Replace("Яйцо-бомбаs", "яйца-бомбы");
                tooltip.Text = tooltip.Text.Replace("Уранs", "уран");
            }
        }
    }
}