using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Managers;

namespace Engine
{
    public class GameObject
    {
        private List<Component> components;
        public int value;

        public GameObject()
        {
            components = new List<Component>();
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
            //Console.WriteLine(component + " : Ajouter");
            component.Initialize(this);
            //Console.WriteLine(component + " : Init");
        }

        public void RemoveComponent(Component component)
        {
            if (components.Exists(c => component != null))
                components.Remove(component);
            else
                Console.WriteLine(component + " : Ce component n'a jamais était mis");
        }
        
        public virtual void Update(GameTime gameTime, InputManager input)
        {
            foreach (var component in components)
                component.Update(gameTime, input);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in components)
                component.Draw(spriteBatch);
        }


        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return components.Find(c => c.ComponentType == componentType) as TComponentType;
        }
    }
}
