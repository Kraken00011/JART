using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

public class IsMusicBoxCondPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("MusicBoxSlotNew") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.MusicBoxSlotLocalization;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("MusicBoxSlotNew", out var mod))
                return null;

            var type = mod.Code.GetType("MusicBoxSlotNew.MusicBoxSlotNew");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] MusicBoxSlotNew/IsMusicBoxCondPatch: тип не найден!");
                return null;
            }

            return type.GetMethod("ItemIsMusicBox",
                BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("Music Box")))
        {
            Logging.PublicLogger.Warn("[JAtRT] MusicBoxSlotNew/IsMusicBoxCondPatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = "Музыкальная шкатулка";
    };
}