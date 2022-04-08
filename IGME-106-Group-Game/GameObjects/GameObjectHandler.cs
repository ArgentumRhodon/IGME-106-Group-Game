﻿using IGME106GroupGame.GameObjects;
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
        private List<Enemy> enemies;
        private List<Projectile> projectiles;

        private Texture2D enemyTexture;

        public Player Player => player;

        // Constructor
        public GameObjectHandler(Texture2D playerTexture, Texture2D enemyTexture)
        {
            this.enemyTexture = enemyTexture;

            // Uses the same sprite, enemy just tints it red
            this.player = new Player(playerTexture, new Vector2(930, 510));
            this.enemies = new List<Enemy>();
            this.projectiles = new List<Projectile>();
        }

        // Methods
        public void Update(GameState state)
        {
            // Update the player
            player.Update();

            // Update enemies
            foreach(Enemy enemy in enemies)
            {
                enemy.Update(enemy.Position, player.Position);
            }

            // Update Projectiles
            foreach(Projectile proj in projectiles)
            {
                proj.Update();
            }
            if (state.MouseManager.MouseClicked())
            {
                projectiles.Add(new Projectile(state.Game.Assets.Get("projectile"), player.Position, state.MouseManager.Position - new Vector2(30, 30))); 
                                                  
            }

            HandleCollisions(state);

            UpdateEnemyCount();
        }

        public void AddProjectile(State state)
        {
            projectiles.Add(new Projectile(state.Game.Assets.Get("projectile"), player.Position, state.MouseManager.Position - new Vector2(30, 30)));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the player
            player.Draw(spriteBatch);

            // Draw enemies
            foreach(Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }

            // Draw projectiles
            foreach(Projectile proj in projectiles)
            {
                proj.Draw(spriteBatch);
            }
        }

        private void HandleCollisions(GameState state)
        {
            HandleEnemyProjectileCollisions();
            if(!state.GodModeEnabled)
            {
                HandleEnemyPlayerCollisions();
            }
            HandleDeadEntities();
        }

        private void HandleEnemyProjectileCollisions()
        {
            // Check each of the enemies
            for(int i = 0; i < enemies.Count; i++)
            {
                // Against each projectile
                for (int j = 0; j < projectiles.Count; j++)
                {
                    // If it hits
                    if (enemies[i].CollisionBox.Intersects(projectiles[j].CollisionBox))
                    {
                        // Enemy takes damage
                        enemies[i].Health -= projectiles[j].Damage;
                        // Projectile is removed
                        projectiles[j].Health--;
                    }
                }
            }
        }

        private void HandleEnemyPlayerCollisions()
        {
            // Check each enemy
            for (int i = 0; i < enemies.Count; i++)
            {
                // Against the player
                if (enemies[i].CollisionBox.Intersects(player.CollisionBox))
                {
                    // Player takes damage
                    if(player.IFrames == 0)
                    {
                        player.Health--;
                        player.ActivateIFrames(30);
                    }
                }
            }
        }

        private void HandleDeadEntities()
        {
            // Remove dead enemies
            for(int i = 0; i < enemies.Count; i++)
            {
                if(enemies[i].Health <= 0)
                {
                    enemies.RemoveAt(i);
                }
            }

            // Remove dead projectiles
            for(int j = 0; j < projectiles.Count; j++)
            {
                if(projectiles[j].Health <= 0)
                {
                    projectiles.RemoveAt(j);
                }
            }
        }

        private void UpdateEnemyCount()
        {
            Rectangle leftSpawn = new Rectangle(60, 60, (int)player.Position.X - 200, 900);
            Rectangle rightSpawn = new Rectangle((int)player.Position.X + 260, 60, 1600 - (int)player.Position.X, 900);

            while (enemies.Count < 15)
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

                enemies.Add(new Enemy(enemyTexture, randomPosition, player.Position));
            }
        }
    }
}
