using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsParusnik
{
    public partial class WFParusnik : Form
    {

        private IMarineVeh par;
        public WFParusnik()
        {
            InitializeComponent();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxParusnik.Width, pictureBoxParusnik.Height);
            Graphics gr = Graphics.FromImage(bmp);
            par.DrawMVeh(gr);
            pictureBoxParusnik.Image = bmp;
        }

        private void buttonCreateLodka_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            par = new Lodka(Color.Brown);
            par.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxParusnik.Width,
                pictureBoxParusnik.Height);
            Draw();
        }
        private void buttonCreateParusnik_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            par = new Parusnik(Color.Brown, true, true);
            par.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxParusnik.Width,
                pictureBoxParusnik.Height);
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
