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
    class EnemyBugs
    {
        SpriteBatch spriteBatch;
        Texture2D enemyBug;
        Texture2D gemBlue, gemOrange, gemGreen; 
        Rectangle rectGemBlue, rectGemOrange, rectGemGreen;
        int posX, posY, numberOfGems;

        public EnemyBugs() 
        {

        }

        public EnemyBugs(SpriteBatch spriteBatch, Texture2D enemyBug,
            Texture2D gemBlue, Texture2D gemOrange, Texture2D gemGreen, 
            Rectangle rectGemBlue, Rectangle rectGemOrange, 
            Rectangle rectGemGreen, int posX, int posY, int numberOfGems) 
        {
            this.spriteBatch = spriteBatch;
            this.enemyBug = enemyBug;
            this.gemBlue = gemBlue;
            this.gemOrange = gemOrange;
            this.gemGreen = gemGreen;
            this.rectGemBlue = rectGemBlue;
            this.rectGemOrange = rectGemOrange;
            this.rectGemGreen = rectGemGreen;
            this.posX = posX;
            this.posY = posY;
            this.numberOfGems = numberOfGems;
            
        }

        public void drawBug(int random) 
        {
            switch (random){
                case 1:
                    spriteBatch.Draw(enemyBug, new Rectangle((posX * random) + 25, posY + 100, 50, 100), Color.White);
                    break;
            
                case 2:
                    spriteBatch.Draw(enemyBug, new Rectangle((posX * random) + 25, posY + 100, 50, 100), Color.White);
                    break;

                case 3:
                    spriteBatch.Draw(enemyBug, new Rectangle((posX * random) + 25, posY + 100, 50, 100), Color.White);
                    break;

                case 4:
                    spriteBatch.Draw(enemyBug, new Rectangle((posX * random) + 25, posY + 100, 50, 100), Color.White);
                    break;

                case 5:
                    spriteBatch.Draw(enemyBug, new Rectangle((posX * random) + 25, posY + 140, 50, 100), Color.White);
                    break;
                
                default: 
                    break;
            }
        }

        public void drawGem()
        {
            if (numberOfGems >= 1)
            {
                spriteBatch.Draw(gemBlue, rectGemBlue, Color.White);
            }
            if (numberOfGems >= 2)
            {
                spriteBatch.Draw(gemOrange, rectGemOrange, Color.White);
            }
            if (numberOfGems == 3)
            {
                spriteBatch.Draw(gemGreen, rectGemGreen, Color.White);
            }
        }
    }
}
