//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Media;

//namespace Innlevering1
//{
//    /// <summary>
//    /// This is the main type for your game
//    /// </summary>
//    public class Game1 : Microsoft.Xna.Framework.Game
//    {
//        GraphicsDeviceManager graphics;
//        SpriteBatch spriteBatch;

//        private CharacterHandler characterHandler;
//        private Building building;
//        private Bug bug;
//        private Life life;
//        private Gem gems;

//        //private List<Character> CharacterList;	

//        public Game1()
//        {
//            graphics = new GraphicsDeviceManager(this);
//            Content.RootDirectory = "Content";


//            // Change the size of the game window
//            graphics.PreferredBackBufferHeight = 570;
//            graphics.PreferredBackBufferWidth = 700;

//            // Makes the mouse visible in the gamewindow
//            IsMouseVisible = true;
//        }

//        /// <summary>
//        /// Allows the game to perform any initialization it needs to before starting to run.
//        /// This is where it can query for any required services and load any non-graphic
//        /// related content.  Calling base.Initialize will enumerate through any components
//        /// and initialize them as well.
//        /// </summary>
//        protected override void Initialize()
//        {
//            // TODO: Add your initialization logic here

//            base.Initialize();
//        }

//        /// <summary>
//        /// LoadContent will be called once per game and is the place to load
//        /// all of your content.
//        /// </summary>
//        protected override void LoadContent()
//        {
//            // Create a new SpriteBatch, which can be used to draw textures.
//            spriteBatch = new SpriteBatch(GraphicsDevice);

//            // Load Content to background variables

//            building = new Building(spriteBatch, Content);
//            bug = new Bug(spriteBatch, Content);
//            life = new Life(spriteBatch, Content);
//            characterHandler = new CharacterHandler(spriteBatch, Content);
//            gems = new Gem(spriteBatch, Content);

//        }

//        /// <summary>
//        /// UnloadContent will be called once per game and is the place to unload
//        /// all content.
//        /// </summary>
//        protected override void UnloadContent()
//        {
//            // TODO: Unload any non ContentManager content here
//        }

//        /// <summary>
//        /// Allows the game to run logic such as updating the world,
//        /// checking for collisions, gathering input, and playing audio.
//        /// </summary>
//        /// <param name="gameTime">Provides a snapshot of timing values.</param>
//        protected override void Update(GameTime gameTime)
//        {
//            // Allows the game to exit
//            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
//                this.Exit();

//            // TODO: Add your update logic here

//            building.Update();
//            bug.Update();
//            life.Update();
//            characterHandler.Update();
//            gems.Update();

//            life.doDamage(characterHandler.getLifeCount());
//            //foreach (Character c in CharacterList)
//            //{
//            //    c.Update();
//            //    if (c.hitCharacter)
//            //        life.doDamage();
//            //}



//            base.Update(gameTime);
//        }

//        /// <summary>
//        /// This is called when the game should draw itself.
//        /// </summary>
//        /// <param name="gameTime">Provides a snapshot of timing values.</param>
//        protected override void Draw(GameTime gameTime)
//        {
//            GraphicsDevice.Clear(Color.White);

//            spriteBatch.Begin();

//            building.Draw();
//            characterHandler.Draw();
//            life.Draw();
//            bug.Draw();

//            gems.Draw();

//            //foreach (Character c in CharacterList)
//            //{
//            //    c.Draw();
//            //}

//            spriteBatch.End();

//            base.Draw(gameTime);
//        }
//    }
//}
