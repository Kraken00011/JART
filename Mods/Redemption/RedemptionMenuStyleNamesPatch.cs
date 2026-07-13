using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

public class RedemptionRuinedKingdomStyleNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("Redemption") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("Redemption", out var mod))
                return null;

            var type = mod.Code.GetType("Redemption.RedemptionMenu");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] RedemptionRuinedKingdomStyleNamePatch: тип не найден!");
                return null;
            }

            return type.GetProperty("DisplayName")?.GetGetMethod();
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Ruined Kingdom")))
        {
            Logging.PublicLogger.Warn("[JAtRT] RedemptionRuinedKingdomStyleNamePatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = "Разрушенное королевство";
    };
}

public class RedemptionEpidotraMapStyleNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("Redemption") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("Redemption", out var mod))
                return null;

            var type = mod.Code.GetType("Redemption.RedemptionMenu2");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] RedemptionEpidotraMapStyleNamePatch: тип не найден!");
                return null;
            }

            return type.GetProperty("DisplayName")?.GetGetMethod();
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Epidotra Map")))
        {
            Logging.PublicLogger.Warn("[JAtRT] RedemptionEpidotraMapStyleNamePatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = "Карта Эпидотры";
    };
}