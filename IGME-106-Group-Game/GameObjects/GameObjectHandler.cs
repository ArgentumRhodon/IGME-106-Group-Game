using IGME106GroupGame.GameObjects;
using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.States
{
    public class GameObjectHandler
    {
        //number of frames between when an enemy fires a projectile
        private int enemyFireTime;
        Random rng = new Random();
        // Fields
        private Player player;
        private List<GameObject> gameObjects;

        public Player Player => player;
        public List<GameObject> GameObjects
        {
            get => gameObjects;
            set => gameObjects = value;
        }
        private List<GameObject> Enemies => gameObjects.FindAll(gameObject => gameObject is RangedEnemy || gameObject is MeleeEnemy);
        private List<GameObject> RangedEnemies => gameObjects.FindAll(gameObject => gameObject is RangedEnemy);
        private List<GameObject> MeleeEnemies => gameObjects.FindAll(gameObject => gameObject is MeleeEnemy);
        private List<GameObject> Projectiles => gameObjects.FindAll(gameObject => gameObject is Projectile);
        private List<GameObject> Entities => gameObjects.FindAll(gameObject => gameObject is IEntity);

        // Constructor
        public GameObjectHandler(Player player)
        {
            this.enemyFireTime = 25;

            this.player = player;

            gameObjects = new List<GameObject>();
            gameObjects.Add(player);
        }

        // Methods
        public void Update(GameState state)
        {
            UpdateGameObjects(state);
            HandleDeadEntities();
            UpdateEnemyCount(state.Game.Assets);
        }

        private void UpdateGameObjects(GameState state)
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Update(this);
            }

            //to be removed for the random delay
            if(enemyFireTime <= 0 && RangedEnemies.Count > 0)
            {
                enemyFireTime = 25;
                AddProjectile(state.Game.Assets.Get("enemyStar"), GetRandomRangedEnemyPosition(), player.Position, true, 16);
            }

            enemyFireTime--;
        }

        private Vector2 GetRandomRangedEnemyPosition()
        {
            int index = rng.Next(0, RangedEnemies.Count);
            return ((RangedEnemy)RangedEnemies[index]).Position;
        }

        //public void AddProjectile(State state)
        //{
        //    gameObjects.Add(new Projectile(25, state.Game.Assets.Get("playerStar"), player.Position, state.MouseManager.Position - new Vector2(30, 30), false));
        //}

        //public void AddProjectile(State state, Enemy enem)
        //{
        //    gameObjects.Add(new Projectile(16, state.Game.Assets.Get("enemyStar"), enem.Position, player.Position, true));
        //}

        public void AddProjectile(Texture2D sprite, Vector2 p1, Vector2 p2, bool isEnemyProjectile, float speed)
        {
            gameObjects.Add(new Projectile(sprite, p1, p2, isEnemyProjectile, speed));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
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

        private void UpdateEnemyCount(Assets assets)
        {
            Rectangle leftSpawn = new Rectangle(60, 60, (int)player.Position.X - 200, 900);
            Rectangle rightSpawn = new Rectangle((int)player.Position.X + 260, 60, 1600 - (int)player.Position.X, 900);

            while (Enemies.Count < 1)
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

                //50 - 50 chance of spawning a ranged or melee enemy
                if (rng.Next(0, 2) == 0)
                {
                    gameObjects.Add(new RangedEnemy(assets.Get("ninja"), randomPosition, player));
                }
                // 50-50 chance of melee being ninja or slimebot
                else if (rng.Next(0, 2) == 0)
                {
                    gameObjects.Add(new MeleeEnemy(assets.Get("meleeNinja"), randomPosition, player));
                }
                else
                {
                    gameObjects.Add(new MeleeEnemy(assets.Get("slimeBot"), randomPosition, player));
                }
            }
        }
    }
}
