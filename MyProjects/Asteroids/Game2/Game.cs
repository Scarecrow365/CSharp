using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game2
{
    static class Game
    {

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        private static List<Bullet> _bullets = new List<Bullet>();
        public static Asteroid[] _asteroids;
        public static BaseObject[] _objs;
        private static Ship _ship;
        private static Heal[] _Hp;

        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();



        static Game()
        {
        }

        //метод инициализации буфера для вывода на форму
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = 90 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Load();
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
        }

        // Управление кораблём
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullets.Add(new Bullet(new Point(_ship.Rect.X
                + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1)));

            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        //Отрисовка игровых объектов
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
            {
                obj?.Draw();
            }

            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();
            }

            foreach (Heal obj in _Hp)
            {
                obj?.Draw();
            }

            foreach (Bullet b in _bullets)
                b.Draw();
            _ship?.Draw();

            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);

            Buffer.Render();
        }

        //Метод для изменения состояний объектов
        public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
            foreach (Bullet b in _bullets) b.Update();

            for (var i = 0; i < _Hp.Length; i++)
            {
                if (_Hp[i] == null) continue;
                _Hp[i].Update();

                if (!_ship.Collision(_Hp[i])) continue;
                {
                    _Hp[i] = null;
                }
                var rnd = new Random();
                _ship?.EnergyUp(rnd.Next(1, 5));
            }


            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();

                for (int j = 0; j < _bullets.Count; j++)
                    if (_asteroids[i] != null && _bullets[j].Collision(_asteroids[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _asteroids[i] = null;
                        _bullets.RemoveAt(j);
                        j--;
                    }
                if (_asteroids[i] == null || !_ship.Collision(_asteroids[i])) continue;
                var rnd = new Random();
                _ship?.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship?.Die();
            }
        }

        //Добавление в игру объектов, а также параметры и количество для этих же объектов
        public static void Load()
        {
            _Hp = new Heal[2];
            _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
            _objs = new BaseObject[100];
            _asteroids = new Asteroid[5];
            Random rnd = new Random();
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new
                Point(-r, r), new Size(3, 3));
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(15, 50);
                _asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Game.Height)),
                new Point(-r / 3, r), new Size(r, r));
            }
            for (var i = 0; i < _Hp.Length; i++)
            {
                int r = 10;
                _Hp[i] = new Heal(new Point(1000, rnd.Next(0, Game.Height)),
                new Point(-r / 3, r), new Size(r, r));
            }
        }

        //Поведение программы при окончании игры
        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);

            Buffer.Render();
        }

    }
}
