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
        private bool godMode;
        private PauseUI pauseUI;
        private DeathUI deathUI;

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        private MouseState currentMouseState;
        private MouseState previousMouseState;

        /// <summary>
        /// This boolean will be used to check if the game is paused
        /// </summary>
        public bool IsPaused
        {
            get => paused;
            set => paused = value;
        }

        // Constructor
        /// <summary>
        /// This constructor will instantiate a new GameState object
        /// </summary>
        /// <param name="game"></param>
        /// <param name="godMode">true for no health, false for regular game</param>
        public GameState(Game1 game, bool godMode = false)
            : base(game)
        {
            this.godMode = godMode;
            paused = false;
            level = new Level(game.Content);
            player = new Player(game.Content.Load<Texture2D>("base"), new Vector2(930, 510));
            enemyTexture = game.Content.Load<Texture2D>("base");
            enemies = new List<Enemy>();
            projectiles = new List<Projectile>();

            ui = new GameUI(game, player);
            pauseUI = new PauseUI(game);
            deathUI = new DeathUI(game);
        }

        // Methods
        /// <summary>
        /// This method will make sure there are 15 enemies that are alive, and if not then add new enemies
        /// </summary>
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

        /// <summary>
        /// This method deals with general game updates that exist in the GameState
        /// </summary>
        public override void Update()
        {
            base.Update();

            HandleCollisions();

            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            if (NewKeyPressed(Keys.E) && player.Health > 0)
            {
                paused = !paused;
            }

            //GameState logic
            if (!paused && player.Health > 0)
            {
                if (LeftMouseNewlyClicked()) // if there is a left click, make a projectile
                {
                    projectiles.Add(new Projectile(game.Content.Load<Texture2D>("base"),
                                                   player.Position,
                                                   new Vector2(currentMouseState.X, currentMouseState.Y) - player.Position - new Vector2(30, 30)));
                }

                level.Update();
                player.Update();

                // Updating objects
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

            // Detecting player death
            else if(!paused && player.Health <= 0)
            {
                deathUI.Update(this);
            }
            else
            { 
                pauseUI.Update(this);
            }

            CreateEnemies();

            previousKeyboardState = currentKeyboardState;
            previousMouseState = currentMouseState;
        }

        /// <summary>
        /// This method will check for collisions between enemies, projectiles, and player
        /// </summary>
        private void HandleCollisions()
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                for(int j = 0; j < projectiles.Count; j++)
                {
                    // Enemy - Projectile Collosions
                    if (enemies[i].CollisionBox.Intersects(projectiles[j].CollisionBox))
                    {
                        enemies[i].TakeDamage(projectiles[j].Damage);
                        projectiles.RemoveAt(j);
                        if(enemies[i].Health <= 0)
                        {
                            enemies.RemoveAt(i);
                            return;
                        }
                    }
                }
                // Enemy - Player collisions
                if(enemies[i].CollisionBox.Intersects(player.CollisionBox))
                {
                    if(!(player.IFrames > 0) && !godMode)
                    {
                        player.Health--;
                    }
                    player.ActivateIFrames(60);
                }
            }
        }

        /// <summary>
        /// This method will check to see if a key has just been pressed
        /// </summary>
        /// <param name="key">The key that was pressed</param>
        /// <returns>true if fresh press, false otherwise</returns>
        private bool NewKeyPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && !previousKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// This method will check for a single mouse click
        /// </summary>
        /// <returns>true if fresh click, false otherwise</returns>
        private bool LeftMouseNewlyClicked()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed && !(previousMouseState.LeftButton == ButtonState.Pressed);
        }

        /// <summary>
        /// This method will draw enemies, projectiles, and the player to the screen, and also draw UI when applicable
        /// </summary>
        /// <param name="_spriteBatch"></param>
        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);

            // GameState rendering
            level.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            ui.Draw(_spriteBatch);

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

            if(player.Health <= 0)
            {
                _spriteBatch.Draw(game.Content.Load<Texture2D>("base"), new Rectangle(0, 0, 1920, 1080), new Color(0, 0, 0, 150));
                deathUI.Draw(_spriteBatch);
            }
        }
    }
}
