using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace InnleveringXNA1
{
    class WalkingCutes
    {
        Texture2D charBoy, charCatGirl, charHornGirl, charPinkGirl, 
            charPrincess;



        public WalkingCutes() 
        {

        }

        public WalkingCutes(Texture2D charBoy, Texture2D charCatGirl, Texture2D charHornGirl, 
            Texture2D charPinkGirl, Texture2D charPrincess) 
        {
            this.charBoy = charBoy;
            this.charCatGirl = charCatGirl;
            this.charHornGirl = charHornGirl;
            this.charPinkGirl = charPinkGirl;
            this.charPrincess = charPrincess;
        }





    }
}
