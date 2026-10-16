using System;
using System.Reflection;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.Localization;
using JAtRT.Core.Config;

public class FancyBossIntrosModSystem : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("FancyBossIntros") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.BossNameDisplayLocalization;

    public override void PostSetupContent()
    {
        if (!ModLoader.TryGetMod("FancyBossIntros", out Mod fbi)) return;

        try
        {
            var asm = fbi.GetType().Assembly;

            byte[] fontBytes = Mod.GetFileBytes("Assets/Fonts/RuFancyBossIntros.ttf");
            fbi.Call("RegisterFont", "JAtRT", "AlgeriusCaps", fontBytes);

            var registryType = asm.GetType("FancyBossIntros.Content.Registries.IntroRegistry");
            var introsField = registryType?.GetField("Definitions", BindingFlags.Public | BindingFlags.Static);
            var intros = introsField?.GetValue(null) as System.Collections.IDictionary;

            var introType = asm.GetType("FancyBossIntros.Content.BossIntro");
            var fontNameField = introType?.GetField("FontName", BindingFlags.Public | BindingFlags.Instance);

            if (intros != null && fontNameField != null)
            {
                foreach (var key in intros.Keys)
                    fontNameField.SetValue(intros[key], "JAtRT:AlgeriusCaps");
                Mod.Logger.Info($"[JAtRT] Пропатчено {intros.Count} вступлений.");
            }
            else
            {
                Mod.Logger.Warn("[JAtRT] Could not find Definitions or FontName field.");
            }
        }
        catch (Exception ex)
        {
            Mod.Logger.Error($"[JAtRT] Error: {ex}");
        }
    }
}