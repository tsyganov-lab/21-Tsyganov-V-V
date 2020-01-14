using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsParusnik
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Parusnik : Lodka
    {
        public bool Parus { private set; get; }
        public bool Flag { private set; get; }

        public Parusnik(Color mainColor, bool parus, bool flag) : base(mainColor)

        {
            Parus = parus;
            Flag = flag;
        }

        public override void DrawMVeh(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br1 = new SolidBrush(Color.NavajoWhite);
            Brush br4 = new SolidBrush(MainColor);
            g.FillRectangle(br4, _startPosX + 40, _startPosY - 10, 5, 45);
            base.DrawMVeh(g);
            if (Parus)
            {
                g.FillRectangle(br1, _startPosX + 10, _startPosY, 30, 32);
            }
            if (Flag)
            {
                Brush br2 = new SolidBrush(Color.LightBlue);
                g.FillRectangle(br2, _startPosX + 45, _startPosY, 20, 7);
                Brush br3 = new SolidBrush(Color.LightGreen);
                g.FillRectangle(br3, _startPosX + 45, _startPosY + 7, 20, 7);
            }
        }
    }
}
