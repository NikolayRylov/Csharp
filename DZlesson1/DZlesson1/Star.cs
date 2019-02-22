using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DZlesson1
{
    class Star : BaseObject
    {       

        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }        

        public override void Draw()
        {
            Random r = new Random();
            Pen br = new Pen(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255)));

            Game.Buffer.Graphics.DrawLine(br, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(br, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

    }
}
