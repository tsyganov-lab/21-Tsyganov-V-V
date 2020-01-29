using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsParusnik
{
    public class Lodka : MarineVeh
    {
        protected const int parWidth = 100;
        protected const int parHeight = 60;
        public Lodka(Color mainColor)
        {
            MainColor = mainColor;
        }
        public Lodka(string info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 1)
            {
                MainColor = Color.FromName(strs[0]);
            }
        }

        public override void MoveMVeh(Direction direction)
        {
            float step = 12;
            switch (direction)
            {
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - parWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - parHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        public override void DrawMVeh(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br = new SolidBrush(MainColor);
            g.FillRectangle(br, _startPosX + 10, _startPosY + 35, 60, 10);
            g.FillRectangle(br, _startPosX, _startPosY + 35, 80, 7);
            g.FillRectangle(br, _startPosX + 20, _startPosY + 35, 40, 14);

        }
        public override string ToString()
        {
            return MainColor.Name;
        }
    }
}