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

public class PotionSlotNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("PotionSlots") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("PotionSlots", out var mod))
                return null;

            var type = mod.Code.GetType("PotionSlots.Content.GUI.PotionSlotGui");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] PotionSlots/PotionSlotsPatch: тип не найден!");
                return null;
            }

            return type.GetMethod("Draw",
                BindingFlags.Instance | BindingFlags.Public);
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Potions")))
        {
            Logging.PublicLogger.Warn("[JAtRT] PotionSlots/PotionSlotsPatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = "Зелья";
    };
}