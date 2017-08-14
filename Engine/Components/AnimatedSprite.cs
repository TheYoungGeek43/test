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
    public class AnimatedSprite : Component
    {
        public override ComponentType ComponentType => ComponentType.AnimatedSprite;

        private Texture2D texture;
        private Vector2 position;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Color color;
        private SpriteSheetOrientation spriteSheetOrientation;
        private Direction direction;
        private int currentFrameX;
        private int currentFrameY;
        private int spriteWidth;
        private int spriteHeight;
        private int maxFrame;

        public AnimatedSprite(string path, int x, int y, int spriteWidth, int spriteHeight, SpriteSheetOrientation spriteSheetOrientation, Direction direction)
        {
            this.texture = RessourceManager.AddTexture(path);
            this.position.X = x;
            this.position.Y = y;
            this.destinationRectangle = new Rectangle(x, y, 32, 32);
            this.sourceRectangle = new Rectangle(this.currentFrameX, this.currentFrameY, 32, 32);
            this.color = Color.White;
            this.spriteSheetOrientation = spriteSheetOrientation;
            direction = Direction.DOWN;
            this.direction = direction;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
        }

        public void setDirection(Direction dir)
        {
            this.direction = dir;
        }

        public override void Update(GameTime gameTime, InputManager input)
        {
            if (spriteSheetOrientation == SpriteSheetOrientation.VERTICAL)
            {
                if (this.direction == Direction.UP)
                {
                    this.currentFrameX = 0;
                    this.currentFrameY = 0;
                }
                else if (this.direction == Direction.DOWN)
                {
                    this.currentFrameX = 1;
                    this.currentFrameY = 0;
                }
                else if (this.direction == Direction.RIGHT)
                {
                    this.currentFrameX = 2;
                    this.currentFrameY = 0;
                }
                else if (this.direction == Direction.LEFT)
                {
                    this.currentFrameX = 3;
                    this.currentFrameY = 0;
                }
            }
            else if (spriteSheetOrientation == SpriteSheetOrientation.HORIZONTAL)
            {
                if (this.direction == Direction.UP)
                {
                    this.currentFrameX = 0;
                    this.currentFrameY = 0;
                }
                else if (this.direction == Direction.DOWN)
                {
                    this.currentFrameX = 0;
                    this.currentFrameY = 1;
                }
                else if (this.direction == Direction.RIGHT)
                {
                    this.currentFrameX = 0;
                    this.currentFrameY = 2;
                }
                else if (this.direction == Direction.LEFT)
                {
                    this.currentFrameX = 0;
                    this.currentFrameY = 3;
                }
            }
            this.sourceRectangle.X = this.currentFrameX * spriteWidth;
            this.sourceRectangle.Y = this.currentFrameY * spriteHeight;
        }

        public void Move(float x, float y)
        {
            if (x > 0)
            {
                direction = Direction.RIGHT;
            }
            else if (x < 0)
            {
                direction = Direction.LEFT;
            }
            else if (y > 0)
            {
                direction = Direction.DOWN;
            }
            else if (y < 0)
            {
                direction = Direction.UP;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, position, sourceRectangle, color);
            
        }
    }
}
