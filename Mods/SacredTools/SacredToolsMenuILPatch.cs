using System.Reflection;
using MonoMod.Cil;
using JAtRT.Core.MonoMod;
using JAtRT.Common.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using SacredTools.Content.Menus;

public class SacredToolsMenuILPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("SacredTools") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod => typeof(RestlessMenu).GetProperty(nameof(RestlessMenu.DisplayName))?.GetGetMethod();

    public override ILContext.Manipulator PatchMethod { get; } = il =>
    {
        TranslationHelper.ModifyIL(il, "Darkness of the Past - Act I", "Тени прошлого - 1 акт");
    };
}