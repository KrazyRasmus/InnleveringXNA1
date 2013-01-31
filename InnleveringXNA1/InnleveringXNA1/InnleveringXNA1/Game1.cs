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

        private Texture2D _CharacterBoy, _CharacterCatGirl, _CharacterHornGirl,
            _CharacterPinkGirl, _CharacterPrincessGirl;

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

            _CharacterBoy = this.Content.Load<Texture2D>("Character Boy");
            _CharacterCatGirl = this.Content.Load<Texture2D>("Character Cat Girl");
            _CharacterHornGirl = this.Content.Load<Texture2D>("Character Horn Girl");
            _CharacterPinkGirl = this.Content.Load<Texture2D>("Character Pink Girl");
            _CharacterPrincessGirl = this.Content.Load<Texture2D>("Character Princess Girl");

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
            _previousMouseState = _currentMouseState;
            _currentKeyboardState = Keyboard.GetState();

            if (_currentKeyboardState.IsKeyDown(Keys.Escape))
                Exit();

            if (isMouseClicked())
            {
                _position = new Vector2(_currentMouseState.X, _currentMouseState.Y);
                Console.WriteLine("Hei");
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
                _mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 10, 10);
                return true;
            }
            return false;
        }

        private bool isMouseClicked()
        {
            _currentMouseState = Mouse.GetState();
            if (_currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
                return true;
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

            // Loop that draws the amount of lives left as hearts
            for (int i = 0; i < _lives; i++)
            {
                spriteBatch.Draw(_heart, new Rectangle((_heart.Width -55) * i, -15, 50, 60), Color.White);
            }

            spriteBatch.Draw(_CharacterBoy, new Vector2(0, _bottom), Color.White);
            spriteBatch.Draw(_CharacterHornGirl, new Vector2(0, _bottom), Color.White);
            spriteBatch.Draw(_CharacterPinkGirl, new Vector2(0, _bottom), Color.White);
            spriteBatch.Draw(_CharacterPrincessGirl, new Vector2(0, _bottom), Color.White);
            spriteBatch.Draw(_CharacterCatGirl, new Vector2(0, _bottom), Color.White);

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