using System.Reflection;
using MonoMod.Cil;
using JAtRT.Core.MonoMod;
using JAtRT.Common.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using RagnarokMod.MainMenu;

public class RagnarokMenuILPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("RagnarokMod") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod => typeof(RagnarokMainMenu).GetProperty(nameof(RagnarokMainMenu.DisplayName))?.GetGetMethod();

    public override ILContext.Manipulator PatchMethod { get; } = il =>
    {
        TranslationHelper.ModifyIL(il, "Ragnarok Style", "Стиль Ragnarok");
    };
}