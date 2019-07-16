using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameDesktopGLGame.Models
{
    public class Mos
    {
        private readonly IMosService _mosService;
        private Texture2D _mosTexture;
        private Vector2 _mosPosition;
        private float _velocity;

        public Mos(int index, IMosService mosService)
        {
            _mosService = mosService;
            _mosPosition = new Vector2(150*index,0);
        }

        public void Load(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            using (var fileStream = new FileStream( Path.Combine(contentManager.RootDirectory,"mos.png"), FileMode.Open))
                _mosTexture = Texture2D.FromStream(graphicsDevice, fileStream);
        }

        public void Update()
        {
            if (_mosService.ShouldJump)
                _velocity = -5;
            else
                _velocity += 0.1f;
            
            _mosPosition.Y += _velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _mosTexture, 
                new Rectangle(_mosPosition.ToPoint(), new Point(128,128)),
                _mosService.Color);
        }
    }
}