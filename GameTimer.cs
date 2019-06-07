using System;
using Microsoft.Xna.Framework;
using NodeGames.UI.Interfaces;

namespace NodeGames.UI.MonoGame
{
    public class GameTimer : IGameTimer
    {
        private GameTime _gameTime;
        
        public void Update(GameTime gameTime)
        {
            _gameTime = gameTime;
        }
        
        public TimeSpan GetElapsedTime()
        {
            if (_gameTime == null)
                return TimeSpan.Zero;

            return _gameTime.ElapsedGameTime;
        }
    }
}