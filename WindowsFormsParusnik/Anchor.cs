using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsParusnik
{
    public class Anchor : IParusnik
    {
        public float globalPosX;
        public float globalPosY;
        public Anchor(float posX, float posY)
        {
            globalPosX = posX;
            globalPosY = posY;
        }
        private int CountToInt(CountParusa Countparusa)
        {
            return (int)Countparusa;
        }
        public void DrawParusa(CountParusa Count, Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br1 = new SolidBrush(Color.NavajoWhite);
            g.FillRectangle(br1, globalPosX + 45, globalPosY + 18, 30, 14);
            g.DrawLine(pen, globalPosX + 60, globalPosY + 40, globalPosX + 50, globalPosY + 50);
            g.DrawLine(pen, globalPosX + 50, globalPosY + 50, globalPosX + 50, globalPosY + 40);
            g.DrawLine(pen, globalPosX + 50, globalPosY + 50, globalPosX + 60, globalPosY + 50);
        }
    }
}