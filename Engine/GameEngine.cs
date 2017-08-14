using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class GameEngine : Game
    {
        public static GraphicsDevice graphicsDevice { get; protected set; }

        public static int screenWidth { get; protected set; }
        public static int screenHeight { get; protected set; }

        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        //protected InputManager input;
        //protected State state;
    }
}
