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
    class Background
    {
        SpriteBatch spriteBatch;
        private int _topRoof, _bottom, _roofBottom, _backgroundWidth;

        Texture2D _roofNorthEast, _roofNorth, _roofEast, _roofSouthEast,
            _roofNorthWest, _roofWest, _roofSouthWest, _roofSouth, _window,
            _wallBlock, _stoneBlock, _door;

        public Background() 
        {

        }

        public Background(SpriteBatch spriteBatch, Texture2D _roofNorthEast, Texture2D _roofNorth, Texture2D _roofEast,
            Texture2D _roofSouthEast, Texture2D _roofNorthWest, Texture2D _roofWest, 
            Texture2D _roofSouthWest, Texture2D _roofSouth, Texture2D _window, 
            Texture2D _wallBlock, Texture2D _stoneBlock, Texture2D _door, int _topRoof, 
            int _bottom, int _roofBottom, int _backgroundWidth) 
        {
            this.spriteBatch = spriteBatch;
            this._roofNorthEast = _roofNorthEast;
            this._roofNorth = _roofNorth;
            this._roofEast = _roofEast;
            this._roofSouthEast = _roofSouthEast;
            this._roofNorthWest = _roofNorthWest;
            this._roofWest = _roofWest;
            this._roofSouthWest = _roofSouthWest;
            this._roofSouth = _roofSouth;
            this._window = _window;
            this._wallBlock = _wallBlock;
            this._stoneBlock = _stoneBlock;
            this._door = _door;
            this._topRoof = _topRoof;
            this._bottom = _bottom;
            this._roofBottom = _roofBottom;
            this._backgroundWidth = _backgroundWidth;
        }

        public void drawBackground()
        {
            drawStreet();
            drawWall();
            drawRoof();
        }

        public void drawRoof() 
        {
            // Loop that draws the top row of the roof
            for (int i = 0; i < _backgroundWidth; i++)
            {
                if (i == 0)
                    spriteBatch.Draw(_roofNorthWest, new Vector2(_window.Width * i, _topRoof), Color.White);
                else if (i == 6)
                    spriteBatch.Draw(_roofNorthEast, new Vector2(_window.Width * i, _topRoof), Color.White);
                else
                    spriteBatch.Draw(_roofNorth, new Vector2(_window.Width * i, _topRoof), Color.White);
            }

            // Loop that draws the middle row of the roof
            for (int i = 0; i < _backgroundWidth; i++)
            {
                if (i == 0)
                    spriteBatch.Draw(_roofWest, new Vector2(_window.Width * i, _bottom - _roofSouthWest.Height - 100), Color.White);
                else if (i == 5)
                    spriteBatch.Draw(_roofNorth, new Vector2(_window.Width * i, 0), Color.White);
                else if (i == 6)
                    spriteBatch.Draw(_roofEast, new Vector2(_window.Width * i, _bottom - _roofSouthWest.Height - 100), Color.White);
                else
                    spriteBatch.Draw(_window, new Vector2(_window.Width * i, _bottom - _roofSouthWest.Height - 60), Color.White);
            }

            // Loop that draws the bottom row of the roof.
            for (int i = 0; i < _backgroundWidth; i++)
            {
                if (i == 0)
                    spriteBatch.Draw(_roofSouthWest, new Vector2(0, _roofBottom), Color.White);
                else if (i == 5)
                    spriteBatch.Draw(_window, new Vector2(_roofSouth.Width * i, _roofBottom), Color.White);
                else if (i == 6)
                    spriteBatch.Draw(_roofSouthEast, new Vector2(_roofSouth.Width * i, _roofBottom), Color.White);
                else
                    spriteBatch.Draw(_roofSouth, new Vector2(_roofSouth.Width * i, _roofBottom), Color.White);
            }
        }

        public void drawWall()
        {
            for (int i = 0; i < _backgroundWidth; i++)
            {
                if (i == 5)
                    spriteBatch.Draw(_door, new Vector2(_wallBlock.Width * i, _bottom - _wallBlock.Height + 80), Color.White);
                else
                    spriteBatch.Draw(_wallBlock, new Vector2(_wallBlock.Width * i, _bottom - _wallBlock.Height + 60), Color.White);
            }
        }

        public void drawStreet() 
        {
            for (int i = 0; i < _backgroundWidth; i++)
            {
                spriteBatch.Draw(_stoneBlock, new Vector2(_stoneBlock.Width * i, _bottom), Color.White);
            }
        }
    }
}
