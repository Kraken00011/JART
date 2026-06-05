using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace JAtRT.Common.Utilities;

public static class ItemHelper
{
    public static void TranslateTooltip(List<TooltipLine> tooltips, string lineName, Action<TooltipLine> action)
    {
        ApplyTooltipEdits(tooltips, tooltipLine => tooltipLine.Name == lineName, action);
    }

    public static void TranslateTooltip(List<TooltipLine> tooltips, Func<TooltipLine, bool> predicate, Action<TooltipLine> action)
    {
        ApplyTooltipEdits(tooltips, predicate, action);
    }

    private static void ApplyTooltipEdits(List<TooltipLine> lines, Func<TooltipLine, bool> predicate, Action<TooltipLine> action)
    {
        foreach (var line in lines.Where(predicate))
            if (line != null)
                action(line);
    }

    public static void ReplaceTooltip(List<TooltipLine> tooltips, string mod, string name, string newText = null, string afterMod = null, string afterName = null, string afterText = null, bool useContains = false, bool useStartsWith = false)
    {
        int index = tooltips.FindIndex(l => l.Name == name && l.Mod == mod);
        if (index == -1) return;

        if (newText != null)
            tooltips[index].Text = newText;

        int targetIndex = -1;

        if (afterMod != null)
            targetIndex = tooltips.FindLastIndex(l => l.Mod == afterMod);
        else if (afterName != null)
            targetIndex = tooltips.FindLastIndex(l => l.Name == afterName);
        else if (afterText != null)
        {
            if (useContains)
                targetIndex = tooltips.FindLastIndex(l => l.Text.Contains(afterText));
            else if (useStartsWith)
                targetIndex = tooltips.FindLastIndex(l => l.Text.StartsWith(afterText));
            else
                targetIndex = tooltips.FindLastIndex(l => l.Text == afterText);
        }

        if (targetIndex != -1 && targetIndex < index)
        {
            var line = tooltips[index];
            tooltips.RemoveAt(index);
            tooltips.Insert(targetIndex + 1, line);
        }
    }
}