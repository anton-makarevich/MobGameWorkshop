using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameDesktopGLGame.Models;

namespace MonoGameDesktopGLGame
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private readonly List<Mos> _moss = new List<Mos>();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            for (var i = 0; i < 10; i++)
            {

                IMosService mosService;
                if (i==0)
                    mosService = new HumanMosService();
                else
                    mosService = new BotMosService();
                
                _moss.Add(new Mos(i, mosService));
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (var mos in _moss)
            {
                mos.Load(Content,_graphics.GraphicsDevice);
            }
            
        }

        protected override void Update(GameTime gameTime)
        {
            #if NETCOREAPP
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            #endif

            foreach (var mos in _moss)
            {
                mos.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Yellow);

            _spriteBatch.Begin();
            foreach (var mos in _moss)
            {
                mos.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}