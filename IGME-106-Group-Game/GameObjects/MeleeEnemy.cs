using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.GameObjects
{
    public class MeleeEnemy : Enemy
    {
        public int Health { get => health; set => health = value; }
        public int Health { get => health; set => health = value; }
        public int Health { get => health; set => health = value; }

        //Constructor
        public MeleeEnemy(Texture2D sprite, Vector2 startPos, Player player) :
            base(sprite, startPos, player)
        {
            movement = new MeleeEnemyMovement(5, this, player);
            health = 1;
        }

        // Methods
        public override void Update(GameObjectHandler gameObjectHandler)
        {
            position += movement.Vector;
            //fireDelay--;
            //-1 so there's a frame where it actually equals 0 for the handler to check
            //if(fireDelay <= -1)
            //{
            //    fireDelay = rng.Next(45, 315);
            //}
        }

            //if(fireDelay <= -1)
            //{
            //    fireDelay = rng.Next(45, 315);
            //}
        }

            //if(fireDelay <= -1)
            //{
            //    fireDelay = rng.Next(45, 315);
            //}
        }

            //if(fireDelay <= -1)
            //{
            //    fireDelay = rng.Next(45, 315);
            //}
        }

            //}
        }

        public override void HandleCollision(GameObject other)
        {
            base.HandleCollision(other);
        }
    }
}
