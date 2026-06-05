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

public class EverwareMenuStyleNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("Everware") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("Everware", out var mod))
                return null;

            var type = mod.Code.GetType("Everware.Content.Menu.EverwareTitle");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] Everware/EverwareMenuStyleNamePatch: тип не найден!");
                return null;
            }

            return type.GetProperty("DisplayName")?.GetGetMethod();
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Somewhere Else")))
        {
            Logging.PublicLogger.Warn("[JAtRT] Everware/EverwareMenuStyleNamePatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = Language.GetTextValue("Где-то, когда-то"); // итоговый перевод
    };
}