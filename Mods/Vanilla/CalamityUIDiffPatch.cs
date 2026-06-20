using System;
using System.Reflection;
using CalamityMod;
using CalamityMod.Systems;
using CalamityMod.UI.ModeIndicator;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using Terraria;
using Terraria.Localization;

public class CalamityUIPatch : OnPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("CalamityMod") && Language.ActiveCulture.Name == "ru-RU";

    public override MethodInfo ModifiedMethod => typeof(ModeIndicatorUI).FindMethod(nameof(ModeIndicatorUI.GetDifficultyStatus));

    private delegate void GetDifficultyStatus(out LocalizedText text);

    public override Delegate Delegate => Translation;

    private void Translation(GetDifficultyStatus orig, out LocalizedText text)
    {
        orig(out text);

        if (!ModeIndicatorUI.MouseScreenArea.Intersects(ModeIndicatorUI.MainClickArea))
            return;

        string name = !Main.getGoodWorld || DifficultyModeSystem.Difficulties[0].FTWName == null
            ? DifficultyModeSystem.Difficulties[1].Name.ToString()
            : DifficultyModeSystem.Difficulties[0].FTWName.ToString();

        bool flag = Main.getGoodWorld;

        for (int index = 1; index < DifficultyModeSystem.Difficulties.Count; ++index)
        {
            if (DifficultyModeSystem.GetCurrentDifficulty == DifficultyModeSystem.Difficulties[index])
            {
                name = !Main.getGoodWorld || DifficultyModeSystem.Difficulties[index].FTWName == null
                    ? DifficultyModeSystem.Difficulties[index].Name.ToString()
                    : DifficultyModeSystem.Difficulties[index].FTWName.ToString();
                flag = true;
            }
        }

        if (name is "Рагнарёк" or "Инфернальный мастер" or "Инфернум + Мастер/Легенда" or "Рагнарёк + Легенда")
        {
            string textValue2 = CalamityUtils.GetTextValue("UI." + (flag ? "InfernumActive" : "InfernumNotActive"));
            text = CalamityUtils.GetText("UI.DifficultyStatusText").WithFormatArgs(name, textValue2.ToLower());
        }
    }
}