using NodeGames.Core;
using NodeGames.UI.Interfaces;

namespace NodeGames.UI.MonoGame
{
    public abstract class CameraLocator : ICameraLocator
    {
        public Point GetCameraLocation()
        {
            var (x, y) = GetCameraCurrentLocation();

            return new Point(x, y);
        }

        protected abstract Microsoft.Xna.Framework.Point GetCameraCurrentLocation();
    }
}