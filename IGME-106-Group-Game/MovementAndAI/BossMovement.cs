﻿
using IGME106GroupGame.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.MovementAndAI
{
    public class BossMovement : Movement
    {
        private Boss boss;
        private Player player;

        private float deltaX = 0;
        private float deltaY = 0;

        public BossMovement(float speed, Boss boss, Player player)
            : base(speed)
        {
            this.boss = boss;
            this.player = player;
        }

        public override void Update()
        {
            deltaX = 0;
            deltaY = 0;

            Vector2 direction = player.Position - boss.Position;

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
