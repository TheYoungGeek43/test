using Engine;
using Engine.Components;
using Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameRPG
{
    public class Game1 : GameEngine
    {

        GameObject player;

        private KeyboardState keyboard;
        private KeyboardState oldKeyboard;
        private MouseState mouse;
        private MouseState oldMouse;

        private InputManager input;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        protected override void Initialize()
        {
            player = new GameObject();

            this.keyboard = Keyboard.GetState();
            this.oldKeyboard = Keyboard.GetState();
            this.mouse = Mouse.GetState();
            this.oldMouse = Mouse.GetState();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            graphicsDevice = GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);         
            RessourceManager.Initialize(Content);
            player.AddComponent(new Sprite("heros", 200, 200));
            player.AddComponent(new Hitbox(16, 16, 0, 0, Color.Red));
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            this.keyboard = Keyboard.GetState();
            this.mouse = Mouse.GetState();

            this.input = new InputManager(this.keyboard, this.oldKeyboard, this.mouse, this.oldMouse);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || this.input.IsKeyPressedOnce(Keys.Escape))
                Exit();

            player.Update(gameTime, input);

            
            this.oldKeyboard = Keyboard.GetState();
            this.oldMouse = Mouse.GetState();

            if (input.IsKeyPressedContinu(Keys.Right))
                player.GetComponent<Sprite>(ComponentType.Sprite).Move(+2, 0);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null);

            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
