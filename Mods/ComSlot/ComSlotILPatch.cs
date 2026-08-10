using System.Collections.Generic;
using System.Reflection;
using MonoMod.Cil;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using Terraria.Localization;
using Terraria.ModLoader;

public class ComSlotILPatch : ILPatcher
{
    public override bool AutoLoad => Language.ActiveCulture.Name == "ru-RU" && ModLoader.HasMod("ComSlot") && JARTLocalizationConf.Instance.ComSlotLocalization;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("ComSlot", out var mod))
                return null;

            var type = mod.Code.GetType("ComSlot.CommunitySlot");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] ComSlot/CommunitySlotPatch: тип не найден!");
                return null;
            }

            return type.GetMethod("OnMouseHover", BindingFlags.Public | BindingFlags.Instance);
        }
    }

    private static readonly Dictionary<string, string> _replacements = new()
    {
        { "Dye",            "Краситель" },
        { "Vanity Slot",    "Внешний вид: Сообщество" },
        { "The Community",  "Сообщество" },
    };

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        while (cursor.TryGotoNext(i => i.MatchLdstr(out string s) && _replacements.ContainsKey(s)))
        {
            cursor.Next.Operand = _replacements[(string)cursor.Next.Operand];
        }
    };
}