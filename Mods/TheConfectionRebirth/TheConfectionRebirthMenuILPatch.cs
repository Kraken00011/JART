using System.Reflection;
using MonoMod.Cil;
using JAtRT.Core.MonoMod;
using JAtRT.Common.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using TheConfectionRebirth;

public class TheConfectionRebirthMenuILPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("TheConfectionRebirth") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod => typeof(ConfectionMenu).GetProperty(nameof(ConfectionMenu.DisplayName))?.GetGetMethod();

    public override ILContext.Manipulator PatchMethod { get; } = il =>
    {
        TranslationHelper.ModifyIL(il, "Confection Menu", "Меню Confection");
    };
}

public class TheConfectionRebirthProgrammerArtMenuILPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("TheConfectionRebirth") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod => typeof(ConfectionMenuProgrammerArt).GetProperty(nameof(ConfectionMenuProgrammerArt.DisplayName))?.GetGetMethod();

    public override ILContext.Manipulator PatchMethod { get; } = il =>
    {
        TranslationHelper.ModifyIL(il, "Confection 1.3.5.3", "Меню Confection версии 1.3.5.3");
    };
}