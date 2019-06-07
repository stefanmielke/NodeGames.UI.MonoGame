using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NodeGames.Core;
using NodeGames.UI.Interfaces;
using Point = NodeGames.Core.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace NodeGames.UI.MonoGame
{
    public abstract class Painter : IPainter<Color>
    {
        private readonly SpriteBatch _spriteBatch;
        private Dictionary<FontSize, SpriteFont> _fonts;
        private Texture2D _whitePixelTexture;
        private readonly List<DrawLineStruct> _drawLineStructs;

        protected abstract Dictionary<FontSize, SpriteFont> GetAllFonts();

        public Painter(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _drawLineStructs = new List<DrawLineStruct>();
        }

        public void Init(GraphicsDevice graphicsDevice)
        {
            LoadFonts();

            _whitePixelTexture = new Texture2D(graphicsDevice, 1, 1);
            _whitePixelTexture.SetData(new[] {Color.White});
        }

        public void DrawBatchCommands()
        {
            if (_drawLineStructs.Count > 0)
            {
                foreach (var line in _drawLineStructs)
                {
                    _spriteBatch.Draw(_whitePixelTexture,
                        new Rectangle((int) line.Start.X, (int) line.Start.Y, line.Length, 1), null, line.Color,
                        line.Angle, Vector2.Zero, SpriteEffects.None, 0);
                }

                _drawLineStructs.Clear();
            }
        }

        private void LoadFonts()
        {
            var fonts = GetAllFonts();
            _fonts = fonts;
        }

        public Point GetTextSize(FontSize fontSize, string text)
        {
            var size = _fonts[fontSize].MeasureString(text);

            return new Point((int) size.X, (int) size.Y);
        }

        public void DrawString(string text, FontSize fontSize, Point location, Color color)
        {
            var drawPosition = new Vector2(location.X, location.Y);

            _spriteBatch.DrawString(_fonts[fontSize], text, drawPosition, color);
        }

        public void Draw(ITexture2D texture, Point location)
        {
            Draw(texture, location, Color.White);
        }

        public void Draw(ITexture2D texture, Point location, Color color)
        {
            var gameTexture = (Texture) texture;

            _spriteBatch.Draw(gameTexture.Texture2D, new Vector2(location.X, location.Y), color);
        }

        public void Draw(ITexture2D texture, Point location, float scale, Color color)
        {
            var gameTexture = (Texture) texture;

            _spriteBatch.Draw(gameTexture.Texture2D, new Vector2(location.X, location.Y), null, color, 0, Vector2.Zero,
                scale, SpriteEffects.None, 0);
        }

        public void DrawRectangle(Point location, Point size, Color color)
        {
            _spriteBatch.Draw(_whitePixelTexture, new Rectangle(location.X, location.Y, size.X, size.Y), color);
        }

        public void DrawRectangleOutline(Point location, Point size, Color color, int thickness = 1)
        {
            _spriteBatch.Draw(_whitePixelTexture, new Rectangle(location.X, location.Y, size.X, thickness), null, color,
                0, Vector2.Zero, SpriteEffects.None, 0);
            _spriteBatch.Draw(_whitePixelTexture, new Rectangle(location.X, location.Y, thickness, size.Y), null, color,
                0, Vector2.Zero, SpriteEffects.None, 0);
            _spriteBatch.Draw(_whitePixelTexture,
                new Rectangle(location.X + size.X - thickness, location.Y, thickness, size.Y), null, color, 0,
                Vector2.Zero, SpriteEffects.None, 0);
            _spriteBatch.Draw(_whitePixelTexture,
                new Rectangle(location.X, location.Y + size.Y - thickness, size.X, thickness), null, color, 0,
                Vector2.Zero, SpriteEffects.None, 0);
        }

        public void DrawLineImmediate(Point start, int length, float angle, Color color)
        {
            _spriteBatch.Draw(_whitePixelTexture, new Rectangle(start.X, start.Y, length, 1), null, color, angle,
                Vector2.Zero, SpriteEffects.None, 0);
        }

        public void DrawLine(float x1, float y1, float x2, float y2, Color color)
        {
            _drawLineStructs.Add(new DrawLineStruct(new Vector2(x1, y1), new Vector2(x2, y2), color));
        }

        private struct DrawLineStruct
        {
            public readonly Vector2 Start;
            public readonly Color Color;
            public readonly int Length;
            public readonly float Angle;

            public DrawLineStruct(Vector2 start, Vector2 finish, Color color)
            {
                Start = start;
                Color = color;
                Length = (int) Vector2.Distance(start, finish);
                Angle = GetRadiansAngleFromTwoPoints(start, finish);
            }

            private static float GetRadiansAngleFromTwoPoints(Vector2 from, Vector2 to)
            {
                return MathHelper.ToRadians(GetDegreesAngleFromTwoPoints(from, to));
            }

            private static float GetDegreesAngleFromTwoPoints(Vector2 from, Vector2 to)
            {
                var xDiff = to.X - from.X;
                var yDiff = to.Y - from.Y;

                return (float) (Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI);
            }
        }
    }
}