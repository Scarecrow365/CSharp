using System;
using System.Windows.Forms;

namespace Dangerous_Space
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Form form = new Form();

            form.Width = 800;
            form.Height = 600;
            if (form.Height >= 1000 || form.Width >= 1000)
            {
                throw new ArgumentOutOfRangeException("Wrong Resolution");
            }

            Game.Init(form);
            form.Show();
            Game.Load();
            Game.Draw();
            Application.Run(form);
        }
    }
}