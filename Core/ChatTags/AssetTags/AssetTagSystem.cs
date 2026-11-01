using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Graphics;
using System;
using Terraria.UI.Chat;
using Terraria.ModLoader;

namespace JAtRT.Core.ChatTags.AssetTags
{
    public class AssetTagSystem : ModSystem
    {
        public override void Load()
        {
            ChatManager.Register<AssetTagHandler>("ast");
        }
    }

    public class AssetTagHandler : ITagHandler
    {
        public TextSnippet Parse(string text, Color baseColor = default, string options = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new TextSnippet(string.Empty);

            string ownerName = text.Split('/')[0];

            bool isVanilla = ownerName == "Terraria";
            bool isLoaded  = isVanilla || ModLoader.HasMod(ownerName);

            if (!isLoaded)
                return new TextSnippet(string.Empty);

            try
            {
                var asset = ModContent.Request<Texture2D>(text, AssetRequestMode.ImmediateLoad);

                if (asset != null)
                    return new AssetSnippet(text, asset, baseColor);
            }
            catch { }

            return new TextSnippet(string.Empty);
        }
    }

    public class AssetSnippet : TextSnippet
    {
        private readonly Asset<Texture2D> _asset;

        private const float MaxDisplaySize = 28f;

        public AssetSnippet(string text, Asset<Texture2D> asset, Color color)
            : base(text, color)
        {
            _asset = asset;
        }

        public override bool UniqueDraw(
            bool justCheckingString,
            out Vector2 size,
            SpriteBatch spriteBatch,
            Vector2 position = default,
            Color color = default,
            float scale = 1f)
        {
            if (_asset == null || !_asset.IsLoaded)
            {
                size = Vector2.Zero;
                return true; // true — движок не рисует запасной текст
            }

            Texture2D tex = _asset.Value;
            float drawScale = scale * (MaxDisplaySize / Math.Max(tex.Width, tex.Height));
            size = new Vector2(tex.Width * drawScale, tex.Height * drawScale);

            if (!justCheckingString && spriteBatch != null)
            {
                spriteBatch.Draw(
                    tex,
                    position,
                    sourceRectangle: null,
                    color,
                    rotation: 0f,
                    origin: Vector2.Zero,
                    drawScale,
                    SpriteEffects.None,
                    layerDepth: 0f);
            }

            return true;
        }

        public override float GetStringLength(DynamicSpriteFont font)
        {
            if (_asset == null || !_asset.IsLoaded)
                return 0f;

            Texture2D tex = _asset.Value;
            float drawScale = MaxDisplaySize / Math.Max(tex.Width, tex.Height);
            return tex.Width * drawScale;
        }
    }
}