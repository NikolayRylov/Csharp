using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DZlesson1
{
    class Bullet : BaseObject
    {
        public Image bullet = Image.FromFile("bullet.png");   //картинка пули
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)  
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(bullet, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// генерируем рандомное положение пули от 1 до высоты экрана
        /// </summary>
        public override void Update()
        {
            Random rnd = new Random();
            Pos.X = Pos.X + Dir.X;
            if (Pos.X > Game.Width)
            {
                Pos.X = 1;
                Pos.Y = rnd.Next(1, Game.Height);
            }
        }

        /// <summary>
        /// генерируем рандомное появление пули при колизии с "Астеройдом"
        /// </summary>
        public void CollisionOn()
        {
            Random rn = new Random();
            Pos.X = 1;
            Pos.Y = rn.Next(1, Game.Height);
        }

    }
}
