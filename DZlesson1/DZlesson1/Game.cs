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

        //public static void Load()
        //{
        //    Random rnd = new Random();
        //    int rndSize;
        //    _objs = new BaseObject[100];
        //    for (int i = 0; i < _objs.Length; i++)
        //    {
        //        rndSize = rnd.Next(1, 20);
        //        _objs[i] = new BaseObject(new Point(rnd.Next(0,1920), rnd.Next(0, 1920)), new Point(rnd.Next(-20, 20), 0), new Size(rndSize, rndSize));
        //    }
        //}
        public static void Load()
        {
            Random rnd = new Random();
            int rndSize;

            _objs = new BaseObject[100];

            for (int i = 0; i < _objs.Length / 2; i++)
            {
                rndSize = rnd.Next(1, 20);
                _objs[i] = new BaseObject(new Point(rnd.Next(0, 1920), rnd.Next(0, 1080)), new Point(rnd.Next(-20, 20), 0), new Size(rndSize, rndSize));
            }

            for (int i = _objs.Length / 2; i < _objs.Length; i++)
            {
                rndSize = rnd.Next(1, 20);
                _objs[i] = new Star(new Point(rnd.Next(1, 1920), rnd.Next(1, 1080)), new Point(i, 0), new Size(5,5));
            }
        }

        static Game()
        {

        }

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

        public static void Draw()
        {
            Buffer.Graphics.DrawImage(cat, 0, 0, 1920, 1080);
            Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(70, 60, 150, 150));
            Buffer.Graphics.FillEllipse(Brushes.YellowGreen, new Rectangle(1000, 580, 45, 45));



            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }     
        
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

    }
}
