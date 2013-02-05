﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace InnleveringXNA1
{
    abstract class GameObject
    {
        protected SpriteBatch spriteBatch;
        protected ContentManager content;

        public GameObject(SpriteBatch spriteBatch, ContentManager content)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw();
    }
}
