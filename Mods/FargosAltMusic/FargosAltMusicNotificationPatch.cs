using System;
using System.Reflection;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.MonoMod;
using JAtRT.Core.Config;

public class FargosAltMusicNotificationTextPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("FargoAltMusicMod") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.FargosAltMusicModLocalization;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("FargoAltMusicMod", out var mod))
                return null;

            var type = mod.Code.GetType("FargoAltMusicMod.NowPlayingSystem");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] FargosAltMusicNotificationTextPatch: тип не найден!");
                return null;
            }

            return type.GetMethod("PostUpdateEverything");
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Now Playing: ")))
        {
            Terraria.ModLoader.Logging.PublicLogger.Warn(
                "[JAtRT] FargosAltMusicNotificationTextPatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = "Сейчас играет: ";
    };
}

public class FargosAltMusicNotificationScalePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("FargoAltMusicMod");

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("FargoAltMusicMod", out var mod))
                return null;

            var type = mod.Code.GetType("FargoAltMusicMod.UI.NowPlayingNotif");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] FargosAltMusicNotificationScalePatch: тип не найден!");
                return null;
            }

            return type.GetMethod("DrawInGame");
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdcR4(12f)))
        {
            Logging.PublicLogger.Warn("[JAtRT] FargosAltMusicNotificationScalePatch: отступ 12f не найден!");
            return;
        }

        cursor.Next.Operand = 26f;
    };
}