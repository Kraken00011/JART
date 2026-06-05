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

public class CompletedTextPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("Munchies") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.MunchiesLocalization;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("Munchies", out var mod))
                return null;

            var type = mod.Code.GetType("Munchies.UIElements.ReportUI");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] Munchies/CompletedTextPatch: тип не найден!");
                return null;
            }

            return type.GetMethod("DrawSelf",
                BindingFlags.Instance | BindingFlags.NonPublic);
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(MoveType.After,
            i => i.MatchCallOrCallvirt("Terraria.Localization.LocalizedText", "Format")))
        {
            Logging.PublicLogger.Warn("[JAtRT] Munchies/CompletedTextPatch: Format не найден!");
            return;
        }

        cursor.EmitDelegate<Func<string, string>>(text => text.Contains("Ванилла") ? "Ванилла завершена!" : text);
    };
}