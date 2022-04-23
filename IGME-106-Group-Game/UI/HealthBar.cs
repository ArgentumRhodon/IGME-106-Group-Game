using IGME106GroupGame.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.UI
{
    public class HealthBar
    {
        private GameObject parent;
        private Rectangle bounds;
        private int maxHealth;
        private int health;

        public Rectangle Bounds => bounds;

        public HealthBar(GameObject parent, int maxHealth)
        {
            this.parent = parent;
            this.maxHealth = maxHealth;
            this.health = maxHealth;
        }

        public void Update()
        {
            if (this.parent != null)
            {
                bounds.X = (int)parent.Position.X;
                bounds.Y = (int)parent.Position.Y + parent.Sprite.Height + 5;
                bounds.Height = 10;
                bounds.Width = (int)(parent.Sprite.Width * (health / (float)maxHealth));

                health = ((IEntity)parent).Health;
            }
        }
    }
}
