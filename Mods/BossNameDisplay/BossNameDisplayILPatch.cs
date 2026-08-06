using System.Reflection;
using MonoMod.Cil;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.MonoMod;

public class BossNameDisplayFontPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("BossNameDisplay") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("BossNameDisplay", out var mod))
                return null;

            var type = mod.Code.GetType("BossNameDisplay.BossTitleSystem");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] BossNameDisplay/BossNameDisplayFontPatch: тип не найден!");
                return null;
            }

            return type.GetMethod("Load", BindingFlags.Public | BindingFlags.Instance);
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        if (!cursor.TryGotoNext(i => i.MatchLdstr("BossNameDisplay/Assets/Fonts/BossTitle")))
        {
            Logging.PublicLogger.Warn("[JAtRT] BossNameDisplay/BossNameDisplayFontPatch: строка не найдена!");
            return;
        }

        cursor.Next.Operand = "JART-Main/Assets/Fonts/BossTitleCyrillic";
    };
}