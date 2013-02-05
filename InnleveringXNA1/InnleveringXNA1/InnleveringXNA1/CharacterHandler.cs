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
    class CharacterHandler : GameObject
    {

        private Texture2D[] _charArray;
        private List<Vector2> _charPosList;
        private List<int> _charToDraw;
        private Random random;
        private int _windowHeight, _timeToAddCharacter, _timeBetweenCharacters; 
        private MouseState _previousMouseState, _currentMouseState;
        private Rectangle _mouseRectangle;
        private Vector2 _characterPosition;
        Texture2D _boy;
        public CharacterHandler(SpriteBatch spriteBatch, ContentManager content, int windowHeight)
            : base(spriteBatch, content)
        {
            _charPosList = new List<Vector2>();
            _charToDraw = new List<int>();
            _timeToAddCharacter = 0;
            _timeBetweenCharacters = 2000;
            _windowHeight = windowHeight;
            random = new Random();
            _boy = content.Load<Texture2D>("Character Boy");
            _charArray = new Texture2D[]{
                content.Load<Texture2D>("Character Boy"),
                content.Load<Texture2D>("Character Cat Girl"),
                content.Load<Texture2D>("Character Horn Girl"),
                content.Load<Texture2D>("Character Pink Girl"),
                content.Load<Texture2D>("Character Princess Girl")
            };
            AddCharacter();
        }

        

        public override void Update(GameTime gameTime)
        {
            CharacterPos();
            _timeToAddCharacter += gameTime.ElapsedGameTime.Milliseconds;
            if (_timeToAddCharacter >= _timeBetweenCharacters && _charToDraw.Count < 10) 
            {
                _timeToAddCharacter = 0;
                AddCharacter();
            }
            CharacterHitBox();
            if (isMousePressed() && _mouseRectangle.Intersects(CharacterHitBox()))
            {
                _characterPosition.X = -100;
            }
        }

        public override void Draw()
        {
            spriteBatch.Draw(_boy, CharacterHitBox(), Color.Blue);
            for (int i = 0; i < _charPosList.Count; i++)
            {
                spriteBatch.Draw(_charArray[_charToDraw[i]], _charPosList[i], Color.White);
            }
        }

        private void CharacterPos()
        {
            for (int i = 0; i < _charPosList.Count; i++)
            {
                _characterPosition = new Vector2(_charPosList[i].X + 3, _charPosList[i].Y);
                _charPosList[i] = _characterPosition;
            }
        }

        private void AddCharacter()
        {
            _charToDraw.Add(random.Next(0, 5));
            _charPosList.Add(new Vector2(-_charArray[0].Bounds.Width, _windowHeight - _charArray[0].Bounds.Height));
        }

        private Rectangle CharacterHitBox() 
        {
            return new Rectangle((int)_characterPosition.X, (int)_characterPosition.Y, 65, 80);
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
    }
}
