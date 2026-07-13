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

public class TheConfectionRebirthMenuNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("TheConfectionRebirth") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("TheConfectionRebirth", out var mod))
                return null;

            var type = mod.Code.GetType("TheConfectionRebirth.ConfectionMenu");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] TheConfectionRebirth/TheConfectionRebirthMenuNamePatch: тип не найден!");
                return null;
            }

            return type.GetProperty("DisplayName")?.GetGetMethod();
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Confection Menu")))
        {
            Logging.PublicLogger.Warn("[JAtRT] TheConfectionRebirth/TheConfectionRebirthMenuNamePatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = Language.GetTextValue("Меню Confection");
    };
}

public class TheConfectionRebirthProgrammerArtMenuNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("TheConfectionRebirth") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("TheConfectionRebirth", out var mod))
                return null;

            var type = mod.Code.GetType("TheConfectionRebirth.ConfectionMenuProgrammerArt");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] TheConfectionRebirth/TheConfectionRebirthProgrammerArtMenuNamePatch: тип не найден!");
                return null;
            }

            return type.GetProperty("DisplayName")?.GetGetMethod();
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Confection 1.3.5.3")))
        {
            Logging.PublicLogger.Warn("[JAtRT] TheConfectionRebirth/TheConfectionRebirthProgrammerArtMenuNamePatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = Language.GetTextValue("Меню Confection 1.3.5.3");
    };
}