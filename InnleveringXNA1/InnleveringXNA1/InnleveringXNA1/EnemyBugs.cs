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
    class EnemyBugs : GameObject
    {
        private Texture2D enemyBug;
        private Texture2D gemBlue, gemOrange, gemGreen;
        private Rectangle rectGemBlue, rectGemOrange, rectGemGreen, _mouseRectangle;
        private int _posX, _posY, _numberOfGems, _timeWithoutRandoms,
            _timeSinceLastRandom, _timeBetweenRandoms, _position,
            _timeWithRandoms, _mouseCounter;
        private Random rand;
        private MouseState _currentMouseState, _previousMouseState;


        public EnemyBugs(SpriteBatch spriteBatch, ContentManager content, int windowWidth)
            : base(spriteBatch, content)
        {
            rectGemBlue = new Rectangle(windowWidth - 60, -20, 60, 60);
            rectGemOrange = new Rectangle(windowWidth - rectGemBlue.Width * 2, -20, 60, 60);
            rectGemGreen = new Rectangle(windowWidth - rectGemBlue.Width * 3, -20, 60, 60);
            _posX = 101;
            _posY = -40;
            _timeSinceLastRandom = 0;
            _timeBetweenRandoms = 5000;
            _timeWithRandoms = _timeBetweenRandoms - 600;
            _numberOfGems = 0;
            _mouseCounter = 0;

            rand = new Random();

            enemyBug = content.Load<Texture2D>("Enemy Bug");
            gemBlue = content.Load<Texture2D>("Gem Blue");
            gemOrange = content.Load<Texture2D>("Gem Orange");
            gemGreen = content.Load<Texture2D>("Gem Green");
        }



        public override void Update(GameTime gameTime)
        {
            _timeWithoutRandoms += gameTime.ElapsedGameTime.Milliseconds;
            _timeSinceLastRandom += gameTime.ElapsedGameTime.Milliseconds;

            if (_timeSinceLastRandom > _timeBetweenRandoms)
            {
                _timeSinceLastRandom -= _timeBetweenRandoms;
                _position = rand.Next(1, 6);
                Console.WriteLine(_position);
            }
            if (_timeWithoutRandoms > _timeWithRandoms)
            {
                _mouseCounter = 0;
                _timeWithoutRandoms = (_timeWithRandoms - _timeBetweenRandoms);
                _position = 0;
            }
            if (isMousePressed()) 
            {
                _mouseCounter++;
                Console.WriteLine(_mouseCounter);
                if (_mouseCounter == 20)
                    _numberOfGems++;
            }
            if (_numberOfGems == 3) 
            {
            }
        }

        public override void Draw()
        {
            drawGem(_numberOfGems);

            switch (_position)
            {
                case 1:
                    spriteBatch.Draw(enemyBug, new Rectangle((_posX * _position) + 25, _posY + 100, 50, 100), Color.White);
                    break;

                case 2:
                    spriteBatch.Draw(enemyBug, new Rectangle((_posX * _position) + 25, _posY + 100, 50, 100), Color.White);
                    break;

                case 3:
                    spriteBatch.Draw(enemyBug, new Rectangle((_posX * _position) + 25, _posY + 100, 50, 100), Color.White);
                    break;

                case 4:
                    spriteBatch.Draw(enemyBug, new Rectangle((_posX * _position) + 25, _posY + 100, 50, 100), Color.White);
                    break;

                case 5:
                    spriteBatch.Draw(enemyBug, new Rectangle((_posX * _position) + 25, _posY + 140, 50, 100), Color.White);
                    break;

                default:
                    break;
            }
        }

        public void drawGem(int numberOfGems)
        {
            //Console.WriteLine("halla balla");
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

        public bool isMousePressed()
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            if (_currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released)
            {
                _mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 10, 10);
                return true;
            }
            return false;
        }

        public bool isGameWon() 
        {
            if (_numberOfGems == 3)
                return true;
            else
                return false;
        }
    }
}
