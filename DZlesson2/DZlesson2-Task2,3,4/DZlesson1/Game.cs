using System;
using System.Windows.Forms;
using System.Drawing;

namespace DZlesson1
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static Image cat = Image.FromFile("Cat.jpg");



        public static int Width { get; set; }               //Свойства       
        public static int Height { get; set; }               //Ширина и высота поля
        public static BaseObject[] _objs;
        public static Asteroid[] _asteroids;
        public static Bullet _bullet;

        public static int screenWidth;
        public static int screenHeight;

        public static void Load()
        {
            Random rnd = new Random();
            int rndSize;

            screenWidth = Screen.PrimaryScreen.Bounds.Width;
            screenHeight = Screen.PrimaryScreen.Bounds.Height;

            _objs = new BaseObject[100];


            /// <summary>
            /// генерируем количество объектов, скорость, направление
            /// </summary>
            for (int i = 0; i < _objs.Length / 2; i++)
            {
                rndSize = rnd.Next(1, 20);
                _objs[i] = new StarImg(new Point(rnd.Next(1, screenWidth - 1), rnd.Next(1, screenHeight - 1)), new Point(rnd.Next(-20, 20), 0), new Size(rndSize, rndSize));
            }

            for (int i = _objs.Length / 2; i < _objs.Length; i++)
            {
                rndSize = rnd.Next(1, 20);
                _objs[i] = new Star(new Point(rnd.Next(1, screenWidth - 1), rnd.Next(1, screenHeight - 1)), new Point(i, 0), new Size(5,5));
            }

            _asteroids = new Asteroid[30];
            for (int i = 0; i < _asteroids.Length;i++)
            {
                _asteroids[i] = new Asteroid(new Point(screenWidth - 30, rnd.Next(1, screenHeight - 1)), new Point(rnd.Next(-10, 0), 0), new Size(30, 30));
            }

            _bullet = new Bullet(new Point(1, screenHeight / 2), new Point(50, 0), new Size(50, 50));

        }

        static Game()
        {

        }

        /// <summary>
        /// описываем графику, разрешение, вызываем метод "Load" и задаем интервал таймера
        /// </summary>
        /// <param name="form"></param>
        public static void Init (Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 75 };
            timer.Start();
            timer.Tick += Timer_Tick;

 
        }

        /// <summary>
        /// устонавливаем картинку на задний фон, добавляем объекты.
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.DrawImage(cat, 0, 0, 1920, 1080);

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            _bullet.Draw();
            Buffer.Render();
        }


        /// <summary>
        /// 
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (Asteroid a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _bullet.CollisionOn();
                    a.CollisionOn();
                }
            }
            _bullet.Update();
            //ChekScreen();   // вызываем метод проверки экрана,  метод ниже..
        }     
        
        /// <summary>
        /// таймер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }


        /// <summary>
        /// проверка на соответствие экрана если превышенно то вызываем исключение. Закоменчено потому, что у меня экран FullHD, а экран подстраивается под пользователя.
        /// </summary>
        //public static void ChekScreen()
        //{
        //    if(screenWidth < 0 || screenWidth > 1000 || screenHeight < 0 || screenHeight > 1000)
        //    {
        //        throw new ArgumentOutOfRangeException("Danger");
        //    }
        //}

    }
}
