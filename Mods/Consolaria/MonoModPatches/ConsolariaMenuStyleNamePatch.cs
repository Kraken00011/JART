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

namespace JAtRT.Mods.Consolaria;

public class ConsolariaMenuStyleNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("Consolaria") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("Consolaria", out var mod))
                return null;

            var type = mod.Code.GetType("Consolaria.Common.ValentinesDayMenu");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] Consolaria/ValentinesMenuStylePatch: тип не найден!");
                return null;
            }

            return type.GetProperty("DisplayName")?.GetGetMethod();
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Valentine's Day")))
        {
            Logging.PublicLogger.Warn("[JAtRT] Consolaria/ValentinesMenuStylePatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = "День святого Валентина"; // итоговый перевод
    };
}