using IGME106GroupGame.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.MovementAndAI
{
    class RangedEnemyMovement : Movement
    {
        private RangedEnemy enemy;
        private Player player;

        private float deltaX = 0;
        private float deltaY = 0;

        public RangedEnemyMovement(float speed, RangedEnemy enemy, Player player)
            : base(speed)
        {
            this.enemy = enemy;
            this.player = player;
        }

        public override void Update()
        {
            deltaX = 0;
            deltaY = 0;

            Vector2 direction = player.Position - enemy.Position;

            if (direction.Length() > 500)
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
