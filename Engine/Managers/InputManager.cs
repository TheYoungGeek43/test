using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine.Managers
{
    public class InputManager
    {
        private KeyboardState keyboard;
        private KeyboardState oldKeyboard;
        private MouseState mouse;
        private MouseState oldMouse;
        /*private GamePadState gamePad;
        private GamePadState oldGamePad;*/

        public InputManager(KeyboardState keyboard, KeyboardState oldKeyboard, MouseState mouse, MouseState oldMouse/*, GamePadState gamePad, GamePadState oldGamePad*/)
        {
            this.keyboard = keyboard;
            this.oldKeyboard = oldKeyboard;
            this.mouse = mouse;
            this.oldMouse = oldMouse;
            /*this.gamePad = gamePad;
            this.oldGamePad = oldGamePad;*/
        }

        public bool IsKeyPressedContinu(Keys key)
        {
            return this.keyboard.IsKeyDown(key);
        }

        public bool IsKeyPressedOnce(Keys key)
        {
            return this.keyboard.IsKeyDown(key) && this.oldKeyboard.IsKeyUp(key);
        }

        public bool IsLeftButtonPressedContinu()
        {
            return this.mouse.LeftButton == ButtonState.Pressed;
        }
        public bool IsLeftButtonPressedOnce()
        {
            return this.mouse.LeftButton == ButtonState.Pressed && this.oldMouse.LeftButton == ButtonState.Released;
        }
        public bool IsRightButtonPressedContinu()
        {
            return this.mouse.RightButton == ButtonState.Pressed;
        }
        public bool IsRightButtonPressedOnce()
        {
            return this.mouse.RightButton == ButtonState.Pressed && this.oldMouse.RightButton == ButtonState.Released;
        }

        /*public bool IsAButtonPressedContinu()
        {
            return this.gamePad.Buttons.A == ButtonState.Pressed;
        }
        public bool IsAButtonPressedOnce()
        {
            return this.gamePad.Buttons.A == ButtonState.Pressed && this.oldGamePad.Buttons.A == ButtonState.Released;
        }*/

        public Point MousePosition()
        {
            return new Point(mouse.Position.X, mouse.Position.Y);
        }
    }
}
