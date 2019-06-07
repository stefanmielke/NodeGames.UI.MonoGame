using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using NodeGames.UI.Interfaces;

namespace NodeGames.UI.MonoGame
{
    public abstract class Input : IInput
    {
        public bool IsInTextMode { get; set; }

        public abstract KeyboardState GetCurrentKeyboardPressedState();
        public abstract KeyboardState GetCurrentKeyboardState();

        private readonly StringBuilder _enteredText;

        protected Input()
        {
            _enteredText = new StringBuilder(5);
        }

        public IEnumerable<char> GetEnteredText()
        {
            var pressedState = GetCurrentKeyboardPressedState();
            var allstate = GetCurrentKeyboardState();

            var pressedKeys = pressedState.GetPressedKeys();
            if (pressedKeys.Length == 0)
                return Enumerable.Empty<char>();

            _enteredText.Clear();
            foreach (var key in pressedKeys)
            {
                switch (key)
                {
                    case Keys.A:
                    case Keys.B:
                    case Keys.C:
                    case Keys.D:
                    case Keys.E:
                    case Keys.F:
                    case Keys.G:
                    case Keys.H:
                    case Keys.I:
                    case Keys.J:
                    case Keys.K:
                    case Keys.L:
                    case Keys.M:
                    case Keys.N:
                    case Keys.O:
                    case Keys.P:
                    case Keys.Q:
                    case Keys.R:
                    case Keys.S:
                    case Keys.T:
                    case Keys.U:
                    case Keys.V:
                    case Keys.W:
                    case Keys.X:
                    case Keys.Y:
                    case Keys.Z:
                        if (allstate.IsKeyDown(Keys.LeftShift) || allstate.IsKeyDown(Keys.RightShift) ||
                            allstate.IsKeyDown(Keys.CapsLock))
                            _enteredText.Append(key.ToString());
                        else
                            _enteredText.Append(key.ToString().ToLower());
                        break;
                    case Keys.NumPad0:
                    case Keys.D0:
                        _enteredText.Append("0");
                        break;
                    case Keys.NumPad1:
                    case Keys.D1:
                        _enteredText.Append("1");
                        break;
                    case Keys.NumPad2:
                    case Keys.D2:
                        _enteredText.Append("2");
                        break;
                    case Keys.NumPad3:
                    case Keys.D3:
                        _enteredText.Append("3");
                        break;
                    case Keys.NumPad4:
                    case Keys.D4:
                        _enteredText.Append("4");
                        break;
                    case Keys.NumPad5:
                    case Keys.D5:
                        _enteredText.Append("5");
                        break;
                    case Keys.NumPad6:
                    case Keys.D6:
                        _enteredText.Append("6");
                        break;
                    case Keys.NumPad7:
                    case Keys.D7:
                        _enteredText.Append("7");
                        break;
                    case Keys.NumPad8:
                    case Keys.D8:
                        _enteredText.Append("8");
                        break;
                    case Keys.NumPad9:
                    case Keys.D9:
                        _enteredText.Append("9");
                        break;
                    case Keys.Space:
                        _enteredText.Append(" ");
                        break;
                }
            }

            return _enteredText.ToString();
        }

        public bool HasPressedEndTextKey()
        {
            var pressedState = GetCurrentKeyboardPressedState();
            
            return pressedState.GetPressedKeys().Any(key => key == Keys.Enter || key == Keys.Escape);
        }

        public bool HasPressedEraseTextKey()
        {
            var pressedState = GetCurrentKeyboardPressedState();
            return pressedState.GetPressedKeys().Any(key => key == Keys.Back);
        }

        public void EnterTextMode()
        {
            IsInTextMode = true;
        }

        public void ExitTextMode()
        {
            IsInTextMode = false;
        }
    }
}