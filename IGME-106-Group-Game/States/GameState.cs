using IGME106GroupGame.GameObjects;
using IGME106GroupGame.Levels;
using IGME106GroupGame.UI.Menus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.States
{
    class GameState : State
    {
        // Fields
        private Player player;
        private Texture2D enemyTexture;
        private List<Enemy> enemies;
        private List<Projectile> projectiles;

        private Level level;
        private bool paused;
        private PauseUI pauseUI;

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        private MouseState currentMouseState;
        private MouseState previousMouseState;

        public bool IsPaused
        {
            get => paused;
            set => paused = value;
        }

        // Constructor
        public GameState(Game1 game)
            : base(game)
        {
            paused = false;
            level = new Level(game.Content);
            player = new Player(game.Content.Load<Texture2D>("base"), new Vector2(930, 510));
            enemyTexture = game.Content.Load<Texture2D>("base");
            enemies = new List<Enemy>();
            projectiles = new List<Projectile>();

            ui = new GameUI(game, player);
            pauseUI = new PauseUI(game);
        }

        // Methods
        private void CreateEnemies()
        {
            Rectangle leftSpawn = new Rectangle(0, 0, (int)player.Position.X - 200, 1080);
            Rectangle rightSpawn = new Rectangle((int)player.Position.X + 260, 0, 1920, 1080);
            
            while(enemies.Count < 15)
            {
                Vector2 randomPosition = new Vector2(-1,-1);

                while(
                      !leftSpawn.Contains(new Rectangle((int)randomPosition.X, (int)randomPosition.Y, 60, 60))
                      && !rightSpawn.Contains(new Rectangle((int)randomPosition.X, (int)randomPosition.Y, 60, 60))
                    )
                {
                    randomPosition.X = (new Random()).Next(0, 1860);
                    randomPosition.Y = (new Random()).Next(0, 1020);
                }

                enemies.Add(new Enemy(enemyTexture, randomPosition));
            }
        }

        public override void Update()
        {
            base.Update();

            HandleCollisions();

            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            if (NewKeyPressed(Keys.E))
            {
                paused = !paused;
            }

            //GameState logic
            if (!paused)
            {
                if (LeftMouseNewlyClicked())
                {
                    projectiles.Add(new Projectile(game.Content.Load<Texture2D>("base"),
                                                   player.Position,
                                                   new Vector2(currentMouseState.X, currentMouseState.Y) - player.Position - new Vector2(30, 30)));
                }

                level.Update();
                player.Update();

                foreach(Enemy enemy in enemies)
                {
                    enemy.Update(player.Position);
                }
                foreach (Enemy enemy in enemies)
                {
                    enemy.Update(player.Position);
                }
                foreach (Projectile proj in projectiles)
                {
                    proj.Update();
                }
            }
            else
            { 
                pauseUI.Update(this);
            }

            CreateEnemies();

            previousKeyboardState = currentKeyboardState;
            previousMouseState = currentMouseState;
        }

        private void HandleCollisions()
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                for(int j = 0; j < projectiles.Count; j++)
                {
                    if (enemies[i].CollisionBox.Intersects(projectiles[j].CollisionBox))
                    {
                        enemies[i].TakeDamage(projectiles[j].Damage);
                        projectiles.RemoveAt(j);
                        if(enemies[i].Health <= 0)
                        {
                            enemies.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        private bool NewKeyPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && !previousKeyboardState.IsKeyDown(key);
        }

        private bool LeftMouseNewlyClicked()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed && !(previousMouseState.LeftButton == ButtonState.Pressed);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);

            // GameState rendering
            level.Draw(_spriteBatch);
            player.Draw(_spriteBatch);

            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(_spriteBatch);
            }
            foreach (Projectile proj in projectiles)
            {
                proj.Draw(_spriteBatch);
            }

            if (paused)
            {
                _spriteBatch.Draw(game.Content.Load<Texture2D>("base"), new Rectangle(0, 0, 1920, 1080), new Color(0,0,0,150));
                pauseUI.Draw(_spriteBatch);
            }
        }
    }
}
