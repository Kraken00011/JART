using System.Reflection;
using MonoMod.Cil;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using JAtRT.Common.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using TheDepths;

public class TheDepthsMenuILPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("TheDepths") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.TheDepthsFix;

    public override MethodBase ModifiedMethod => typeof(TheDepthsMenuTheme).GetProperty(nameof(TheDepthsMenuTheme.DisplayName))?.GetGetMethod();

    public override ILContext.Manipulator PatchMethod { get; } = il =>
    {
        TranslationHelper.ModifyIL(il, "Depths", "Глубины");
    };
}

public class TheDepthsOtherworldlyMenuILPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("TheDepths") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.TheDepthsFix;

    public override MethodBase ModifiedMethod => typeof(TheDepthsOtherworldlyMenuTheme).GetProperty(nameof(TheDepthsOtherworldlyMenuTheme.DisplayName))?.GetGetMethod();

    public override ILContext.Manipulator PatchMethod { get; } = il =>
    {
        TranslationHelper.ModifyIL(il, "Depths (Otherworldly)", "Глубины (Иномирные)");
    };
}