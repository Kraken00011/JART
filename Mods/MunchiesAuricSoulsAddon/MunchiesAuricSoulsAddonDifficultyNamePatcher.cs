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

public class AllCalamityAddonDifficultyNamePatch_Rage : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("MunchiesAuricSoulsAddon") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.MunchiesAuricSoulsAddonLocalization;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("MunchiesAuricSoulsAddon", out var mod))
                return null;

            var type = mod.Code.GetType("MunchiesAuricSoulsAddon.MunchiesAuricSoulsAddon");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] MunchiesAuricSoulsAddon/DifficultyNamePatch_Rage: тип не найден!");
                return null;
            }

            return type.GetMethod("AddCalamityConsumables_RageMode",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);
        while (cursor.TryGotoNext(i => i.MatchLdstr("Revengeance")))
            cursor.Next.Operand = "Месть";
    };
}

public class AllCalamityAddonDifficultyNamePatch_Adrenaline : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("MunchiesAuricSoulsAddon") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("MunchiesAuricSoulsAddon", out var mod))
                return null;

            var type = mod.Code.GetType("MunchiesAuricSoulsAddon.MunchiesAuricSoulsAddon");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] MunchiesAuricSoulsAddon/DifficultyNamePatch_Adrenaline: тип не найден!");
                return null;
            }

            return type.GetMethod("AddCalamityConsumables_AdrenalineMode",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);
        while (cursor.TryGotoNext(i => i.MatchLdstr("Revengeance")))
            cursor.Next.Operand = "Месть";
    };
}