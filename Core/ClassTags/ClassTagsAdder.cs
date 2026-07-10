using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using JAtRT.Core.Config;

namespace JAtRT.Core.ClassTags
{
    public static class ClassTagsAdder
    {
        public static readonly (string Name, string Text, Color Color)[] Tags;

        static ClassTagsAdder()
        {
            var tags = new List<(string, string, Color)>();

            if (ModLoader.HasMod("ThoriumClassTagsConsistency"))
            {
                tags.Add(("MulticlassTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Multiclass"), new Color(55, 182, 206)));
                tags.Add(("ClasslessTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Classless"), new Color(255, 255, 255)));
                tags.Add(("FishingTag", Language.GetTextValue("Mods.JAtRT.Tags.Special.Fishing"), new Color(102, 255, 255)));
                tags.Add(("MovementTag", Language.GetTextValue("Mods.JAtRT.Tags.Special.Movement"), new Color(144, 238, 144)));
                tags.Add(("SurvivabilityTag", Language.GetTextValue("Mods.JAtRT.Tags.Special.Survivability"), new Color(220, 20, 60)));
                tags.Add(("ToolTag", Language.GetTextValue("Mods.JAtRT.Tags.Special.Tool"), new Color(224, 255, 255)));
                tags.Add(("MiningTag", Language.GetTextValue("Mods.JAtRT.Tags.Special.Mining"), new Color(224, 255, 255)));
                
                tags.Add(("WarriorTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Warrior"), new Color(229, 25, 25)));
                tags.Add(("RangerTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Ranger"), new Color(0, 170, 56)));
                tags.Add(("SorcererTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Sorcerer"), new Color(14, 129, 244)));
                tags.Add(("SummonerTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Summoner"), new Color(248, 112, 190)));
                tags.Add(("ThrowerTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Thrower"), new Color(255, 165, 60)));

                if (ModLoader.HasMod("CalamityMod"))
                {
                    tags.Add(("TrueWarriorTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.TrueWarrior"), new Color(229, 25, 25)));
                    tags.Add(("RogueTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Rogue"), new Color(255, 137, 0)));
                }

                if (ModLoader.HasMod("ThoriumMod"))
                {
                    tags.Add(("HealerTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Healer"), new Color(255, 255, 91)));
                    tags.Add(("DarkHealerTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Healer"), new Color(178, 102, 255)));
                    tags.Add(("BardTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Bard"), new Color(0, 255, 128)));
                    tags.Add(("TransformationTag", Language.GetTextValue("Mods.JAtRT.Tags.Special.Transformation"), new Color(200, 175, 120)));
                    tags.Add(("OmniShieldTag", Language.GetTextValue("Mods.JAtRT.Tags.Special.OmniShield"), new Color(102, 255, 255)));
                }

                if (ModLoader.HasMod("Split"))
                    tags.Add(("HeavyWarriorTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.HeavyWarrior"), new Color(229, 25, 25)));

                if (ModLoader.HasMod("SOTS"))
                    tags.Add(("VoidTag", Language.GetTextValue("Mods.JAtRT.Tags.Special.Void"), new Color(153, 50, 204)));

                if (ModLoader.HasMod("Redemption"))
                    tags.Add(("RitualistTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Ritualist"), new Color(255, 69, 0)));

                if (ModLoader.HasMod("DemolisherClass"))
                    tags.Add(("DemolisherTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Demolisher"), new Color(246, 0, 24)));

                if (ModLoader.HasMod("RoA"))
                    tags.Add(("DruidTag", Language.GetTextValue("Mods.JAtRT.Tags.Class.Druid"), new Color(34, 139, 34)));
            }

            Tags = tags.ToArray();
        }

        public static void AddTag(Mod mod, List<TooltipLine> tooltips, string tagName)
        {
            if (!JARTClientCfg.Instance.ExtraClassTags) return;

            (string Name, string Text, Color Color) tag = default;
            foreach (var t in Tags)
            {
                if (t.Name == tagName) { tag = t; break; }
            }
            if (tag == default) return;

            int index = tooltips.FindIndex(l => l.Mod.Equals("Terraria") && l.Name.Equals("ItemName"));

            if (index != -1)
            {
                tooltips.Insert(index + 1, new TooltipLine(mod, tag.Name, tag.Text)
                {
                    OverrideColor = tag.Color
                });
            }
        }

        public static void AddTags(Mod mod, List<TooltipLine> tooltips, params string[] tagNames)
        {
            for (int i = tagNames.Length - 1; i >= 0; i--)
                AddTag(mod, tooltips, tagNames[i]);
        }

        public static void RemoveTag(List<TooltipLine> tooltips, string tagName, string modName)
        {
            tooltips.RemoveAll(l => l.Name.Equals(tagName) && l.Mod.Equals(modName));
        }

        public static void RemoveTags(List<TooltipLine> tooltips, params (string TagName, string ModName)[] tags)
        {
            foreach (var (tagName, modName) in tags)
                RemoveTag(tooltips, tagName, modName);
        }
    }
}