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

public class SacredToolsStyleNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("SacredTools") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("SacredTools", out var mod))
                return null;

            var type = mod.Code.GetType("SacredTools.Content.Menus.RestlessMenu");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] SacredTools/MenuStyleNamePatch: тип не найден!");
                return null;
            }

            return type.GetProperty("DisplayName")?.GetGetMethod();
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Darkness of the Past - Act I")))
        {
            Logging.PublicLogger.Warn("[JAtRT] SacredTools/MenuStyleNamePatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = "Тени прошлого - 1 Акт"; // итоговый перевод
    };
}