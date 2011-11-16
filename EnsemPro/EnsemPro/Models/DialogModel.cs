﻿using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

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
        
        public DialogModel(string filename)
        {
            DialogFileName = filename;
        }

        public void LoadContent(ContentManager cm)
        {
            Content = cm.Load<DataTypes.DialogData>("Dialogs//" + DialogFileName).Content;
        }
    }
}