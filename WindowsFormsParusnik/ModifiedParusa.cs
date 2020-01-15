using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsParusnik
{
    public class ModifiedParusa : IParusnik
    {
        public float globalPosX;
        public float globalPosY;
        public ModifiedParusa(float posX, float posY)
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
            g.FillEllipse(br1, globalPosX + 44, globalPosY + 18, 30, 14);
            g.FillEllipse(br1, globalPosX + 45, globalPosY - 10, 15, 6);
        }
    }
}