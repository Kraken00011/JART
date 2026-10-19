using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace JAtRT.Core
{
    public enum BuffSide
    {
        Enemy,   // тег для врага [jbuff:]
        Player   // тег для игрока [jbuffplr:]
    }

    public static class BuffInfoRegistry
    {
        public sealed class Entry
        {
            public Color? Color;
            public string DescriptionKey;
            public List<(Func<bool> condition, string key)> Variants = new();
            public HashSet<string> IgnoredColorMods = new();
        }

        private static readonly Dictionary<string, Entry> Entries = new();
        public static readonly List<(string modName, Func<int, Color?> provider)> ModColorProviders = new();

        public static void RegisterColorProvider(string modName, Func<int, Color?> provider)
            => ModColorProviders.Add((modName, provider));

        public static Color DefaultColor = new(230, 202, 250);

        public static string NameOpen = "«";
        public static string NameClose = "»";

        public static float IconGapMultiplier = 0.5f;

        public static readonly List<BuffInfoModule> Modules = new();

        public static void Clear()
        {
            Entries.Clear();
            ItemEntries.Clear();
            ModColorProviders.Clear();
            Modules.Clear();
        }

        // подпись принадлежности в развёрнутом описании
        public static string SideEnemyText = "(На враге)";
        public static string SidePlayerText = "(На игроке)";

        // суффиксы ключей по принадлежности (ItemTooltipEnemy / ItemTooltipPlayer)
        public static string SideKeySuffix(BuffSide side) => side == BuffSide.Player ? "Player" : "Enemy";
        public static string SideLabel(BuffSide side) => side == BuffSide.Player ? SidePlayerText : SideEnemyText;

        // псевдонимы модов для суффикса ключа (ItemTooltipEnemyCalamity вместо ItemTooltipEnemyCalamityMod)
        public static readonly Dictionary<string, string> ModSuffixAliases = new()
        {
            ["CalamityMod"] = "Calamity",
        };

        // если установлено несколько модов с вариантами — выигрывает тот, что выше в списке.
        public static readonly List<string> ModPriority = new() { "CalamityMod" };

        public static string FullName(int buffId)
        {
            if (buffId < BuffID.Count)
                return "Terraria/" + BuffID.Search.GetName(buffId);
            var b = BuffLoader.GetBuff(buffId);
            return b.Mod.Name + "/" + b.Name;
        }

        private static Entry Get(string fullName)
        {
            if (!Entries.TryGetValue(fullName, out var e))
                Entries[fullName] = e = new Entry();
            return e;
        }

        private static Entry Find(int buffId)
            => Entries.TryGetValue(FullName(buffId), out var e) ? e : null;

        // регистрация баффов
        public static Entry Register(int vanillaBuffId, Color? color = null, string descriptionKey = null)
            => Register("Terraria", BuffID.Search.GetName(vanillaBuffId), color, descriptionKey);
        // для ванильного баффа ^

        public static Entry Register(string modName, string buffName, Color? color = null, string descriptionKey = null)
        {
            var e = Get(modName + "/" + buffName);
            e.Color = color ?? e.Color;
            e.DescriptionKey = descriptionKey ?? e.DescriptionKey;
            return e;
        }
        // для модового ^

        public static Entry WhenModLoaded(this Entry e, string modName, string key)
        {
            e.Variants.Add((() => ModLoader.HasMod(modName), key));
            return e;
        }

        public static Entry When(this Entry e, Func<bool> condition, string key)
        {
            e.Variants.Add((condition, key));
            return e;
        }

        public static Entry IgnoreColorFrom(this Entry e, string modName)
        {
            e.IgnoredColorMods.Add(modName);
            return e;
        }

        public sealed class ItemEntry
        {
            internal readonly List<(string mod, string name, BuffSide side)> Buffs = new();

            // Один или несколько ванильных баффов: .Enemy(BuffID.Poisoned, BuffID.OnFire)
            public ItemEntry Enemy(params int[] vanillaBuffIds) => AddVanilla(BuffSide.Enemy, vanillaBuffIds);
            public ItemEntry Player(params int[] vanillaBuffIds) => AddVanilla(BuffSide.Player, vanillaBuffIds);

            // Один бафф мода: .Enemy("CalamityMod", "Plague")
            public ItemEntry Enemy(string modName, string buffName) => Add(modName, buffName, BuffSide.Enemy);
            public ItemEntry Player(string modName, string buffName) => Add(modName, buffName, BuffSide.Player);

            // Несколько баффов модов: .Enemy(("CalamityMod", "Plague"), ("CalamityMod", "Nightwither"))
            public ItemEntry Enemy(params (string mod, string name)[] buffs) => AddMany(BuffSide.Enemy, buffs);
            public ItemEntry Player(params (string mod, string name)[] buffs) => AddMany(BuffSide.Player, buffs);

            private ItemEntry AddVanilla(BuffSide side, int[] ids)
            {
                foreach (int id in ids)
                    Add("Terraria", BuffID.Search.GetName(id), side);
                return this;
            }

            private ItemEntry AddMany(BuffSide side, (string mod, string name)[] buffs)
            {
                foreach (var (mod, name) in buffs)
                    Add(mod, name, side);
                return this;
            }

            private ItemEntry Add(string mod, string name, BuffSide side)
            {
                Buffs.Add((mod, name, side));
                return this;
            }
        }

        private static readonly Dictionary<string, ItemEntry> ItemEntries = new();

        // ванильный предмет
        // пример: RegisterItem(ItemID.CopperShortsword).Enemy(BuffID.Poisoned)
        public static ItemEntry RegisterItem(int vanillaItemId)
            => RegisterItem("Terraria", ItemID.Search.GetName(vanillaItemId));

        // предмет любого мода
        // пример: RegisterItem("CalamityMod", "Murasama").Enemy("CalamityMod", "Какой-то дебафф")
        public static ItemEntry RegisterItem(string modName, string itemName)
        {
            string key = modName + "/" + itemName;
            if (!ItemEntries.TryGetValue(key, out var e))
                ItemEntries[key] = e = new ItemEntry();
            return e;
        }

        public static IEnumerable<(int id, BuffSide side)> GetItemBuffs(Item item)
        {
            string key = item.ModItem != null
                ? item.ModItem.Mod.Name + "/" + item.ModItem.Name
                : item.type > ItemID.None && item.type < ItemID.Count ? "Terraria/" + ItemID.Search.GetName(item.type) : null;

            if (key == null || !ItemEntries.TryGetValue(key, out var entry))
                yield break;

            foreach (var (mod, name, side) in entry.Buffs)
                if (TryResolveBuff(mod, name, out int id))
                    yield return (id, side);
        }

        private static bool TryResolveBuff(string mod, string name, out int id)
        {
            id = 0;
            if (mod == "Terraria")
                return BuffID.Search.TryGetId(name, out id);
            if (ModContent.TryFind<ModBuff>(mod, name, out var mb))
            {
                id = mb.Type;
                return true;
            }
            return false;
        }

        // данные
        public static Color ResolveColor(int buffId)
        {
            var e = Find(buffId);

            // 1) Цвет установленного мода применяется всегда, если бафф его не игнорирует.
            foreach (var (modName, provider) in ModColorProviders)
            {
                if (!ModLoader.HasMod(modName) || (e != null && e.IgnoredColorMods.Contains(modName)))
                    continue;
                var c = provider(buffId);
                if (c.HasValue)
                    return c.Value;
            }

            // 2) Собственный цвет записи.
            if (e?.Color != null)
                return e.Color.Value;

            // 3) IBuffInfo на самом ModBuff.
            if (buffId >= BuffID.Count && BuffLoader.GetBuff(buffId) is IBuffInfo info && info.InfoColor.HasValue)
                return info.InfoColor.Value;

            return DefaultColor;
        }

        public static string ResolveDescription(int buffId, BuffSide side)
        {
            var e = Find(buffId);
            string full = FullName(buffId);
            string sideSuf = SideKeySuffix(side);

            if (e != null)
                foreach (var (cond, key) in e.Variants)
                {
                    if (!cond())
                        continue;
                    if (HasText(key + sideSuf))
                        return Language.GetTextValue(key + sideSuf);
                    if (HasText(key))
                        return Language.GetTextValue(key);
                }

            var bases = new List<string>();
            if (e?.DescriptionKey != null) bases.Add(e.DescriptionKey);
            bases.Add($"Mods.JAtRT.BuffInfo.{full.Replace('/', '.')}.ItemTooltip");
            bases.Add(OriginalKey(buffId));

            var suffixes = InstalledSuffixes().ToList();

            foreach (string b in bases)
            {
                foreach (string suf in suffixes)
                    if (HasText(b + sideSuf + suf))
                        return Language.GetTextValue(b + sideSuf + suf);

                if (HasText(b + sideSuf))
                    return Language.GetTextValue(b + sideSuf);

                foreach (string suf in suffixes)
                    if (HasText(b + suf))
                        return Language.GetTextValue(b + suf);

                if (HasText(b))
                    return Language.GetTextValue(b);
            }
            return null;
        }

        private static IEnumerable<string> InstalledSuffixes()
        {
            var names = ModLoader.Mods.Select(m => m.Name).ToList();
            var ordered = ModPriority.Where(names.Contains).Concat(names.Where(n => !ModPriority.Contains(n)));
            foreach (var n in ordered)
                yield return ModSuffixAliases.TryGetValue(n, out var alias) ? alias : n;
        }

        public static string OriginalKey(int buffId)
        {
            if (buffId < BuffID.Count)
                return $"Mods.Terraria.Buffs.{BuffID.Search.GetName(buffId)}.ItemTooltip";
            var b = BuffLoader.GetBuff(buffId);
            return $"Mods.{b.Mod.Name}.Buffs.{b.Name}.ItemTooltip";
        }

        private static bool HasText(string key)
            => !string.IsNullOrEmpty(key) && Language.Exists(key) && !string.IsNullOrWhiteSpace(Language.GetTextValue(key));
    }

    public interface IBuffInfo
    {
        Color? InfoColor { get; }
    }

    public abstract class BuffInfoModule : ILoadable
    {
        public abstract string ModName { get; }

        public bool IsActive => ModName == null || ModName == "Terraria" || ModLoader.HasMod(ModName);

        /// Здесь регистрируются и баффы (Register), и предметы (RegisterItem) этого мода.
        public abstract void Register();

        void ILoadable.Load(Mod mod) => BuffInfoRegistry.Modules.Add(this);
        void ILoadable.Unload() { }
    }

    public class BuffInfoSetup : ModSystem
    {
        public override void PostSetupContent()
        {
            foreach (var module in BuffInfoRegistry.Modules)
                if (module.IsActive)
                    module.Register();
        }

        public override void Unload() => BuffInfoRegistry.Clear();
    }

    public sealed class BuffSnippet : TextSnippet
    {
        private const float IconSize = 26f;

        public int BuffId { get; }
        public BuffSide Side { get; }
        public bool ShowSide { get; }

        public string CustomName { get; }

        /// true — только иконка, без названия и «ёлочек» (в теге после второго двоеточия пусто).
        public bool HideName { get; }

        public BuffSnippet(int buffId, BuffSide side, bool showSide, string customName = null) : base("")
        {
            // customName == null      -> нет второго двоеточия: обычное название
            // customName пустой/пробелы -> двоеточие есть, но текста нет: название скрыто
            HideName = customName != null && string.IsNullOrWhiteSpace(customName);
            CustomName = string.IsNullOrWhiteSpace(customName) ? null : customName.Trim();
            BuffId = buffId;
            Side = side;
            ShowSide = showSide;
            CheckForHover = false;
        }

        private static float IconGap(DynamicSpriteFont font) => font.MeasureString(" ").X * BuffInfoRegistry.IconGapMultiplier;

        private string DisplayName
            => HideName
                ? ""
                : BuffInfoRegistry.NameOpen + (CustomName ?? Lang.GetBuffName(BuffId)) + BuffInfoRegistry.NameClose;

        // Только иконка: отступ IconGapMultiplier с обеих сторон иконки (слева — только в этом режиме).
        private float LeftPad(DynamicSpriteFont font) => HideName ? IconGap(font) : 0f;

        private string SideText => ShowSide ? (HideName ? "" : " ") + BuffInfoRegistry.SideLabel(Side) : "";

        public override bool UniqueDraw(bool justCheckingString, out Vector2 size, SpriteBatch spriteBatch,
            Vector2 position = default, Color color = default, float scale = 1f)
        {
            var font = FontAssets.MouseText.Value;
            size = new Vector2(GetStringLength(font), IconSize);

            if (!justCheckingString && (color.R != 0 || color.G != 0 || color.B != 0))
            {
                position.X += LeftPad(font) * scale;

                if (!Main.dedServ)
                {
                    var tex = TextureAssets.Buff[BuffId].Value;
                    spriteBatch.Draw(tex, new Rectangle((int)position.X, (int)position.Y - 2, (int)IconSize, (int)IconSize), Color.White);
                }
                position.X += IconSize + IconGap(font) * scale;

                ChatManager.DrawColorCodedStringWithShadow(spriteBatch, font,
                    DisplayName, position, BuffInfoRegistry.ResolveColor(BuffId), 0f, Vector2.Zero, new Vector2(scale));

                if (ShowSide)
                {
                    position.X += font.MeasureString(DisplayName).X * scale;
                    ChatManager.DrawColorCodedStringWithShadow(spriteBatch, font,
                        SideText, position, Color.White, 0f, Vector2.Zero, new Vector2(scale));
                }
            }
            return true;
        }

        public override float GetStringLength(DynamicSpriteFont font)
            => (LeftPad(font) + IconSize + IconGap(font) + font.MeasureString(DisplayName + SideText).X) * Scale;
    }

    internal static class BuffTagParser
    {
        //  [jbuff:бафф] или [jbuff:бафф:кастомное название], где Бафф это внутренне название баффа или если из мода, то Внут. назв. мода/Бафф.
        public static TextSnippet Parse(string text, BuffSide side, string options, Color baseColor)
        {
            bool showSide = options != null && options.Contains("side");

            string customName = null;
            int colon = text.IndexOf(':');
            if (colon >= 0)
            {
                customName = text.Substring(colon + 1);
                text = text.Substring(0, colon);
            }
            text = text.Trim();

            if (int.TryParse(text, out int id) && id > 0 && id < BuffLoader.BuffCount)
                return new BuffSnippet(id, side, showSide, customName);

            if (BuffID.Search.TryGetId(text, out id))
                return new BuffSnippet(id, side, showSide, customName);

            var parts = text.Split('/');
            if (parts.Length == 2 && ModContent.TryFind<ModBuff>(parts[0], parts[1], out var mb))
                return new BuffSnippet(mb.Type, side, showSide, customName);

            // Бафф не найден (например, мод не установлен):
            //  - есть название после второго двоеточия  -> «Название» (без иконки, цвет по умолчанию)
            //  - двоеточие есть, но название пустое     -> ничего не показываем
            //  - второго двоеточия нет                  -> как раньше: исходный текст ("Мод/Бафф")
            if (customName != null)
            {
                customName = customName.Trim();
                return customName.Length == 0
                    ? new TextSnippet("")
                    : new TextSnippet(BuffInfoRegistry.NameOpen + customName + BuffInfoRegistry.NameClose, baseColor);
            }

            return new TextSnippet(text, baseColor);
        }
    }

    // [jbuff] - на враге
    public sealed class BuffTagHandler : ITagHandler, ILoadable
    {
        public void Load(Mod mod) => ChatManager.Register<BuffTagHandler>("jbuff");
        public void Unload() { }

        public TextSnippet Parse(string text, Color baseColor = default, string options = null)
            => BuffTagParser.Parse(text, BuffSide.Enemy, options, baseColor);
    }

    // [jbuffplr] - на игроке
    public sealed class PlayerBuffTagHandler : ITagHandler, ILoadable
    {
        public void Load(Mod mod) => ChatManager.Register<PlayerBuffTagHandler>("jbuffplr");
        public void Unload() { }

        public TextSnippet Parse(string text, Color baseColor = default, string options = null)
            => BuffTagParser.Parse(text, BuffSide.Player, options, baseColor);
    }

    // тултипчики
    public class BuffInfoTooltips : GlobalItem
    {
        public static bool HideBaseTextWhenExpanded = true;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            var buffs = new List<(int id, BuffSide side)>();

            // Баффы из тегов в тексте тултипа
            foreach (var line in tooltips)
            {
                if (!line.Text.Contains("[jbuff"))
                    continue;
                foreach (var s in ChatManager.ParseMessage(line.Text, Color.White))
                    if (s is BuffSnippet bs && !buffs.Contains((bs.BuffId, bs.Side)))
                        buffs.Add((bs.BuffId, bs.Side));
            }

            // Баффы, зарегистрированные для предмета в коде (без тега)
            foreach (var reg in BuffInfoRegistry.GetItemBuffs(item))
                if (!buffs.Contains(reg))
                    buffs.Add(reg);

            if (buffs.Count == 0)
                return;

            var described = buffs
                .Select(b => (b.id, b.side, text: BuffInfoRegistry.ResolveDescription(b.id, b.side)))
                .Where(x => x.text != null)
                .ToList();
            if (described.Count == 0)
                return;

            if (!PlayerInput.Triggers.Current.SmartCursor)
            {
                tooltips.Add(new TooltipLine(Mod, "BuffHint", $"Удерживайте {GetKeyName()} для просмотра информации о дебаффах")
                {
                    OverrideColor = new Color(170, 170, 170)
                });
                return;
            }

            if (HideBaseTextWhenExpanded)
                foreach (var t in tooltips)
                    if (t.Name.StartsWith("Tooltip"))
                        t.Hide();

            foreach (var (id, side, text) in described)
            {
                string tag = side == BuffSide.Player ? "jbuffplr" : "jbuff";
                tooltips.Add(new TooltipLine(Mod, $"BuffExpand{id}_{side}", $"[{tag}/side:{id}]\n{text}"));
            }
        }

        private static string GetKeyName()
        {
            try { return PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard].KeyStatus["SmartCursor"].First().ToString(); }
            catch { return "Smart Cursor"; }
        }
    }
}