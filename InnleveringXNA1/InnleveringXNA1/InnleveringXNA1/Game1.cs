using System;
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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;

        private MouseState _currentMouseState;
        private MouseState _previousMouseState;
        private Vector2 _position;
        private Rectangle _mouseRectangle;

        private Texture2D _roofNorthEast, _roofNorth, _roofEast,
            _roofSouthEast, _roofNorthWest, _roofWest, _roofSouthWest,
            _roofSouth, _window, _wallBlock, _stoneBlock, _door, _heart;
        private int _numberOfRoofNorth, _numberOfRoofSouth, _numberOfWall,
            _numberOfStone, _numberOfWindows, _topRoof, _rightRoof, _bottom, _rightWall,
            _roofBottom;

        private int _lives = 5;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _position = new Vector2(0, 100);
            IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            _roofNorthEast = this.Content.Load<Texture2D>("Roof North East");
            _roofNorth = this.Content.Load<Texture2D>("Roof North");
            _roofEast = this.Content.Load<Texture2D>("Roof East");
            _roofSouthEast = this.Content.Load<Texture2D>("Roof South East");
            _roofNorthWest = this.Content.Load<Texture2D>("Roof North West");
            _roofWest = this.Content.Load<Texture2D>("Roof West");
            _roofSouthWest = this.Content.Load<Texture2D>("Roof South West");
            _roofSouth = this.Content.Load<Texture2D>("Roof South");
            _window = this.Content.Load<Texture2D>("Window Tall");
            _wallBlock = this.Content.Load<Texture2D>("Wall Block Tall");
            _stoneBlock = this.Content.Load<Texture2D>("Stone Block");
            _door = this.Content.Load<Texture2D>("Door Tall Closed");
            _heart = this.Content.Load<Texture2D>("Heart");

            _numberOfStone = 7;
            _numberOfWall = 5;
            _numberOfRoofSouth = 4;
            _numberOfRoofNorth = 5;
            _numberOfWindows = 4;

            _topRoof = -40;
            _rightRoof = _roofNorthWest.Width + 5 * _roofNorth.Width;
            _bottom = Window.ClientBounds.Height - _stoneBlock.Height;
            _rightWall = _wallBlock.Width * 5 + _door.Width;
            _roofBottom = 115;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Window.Title = "Capture the Cutes";
            _currentKeyboardState = Keyboard.GetState();
            if (_currentKeyboardState.IsKeyDown(Keys.Escape))
                Exit();
            if (isMousePressed())
            {
                _position = new Vector2(_currentMouseState.X, _currentMouseState.Y);
                Console.WriteLine("X: " + _currentMouseState.X + " Y: " + _currentMouseState.Y);
            }

            base.Update(gameTime);
        }

        public bool IsKeyPressed(Keys key)
        {
            if (_currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key))
                return true;
            return false;
        }

        private bool isMousePressed()
        {
            _currentMouseState = Mouse.GetState();
            if (_currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released)
            {
                this._mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 10, 10);
                return true;
            }
            return false;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            for (int i = 0; i < _numberOfStone; i++)
            {
                spriteBatch.Draw(_stoneBlock, new Vector2(_stoneBlock.Width * i, _bottom), Color.White);
            }
            for (int i = 0; i < _numberOfWall; i++)
            {
                spriteBatch.Draw(_wallBlock, new Vector2(_wallBlock.Width * i, _bottom - _wallBlock.Height + 65), Color.White);
            }

            spriteBatch.Draw(_wallBlock, new Vector2(_rightWall, _bottom - _wallBlock.Height + 65), Color.White);

            spriteBatch.Draw(_door, new Vector2(_wallBlock.Width * 5, _bottom - _wallBlock.Height + 85), Color.White);

            spriteBatch.Draw(_roofNorthWest, new Vector2(0, _topRoof), Color.White);

            for (int i = 0; i < _numberOfRoofNorth; i++)
            {
                spriteBatch.Draw(_roofNorth, new Vector2(_roofNorthWest.Width + (i * _roofNorth.Width), _topRoof), Color.White);
            }

            spriteBatch.Draw(_roofNorth, new Vector2(_roofNorthWest.Width + 4 * _roofNorth.Width, 0), Color.White);



            spriteBatch.Draw(_roofNorthEast, new Vector2(_rightRoof, _topRoof), Color.White);

            spriteBatch.Draw(_roofWest, new Vector2(0, _bottom - _roofSouthWest.Height - 100), Color.White);

            for (int i = 0; i < _numberOfWindows; i++)
            {
                spriteBatch.Draw(_window, new Vector2(_roofWest.Width + (_window.Width * i), _bottom - _roofSouthWest.Height - 60), Color.White);
            }

            spriteBatch.Draw(_roofSouthWest, new Vector2(0, _roofBottom), Color.White);

            for (int i = 0; i < _numberOfRoofSouth; i++)
            {
                spriteBatch.Draw(_roofSouth, new Vector2(_roofSouthWest.Width + _roofSouth.Width * i, _roofBottom), Color.White);
            }

            spriteBatch.Draw(_roofSouthEast, new Vector2(_roofSouthWest.Width + _roofSouth.Width * _numberOfRoofSouth, _roofBottom), Color.White);

            spriteBatch.Draw(_window, new Vector2(_roofSouthEast.Width + _roofSouth.Width * 4, _roofBottom), Color.White);

            spriteBatch.Draw(_roofEast, new Vector2(_roofWest.Width + (_window.Width * 4) + _roofNorth.Width, _topRoof + 80), Color.White);

            spriteBatch.Draw(_roofSouthEast, new Vector2(_rightRoof, _roofBottom), Color.White);

            // Loop that draws the amount of lives left as hearts
            for (int i = 0; i < _lives; i++)
            {
                spriteBatch.Draw(_heart, new Rectangle(_heart.Width * i, 0, 60, 120), Color.White);
            }

            spriteBatch.End();
            // LOOOOOOOL

       

            base.Draw(gameTime);
        }

        /// <summary>
        /// Method that subtracts 1 from the variable _lives
        /// </summary>
        /// <returns>The current value of _lives</returns>
        public int LoseLife()
        {
            _lives -= 1;
            return _lives;
        }
    }
}