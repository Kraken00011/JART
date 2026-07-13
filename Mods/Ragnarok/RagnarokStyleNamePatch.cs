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

public class RagnarokStyleNamePatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("RagnarokMod") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("RagnarokMod", out var mod))
                return null;

            var type = mod.Code.GetType("RagnarokMod.MainMenu.RagnarokMainMenu");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] RagnarokMod/RagnarokStyleNamePatch: тип не найден!");
                return null;
            }

            return type.GetProperty("DisplayName")?.GetGetMethod();
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Ragnarok Style")))
        {
            Logging.PublicLogger.Warn("[JAtRT] RagnarokMod/RagnarokStyleNamePatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = "Стиль Ragnarok";
    };
}