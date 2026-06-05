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

public class StressBarNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("CalamityHunt") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.CalamityHuntFix;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("CalamityHunt", out var mod))
                return null;

            var type = mod.Code.GetType("CalamityHunt.Common.UI.StressBar");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] CalamityHunt/StressBarNamePatch: тип не найден!");
                return null;
            }

            return type.GetNestedType("<>c", BindingFlags.NonPublic)
                ?.GetMethod("<ModifyInterfaceLayers>b__7_1",
                BindingFlags.Instance | BindingFlags.NonPublic);
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        while (cursor.TryGotoNext(i => i.MatchLdstr("Stress: ")))
            cursor.Next.Operand = "Стресс: ";
    };
}