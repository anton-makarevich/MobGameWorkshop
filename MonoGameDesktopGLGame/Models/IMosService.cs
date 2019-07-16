using Microsoft.Xna.Framework;

namespace MonoGameDesktopGLGame.Models
{
    public interface IMosService
    {
        bool ShouldJump { get; }
        Color Color { get; }
    }
}