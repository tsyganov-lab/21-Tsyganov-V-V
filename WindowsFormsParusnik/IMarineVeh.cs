using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsParusnik
{
    public interface IMarineVeh
    {
        void SetPosition(int x, int y, int width, int height);
        void MoveMVeh(Direction direction);
        void DrawMVeh(Graphics g);
    }
}
