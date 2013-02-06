using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace InnleveringXNA1
{
    class Character : GameObject
    {
        //pung
        #region CharacterDeclarations : Where all variables are declared

        private Texture2D _charBoy, _charCatGirl, _charHornGirl, 
            _charPinkgirl, _charPrincessGirl;
        public bool hitCharacter { get; private set; }

        private MouseState _previousMouseState, _currentMouseState;

        private Vector2 _charPosition; 

        private Rectangle mouseBox;
        private Rectangle characterHitBox;

        private Random rand;

        private int _charStartPosition, _windowWidth,_characterToDraw, level, 
            runTimeCounter, levelSpeed, nextLevelSpeed;

        private Boolean ifCharacterChoosen = true;

        #endregion

        public Character(SpriteBatch spriteBatch, ContentManager contentMananger)
            : base(spriteBatch, contentMananger)
        {
            _charBoy = content.Load<Texture2D>("Character Boy");
            _charCatGirl = content.Load<Texture2D>("Character Cat Girl");
            _charHornGirl = content.Load<Texture2D>("Character Horn girl");
            _charPinkgirl = content.Load<Texture2D>("Character Pink Girl");
            _charPrincessGirl = content.Load<Texture2D>("Character Princess Girl");
            
            _charStartPosition = -101;
            _windowWidth = 700;
            level = 0;
            runTimeCounter = 0;
            levelSpeed = 1;
            nextLevelSpeed = 1;

            rand = new Random();
            _charPosition = new Vector2(-100, 350);
        }

        internal override void Update()
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            mouseBox = new Rectangle(
                Mouse.GetState().X + (mouseBox.Width / 2)
                , Mouse.GetState().Y + (mouseBox.Height / 2)
                , 1, 1);

            characterHitBox = new Rectangle(
                (int)_charPosition.X + 20
                , (int)_charPosition.Y + 60
                , 65, 80);

            _charPosition.X += levelSpeed;

            if (mouseBox.Intersects(characterHitBox) && IsMousePressed())
                _charPosition.X = _charStartPosition;

            if (_charPosition.X > _windowWidth)
            {
                _charPosition.X = _charStartPosition;
                hitCharacter = true;
            }
            else
                hitCharacter = false;


            if (ifCharacterChoosen)
            {
                _characterToDraw = rand.Next(0, 5);
                ifCharacterChoosen = false;
            }
            if (_charPosition.X == _charStartPosition)
                ifCharacterChoosen = true;

            if (runTimeCounter == 1000)
            {
                runTimeCounter = 0;
                if (level == 0)
                    level = 1;
                else
                    level = 0;
            }
            switch (level)
            {
                case 0:
                    if (nextLevelSpeed == levelSpeed)
                    {
                        nextLevelSpeed = levelSpeed + 1;
                    }
                    break;
                case 1:
                    levelSpeed = nextLevelSpeed;
                    break;
                default:
                    levelSpeed = 1;
                    break;
            }

            runTimeCounter++;
        }

        internal void DrawCharacters()
        {
            switch (_characterToDraw)
            {
                case 0:
                    spriteBatch.Draw(_charBoy, _charPosition, Color.White);
                    break;
                case 1:
                    spriteBatch.Draw(_charCatGirl, _charPosition, Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(_charHornGirl, _charPosition, Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(_charPinkgirl, _charPosition, Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(_charPrincessGirl, _charPosition, Color.White);
                    break;
                default:
                    spriteBatch.Draw(_charBoy, _charPosition, Color.White);
                    break;
            }
        }

        internal override void Draw()
        {
            DrawCharacters();
        }

        internal bool IsMousePressed()
        {
            return ((_currentMouseState.LeftButton == ButtonState.Pressed)
                && (_previousMouseState.LeftButton == ButtonState.Released));
        }

    }
}
