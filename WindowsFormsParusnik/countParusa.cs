using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsParusnik
{
    public enum _countParusa
    {
        One,
        Two,
        Three
    }
    public class countParusa
    {
        public _countParusa parusCount { private get; set; }
        float posx;
        float posy;

        public countParusa(_countParusa numberOfParusa, float _startPosX, float _startPosY)
        {
            parusCount = numberOfParusa;
            posx = _startPosX;
            posy = _startPosY;

        }
        public void ParusDraw(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br1 = new SolidBrush(Color.NavajoWhite);
            switch (parusCount)
            {
                case _countParusa.One:
                    g.FillRectangle(br1, posx + 45, posy + 18, 30, 14);
                    break;
                case _countParusa.Two:
                    g.FillRectangle(br1, posx + 45, posy + 18, 30, 14);
                    g.FillRectangle(br1, posx + 45, posy - 10, 15, 6);
                    break;
                case _countParusa.Three:
                    g.FillRectangle(br1, posx + 45, posy + 18, 30, 14);
                    g.FillRectangle(br1, posx + 45, posy - 10, 15, 6);
                    g.FillRectangle(br1, posx + 30, posy - 10, 10, 6);
                    break;

            }

        }
    }
}