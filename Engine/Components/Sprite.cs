using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Managers;

namespace Engine.Components
{
    public class Sprite : Component
    {
        public override ComponentType ComponentType => ComponentType.Sprite;

        private Texture2D texture;
        private int spriteWidth;
        private int spriteHeight;
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 origin;
        private float rotation;
        private Vector2 scale;
        private Color color;
        private SpriteEffects spriteEffects;
        private float layerDepth;
        private bool isDrawable;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public int SpriteWidth
        {
            get { return spriteWidth; }
        }

        public int SpriteHeight
        {
            get { return spriteHeight; }
        }

        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public SpriteEffects SpriteEffects
        {
            get { return spriteEffects; }
            set { spriteEffects = value; }
        }

        public float LayerDepth
        {
            get { return layerDepth; }
            set { layerDepth = value; }
        }

        public bool IsDrawable
        {
            get { return isDrawable; }
            set { isDrawable = true; }
        }

        public Sprite(string textureName, float x, float y)
        {
            texture = RessourceManager.AddTexture(textureName);
            spriteWidth = texture.Width;
            spriteHeight = texture.Height;
            position = new Vector2(x, y);
            velocity = Vector2.Zero;
            origin = Vector2.Zero;
            rotation = 0f;
            scale = new Vector2(1);
            color = Color.White;
            spriteEffects = SpriteEffects.None;
            layerDepth = 0;
            isDrawable = true;
        }

        public void Move(float vx, float vy)
        {
            velocity.X += vx;
            velocity.Y += vy;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isDrawable)
            {
                spriteBatch.Draw(texture,
                                 position,
                                 new Rectangle(0, 0, SpriteWidth, SpriteHeight),
                                 color,
                                 rotation,
                                 origin,
                                 scale,
                                 spriteEffects,
                                 layerDepth);
            }
            
        }

        public override void Update(GameTime gameTime, InputManager input)
        {
            position += velocity;

            velocity = Vector2.Zero;
        }
    }
}
