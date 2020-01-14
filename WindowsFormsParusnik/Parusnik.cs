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

    public class Parusnik
    {
        /// <summary>
        /// Левая координата отрисовки автомобиля
        /// </summary>
        private float _startPosX;
        /// <summary>
        /// Правая кооридната отрисовки автомобиля
        /// </summary>
        private float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int _pictureHeight;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        private const int parWidth = 100;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        private const int parHeight = 60;
        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { private set; get; }
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }
        public bool Parus { private set; get; }
        public bool Flag { private set; get; }



        public Parusnik(Color mainColor, Color dopcolor, bool parus, bool flag)

        {
            MainColor = mainColor;
            DopColor = dopcolor;
            Parus = parus;
            Flag = flag;
        }
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        public void MoveMVeh(Direction direction)
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
        public void DrawMVeh(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br1 = new SolidBrush(DopColor);
            Brush br4 = new SolidBrush(MainColor);
            g.FillRectangle(br4, _startPosX + 10, _startPosY + 35, 60, 10);
            g.FillRectangle(br4, _startPosX, _startPosY + 35, 80, 7);
            g.FillRectangle(br4, _startPosX + 20, _startPosY + 35, 40, 14);
            g.FillRectangle(br4, _startPosX + 40, _startPosY - 10, 5, 45);
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
