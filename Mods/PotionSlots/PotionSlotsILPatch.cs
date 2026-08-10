using System.Reflection;
using MonoMod.Cil;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using JAtRT.Common.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using PotionSlots.Content.GUI;

public class PotionSlotILPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("PotionSlots") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.PotionSlotsLocalization;

    public override MethodBase ModifiedMethod => typeof(PotionSlotGui).GetProperty(nameof(PotionSlotGui.Draw))?.GetGetMethod();

    public override ILContext.Manipulator PatchMethod { get; } = il =>
    {
        TranslationHelper.ModifyIL(il, "Potions", "Зелья");
    };
}