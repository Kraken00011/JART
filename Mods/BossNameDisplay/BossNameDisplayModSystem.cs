using System;
using System.Reflection;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using MonoMod.RuntimeDetour;
using ReLogic.Content;
using Terraria.ModLoader;
using Terraria.Localization;
using JAtRT.Core.Config;

public class BossNameDisplayModSystem : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("BossNameDisplay") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.BossNameDisplayLocalization;

    private Hook _sanitizeHook;

    public override void Load()
    {
        if (!ModLoader.HasMod("BossNameDisplay")) return;

        var asm = ModLoader.GetMod("BossNameDisplay").GetType().Assembly;
        var type = asm.GetType("BossNameDisplay.BossTitleSystem");
        var method = type.GetMethod("SanitizeText", BindingFlags.NonPublic | BindingFlags.Instance);

        _sanitizeHook = new Hook(method,
            (Func<object, string, string> orig, object self, string text) =>
            {
                return text;
            });
    }

    public override void Unload()
    {
        _sanitizeHook?.Dispose();
        _sanitizeHook = null;
    }

    public override void PostSetupContent()
    {
        if (!ModLoader.TryGetMod("BossNameDisplay", out Mod bossNameDisplay))
        {
            Mod.Logger.Warn("[JAtRT] BossNameDisplay не найден.");
            return;
        }
        try
        {
            var asm = bossNameDisplay.GetType().Assembly;
            var systemType = asm.GetType("BossNameDisplay.BossTitleSystem");
            var fontField = systemType.GetField("BossTitleFont", BindingFlags.Public | BindingFlags.Static);
            var myFont = ModContent.Request<SpriteFont>(
                "JAtRT/Assets/Fonts/BossTitle",
                AssetRequestMode.ImmediateLoad
            );
            fontField.SetValue(null, myFont);
            Mod.Logger.Info("[JAtRT] Шрифт заменён.");
        }
        catch (Exception ex)
        {
            Mod.Logger.Error($"[JAtRT] Error: {ex}");
        }
    }
}