using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsParusnik
{
    public partial class WFParusnik : Form
    {
        private Parusnik par;

        public WFParusnik()
        {
            InitializeComponent();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxMVeh.Width, pictureBoxMVeh.Height);
            Graphics gr = Graphics.FromImage(bmp);
            par.DrawMVeh(gr);
            pictureBoxMVeh.Image = bmp;
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            par = new Parusnik(Color.Blue, Color.Yellow, true, true, _countParusa.Three);
            par.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxMVeh.Width,
           pictureBoxMVeh.Height);
            Draw();
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    par.MoveMVeh(Direction.Up);
                    break;
                case "buttonDown":
                    par.MoveMVeh(Direction.Down);
                    break;
                case "buttonLeft":
                    par.MoveMVeh(Direction.Left);
                    break;
                case "buttonRight":
                    par.MoveMVeh(Direction.Right);
                    break;
            }
            Draw();
        }

    }
}
