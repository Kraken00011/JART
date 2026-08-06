using System.Reflection;
using MonoMod.Cil;
using JAtRT.Core.MonoMod;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

public class ActivateWindowsImgILPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("ActivateWindows") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.ActivateWindowsLocalization;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("ActivateWindows", out var mod))
                return null;

            var type = mod.Code.GetType("ActivateWindows.UI.WindowsUI");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] ActivateWindows/ValentinesMenuStylePatch: тип не найден!");
                return null;
            }

            return type.GetMethod("OnInitialize", BindingFlags.Public | BindingFlags.Instance);
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("ActivateWindows/UI/activateWindows")))
        {
            Logging.PublicLogger.Warn("[JAtRT] ActivateWindows/ValentinesMenuStylePatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = "JAtRT/Assets/ActivateWindows_ru";
    };
}