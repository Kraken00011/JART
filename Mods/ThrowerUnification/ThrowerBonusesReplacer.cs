using System.Collections.Generic;
using System.Text.RegularExpressions;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using ThrowerUnification;
using HomewardRagnarok.Config;

public partial class ThrowerBonusesGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.ThrowerUnificationFix && ModLoader.HasMod("ThrowerUnification");
    }
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        if (item.defense <= 0 && !item.accessory)
        {
            return;
        }

        for (int i = 0; i < tooltips.Count; i++)
        {
            if (i != 0)
            {
                //Метатель
                if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Thrower)
                {
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойный", "Метательный");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойный", "метательный");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойные", "Метательные");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойные", "метательные");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойных", "Метательных");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойных", "метательных");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойной", "Метательной");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойной", "метательной");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойного", "Метательного");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойного", "метательного");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Оружие разбойника", "Оружие метателя");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость снарядов разбойника", "Скорость снарядов метателя");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость снарядов разбойника", "скорость снарядов метателя");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость оружия разбойника", "Скорость оружия метателя");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость оружия разбойника", "скорость оружия метателя");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "оружие разбойника", "оружие метателя");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойному оружию", $"метательному оружию");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "предмет разбойника", "предмет метателя");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойное", "Метательное");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойное", "метательное");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойную", "Метательную");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойную", "метательную");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойным", "Метательным");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойным", "метательным");

                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломный", "Метательный");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломный", "метательный");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломные", "Метательные");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломные", "метательные");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломных", "Метательных");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломных", "метательных");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломного", "Метательного");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломного", "метательного");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломное", "Метательное");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломное", "метательное");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломную", "Метательную");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломную", "метательную");
                }

                //Разбойник
                if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Rogue)
                {
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательный", "Разбойный");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательный", "разбойный");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательные", "Разбойные");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательные", "разбойные");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательных", "Разбойных");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательных", "разбойных");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательной", "Разбойной");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательной", "разбойной");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательного", "Разбойного");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательного", "разбойного");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Оружие метателя", "Оружие разбойника");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость снарядов метателя", "Скорость снарядов разбойника");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость снарядов метателя", "скорость снарядов разбойника");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость оружия метателя", "Скорость оружия разбойника");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость оружия метателя", "скорость оружия разбойника");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "оружие метателя", "оружие разбойника");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательное", "Разбойное");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательное", "разбойное");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательную", "Разбойную");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательную", "разбойную");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательным", "Разбойным");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательным", "разбойным");

                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломный", "Разбойный");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломный", "разбойный");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломные", "Разбойные");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломные", "разбойные");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломных", "Разбойных");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломных", "разбойных");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломного", "Разбойного");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломного", "разбойного");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломное", "Разбойное");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломное", "разбойное");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломную", "Разбойную");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломную", "разбойную");
                }

                // Веролом
                if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Malevolent)
                {
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательный", "Вероломный");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательный", "вероломный");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательные", "Вероломные");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательные", "вероломные");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательных", "Вероломных");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательных", "вероломных");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательной", "Вероломной");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательной", "вероломной");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательного", "Вероломного");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательного", "вероломного");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Оружие метателя", "Оружие веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость снарядов метателя", "Скорость снарядов веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость снарядов метателя", "скорость снарядов веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость оружия метателя", "Скорость оружия веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость оружия метателя", "скорость оружия веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "оружие метателя", "оружие веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательное", "Вероломное");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательное", "вероломное");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательную", "Вероломную");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательную", "вероломную");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательным", "Вероломным");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательным", "вероломным");

                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойный", "Вероломный");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойный", "вероломный");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойные", "Вероломные");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойные", "вероломные");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойных", "Вероломных");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойных", "вероломных");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойной", "Вероломной");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойной", "вероломной");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойного", "Вероломного");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойного", "вероломного");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Оружие разбойника", "Оружие веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость снарядов разбойника", "Скорость снарядов веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость снарядов разбойника", "скорость снарядов веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость оружия разбойника", "Скорость оружия веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость оружия разбойника", "скорость оружия веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "оружие разбойника", "оружие веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойному оружию", $"вероломному оружию");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "предмет разбойника", "предмет веролома");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойное", "Вероломное");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойное", "вероломное");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойную", "Вероломную");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойную", "вероломную");
                }

                // Кинетик
                if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Kinetic)
                {
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательный", "Кинетический");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательный", "кинетический");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательные", "Кинетический");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательные", "кинетический");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательных", "Кинетических");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательных", "кинетических");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательной", "Кинетической");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательной", "кинетической");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательного", "Кинетического");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательного", "кинетического");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Оружие метателя", "Оружие кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость снарядов метателя", "Скорость снарядов кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость снарядов метателя", "скорость снарядов кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость оружия метателя", "Скорость оружия кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость оружия метателя", "скорость оружия кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "оружие метателя", "оружие кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательное", "Кинетическое");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательное", "кинетическое");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательную", "Кинетическую");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательную", "кинетическую");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательным", "Кинетическим");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательным", "кинетическим");

                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойный", "Кинетический");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойный", "кинетический");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойные", "Кинетические");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойные", "кинетические");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойных", "Кинетических");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойных", "кинетических");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойной", "Кинетической");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойной", "кинетической");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойного", "Кинетического");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойного", "кинетического");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Оружие разбойника", "Оружие кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость снарядов разбойника", "Скорость снарядов кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость снарядов разбойника", "скорость снарядов кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость оружия разбойника", "Скорость оружия кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость оружия разбойника", "скорость оружия кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "оружие разбойника", "оружие кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойному оружию", $"кинетическому оружию");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "предмет разбойника", "предмет кинетика");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойное", "Кинетическое");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойное", "кинетическое");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойную", "Кинетическую");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойную", "кинетическую");

                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломный", "Кинетический");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломный", "кинетический");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломные", "Кинетические");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломные", "кинетические");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломных", "Кинетических");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломных", "кинетических");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломного", "Кинетического");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломного", "кинетического");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломное", "Кинетическое");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломное", "кинетическое");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломную", "Кинетическую");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломную", "кинетическую");
                }

                // Кастомное
                if (ThrowerModConfig.Instance.TooltipOverride == TooltipOverrideStyle.Custom)
                {
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательный", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательный", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательные", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательные", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательных", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательных", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательной", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательной", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательного", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательного", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Оружие метателя", $"Оружие {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость снарядов метателя", $"Скорость снарядов {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость снарядов метателя", $"скорость снарядов {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость оружия метателя", $"Скорость оружия {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость оружия метателя", $"скорость оружия {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "оружие метателя", $"оружие {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательное", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательное", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательную", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательную", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Метательным", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "метательным", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());

                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойный", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойный", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойные", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойные", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойных", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойных", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойной", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойной", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойного", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойного", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Оружие разбойника", $"Оружие {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость снарядов разбойника", $"Скорость снарядов {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость снарядов разбойника", $"скорость снарядов {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Скорость оружия разбойника", $"Скорость оружия {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "скорость оружия разбойника", $"скорость оружия {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "оружие разбойника", $"оружие {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойному оружию", $"{ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()} оружию");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "предмет разбойника", $"предмет {ThrowerModConfig.Instance.CustomTooltipOverride.ToLower()}");
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойное", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойное", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Разбойную", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "разбойную", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());

                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломный", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломный", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломные", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломные", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломных", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломных", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломного", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломного", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломное", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломное", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "Вероломную", ThrowerModConfig.Instance.CustomTooltipOverride);
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "вероломную", ThrowerModConfig.Instance.CustomTooltipOverride.ToLower());
                }
            }
        }
    }
}