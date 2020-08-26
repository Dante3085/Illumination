using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Illumination
{

    public enum ETexture
    {
        MAIN_CHARACTER
    }

    public enum EFrameMap
    {
        MAIN_CHARACTER
    }

    public enum EFont
    {

    }

    public enum ESong
    {

    }

    public enum ESoundEffect
    {

    }

    public static class AssetManager
    {
        private static bool loaded = false;

        private static Dictionary<ETexture, Texture2D> textures = new Dictionary<ETexture, Texture2D>();
        private static Dictionary<EFrameMap, Dictionary<string, Rectangle>> frameMaps = new Dictionary<EFrameMap, Dictionary<string, Rectangle>>();
        private static Dictionary<EFont, SpriteFont> fonts = new Dictionary<EFont, SpriteFont>();
        private static Dictionary<ESong, Song> songs = new Dictionary<ESong, Song>();
        private static Dictionary<ESoundEffect, SoundEffect> sfx = new Dictionary<ESoundEffect, SoundEffect>();

        private static Dictionary<String, ETexture> textureNames = new Dictionary<string, ETexture>()
    {
            { "main_character", ETexture.MAIN_CHARACTER }
    };

        private static Dictionary<String, EFrameMap> frameMapNames = new Dictionary<string, EFrameMap>()
        {
            { "main_character_frameMap", EFrameMap.MAIN_CHARACTER }
        };

        private static Dictionary<String, EFont> fontNames = new Dictionary<string, EFont>()
    {
        
    };

        private static Dictionary<String, ESong> songNames = new Dictionary<string, ESong>()
    {
        
    };

        private static Dictionary<String, ESoundEffect> sfxNames = new Dictionary<string, ESoundEffect>()
    {
        
    };

        public static void LoadAssets(ContentManager contentManager)
        {
            if (loaded)
            {
                throw new InvalidOperationException("All assets have already been loaded. It does not make " +
                                                    "senese to call this Method more than once.");
            }

            // Load Texture2Ds
            foreach (String textureName in textureNames.Keys)
            {
                textures.Add(textureNames[textureName], contentManager.Load<Texture2D>(textureName));
            }

            // Load FrameMaps for Animations
            foreach (String frameMapName in frameMapNames.Keys)
            {
                frameMaps.Add(frameMapNames[frameMapName], contentManager.Load<Dictionary<string, Rectangle>>(frameMapName));
            }

            // Load SpriteFonts
            foreach (String fontName in fontNames.Keys)
            {
                fonts.Add(fontNames[fontName], contentManager.Load<SpriteFont>(fontName));
            }

            // Load Songs
            foreach (String songName in songNames.Keys)
            {
                songs.Add(songNames[songName], contentManager.Load<Song>(songName));
            }

            // Load SFX
            foreach (String sfxName in sfxNames.Keys)
            {
                sfx.Add(sfxNames[sfxName], contentManager.Load<SoundEffect>(sfxName));
            }

            loaded = true;
        }

        public static Texture2D GetTexture(ETexture texture)
        {
            if (!loaded)
                throw new InvalidOperationException("Call 'LoadAssets()' before you try to get any assets.");

            return textures[texture];
        }

        public static Dictionary<string, Rectangle> GetFrameMap(EFrameMap frameMap)
        {
            if (!loaded)
                throw new InvalidOperationException("Call 'LoadAssets()' before you try to get any assets.");

            return frameMaps[frameMap];
        }

        public static SpriteFont GetFont(EFont font)
        {
            if (!loaded)
                throw new InvalidOperationException("Call 'LoadAssets()' before you try to get any assets.");

            return fonts[font];
        }

        public static Song GetSong(ESong song)
        {
            if (!loaded)
                throw new InvalidOperationException("Call 'LoadAssets()' before you try to get any assets.");

            return songs[song];
        }

        public static SoundEffect GetSoundEffect(ESoundEffect soundEffect)
        {
            if (!loaded)
                throw new InvalidOperationException("Call 'LoadAssets()' before you try to get any assets.");

            return sfx[soundEffect];
        }
    }
}