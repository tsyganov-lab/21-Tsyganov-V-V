using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsParusnik
{
    public class ClassParusa : IParusa
    {
        public float globalPosX;
        public float globalPosY;
        public ClassParusa(float posX, float posY)
        {
            globalPosX = posX;
            globalPosY = posY;
        }

        public void DrawParusa(CountParusa Count, Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br1 = new SolidBrush(Color.NavajoWhite);
            g.FillRectangle(br1, globalPosX + 45, globalPosY + 18, 30, 14);
            g.FillRectangle(br1, globalPosX + 45, globalPosY - 10, 15, 6);
            g.FillRectangle(br1, globalPosX + 30, globalPosY - 10, 10, 6);
        }
    }
}