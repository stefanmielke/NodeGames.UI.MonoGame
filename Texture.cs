using Microsoft.Xna.Framework.Graphics;
using NodeGames.UI.Interfaces;

namespace NodeGames.UI.MonoGame
{
    public class Texture : ITexture2D
    {
        public Texture2D Texture2D { get; }

        public Texture(Texture2D texture)
        {
            Texture2D = texture;
        }
    }
}