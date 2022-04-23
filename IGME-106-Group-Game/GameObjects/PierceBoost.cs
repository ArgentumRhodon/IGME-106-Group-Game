using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IGME106GroupGame.States;
using IGME106GroupGame.GameObjects;
using IGME106GroupGame.MovementAndAI;

namespace IGME106GroupGame.GameObjects
{
    public class PierceBoost : Powerup
    {
        private Random rng = new Random();
        public PierceBoost(Texture2D sprite, Vector2 position) :
            base(sprite, position)
        {
        }
    }
}
