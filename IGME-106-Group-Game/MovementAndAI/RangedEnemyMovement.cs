using IGME106GroupGame.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.MovementAndAI
{
    class RangedEnemyMovement : EnemyMovement
    {
        private float range;

        public RangedEnemyMovement(float speed, Enemy enemy, Player player, float range)
            : base(speed, enemy, player)
        {
            this.range = range;
         }

        public override void Update()
        {
            deltaX = 0;
            deltaY = 0;

            Vector2 direction = player.Position - enemy.Position;

            if (direction.Length() > range)
            {
                deltaX = direction.X;
                deltaY = direction.Y;
            }

            vector = new Vector2(deltaX, deltaY);
            if (vector.X != 0 || vector.Y != 0)
            {
                vector.Normalize();
            }

            vector *= speed;
        }
    }
}
