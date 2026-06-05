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

public class TheDepthsMenuNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("TheDepths") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("TheDepths", out var mod))
                return null;

            var type = mod.Code.GetType("TheDepths.TheDepthsMenuTheme");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] TheDepths/TheDepthsMenuNamePatch: тип не найден!");
                return null;
            }

            return type.GetProperty("DisplayName")?.GetGetMethod();
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Depths")))
        {
            Logging.PublicLogger.Warn("[JAtRT] TheDepths/TheDepthsMenuNamePatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = Language.GetTextValue("Глубины"); // итоговый перевод
    };
}

public class TheDepthsOtherworldlyMenuNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("TheDepths") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("TheDepths", out var mod))
                return null;

            var type = mod.Code.GetType("TheDepths.TheDepthsOtherworldlyMenuTheme");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] TheDepths/TheDepthsOtherworldlyMenuNamePatch: тип не найден!");
                return null;
            }

            return type.GetProperty("DisplayName")?.GetGetMethod();
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Depths (Otherworldly)")))
        {
            Logging.PublicLogger.Warn("[JAtRT] TheDepths/TheDepthsOtherworldlyMenuNamePatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = Language.GetTextValue("Глубины (Иномирные)"); // итоговый перевод
    };
}