using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameDesktopGLGame.Models
{
    public class HumanMosService:IMosService
    {
        public bool ShouldJump => TouchPanel.GetCapabilities().IsConnected 
            ? TouchPanel.GetState().Count>0
            : Keyboard.GetState().IsKeyDown(Keys.Space);

        public Color Color => Color.White;
    }
}