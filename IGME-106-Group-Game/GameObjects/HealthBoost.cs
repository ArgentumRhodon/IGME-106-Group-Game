using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGME106GroupGame.GameObjects;
using IGME106GroupGame.MovementAndAI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IGME106GroupGame.States;

namespace IGME106GroupGame.GameObjects
{
    public class HealthBoost : Powerup
    {
        public HealthBoost(Texture2D sprite, Vector2 position) :
            base(sprite, position)
        {
        }

        public override void OnPickup(Player player)
        {
            player.Health += 2;
            base.OnPickup(player);
        }
    }
}
