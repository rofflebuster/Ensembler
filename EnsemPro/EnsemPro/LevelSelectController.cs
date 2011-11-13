﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace EnsemPro
{
    class LevelSelectController
    {
        GameModel gameState;
        SpriteBatch spriteBatch;

        ChooseLevelScreen levelSelectScreen;
        int selected = 0;
        KeyboardState lastState = Keyboard.GetState();

        SoundEffect MenuMove;
        SoundEffect MenuSelect;

        public LevelSelectController(GameModel gm, SpriteBatch sb)
        {
            gameState = gm;
            spriteBatch = sb;
            levelSelectScreen = new ChooseLevelScreen(sb);
        }

        public void Initialize()
        {

        }

        public void LoadContent(ContentManager cm)
        {
            levelSelectScreen.LoadContent(cm);
            MenuMove = cm.Load<SoundEffect>("Sounds//MenuMove");
            MenuSelect = cm.Load<SoundEffect>("Sounds//MenuSelect");
        }

        public void Update(GameTime t)
        {
            // todo: support for Wii and mouse
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down) && lastState.IsKeyUp(Keys.Down))
            {
                selected = (selected + 1) % gameState.Levels.Length;
                MenuMove.Play();
                
            }
            else if (ks.IsKeyDown(Keys.Up) && lastState.IsKeyUp(Keys.Up))
            {
                selected = (selected == 0) ? (gameState.Levels.Length - 1) : (selected - 1);
                MenuMove.Play();
            }
            else if (gameState.Input.Confirm)
            {
                MenuSelect.Play();
                gameState.CurrentScreen = DataTypes.Screens.PlayLevel;
                gameState.SelectedLevel = gameState.Levels[selected].AssetName;
                // gameState.Input.Confirm = false;
            }
            
            lastState = ks;
        }

        /// <summary>
        /// Command all related views to draw.
        /// </summary>
        /// <param name="t"></param>
        public void Draw(GameTime t)
        {
            levelSelectScreen.Draw(t, gameState.Levels, selected);
        }
    }
}
