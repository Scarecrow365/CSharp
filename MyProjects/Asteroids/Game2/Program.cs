﻿using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;


namespace Game2
{
    static class Program
    {
        static void Main()
        {
            Form form = new Form();
            {
                form.Width = 800;
                form.Height = 600;
            }
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }    
}



