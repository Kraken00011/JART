using System;
using System.Reflection;
using InfernalEclipseWeaponsDLC.ChatTags;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using ReLogic.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

public class InfernalArsenalBuffSnippetUniqueDrawPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("InfernalEclipseWeaponsDLC") && JARTLocalizationConf.Instance.InfernalEclipseWeaponsDLCLocalization && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod =>
        typeof(InfernalArsenalBuffTagHandler.Snippet).GetMethod(nameof(InfernalArsenalBuffTagHandler.Snippet.UniqueDraw));

    public override ILContext.Manipulator PatchMethod { get; } = il =>
    {
        ILCursor cursor = new ILCursor(il);

        while (cursor.TryGotoNext(i => i.MatchLdstr(" ")))
            cursor.Next.Operand = " «";

        cursor.Index = 0;

        int count = 0;
        while (cursor.TryGotoNext(i => i.MatchLdcR4(26f)))
        {
            if (++count <= 2)
                cursor.Next.Operand = 22f;
        }

        cursor.Index = 0;

        if (cursor.TryGotoNext(MoveType.Before, i => i.MatchCall(typeof(string), nameof(string.Concat))))
        {
            cursor.Emit(OpCodes.Ldstr, "»");
            cursor.Remove();
            cursor.Emit(OpCodes.Call, typeof(string).GetMethod(
                nameof(string.Concat),
                new[] { typeof(string), typeof(string), typeof(string) }
            ));
        }
    };
}

public class InfernalArsenalBuffSnippetGetStringLengthPatch : OnPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("InfernalEclipseWeaponsDLC");

    public override MethodBase ModifiedMethod =>
        typeof(InfernalArsenalBuffTagHandler.Snippet).GetMethod(nameof(InfernalArsenalBuffTagHandler.Snippet.GetStringLength));

    public override Delegate Delegate => Translation;

    private static float Translation(
        Func<InfernalArsenalBuffTagHandler.Snippet, DynamicSpriteFont, float> orig,
        InfernalArsenalBuffTagHandler.Snippet self,
        DynamicSpriteFont font)
    {
        return (!self.DrawIcon ? 0f : 22f + font.MeasureString(" «").X)
            + font.MeasureString(Lang.GetBuffName(self.BuffId)).X
            + font.MeasureString("»").X * self.Scale;
    }
}