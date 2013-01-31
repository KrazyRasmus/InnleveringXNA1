using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnleveringXNA1
{
    public class Background
    {
        private int _topRoof = -40, _bottom = Window.ClientBounds.Height - _stoneBlock.Height, _roofBottom = 115, _backgroundWidth = 7;
        public void DrawBackground()
        {
            // Loop that draws the bottom row of the background.
            for (int i = 0; i < _backgroundWidth; i++)
            {
                spriteBatch.Draw(_stoneBlock, new Vector2(_stoneBlock.Width * i, _bottom), Color.White);
            }

            // Loop that draws the wall and door of the background. 
            for (int i = 0; i < _backgroundWidth; i++)
            {
                if (i == 5)
                {
                    spriteBatch.Draw(_door, new Vector2(_wallBlock.Width * i, _bottom - _wallBlock.Height + 80), Color.White);
                }
                else
                {
                    spriteBatch.Draw(_wallBlock, new Vector2(_wallBlock.Width * i, _bottom - _wallBlock.Height + 60), Color.White);
                }
            }

            // Loop that draws the top row of the roof
            for (int i = 0; i < _backgroundWidth; i++)
            {
                if (i == 0)
                {
                    spriteBatch.Draw(_roofNorthWest, new Vector2(_window.Width * i, _topRoof), Color.White);
                }
                else if (i == 6)
                {
                    spriteBatch.Draw(_roofNorthEast, new Vector2(_window.Width * i, _topRoof), Color.White);
                }
                else
                {
                    spriteBatch.Draw(_roofNorth, new Vector2(_window.Width * i, _topRoof), Color.White);
                }
            }

            // Loop that draws the middle row of the roof
            for (int i = 0; i < _backgroundWidth; i++)
            {
                if (i == 0)
                {
                    spriteBatch.Draw(_roofWest, new Vector2(_window.Width * i, _bottom - _roofSouthWest.Height - 100), Color.White);
                }
                else if (i == 5)
                {
                    spriteBatch.Draw(_roofNorth, new Vector2(_window.Width * i, 0), Color.White);
                }
                else if (i == 6)
                {
                    spriteBatch.Draw(_roofEast, new Vector2(_window.Width * i, _bottom - _roofSouthWest.Height - 100), Color.White);
                }
                else
                {
                    spriteBatch.Draw(_window, new Vector2(_window.Width * i, _bottom - _roofSouthWest.Height - 60), Color.White);
                }
            }

            // Loop that draws the bottom row of the roof.
            for (int i = 0; i < _backgroundWidth; i++)
            {
                if (i == 0)
                {
                    spriteBatch.Draw(_roofSouthWest, new Vector2(0, _roofBottom), Color.White);
                }
                else if (i == 5)
                {
                    spriteBatch.Draw(_window, new Vector2(_roofSouth.Width * i, _roofBottom), Color.White);
                }
                else if (i == 6)
                {
                    spriteBatch.Draw(_roofSouthEast, new Vector2(_roofSouth.Width * i, _roofBottom), Color.White);
                }
                else
                {
                    spriteBatch.Draw(_roofSouth, new Vector2(_roofSouth.Width * i, _roofBottom), Color.White);
                }
            }
        }
    }
}
