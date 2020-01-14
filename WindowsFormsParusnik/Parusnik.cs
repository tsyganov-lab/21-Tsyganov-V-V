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

    public class Parusnik : Lodka, IComparable<Parusnik>, IEquatable<Parusnik>

    {
        public bool Parus { private set; get; }
        public bool Flag { private set; get; }
        public Color DopeColor { protected set; get; }

        public Parusnik(Color mainColor, Color dopeColor, bool parus, bool flag) : base(mainColor)

        {
            DopeColor = dopeColor;
            Parus = parus;
            Flag = flag;
        }
        public Parusnik(string info) : base(info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 4)
            {
                MainColor = Color.FromName(strs[0]);
                DopeColor = Color.FromName(strs[1]);
                Parus = Convert.ToBoolean(strs[2]);
                Flag = Convert.ToBoolean(strs[3]);
            }
        }

        public override void DrawMVeh(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br1 = new SolidBrush(DopeColor);
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
        /// Смена дополнительного цвета
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopeColor = color;
        }
        public override string ToString()
        {
            return base.ToString() + ";" + DopeColor.Name + ";" + Parus + ";" +
           Flag;
        }
        public int CompareTo(Parusnik other)
        {
            var res = (this is Lodka).CompareTo(other is Lodka);
            if (res != 0)
            {
                return res;
            }
            if (DopeColor != other.DopeColor)
            {
                DopeColor.Name.CompareTo(other.DopeColor.Name);
            }
            return 0;
        }
        public bool Equals(Parusnik other)
        {
            var res = (this as Lodka).Equals(other as Lodka);
            if (!res)
            {
                return res;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (DopeColor != other.DopeColor)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Parusnik carObj))
            {
                return false;
            }
            else
            {
                return Equals(carObj);
            }
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
