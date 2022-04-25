using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.States;
using IGME106GroupGame.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.GameObjects
{
    public enum BossState
    {
        Melee,
        Ranged
    }


    public class Boss : Enemy
    {
        private BossState state;

        private Random random;
        private Player player;
        private int fireDelay;

        private int stateSwitchTimer;
        public int FireDelay { get { return fireDelay; } set { fireDelay = value; } }
        public BossState State => state;

        public Boss(Texture2D sprite, Vector2 startPos, Player player)
            : base(sprite, startPos, player)
        {
            this.player = player;
            movement = new RangedEnemyMovement(4, this, player, 100);
            health = 200;
            healthBar = new HealthBar(this, health);
            random = new Random();
            stateSwitchTimer = random.Next(120, 180);
        }

        public override void Update(GameObjectHandler gameObjectHandler)
        {
            base.Update(gameObjectHandler);

            stateSwitchTimer--;
            if (stateSwitchTimer == 0)
            {
                ChangeState();
                stateSwitchTimer = random.Next(300, 600);
            }

            if(state == BossState.Ranged)
            {
                fireDelay--;
                if (fireDelay == -1)
                {
                    fireDelay = random.Next(2, 5);
                }
            }
        }

        public override void HandleCollision(GameObject other)
        {
            if (other is Projectile && !((Projectile)other).IsEnemyProjectile && ((Projectile)other).CurrentEnemy != this)
            {
                health--;
            }

            if (other is WallCollider)
            {
                //Vector2 direction = position - collisionPosition;
                //direction.Normalize();
                //movement.Vector = direction;

                movement.Stop(WillCollideX(other), WillCollideY(other));
            }
        }

        private void ChangeState()
        {
            if(state == BossState.Melee)
            {
                state = BossState.Ranged;
                movement = new RangedEnemyMovement(4, this, player, 100);
                fireDelay = 90;
            }
            else
            {
                state = BossState.Melee;
                movement = new MeleeEnemyMovement(8, this, player);
            }
        }
    }
}
