using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Dangerous_Space
{
    public class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        private static Timer _timer;
        private static Timer _timerShot;
        private static bool _canShoot = true;

        private static Star[] _stars;
        private static List<Bullet> _bullet = new List<Bullet>();
        private static Asteroid[] _asteroids;
        private static Ship _ship;
        private static Energy _energy;
        private static int _energyBoost = 30;
        private static int _bulletSpeed = 20;
        private static int _crashEnemyCount;
        private static int _enemyCount;
        private static int _wave = 1;

        private static Action<string> _logLine = Logs.ConsoleMessage;

        public static int widthPlayingField { get; set; }
        public static int heightPlayingField { get; set; }

        public static void Init(Form form)
        {
            Graphics graphics;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            graphics = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            widthPlayingField = form.ClientSize.Width;
            heightPlayingField = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(graphics, new Rectangle(0, 0, widthPlayingField, heightPlayingField));


            _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(20, 20));

            _timerShot = new Timer { Interval = 400};
            _timerShot.Start();
            _timerShot.Tick += CanShoot;

            _timer = new Timer {Interval = 40};
            _timer.Start();
            _timer.Tick += Timer_Tick;
            Ship.MessageDie += Finish;

            form.KeyDown += Form_KeyDown;
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey && _canShoot)
            {
                _bullet.Add(new Bullet(new Point(_ship.rect.X + 10, _ship.rect.Y + 10), new Point(_bulletSpeed, 0),
                    new Size(8, 3)));
                _canShoot = false;
            }

            if(e.KeyCode == Keys.Down)
                _ship.Down();
            if(e.KeyCode == Keys.Up)
                _ship.Up();

        }

        private static void CanShoot(object sender, EventArgs e)
        {
            _canShoot = true;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void CreateAsteroids(int countAsteroids)
        {
            Random random = new Random();
            _asteroids = new Asteroid[countAsteroids];
            _enemyCount = _asteroids.Length;
            _logLine($"We need destroy {_enemyCount} asteroids");

            for (var i = 0; i < _asteroids.Length; i++)
            {
                var randomNum = random.Next(5, 10);
                _asteroids[i] = new Asteroid(
                    new Point(widthPlayingField, random.Next(0, heightPlayingField)),
                    new Point(randomNum, randomNum),
                    new Size(25, 25));
            }
        }

        public static void Load()
        {
            Random random = new Random();

            _stars = new Star[70];
            CreateAsteroids(3);
            _energy = new Energy(new Point(random.Next(widthPlayingField, widthPlayingField),
                    random.Next(0, heightPlayingField)),
                new Point(random.Next(5, 20), 0),
                new Size(10, 10));

            for (var i = 0; i < _stars.Length; i++)
            {
                _stars[i] = new Star(
                    new Point(random.Next(0, widthPlayingField), 
                                  random.Next(0, heightPlayingField)),
                    new Point(random.Next(5, 20), 0),
                        new Size(5, 5));
            }
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (Star star in _stars)
                star.Draw();
            foreach (Asteroid asteroid in _asteroids)
                asteroid?.Draw();
            foreach (Bullet bullet in _bullet) 
                bullet?.Draw();


            _ship?.Draw();
            _energy?.Draw();

            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy: " + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString("Asteroids: " + _crashEnemyCount, SystemFonts.DefaultFont, Brushes.White, 0,15);
                Buffer.Graphics.DrawString("Wave: " + _wave, SystemFonts.DefaultFont, Brushes.White, 0,30);
            }

            Buffer.Render();
        }

        public static void Update()
        {
            foreach (Star star in _stars)
                star.Update();
            foreach (Bullet bullet in _bullet)
                bullet.Update();

            if (_enemyCount <= 2)
                _energy?.Update();

            for (int numOfAsteroid = 0; numOfAsteroid < _asteroids.Length; numOfAsteroid++)
            {
                if(_asteroids[numOfAsteroid] == null)continue;
                _asteroids[numOfAsteroid].Update();

                for (int numOfBullet = 0; numOfBullet < _bullet?.Count; numOfBullet++)
                {
                    if (_asteroids[numOfAsteroid] != null && _bullet[numOfBullet].Collision(_asteroids[numOfAsteroid]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _asteroids[numOfAsteroid] = null;
                        _bullet.RemoveAt(numOfBullet);
                        numOfBullet--;
                        _enemyCount--;
                        _crashEnemyCount++;
                        _logLine($"We need destroy {_enemyCount} asteroids");
                    }

                    if (_enemyCount < 1)
                    {
                        _logLine($"Awesome {_wave} wave is completed");
                        CreateAsteroids(3 + _wave);
                        _wave++;
                        
                    }
                }

                if (_asteroids[numOfAsteroid] == null || _ship.Collision(_asteroids[numOfAsteroid]))
                {
                    Random random = new Random();
                    int damage = 0;
                    _ship?.GetDamage(damage = random.Next(1, 10));
                    _logLine($"Our spaceship get damage = {damage}");
                    System.Media.SystemSounds.Beep.Play();
                    if (_ship.Energy < 1)
                        _ship.Die();
                }

                if (_energy != null && _energy.Collision(_ship))
                {
                    _ship?.GetDamage(-_energyBoost);
                    _energy = null;
                    _logLine($"Get {_energyBoost} hp");
                }
            }
        }

        public static void Finish()
        {
            _logLine("Our spaceship is dead");
            _timer.Stop();
            Buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Italic),
                Brushes.White, 200, 100);
            Buffer.Render();
        }
    }
}