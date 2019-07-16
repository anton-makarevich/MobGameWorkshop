using System;
using Microsoft.Xna.Framework;

namespace MonoGameDesktopGLGame.Models
{
    public class BotMosService:IMosService
    {
        readonly Random _random = new Random((int)DateTime.Now.Ticks);
        public bool ShouldJump => _random.Next(100) < 2;
        public Color Color => Color.Red;
    }
}