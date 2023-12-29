using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Reflection;
using InscryptionAPI.Helpers;


namespace MagnificusMod
{
    public class Tools 
    {
        private static Assembly _assembly;
        public static Assembly CurrentAssembly => _assembly ??= Assembly.GetExecutingAssembly();

        public static Texture2D getImage(string name)
        {
            return TextureHelper.GetImageAsTexture(name, CurrentAssembly);
        }

        public static Sprite getSprite(string path)
        {
            Sprite sprite = new Sprite();
            Texture2D image = Tools.getImage(path);
            return Sprite.Create(image, new Rect(0f, 0f, image.width, image.height), new Vector2(0.5f, 0.5f));
        }

        public static Sprite convertToSprite(Texture2D texture)
        {
            Sprite sprite = new Sprite();
            Texture2D image = texture;
            return Sprite.Create(image, new Rect(0f, 0f, image.width, image.height), new Vector2(0.5f, 0.5f));
        }
        public static Sprite getPortraitSprite(string path)
        {
            Sprite sprite = new Sprite();
            Texture2D image = Tools.getImage(path);
            return Sprite.Create(image, new Rect(0f, 0f, 114, 94), new Vector2(0.5f, 0.5f));
        }
    }
}
