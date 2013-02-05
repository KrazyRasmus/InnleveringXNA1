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
        private Rectangle _rectGemBlue, _rectGemOrange, _rectGemGreen;

        private Texture2D _roofNorthEast, _roofNorth, _roofEast,
            _roofSouthEast, _roofNorthWest, _roofWest, _roofSouthWest,
            _roofSouth, _window, _wallBlock, _stoneBlock, _door, _heart,
            _enemyBug, _gemBlue, _gemOrange, _gemGreen, _charBoy, _charCatGirl, 
            _charHornGirl, _charPinkGirl, _charPrincess;

        private int _topRoof, _bottom, _roofBottom, _backgroundWidth, 
            _timeSinceLastRandom, _timeBetweenRandoms, _test, _runder, _position, _numberOfGems, _timeWithoutRandoms;

        private Random rand = new Random(); 

        Background drawBackground = new Background();
        EnemyBugs enemyBug = new EnemyBugs();

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
            _charBoy = this.Content.Load<Texture2D>("Character Boy");
            _charCatGirl = this.Content.Load<Texture2D>("Character Cat Girl");
            _charHornGirl = this.Content.Load<Texture2D>("Character Horn Girl");
            _charPinkGirl = this.Content.Load<Texture2D>("Character Pink Girl");
            _charPrincess = this.Content.Load<Texture2D>("Character Princess Girl");

            _rectGemBlue = new Rectangle(Window.ClientBounds.Width - 60, -20, 60, 60);
            _rectGemOrange = new Rectangle(Window.ClientBounds.Width - _rectGemBlue.Width * 2, -20, 60, 60);
            _rectGemGreen = new Rectangle(Window.ClientBounds.Width - _rectGemBlue.Width * 3, -20, 60, 60);
            

            _backgroundWidth = 7;
            _topRoof = -40;
            _bottom = Window.ClientBounds.Height - _stoneBlock.Height;
            _roofBottom = 115;
            _timeSinceLastRandom = 0;
            _timeBetweenRandoms = 6000;
            _test = _timeBetweenRandoms - 600;
            _runder = 0;
            _numberOfGems = 0;
            _position = 0;
            Console.WriteLine(_position);

            drawBackground = new Background(spriteBatch, _roofNorthEast, _roofNorth, 
                _roofEast, _roofSouthEast,_roofNorthWest, _roofWest, _roofSouthWest, 
                _roofSouth, _window, _wallBlock, _stoneBlock, _door, _topRoof, _bottom,
                _roofBottom, _backgroundWidth);

            enemyBug = new EnemyBugs(spriteBatch, _enemyBug, _gemBlue, _gemOrange, _gemGreen,
                _rectGemBlue, _rectGemOrange, _rectGemGreen, _window.Width, _topRoof, _numberOfGems);

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

            _timeWithoutRandoms += gameTime.ElapsedGameTime.Milliseconds;
            _timeSinceLastRandom += gameTime.ElapsedGameTime.Milliseconds;
            Console.WriteLine("Tid til neste" + _timeSinceLastRandom);
            if (_timeSinceLastRandom > _timeBetweenRandoms)
            {
                _timeSinceLastRandom -= _timeBetweenRandoms;
                _position = rand.Next(1, 6);
                Console.WriteLine(_position);
            }     
            if (_timeWithoutRandoms > _test) 
            {
                _runder++;
                _timeWithoutRandoms = (_test - _timeBetweenRandoms);
                Console.WriteLine("test" + _timeWithoutRandoms);
                _position = 0;
            }
            

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            drawBackground.drawBackground();
            enemyBug.drawBug(_position);
            enemyBug.drawGem();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}