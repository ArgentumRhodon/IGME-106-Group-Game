using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGME106GroupGame.GameObjects;
using Microsoft.Xna.Framework;

namespace IGME106GroupGame.MovementAndAI
{
    class EnemyMovement : Movement
    {
        protected Enemy enemy;
        protected Player player;

        protected float deltaX = 0;
        protected float deltaY = 0;

        public EnemyMovement(float speed, Enemy enemy, Player player)
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

            if (direction.Length() > speed)
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
