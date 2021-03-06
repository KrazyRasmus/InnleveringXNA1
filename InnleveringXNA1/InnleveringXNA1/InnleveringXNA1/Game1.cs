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
        private Rectangle _rectGemBlue, _rectGemOrange, _rectGemGreen;

        private float movementSpeed;

        private Texture2D _roofNorthEast, _roofNorth, _roofEast,
            _roofSouthEast, _roofNorthWest, _roofWest, _roofSouthWest,
            _roofSouth, _window, _wallBlock, _stoneBlock, _door, _heart,
            _enemyBug;

        private int _topRoof, _bottom, _roofBottom, _backgroundWidth;

        private int _lives = 5;

        private bool _drawBugBool;

        private Random rand = new Random();
        private int _enemySpawnMinMilliseconds = 1000;
        private int _enemySpawnMaxMilliseconds = 2000;
        private int _nextSpawnTime = 0;

        private Rectangle _endOfRoad;

        private Texture2D _CharacterBoy, _CharacterCatGirl, _CharacterHornGirl,
            _CharacterPinkGirl, _CharacterPrincessGirl, _gemBlue, _gemOrange, _gemGreen;

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
            //Resets the spawn time
            ResetSpawnTime();

            _position = new Vector2(0, 280);
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
            _gemBlue = this.Content.Load<Texture2D>("Gem Blue");
            _gemOrange = this.Content.Load<Texture2D>("Gem Orange");
            _gemGreen = this.Content.Load<Texture2D>("Gem Green");
            _enemyBug = this.Content.Load<Texture2D>("Enemy Bug");


            _CharacterBoy = this.Content.Load<Texture2D>("Character Boy");
            _CharacterCatGirl = this.Content.Load<Texture2D>("Character Cat Girl");
            _CharacterHornGirl = this.Content.Load<Texture2D>("Character Horn Girl");
            _CharacterPinkGirl = this.Content.Load<Texture2D>("Character Pink Girl");
            _CharacterPrincessGirl = this.Content.Load<Texture2D>("Character Princess Girl");

            _rectGemBlue = new Rectangle(Window.ClientBounds.Width - 60, -20, 60, 60);
            _rectGemOrange = new Rectangle(Window.ClientBounds.Width - _rectGemBlue.Width * 2, -20, 60, 60);
            _rectGemGreen = new Rectangle(Window.ClientBounds.Width - _rectGemBlue.Width * 3, -20, 60, 60);

            //rectangel placement to crash characters in end of screen.
            _endOfRoad = new Rectangle(Window.ClientBounds.Width - _CharacterBoy.Width, Window.ClientBounds.Height - _CharacterBoy.Width, 40, 40);


            _backgroundWidth = 7;
            _topRoof = -40;
            _bottom = Window.ClientBounds.Height - _stoneBlock.Height;
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

            if (_currentKeyboardState.IsKeyDown(Keys.Escape) || _lives == 0)
                Exit();

            if (isMouseClicked())
            {
                _mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 10, 10);
                Console.WriteLine("Hei");
            }

            movementSpeed = 100f;
            _position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * movementSpeed;



            //Counts down from the _nextSpawnTime (with limits set
            //to min 1000 and max 2000 milliseconds)
            _nextSpawnTime -= gameTime.ElapsedGameTime.Milliseconds;
            if (_nextSpawnTime < 0)
            {
                SpawnEnemy();
                Console.WriteLine("N�");
                //Reset spawn timer
                ResetSpawnTime();
            }
            else 
            {
                _drawBugBool = false;
            }

          
            base.Update(gameTime);
            // hva skjer a?
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
        /// Method that subtracts 1 from the variable _lives
        /// </summary>
        /// <returns>The current value of _lives</returns>
        public int LoseLife()
        {
            _lives -= 1;
            return _lives;
        }

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
                    spriteBatch.Draw(_door, new Vector2(_wallBlock.Width * i, _bottom - _wallBlock.Height + 80), Color.White);
                else
                    spriteBatch.Draw(_wallBlock, new Vector2(_wallBlock.Width * i, _bottom - _wallBlock.Height + 60), Color.White);
            }

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
                // Der characters treffer veggen.
  

        public void drawGem(int numberOfGems)
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

        public void drawEnemyBug(int position)
        {
            if (position == 0)
            {
                spriteBatch.Draw(_enemyBug, new Rectangle(_window.Width * (position + 1) + 25, _topRoof + 100, 50, 100), Color.White);
            }
            if (position == 1)
            {
                spriteBatch.Draw(_enemyBug, new Rectangle(_window.Width * (position + 1) + 25, _topRoof + 100, 50, 100), Color.White);
            }
            if (position == 2)
            {
                spriteBatch.Draw(_enemyBug, new Rectangle(_window.Width * (position + 1) + 25, _topRoof + 100, 50, 100), Color.White);
            }
            if (position == 3)
            {
                spriteBatch.Draw(_enemyBug, new Rectangle(_window.Width * (position + 1) + 25, _topRoof + 100, 50, 100), Color.White);
            }
            if (position == 4)
            {
                spriteBatch.Draw(_enemyBug, new Rectangle(_window.Width * (position + 1) + 25, _topRoof + 140, 50, 100), Color.White);
            }
        }

        private void ResetSpawnTime()
        {
            _nextSpawnTime = rand.Next(
                _enemySpawnMinMilliseconds,
                _enemySpawnMaxMilliseconds);
            Console.WriteLine(_nextSpawnTime);
        }

        private void SpawnEnemy()
        {
            _drawBugBool = true;
            Console.WriteLine("HAHAHHA");
            LoseLife();
        }




        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            DrawBackground();

            if (_drawBugBool)
            {
                drawEnemyBug(0);
            }

            // Loop that draws the amount of lives left as hearts
            for (int i = 0; i < _lives; i++)
            {
                spriteBatch.Draw(_heart, new Rectangle((_heart.Width - 55) * i, -15, 50, 60), Color.White);
            }
            spriteBatch.Draw(_CharacterBoy, _position, Color.White);
            spriteBatch.Draw(_CharacterHornGirl, _position, Color.White);
            spriteBatch.Draw(_CharacterPinkGirl, _position, Color.White);
            spriteBatch.Draw(_CharacterPrincessGirl, _position, Color.White);
            spriteBatch.Draw(_CharacterCatGirl, _position, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}