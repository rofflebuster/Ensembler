﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Audio;

namespace EnsemPro
{
    public class DialogController
    {
        GameState gameState;
        SpriteBatch spriteBatch;
        ContentManager contentManager;

        Queue<String> names;
        Queue<String> lines;
        Queue<String> colors;

        String speaker;
        String speech;
        String color;

        DialogModel dialogModel;
        DialogView screen;
        //DataTypes.WorldData.CityState nodeState;
        KeyboardState lastState;
        SoundEffect NextDialog;
        SoundEffect ReceiveItem;

        bool IsFinished;

        public DialogController(GameState gm, SpriteBatch sb, DialogModel dm, string cityName)
        {
            gameState = gm;
            spriteBatch = sb;
            dialogModel = dm;

            names = new Queue<String>();
            lines = new Queue<String>();
            colors = new Queue<String>();
            Parse();
            speaker = "";
            speech = cityName;
            screen = new DialogView(sb);

        }

        public void Initialize()
        {
            IsFinished = false;

        }

        public void LoadContent(ContentManager cm)
        {
            screen.LoadContent(cm);
            NextDialog = cm.Load<SoundEffect>("Sounds//NextDialog");
            ReceiveItem = cm.Load<SoundEffect>("Sounds//ReceiveItem");
            contentManager = cm;
        }

        public void UnloadContent() 
        {
            contentManager.Unload();
        }

        private void Parse()
        {
            for (int i = 0; i< dialogModel.Content.Length; i++)
            {
                names.Enqueue(dialogModel.Content[i].Character);
                lines.Enqueue(dialogModel.Content[i].Line);
               // colors.Enqueue(dialogModel.Content[i].Color);
            }
            /*
            switch (nodeState)
            {
                case DataTypes.WorldData.CityState.NewlyUnlocked:
                    for (int i = 0; i < dialogModel.NewlyUnlocked.Length; i++)
                    {
                        names.Enqueue(dialogModel.NewlyUnlocked[i].Character);
                        lines.Enqueue(dialogModel.NewlyUnlocked[i].Line);
                    }
                    break;
                case DataTypes.WorldData.CityState.Unlocked:
                    for (int i = 0; i < dialogModel.Unlocked.Length; i++)
                    {
                        names.Enqueue(dialogModel.Unlocked[i].Character);
                        lines.Enqueue(dialogModel.Unlocked[i].Line);
                    }
                    break;
                case DataTypes.WorldData.CityState.Cleared:
                    for (int i = 0; i < dialogModel.Cleared.Length; i++)
                    {
                        names.Enqueue(dialogModel.Cleared[i].Character);
                        lines.Enqueue(dialogModel.Cleared[i].Line);
                    }
                    break;
                default:
                    break;
            }
            */
        }

        public bool Finished() { return IsFinished; }

        public void Update(GameTime t)
        {
            KeyboardState ks = Keyboard.GetState();
            if (names.Count == 0 && ks.IsKeyDown(Keys.Right) && lastState.IsKeyUp(Keys.Right)) // end of this dialog mode, move on to playlevel or map
            {
               
                IsFinished = true;
            }
            else
            {
                if (ks.IsKeyDown(Keys.Right) && lastState.IsKeyUp(Keys.Right))
                {
                    NextDialog.Play();
                    speaker = names.Dequeue();
                    speech = lines.Dequeue();
                    if (speech[0] == '*') ReceiveItem.Play();
                    string firstPart = "";
                    string secondPart = speech;
                    while (secondPart.Length > 55)
                    {
                        string subSpeech = secondPart.Substring(0,55);
                        int lastSpace = subSpeech.LastIndexOf(" ");
                        firstPart = firstPart + secondPart.Substring(0, lastSpace) + "\n";
                        secondPart = secondPart.Substring(lastSpace, secondPart.Length - lastSpace);
                    }
                    speech = firstPart + secondPart;
                }
                lastState = ks;
            }
        }

        /// <summary>
        /// Command all related views to draw.
        /// </summary>
        /// <param name="t"></param>
        public void Draw(GameTime t)
        {
            screen.Draw(t,speaker,speech);
        }
    }
}