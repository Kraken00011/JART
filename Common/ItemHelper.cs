using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace JAtRT.Common.Utilities;

public enum MatchMode
{
    Equals,
    Contains,
    StartsWith,
    EndsWith
}

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

    private static bool Matches(string value, string pattern, MatchMode mode)
    {
        if (value == null || pattern == null) return false;

        return mode switch
        {
            MatchMode.Contains => value.Contains(pattern, StringComparison.Ordinal),
            MatchMode.StartsWith => value.StartsWith(pattern, StringComparison.Ordinal),
            MatchMode.EndsWith => value.EndsWith(pattern, StringComparison.Ordinal),
            _ => value == pattern
        };
    }

    public static void ReplaceTooltip(List<TooltipLine> tooltips, string mod, string name, string newText = null, string afterMod = null, string afterName = null, string afterText = null,
     MatchMode modMode = MatchMode.Equals, MatchMode nameMode = MatchMode.Equals, MatchMode afterModMode = MatchMode.Equals, MatchMode afterNameMode = MatchMode.Equals, MatchMode afterTextMode = MatchMode.Equals)
    {
        // Все строки, подходящие под описание
        var matchedIndices = new List<int>();
        for (int i = 0; i < tooltips.Count; i++)
        {
            if (Matches(tooltips[i].Name, name, nameMode) && Matches(tooltips[i].Mod, mod, modMode))
                matchedIndices.Add(i);
        }

        if (matchedIndices.Count == 0) return;

        if (newText != null)
        {
            foreach (int i in matchedIndices)
                tooltips[i].Text = newText;
        }

        if (afterMod == null && afterName == null && afterText == null) return;

        var matchedSet = new HashSet<int>(matchedIndices);

        bool IsAnchor(TooltipLine l)
        {
            if (afterMod != null) return Matches(l.Mod, afterMod, afterModMode);
            if (afterName != null) return Matches(l.Name, afterName, afterNameMode);
            return Matches(l.Text, afterText, afterTextMode);
        }

        int targetIndex = -1;
        for (int i = tooltips.Count - 1; i >= 0; i--)
        {
            if (!matchedSet.Contains(i) && IsAnchor(tooltips[i]))
            {
                targetIndex = i;
                break;
            }
        }

        if (targetIndex == -1) return;

        var toMove = matchedIndices.Where(i => i > targetIndex).ToList();
        if (toMove.Count == 0) return;

        var lines = toMove.Select(i => tooltips[i]).ToList();

        for (int i = toMove.Count - 1; i >= 0; i--)
            tooltips.RemoveAt(toMove[i]);

        tooltips.InsertRange(targetIndex + 1, lines);
    }
}