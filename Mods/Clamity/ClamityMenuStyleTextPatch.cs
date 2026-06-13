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

public class ClamityMenuStyleNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("Clamity") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.ClamityFix;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("Clamity", out var mod))
                return null;

            var type = mod.Code.GetType("Clamity.Content.Menu.ClamityMenu");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] Clamity/ClamityMenuStyleNamePatch: тип не найден!");
                return null;
            }

            return type.GetProperty("DisplayName")?.GetGetMethod();
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Clamity Style")))
        {
            Logging.PublicLogger.Warn("[JAtRT] Clamity/ClamityMenuStyleNamePatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = "Стиль Clamity"; // итоговый перевод
    };
}