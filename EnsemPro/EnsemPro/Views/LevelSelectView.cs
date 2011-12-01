﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace EnsemPro
{
    class LevelSelectView
    {
        Texture2D background;
        SpriteBatch spriteBatch;
        Texture2D normalTexture;
        Texture2D selectedTexture;
        SpriteFont font;
        Song bgSong;
        GameState state;
        float offsetBottom;

        public LevelSelectView(SpriteBatch sb, GameState s)
        {
            spriteBatch = sb;
            state = s;
            offsetBottom = state.ViewPort.Height - 170;
        }

        public void LoadContent(ContentManager cm)
        {
            background = cm.Load<Texture2D>("Images//SelectionScreen//background");
            normalTexture = cm.Load<Texture2D>("Images//SelectionScreen//normalbox");
            selectedTexture = cm.Load<Texture2D>("Images//SelectionScreen//selectedbox");
            font = cm.Load<SpriteFont>("images//ScoreFont");
            bgSong = cm.Load<Song>("journey");
        }

        public void Draw(GameTime t, DataTypes.LevelSummary[] levels, int selected)
        {
            spriteBatch.Draw(background, new Vector2(), Color.White);
            for (int i = 0; i < levels.Length; i++)
            {
                spriteBatch.Draw(i == selected ? selectedTexture : normalTexture, new Rectangle(400, 120+i * 100, 400, 100), Color.White);
                spriteBatch.DrawString(font, levels[i].Title, new Vector2(450, 140+i*100), Color.Black);
            }
            
            // Draws data about the selected level
            spriteBatch.DrawString(font, "High Score: " + levels[selected].HighScore, new Vector2(10, offsetBottom - 150), Color.Black,0.0f,new Vector2(),0.8f,SpriteEffects.None,0.0f);
            spriteBatch.DrawString(font, "Developer High Score: " + levels[selected].DeveloperHighScore, new Vector2(10, offsetBottom - 100), Color.Black, 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(font, "High Combo: " + levels[selected].HighCombo, new Vector2(10, offsetBottom - 50), Color.Black, 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(font, "Developer High Combo: " + levels[selected].DeveloperHighCombo, new Vector2(10, offsetBottom), Color.Black, 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);
        }
    }
}
