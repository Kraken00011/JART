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

public class CalamityAddonDifficultyNamePatch_Rage : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("Munchies_CalamityAddon") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.MunchiesCalamityAddonLocalization;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("Munchies_CalamityAddon", out var mod))
                return null;

            var type = mod.Code.GetType("Munchies_CalamityAddon.Munchies_CalamityAddon");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] Munchies_CalamityAddon/DifficultyNamePatch_Rage: тип не найден!");
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

public class CalamityAddonDifficultyNamePatch_Adrenaline : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("Munchies_CalamityAddon") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.MunchiesCalamityAddonLocalization != null;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("Munchies_CalamityAddon", out var mod))
                return null;

            var type = mod.Code.GetType("Munchies_CalamityAddon.Munchies_CalamityAddon");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] Munchies_CalamityAddon/DifficultyNamePatch_Adrenaline: тип не найден!");
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