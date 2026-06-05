using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using JAtRT.Common.Utilities;
using JAtRT.Common;
using JAtRT.Core.Config;

namespace JAtRT.Core.ClassTags
{
    public class ClassTagMapSystem : ModSystem
    {
        public override void OnModLoad()
        {
            ClassTagsAdderHelper.ClassTagGlobalItem.InvalidateCache();
        }
    }
    public static class ClassTagsAdderHelper
    {
        public static List<(int, string)> GetTaggedItems(string[] items, string tagName, string modName)
        {
            return TranslationHelper.GetItemTypesFromMod(items, modName)
                .Select(type => (type, tagName))
                .ToList();
        }

        public static List<(int, string, string)> GetTaggedItems(string[] items, string tagName, string modName, string tagModName)
        {
            return TranslationHelper.GetItemTypesFromMod(items, modName)
                .Select(type => (type, tagName, tagModName))
                .ToList();
        }

        public class ClassTagGlobalItem : GlobalItem
        {
            private static Dictionary<int, List<string>> _tagMap;
            private static Dictionary<int, List<(string TagName, string ModName)>> _removeMap;

            public static void InvalidateCache()
            {
                _tagMap = null;
                _removeMap = null;
            }

            private static Dictionary<int, List<string>> TagMap
            {
                get
                {
                    if (_tagMap != null) return _tagMap;
                    _tagMap = new Dictionary<int, List<string>>();

                    foreach (var type in typeof(ClassTagGlobalItem).Assembly.GetTypes())
                    {
                        if (!typeof(ItemTagsAdder).IsAssignableFrom(type) || type.IsInterface || type.IsAbstract) continue;

                        var instance = (ItemTagsAdder)Activator.CreateInstance(type);
                        if (!instance.IsEnabled) continue;

                        foreach (var (itemType, tagName) in instance.TaggedItems)
                        {
                            if (!_tagMap.ContainsKey(itemType))
                                _tagMap[itemType] = new List<string>();

                            if (!_tagMap[itemType].Contains(tagName))
                                _tagMap[itemType].Add(tagName);
                        }
                    }

                    return _tagMap;
                }
            }

            private static Dictionary<int, List<(string TagName, string ModName)>> RemoveMap
            {
                get
                {
                    if (_removeMap != null) return _removeMap;
                    _removeMap = new Dictionary<int, List<(string, string)>>();

                    foreach (var type in typeof(ClassTagGlobalItem).Assembly.GetTypes())
                    {
                        if (!typeof(ItemTagsRemover).IsAssignableFrom(type) || type.IsInterface || type.IsAbstract) continue;

                        var instance = (ItemTagsRemover)Activator.CreateInstance(type);
                        if (!instance.IsEnabled) continue;

                        foreach (var (itemType, tagName, modName) in instance.RemovedItems)
                        {
                            if (!_removeMap.ContainsKey(itemType))
                                _removeMap[itemType] = new List<(string, string)>();

                            if (!_removeMap[itemType].Contains((tagName, modName)))
                                _removeMap[itemType].Add((tagName, modName));
                        }
                    }

                    return _removeMap;
                }
            }

            public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
            {
                if (TagMap.TryGetValue(item.type, out var tagNames))
                    ClassTagsAdder.AddTags(Mod, tooltips, tagNames.ToArray());

                if (RemoveMap.TryGetValue(item.type, out var removePairs))
                    ClassTagsAdder.RemoveTags(tooltips, removePairs.ToArray());
            }
        }
    }
}