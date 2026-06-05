using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

public class ExtraWorldSizesPatch : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("ExtraWorldSizes") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.ExtraWorldSizesLocalization;

    public override void OnLocalizationsLoaded()
    {
        if (!ModLoader.TryGetMod("ExtraWorldSizes", out var mod))
            return;

        void Set(string key, string value)
        {
            var text = Language.GetOrRegister(key);
            typeof(LocalizedText)
                .GetField("_value", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(text, value);
        }

        // Названия размеров
        Set($"Mods.{mod.Name}.UI.WorldSizeTiny", "Крошечный");
        Set($"Mods.{mod.Name}.UI.WorldSizeHMedium", "Средний");
        Set($"Mods.{mod.Name}.UI.WorldSizeHuge", "Огромный");

        // Описания размеров
        Set($"Mods.{mod.Name}.UI.WorldDescriptionSizeTiny", "Мелкий и очень компактный мир, идеален для проведения различных испытаний и тестов.");
        Set($"Mods.{mod.Name}.UI.WorldDescriptionSizeHuge", "Гигантский мир для очень длительного прохождения или крупного сервера.");
    }
}