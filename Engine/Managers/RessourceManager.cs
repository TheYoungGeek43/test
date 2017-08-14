using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Managers
{
    public static class RessourceManager
    {
        private static Dictionary<string, Texture2D> textures;
        private static Dictionary<string, SpriteFont> spriteFonts;
        private static Dictionary<string, SoundEffect> musics;
        private static Dictionary<string, SoundEffect> sounds;
        
        private static ContentManager content;

        public static void Initialize(ContentManager contentManager)
        {
            content = contentManager;

            textures = new Dictionary<string, Texture2D>();
            spriteFonts = new Dictionary<string, SpriteFont>();
            musics = new Dictionary<string, SoundEffect>();
            sounds = new Dictionary<string, SoundEffect>();
        }

        public static void Unload()
        {
            content.Unload();
        }

        public static Texture2D AddTexture(string textureName)
        {
            if (!textures.ContainsKey(textureName))
            {
                try
                {
                    textures.Add(textureName, content.Load<Texture2D>("graphics/" + textureName));
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Debug.WriteLine(e.Message);
                }
            }

            return textures[textureName];
        }

        public static SpriteFont AddFont(string fontName)
        {
            if (!spriteFonts.ContainsKey(fontName))
            {
                try
                {
                    spriteFonts.Add(fontName, content.Load<SpriteFont>("fonts/" + fontName));
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Debug.WriteLine(e.Message);
                }
            }

            return spriteFonts[fontName];
        }

        public static SoundEffect AddMusic(string musicName)
        {
            if (!musics.ContainsKey(musicName))
            {
                try
                {
                    musics.Add(musicName, content.Load<SoundEffect>("musics/" + musicName));
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Debug.WriteLine(e.Message);
                }
            }

            return musics[musicName];
        }

        public static SoundEffect AddSound(string soundName)
        {
            if (!sounds.ContainsKey(soundName))
            {
                try
                {
                    sounds.Add(soundName, content.Load<SoundEffect>("sounds/" + soundName));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Debug.WriteLine(e.Message);
                }
            }

            return sounds[soundName];
        }
    }
}
