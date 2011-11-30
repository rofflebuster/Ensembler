﻿using Microsoft.Xna.Framework.Content;

namespace EnsemPro
{
    public class DialogModel
    {
        private string DialogFileName;

        public DataTypes.ContentSummary[] Content
        {
            get;
            set;
        }

        public DataTypes.ColorSummary[] Colors
        {
            get;
            set;
        }

        public DataTypes.FaceTexturePath[] Faces
        {
            get;
            set;
        }

        public DataTypes.CutSceneSummary[] CutScenes
        {
            get;
            set;
        }
        public string getName(){return DialogFileName;}

        public DialogModel(string filename)
        {
            DialogFileName = filename;
        }

        public void LoadContent(ContentManager cm)
        {
            Content = cm.Load<DataTypes.DialogData>("Dialogs//" + DialogFileName).Content;
            Colors = cm.Load<DataTypes.DialogData>("Dialogs//" + DialogFileName).Colors;
            Faces = cm.Load<DataTypes.DialogData>("Dialogs//" + DialogFileName).Faces;
            CutScenes = cm.Load<DataTypes.DialogData>("Dialogs//" + DialogFileName).CutScenes;
        }
    }
}
