using NodeGames.Core;
using NodeGames.UI.Interfaces;

namespace NodeGames.UI.MonoGame
{
    public abstract class MouseLocator : IMouseLocator
    {
        public Point GetMousePosition()
        {
            var (x, y) = GetMouseCurrentLocation();

            return new Point(x, y);
        }

        protected abstract Microsoft.Xna.Framework.Point GetMouseCurrentLocation();
    }
}