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
        private Boss boss;
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
        private List<GameObject> Walls => gameObjects.FindAll(gameObject => gameObject is WallEntity);

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

            if(Enemies.Count <= 0)
            {
                if(state.Wave < 5)
                {
                    UpdateEnemyCount(state);
                    state.Wave++;
                }
                else
                {
                    if (boss == null)
                    {
                        state.Wave++;
                        gameObjects.Add(boss = new Boss(Assets.Textures["monocrome"], new Vector2(60, 60), player));
                        state.SetBossWave();
                    }
                }
            }
        }

        private void UpdateGameObjects(GameState state)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(this);

                if (gameObject is IEntity)
                {
                    if (!(gameObject is Player || gameObject is Projectile))
                    {
                        ((IEntity)gameObject).HealthBar.Update();
                    }
                }
            }

            foreach (RangedEnemy rangedEnemy in RangedEnemies)
            {
                if (rangedEnemy.FireDelay <= 0)
                {
                    AddEnemyProjectile(Assets.Textures["enemyStar"], GetRandomRangedEnemyPosition(), player.Position);
                }
            }

            if (gameObjects.Contains(boss) && boss.State == BossState.Ranged)
            {
                if (boss.FireDelay <= 0)
                {
                    ShootBossProjectile();
                }
            }

            enemyFireTime--;
        }

        private Texture2D GetTexture(GraphicsDevice gd)
        {
            Texture2D healthBar = new Texture2D(gd, 1, 1);
            healthBar.SetData(new[] { Color.White });
            return healthBar;
        }

        private void ShootBossProjectile()
        {
            int spreadFactor = 120;
            Vector2 spread = new Vector2(rng.Next(-spreadFactor, spreadFactor), rng.Next(-spreadFactor, spreadFactor));
            AddEnemyProjectile(Assets.Textures["bossStar"], boss.Center, player.Position + spread);
        }

        private Vector2 GetRandomRangedEnemyPosition()
        {
            int index = rng.Next(0, RangedEnemies.Count);
            return ((RangedEnemy)RangedEnemies[index]).Position;
        }

        public void AddPlayerProjectile(Texture2D sprite, Vector2 p1, Vector2 p2)
        {
            if (player.FireDelay <= 0)
            {
                gameObjects.Add(new Projectile(sprite, p1, p2, false, 18));
                player.FireDelay = 15;
            }
        }

        private void AddEnemyProjectile(Texture2D sprite, Vector2 p1, Vector2 p2)
        {
            gameObjects.Add(new Projectile(sprite, p1, p2, true, 15));
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice gd)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);

                if (gameObject is IEntity)
                {
                    if (!(gameObject is Player || gameObject is Projectile))
                    {
                        spriteBatch.Draw(GetTexture(gd), ((IEntity)gameObject).HealthBar.Bounds, new Color(255, 86, 203));
                    }
                }
            }
        }

        public List<GameObject> GetCollidingObjects(GameObject check)
        {
            return gameObjects.FindAll(gameObject => gameObject != check && gameObject.NextCollisionBox.Intersects(check.NextCollisionBox));
        }

        private void HandleDeadEntities()
        {
            List<GameObject> entities = Entities;
            for (int i = 0; i < entities.Count; i++)
            {
                if (((IEntity)entities[i]).Health <= 0)
                {
                    gameObjects.Remove(entities[i]);
                }
            }
        }

        private void UpdateEnemyCount(GameState state)
        {
            Rectangle leftSpawn = new Rectangle(60, 60, (int)player.Position.X - 200, 900);
            Rectangle rightSpawn = new Rectangle((int)player.Position.X + 260, 60, 1600 - (int)player.Position.X, 900);

            while (Enemies.Count < 5 + state.Wave * 3)
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

                #region NormalEnemySpawning
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
                #endregion
            }
        }
    }
}
