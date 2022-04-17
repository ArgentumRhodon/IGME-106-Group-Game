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

        //Constructor
        public MeleeEnemy(Texture2D sprite, Vector2 startPos, Player player) :
            base(sprite, startPos, player)
        {
            movement = new MeleeEnemyMovement(6, this, player);
            health = 1;
        }

        // Methods
        public override void Update(GameObjectHandler gameObjectHandler)
        {
            base.Update(gameObjectHandler);
        }

        public override void HandleCollision(GameObject other)
        {
            base.HandleCollision(other);
        }
    }
}
