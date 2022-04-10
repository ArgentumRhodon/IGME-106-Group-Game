using IGME106GroupGame.GameObjects;
using IGME106GroupGame.MovementAndAI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.States
{
    class GameObjectHandler
    {
        // Fields
        private Player player;
        private List<GameObject> gameObjects;

        private Texture2D enemyTexture;

        public Player Player => player;
        public List<GameObject> GameObjects
        {
            get => gameObjects;
            set => gameObjects = value;
        }
        private List<GameObject> Enemies => gameObjects.FindAll(gameObject => gameObject is Enemy);
        private List<GameObject> Projectiles => gameObjects.FindAll(gameObject => gameObject is Projectile);
        private List<GameObject> Entities => gameObjects.FindAll(gameObject => gameObject is IEntity);

        // Constructor
        public GameObjectHandler(Texture2D playerTexture, Texture2D enemyTexture, bool isGodMode)
        {
            this.enemyTexture = enemyTexture;

            // Uses the same sprite, enemy just tints it red
            this.player = new Player(playerTexture, new Vector2(930, 510), isGodMode);
            gameObjects = new List<GameObject>();

            gameObjects.Add(player);
        }

        // Methods
        public void Update()
        {
            UpdateGameObjects();
            HandleDeadEntities();
            UpdateEnemyCount();
        }

        private void UpdateGameObjects()
        {
            player.Update(this);

            foreach(Enemy enemy in Enemies)
            {
                enemy.Update(this, enemy.Position, player.Position);
            }

            foreach(Projectile projectile in Projectiles)
            {
                projectile.Update(this);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the player
            player.Draw(spriteBatch);

            // Draw enemies
            foreach (Enemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }

            // Draw projectiles
            foreach (Projectile proj in Projectiles)
            {
                proj.Draw(spriteBatch);
            }
        }

        public void AddProjectile(State state)
        {
            gameObjects.Add(new Projectile(state.Game.Assets.Get("projectile"), player.Position, state.MouseManager.Position - new Vector2(30, 30)));
        }

        public List<GameObject> GetCollidingObjects(GameObject check)
        {
            return gameObjects.FindAll(gameObject => gameObject != check && gameObject.NextCollisionBox.Intersects(check.NextCollisionBox));
        }

        private void HandleDeadEntities()
        {
            List<GameObject> entities = Entities;
            for(int i = 0; i < entities.Count; i++)
            {
                if(((IEntity)entities[i]).Health <= 0)
                {
                    gameObjects.Remove(entities[i]);
                }
            }
        }

        private void UpdateEnemyCount()
        {
            Rectangle leftSpawn = new Rectangle(60, 60, (int)player.Position.X - 200, 900);
            Rectangle rightSpawn = new Rectangle((int)player.Position.X + 260, 60, 1600 - (int)player.Position.X, 900);

            while (Enemies.Count < 15)
            {
                Vector2 randomPosition = new Vector2(-1, -1);

                while (
                      !leftSpawn.Contains(new Rectangle((int)randomPosition.X, (int)randomPosition.Y, 60, 60))
                      && !rightSpawn.Contains(new Rectangle((int)randomPosition.X, (int)randomPosition.Y, 60, 60))
                    )
                {
                    randomPosition.X = (new Random()).Next(60, 1800);
                    randomPosition.Y = (new Random()).Next(60, 900);
                }

                gameObjects.Add(new Enemy(enemyTexture, randomPosition, player.Position));
            }
        }
    }
}
