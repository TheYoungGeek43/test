using Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class Component
    {
        private GameObject gameObject;
        public abstract ComponentType ComponentType { get; }

        public void Initialize(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void RemoveMe()
        {
            this.gameObject.RemoveComponent(this);
        }

        public abstract void Update(GameTime gameTime, InputManager input);
        public abstract void Draw(SpriteBatch spriteBatch);

        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return this.gameObject == null ? null : this.gameObject.GetComponent<TComponentType>(componentType);
        }
    }
}
