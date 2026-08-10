using System.Reflection;
using MonoMod.Cil;
using JAtRT.Core.MonoMod;
using JAtRT.Common.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using Redemption;

public class RedemptionRuinedKingdomMenuILPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("Redemption") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod => typeof(RedemptionMenu).GetProperty(nameof(RedemptionMenu.DisplayName))?.GetGetMethod();

    public override ILContext.Manipulator PatchMethod { get; } = il =>
    {
        TranslationHelper.ModifyIL(il, "Ruined Kingdom", "Разрушенное королевство");
    };
}

public class RedemptionEpidotraMapMenuILPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("Redemption") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod => typeof(RedemptionMenu2).GetProperty(nameof(RedemptionMenu2.DisplayName))?.GetGetMethod();

    public override ILContext.Manipulator PatchMethod { get; } = il =>
    {
        TranslationHelper.ModifyIL(il, "Epidotra Map", "Карта Эпидотры");
    };
}