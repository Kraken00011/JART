using System.Reflection;
using MonoMod.Cil;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using JAtRT.Common.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using MusicBoxSlotNew;

public class MusicBoxSlotNewILPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("MusicBoxSlotNew") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.MusicBoxSlotLocalization;

    public override MethodBase ModifiedMethod => typeof(MusicBoxSlotNew.MusicBoxSlotNew).GetProperty(nameof(MusicBoxSlotNew.MusicBoxSlotNew.ItemIsMusicBox))?.GetGetMethod();

    public override ILContext.Manipulator PatchMethod { get; } = il =>
    {
        TranslationHelper.ModifyIL(il, "Music Box", "Музыкальная шкатулка");
    };
}