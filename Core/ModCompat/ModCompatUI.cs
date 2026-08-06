/*using System;
using System.Collections.Generic;
using System.Reflection;
using CalamityRuTranslate.Common.Utilities;
using JAtRT.Core.ModCompat;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI.Chat;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.UI;
using Terraria.UI;

namespace JAtRT.Core.ModCompat;

public readonly struct CompatibilityNotification
{
    public string Text { get; init; }
    public string ModName { get; init; }
}

public class ModCompatUI : UIState
{
    private const int MaxVisible = 3;
    private const float PanelWidth = 700f;
    private const float PanelMinHeight = 180f;
    private const float TextPadding = 14f;
    private const float ButtonHeight = 40f;
    private const float ButtonWidth = 200f;
    private const float ButtonMarginTop = 12f;
    private const float ButtonBottom = 40f;
    private const float PanelGap = 14f;

    private readonly Queue<CompatibilityNotification> _pending = new();
    private readonly List<NotificationPanel> _active = new();

    public void Enqueue(CompatibilityNotification notification)
    {
        _pending.Enqueue(notification);
        TryShowNext();
    }

    public void Enqueue(string text, string modName = "")
        => Enqueue(new CompatibilityNotification { Text = text, ModName = modName });

    public override void OnInitialize() { }

    public override void Draw(SpriteBatch spriteBatch)
    {
        float totalHeight = CalcStackHeight();
        float startY = (Main.screenHeight - totalHeight) / 2f;

        float y = startY;
        foreach (NotificationPanel np in _active)
        {
            np.Panel.Left.Pixels = (Main.screenWidth - np.Panel.Width.Pixels) / 2f;
            np.Panel.Top.Pixels = y;
            np.Panel.Recalculate();
            y += np.Panel.Height.Pixels + PanelGap;
        }

        base.Draw(spriteBatch);
    }

    private void TryShowNext()
    {
        while (_active.Count < MaxVisible && _pending.Count > 0)
            ShowNotification(_pending.Dequeue());

        if (_active.Count == 0 && _pending.Count == 0)
            ModContent.GetInstance<JARTsModCompatibilityChecker>().CompatibilityUIManager.SetState(null);
    }

    private void ShowNotification(CompatibilityNotification notification)
    {
        var np = new NotificationPanel(notification, this);
        _active.Add(np);
        Append(np.Panel);
    }

    internal void ClosePanel(NotificationPanel np)
    {
        _active.Remove(np);
        RemoveChild(np.Panel);
        TryShowNext();
    }

    private float CalcStackHeight()
    {
        float total = 0f;
        for (int i = 0; i < _active.Count; i++)
        {
            total += _active[i].Panel.Height.Pixels;
            if (i < _active.Count - 1)
                total += PanelGap;
        }
        return Math.Max(total, 0f);
    }

    internal sealed class NotificationPanel
    {
        public UIPanel Panel { get; }

        private readonly CompatibilityNotification _notification;
        private readonly ModCompatUI _owner;

        public NotificationPanel(CompatibilityNotification notification, ModCompatUI owner)
        {
            _notification = notification;
            _owner = owner;

            var font = FontAssets.MouseText.Value;
            float lineHeight = font.MeasureString("A").Y;

            float maxLineWidth = 0f;
            foreach (string line in notification.Text.Split('\n'))
            {
                string stripped = StripColorTags(line);
                float w = font.MeasureString(stripped).X;
                if (w > maxLineWidth) maxLineWidth = w;
            }

            float panelWidth = Math.Max(maxLineWidth + TextPadding * 4f, PanelWidth);
            float textHeight = lineHeight * notification.Text.Split('\n').Length;
            float panelHeight = TextPadding + textHeight + ButtonMarginTop + ButtonHeight + ButtonBottom;
            panelHeight = Math.Max(panelHeight, PanelMinHeight);

            Panel = new UIPanel { BackgroundColor = UICommon.MainPanelBackground };
            Panel.Width.Set(panelWidth, 0f);
            Panel.Height.Set(panelHeight, 0f);

            var textElement = new ColoredTextElement(notification.Text, maxLineWidth);
            textElement.Top.Set(TextPadding, 0f);
            textElement.Left.Set(TextPadding, 0f);
            Panel.Append(textElement);

            float buttonTop = panelHeight - ButtonHeight - ButtonBottom;

            Panel.Append(CreateButton("Закрыть и продолжить",
                new Vector2(TextPadding, buttonTop), OnClose));

            Panel.Append(CreateButton("Перейти в браузер модов",
                new Vector2(panelWidth - ButtonWidth - TextPadding * 3f, buttonTop), OnOpenBrowser));
        }

        private static string StripColorTags(string text)
        {
            var sb = new System.Text.StringBuilder(text.Length);
            int i = 0;
            while (i < text.Length)
            {
                if (i + 2 < text.Length && text[i] == '[' && text[i + 1] == 'c' && text[i + 2] == '/')
                {
                    int colon = text.IndexOf(':', i);
                    int close = text.IndexOf(']', colon > -1 ? colon : i);
                    if (colon > -1 && close > colon)
                    {
                        sb.Append(text, colon + 1, close - colon - 1);
                        i = close + 1;
                        continue;
                    }
                }
                sb.Append(text[i]);
                i++;
            }
            return sb.ToString();
        }

        private sealed class ColoredTextElement : UIElement
        {
            private readonly List<List<TextSnippet>> _lines;
            private readonly float _lineHeight;

            public ColoredTextElement(string text, float width)
            {
                var font = FontAssets.MouseText.Value;
                _lineHeight = font.MeasureString("A").Y;
                _lines = new List<List<TextSnippet>>();

                foreach (string line in text.Split('\n'))
                {
                    TextSnippet[] snippets = ChatManager.ParseMessage(line, Color.White).ToArray();
                    ChatManager.ConvertNormalSnippets(snippets);
                    _lines.Add(new List<TextSnippet>(snippets));
                }

                Width.Set(width, 0f);
                Height.Set(_lineHeight * _lines.Count, 0f);
            }

            protected override void DrawSelf(SpriteBatch spriteBatch)
            {
                float x = GetDimensions().X;
                float y = GetDimensions().Y;

                foreach (var line in _lines)
                {
                    ChatManager.DrawColorCodedStringWithShadow(
                        spriteBatch,
                        FontAssets.MouseText.Value,
                        line.ToArray(),
                        new Vector2(x, y),
                        0f, Vector2.Zero, Vector2.One, out _);
                    y += _lineHeight;
                }
            }
        }

        private void OnClose(UIMouseEvent evt, UIElement listeningElement)
        {
            SoundEngine.PlaySound(SoundID.MenuClose);
            _owner.ClosePanel(this);
        }

        private void OnOpenBrowser(UIMouseEvent evt, UIElement listeningElement)
        {
            SoundEngine.PlaySound(SoundID.MenuClose);

            string modName = _notification.ModName;

            Main.RunOnMainThread(() =>
            {
                Main.menuMode = 10;
                Main.gameMenu = true;
                WorldGen.SaveAndQuit();
            });

            Main.OnPostDraw += WaitForMenuTransitionThenOpenBrowser;

            void WaitForMenuTransitionThenOpenBrowser(GameTime _)
            {
                if (Main.menuMode == 10)
                    return;

                Main.OnPostDraw -= WaitForMenuTransitionThenOpenBrowser;
                Main.RunOnMainThread(() =>
                {
                    Main.menuMode = 10007;

                    Assembly tmlAssembly = typeof(ModLoader).Assembly;
                    object modBrowserInstance = tmlAssembly.GetType("Terraria.ModLoader.UI.Interface")
                                                           ?.GetMemberValue<object>("modBrowser");
                    object filterTextBoxInstance = modBrowserInstance?.GetMemberValue<object>("FilterTextBox");
                    filterTextBoxInstance?.SetMemberValue("Text", "");
                    filterTextBoxInstance?.SetMemberValue("Text", modName);
                });
            }
        }

        private static UIButton<string> CreateButton(string text, Vector2 position, MouseEvent clickAction)
        {
            var button = new UIButton<string>(text)
            {
                Width = { Pixels = ButtonWidth },
                Height = { Pixels = ButtonHeight },
                Left = { Pixels = position.X },
                Top = { Pixels = position.Y }
            };
            button.OnLeftClick += clickAction;
            button.OnMouseOver += (_, _) => SoundEngine.PlaySound(SoundID.MenuTick);
            return button;
        }
    }
}
*/