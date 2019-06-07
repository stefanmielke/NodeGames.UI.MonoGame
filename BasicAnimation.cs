using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NodeGames.UI.Interfaces;
using Point = NodeGames.Core.Point;

namespace NodeGames.UI.MonoGame
{
    public abstract class BasicAnimation : IBasicAnimation<Color>
    {
        public Point Center { get; }

        protected BasicAnimation(Vector2 center)
        {
            Center = new Point((int) center.X, (int) center.Y);
        }

        protected BasicAnimation(Microsoft.Xna.Framework.Point center)
        {
            Center = new Point(center.X, center.Y);
        }

        protected abstract Texture2D GetCurrentTexture();
        public abstract void Update(TimeSpan getElapsedTime);

        public void Draw(IPainter<Color> painter, Point location)
        {
            var currentTexture = GetCurrentTexture();
            
            var texture = new Texture(currentTexture);
            
            painter.Draw(texture, location, Color.White);
        }

        public void Draw(IPainter<Color> painter, Point location, float scale)
        {
            var currentTexture = GetCurrentTexture();
            
            var texture = new Texture(currentTexture);
            
            painter.Draw(texture, location, scale, Color.White);
        }
    }
}