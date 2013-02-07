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
using System.Diagnostics;

namespace InnleveringXNA1
{
    class EnemyBugs : GameObject
    {
        private Texture2D _enemyBug, _gemBlue, _gemOrange, _gemGreen;
        private Rectangle _rectGemBlue, _rectGemOrange, _rectGemGreen,
            _mouseRectangle, _normalBugRect, _lowerBugRect;
        private int _posX, _posY, _numberOfGems, _timeBetweenRandoms, 
            _position, _timeWithRandoms, _mouseCounter, _timeWithoutRandoms, 
            _timeSinceLastRandom;

        private Random rand;
        private MouseState _currentMouseState, _previousMouseState;

        private Stopwatch _gameTime;


        public EnemyBugs(SpriteBatch spriteBatch, ContentManager content, int windowWidth)
            : base(spriteBatch, content)
        {
            _enemyBug = content.Load<Texture2D>("Enemy Bug");
            _gemBlue = content.Load<Texture2D>("Gem Blue");
            _gemOrange = content.Load<Texture2D>("Gem Orange");
            _gemGreen = content.Load<Texture2D>("Gem Green");

            _posX = 101;
            _posY = -40;
            _timeBetweenRandoms = 10000;
            _timeWithRandoms = _timeBetweenRandoms - 600;
            _numberOfGems = 0;
            _mouseCounter = 0;

            _rectGemBlue = new Rectangle(windowWidth - 60, -20, 60, 60);
            _rectGemOrange = new Rectangle(windowWidth - _rectGemBlue.Width * 2, -20, 60, 60);
            _rectGemGreen = new Rectangle(windowWidth - _rectGemBlue.Width * 3, -20, 60, 60);

            _gameTime = new Stopwatch();
            _gameTime.Start();
            rand = new Random();
        }

        internal override void Update() // HUSK A LEGGE TIL GAMETIME
        {
            _mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 10, 10);

            _timeWithoutRandoms += (int)_gameTime.ElapsedMilliseconds;
            _timeSinceLastRandom += (int)_gameTime.ElapsedMilliseconds;
            _gameTime.Restart();

            if (_timeSinceLastRandom > _timeBetweenRandoms)
            {
                _timeSinceLastRandom = 0;
                _position = rand.Next(1, 6);
                Console.WriteLine(_position);
            }
            if (_timeWithoutRandoms > _timeWithRandoms)
            {
                _mouseCounter = 0;
                _timeWithoutRandoms = (_timeWithRandoms - _timeBetweenRandoms);
                _position = 0;
            }
            if (IsMousePressed() && (_mouseRectangle.Intersects(_normalBugRect) ||
                _mouseRectangle.Intersects(_lowerBugRect)))
            {
                _mouseCounter++;
                Console.WriteLine(_mouseCounter);
                if (_mouseCounter == 20)
                    _numberOfGems++;
            }
        }

        internal override void Draw()
        {
            drawGem(_numberOfGems);
            _normalBugRect = new Rectangle((_posX * _position) + 25, _posY + 100, 50, 100);
            _lowerBugRect = new Rectangle((_posX * _position) + 25, _posY + 140, 50, 100);

            switch (_position)
            {
                case 1:
                    spriteBatch.Draw(_enemyBug, _normalBugRect, Color.White);
                    break;

                case 2:
                    spriteBatch.Draw(_enemyBug, _normalBugRect, Color.White);
                    break;

                case 3:
                    spriteBatch.Draw(_enemyBug, _normalBugRect, Color.White);
                    break;

                case 4:
                    spriteBatch.Draw(_enemyBug, _normalBugRect, Color.White);
                    break;

                case 5:
                    spriteBatch.Draw(_enemyBug, _lowerBugRect, Color.White);
                    break;

                default:
                    break;
            }
        }

        internal void drawGem(int numberOfGems)
        {
            if (numberOfGems >= 1)
            {
                spriteBatch.Draw(_gemBlue, _rectGemBlue, Color.White);
            }
            if (numberOfGems >= 2)
            {
                spriteBatch.Draw(_gemOrange, _rectGemOrange, Color.White);
            }
            if (numberOfGems == 3)
            {
                spriteBatch.Draw(_gemGreen, _rectGemGreen, Color.White);
            }
        }

        internal bool IsMousePressed()
        {
            return ((_currentMouseState.LeftButton == ButtonState.Pressed)
                && (_previousMouseState.LeftButton == ButtonState.Released));
        }

        public bool isGameWon()
        {
            return (_numberOfGems == 3);
        }
    }
}
