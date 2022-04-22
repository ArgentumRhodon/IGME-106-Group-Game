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
        private Powerup pickup;
        private int enemCount;
        private List<GameObject> gameObjects;

        public Player Player => player;
        public List<GameObject> GameObjects
        {
            get => gameObjects;
            set => gameObjects = value;
        }
        private List<GameObject> Enemies => gameObjects.FindAll(gameObject => gameObject is Enemy);
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
            this.enemCount = 5;
            this.pickup = null;
            // Uses the same sprite, enemy just tints it red
            gameObjects = new List<GameObject>();
            
            gameObjects.Add(player);
        }


        // Methods
        public void Update(GameState state)
        {
            HandleCollectedPickups();
            UpdateGameObjects(state);
            HandleDeadEntities();
            UpdateEnemyCount();
        }

        private void UpdateGameObjects(GameState state)
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Update(this);
            }

            foreach (Projectile proj in Projectiles)
            {
                if (proj.Position.X < 0 || proj.Position.X > 1920 || proj.Position.Y < 0 || proj.Position.Y > 1920)
                {
                    proj.Health = 0;
                }
            }
            foreach (RangedEnemy rangedEnemy in RangedEnemies)
            {
                if(rangedEnemy.FireDelay <= 0)
                {
                    AddEnemyProjectile(Assets.Textures["enemyStar"], GetRandomRangedEnemyPosition(), player.Position);
                }
            }

            enemyFireTime--;
        }

        private Vector2 GetRandomRangedEnemyPosition()
        {
            int index = rng.Next(0, RangedEnemies.Count);
            return ((RangedEnemy)RangedEnemies[index]).Position;
        }

        public void AddPlayerProjectile(Texture2D sprite, Vector2 p1, Vector2 p2)
        { 
             gameObjects.Add(new Projectile(sprite, p1, p2, false, 18));
        }

        private void AddEnemyProjectile(Texture2D sprite, Vector2 p1, Vector2 p2)
        {
            gameObjects.Add(new Projectile(sprite, p1, p2, true, 15));
        }

        public void AddPickup(State state)
        {
            pickup = new Powerup(Assets.Textures["smallHeart"], new Vector2(rng.Next(100, 1800), rng.Next(100, 900)));
            gameObjects.Add(pickup);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
            if(pickup != null)
            {
                pickup.Draw(spriteBatch);
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

        private void HandleCollectedPickups()
        {
            //this removes the pickup if it's been collected
            if (pickup != null && pickup.IsCollected)
            {
                gameObjects.Remove(pickup);
                pickup = null;
            }
        }
        private void UpdateEnemyCount()
        {
            Rectangle leftSpawn = new Rectangle(60, 60, (int)player.Position.X - 200, 900);
            Rectangle rightSpawn = new Rectangle((int)player.Position.X + 260, 60, 1600 - (int)player.Position.X, 900);

            while (Enemies.Count < 7)
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
                    gameObjects.Add(new RangedEnemy(Assets.Textures["ninja"], randomPosition, player));
                }
                // 50-50 chance of melee being ninja or slimebot
                else if (rng.Next(0, 2) == 0)
                {
                    gameObjects.Add(new MeleeEnemy(Assets.Textures["meleeNinja"], randomPosition, player));
                }
                else
                {
                    gameObjects.Add(new MeleeEnemy(Assets.Textures["slimeBot"], randomPosition, player));
                }
                enemCount--;
            }
        }
    }
}
