using IGME106GroupGame.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.MovementAndAI
{
    public class MeleeEnemyMovement : EnemyMovement
    {

        public MeleeEnemyMovement(float speed, Enemy enemy, Player player)
            : base(speed, enemy, player)
        {
        }

        public override void Update()
        {
            base.Update(); 
        }
    }
}
