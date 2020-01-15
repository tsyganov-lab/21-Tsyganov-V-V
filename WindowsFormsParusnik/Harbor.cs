﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsParusnik
{
    public class Harbor<T,N> where T : class, IMarineVeh where N : class, IParusa
    {
        /// <summary>
        /// Массив объектов, которые храним
        /// </summary>
        private T[] _places; 
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int PictureWidth { get; set; }
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int PictureHeight { get; set; }
        /// <summary>
        /// Массив объектов, которые храним
        /// </summary>
        private const int _placeSizeWidth = 180;
        /// <summary>
        /// Размер парковочного места (высота)
        /// </summary>
        private const int _placeSizeHeight = 70;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sizes">Количество мест на парковке</param>
        /// <param name="pictureWidth">Рамзер парковки - ширина</param>
        /// <param name="pictureHeight">Рамзер парковки - высота</param>
        public Harbor(int sizes, int pictureWidth, int pictureHeight)
        {
            _places = new T[sizes];
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
            for (int i = 0; i < _places.Length; i++)
            {
                _places[i] = null;
            }
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на парковку добавляется автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="car">Добавляемый автомобиль</param>
        /// <returns></returns>
        public static int operator +(Harbor<T,N> p, T par)
        {
            for (int i = 0; i < p._places.Length; i++)
            {
                if (p.CheckFreePlace(i))
                {
                    p._places[i] = par;
                    p._places[i].SetPosition(5 + i / 5 * _placeSizeWidth + 15,
                        i % 5 * _placeSizeHeight + 55, p.PictureWidth, p.PictureHeight);
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: с парковки забираем автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="index">Индекс места, с которого пытаемся извлечь
        ///объект</param>
        /// <returns></returns>
        public static T operator -(Harbor<T,N> p, int index)
        {
            if (index < 0 || index > p._places.Length)
            {
                return null;
            }
            if (!p.CheckFreePlace(index))
            {
                T par = p._places[index];
                p._places[index] = null;
                return par;
            }
            return null;
        }
        //перешвартоваться
        public static int operator +(Harbor<T, N> p, int size)
        {
            int freeplace = 15;
            for (int i = 0; i < p._places.Length; i++)
            {
                if (!p.CheckFreePlace(i))
                {
                    if (freeplace != 15)
                        if (p.CheckFreePlace(freeplace))
                        {
                            p._places[freeplace] = p._places[i];
                            p._places[freeplace].SetPosition(5 + freeplace / 5 * _placeSizeWidth + 15,
                            freeplace % 5 * _placeSizeHeight + 55, p.PictureWidth,
                           p.PictureHeight);
                            p._places[i] = null;
                            i = freeplace;
                            freeplace = 15;
                        }
                }
                else
                    if (i <= freeplace)
                    freeplace = i;
            }
            return 1;
        }

        //очистка гавани
        public static int operator -(Harbor<T, N> p, string size)
        {
            for (int i = 0; i < Convert.ToInt32(size); i++)
            {
                p._places[i] = null;
            }
            return 1;
        }
        private bool CheckFreePlace(int index)
        {
            return _places[index] == null;
        }
        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Length; i++)
            {
                if (!CheckFreePlace(i))
                {//если место не пустое
                    _places[i].DrawMVeh(g);
                }
            }
        }
        /// <summary>
        /// Метод отрисовки разметки парковочных мест
        /// </summary>
        /// <param name="g"></param>
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            //границы праковки
            g.DrawRectangle(pen, 0, 0, (_places.Length / 5) * _placeSizeWidth, 480);
            for (int i = 0; i < _places.Length / 5; i++)
            {//отрисовываем, по 5 мест на линии
                for (int j = 0; j < 6; ++j)
                {
                    //линия рамзетки места
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight,
                    i * _placeSizeWidth + 110, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, 400);
            }
        }


    }
}
