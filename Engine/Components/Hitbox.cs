using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Managers;
using Microsoft.Xna.Framework.Input;

namespace Engine.Components
{
    public class Hitbox : Component
    {
        public override ComponentType ComponentType => ComponentType.Hitbox;

        private Rectangle hitbox;
        private int offsetX;
        private int offsetY;
        private int hitboxWidth, hitboxHeight;
        private Texture2D displayHitbox;
        private Color hitboxColor;
        private bool isDrawable;

        public Hitbox(int hitboxWidth, int hitboxHeight, int offsetX, int offsetY, Color hitboxColor)
        {
            this.hitboxWidth = hitboxWidth;
            this.hitboxHeight = hitboxHeight;

            this.offsetX = offsetX;
            this.offsetY = offsetY;

            this.hitboxColor = hitboxColor;
            displayHitbox = new Texture2D(GameEngine.graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            displayHitbox.SetData(new[] { hitboxColor });

            isDrawable = true;
        }

        public bool IsTouchingLeft(Rectangle rectangle)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);

            return hitbox.Right + sprite.Velocity.X > rectangle.Left &&
                   hitbox.Left < rectangle.Left &&
                   hitbox.Bottom > rectangle.Top &&
                   hitbox.Top < rectangle.Bottom;
        }

        public bool IsTouchingRight(Rectangle rectangle)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);

            return hitbox.Left + sprite.Velocity.X < rectangle.Right &&
                   hitbox.Right > rectangle.Right &&
                   hitbox.Bottom > rectangle.Top &&
                   hitbox.Top < rectangle.Bottom;
        }

        public bool IsTouchingTop(Rectangle rectangle)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);

            return hitbox.Bottom + sprite.Velocity.Y > rectangle.Top &&
                   hitbox.Top < rectangle.Top &&
                   hitbox.Right > rectangle.Left &&
                   hitbox.Left < rectangle.Right;
        }

        public bool IsTouchingBottom(Rectangle rectangle)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);

            return hitbox.Top + sprite.Velocity.Y < rectangle.Bottom &&
                   hitbox.Bottom > rectangle.Bottom &&
                   hitbox.Right > rectangle.Left &&
                   hitbox.Left < rectangle.Right;
        }

        public bool isCollid(Rectangle Rectangle)
        {
            return (hitbox.Intersects(Rectangle));                
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isDrawable)
            {
                spriteBatch.Draw(displayHitbox, new Rectangle(hitbox.X, hitbox.Y, hitboxWidth, 1), hitboxColor);
                spriteBatch.Draw(displayHitbox, new Rectangle(hitbox.X + hitboxWidth, hitbox.Y, 1, hitboxHeight), hitboxColor);
                spriteBatch.Draw(displayHitbox, new Rectangle(hitbox.X, hitbox.Y + hitboxHeight, hitboxWidth, 1), hitboxColor);
                spriteBatch.Draw(displayHitbox, new Rectangle(hitbox.X, hitbox.Y, 1, hitboxHeight), hitboxColor);
            }
        }

        public override void Update(GameTime gameTime, InputManager input)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            hitbox = new Rectangle(offsetX + (int)sprite.X, offsetY + (int)sprite.Y, hitboxWidth, hitboxHeight);

            if (input.IsKeyPressedOnce(Keys.F3) && !isDrawable)
                isDrawable = true;
            else if (input.IsKeyPressedOnce(Keys.F3) && isDrawable)
                isDrawable = false;
        }
    }
}
