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
    public partial class FormHarbor : Form
    {
        Harbor<IMarineVeh> harbor;
        public FormHarbor()
        {
            InitializeComponent();
            harbor = new Harbor<IMarineVeh>(20, pictureBoxMVeh.Width, pictureBoxMVeh.Height);
            Draw();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxMVeh.Width, pictureBoxMVeh.Height);
            Graphics gr = Graphics.FromImage(bmp);
            harbor.Draw(gr);
            pictureBoxMVeh.Image = bmp;
        }
        private void buttonSetLodka_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var lodka = new Lodka(dialog.Color);
                int place = harbor + lodka;
                Draw();
            }
        }
        private void buttonSetParusnik_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var par = new Parusnik(dialog.Color, dialogDop.Color, true, true);
                    int place = harbor + par;
                    Draw();
                }
            }
        }
        private void buttonTake_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxPlace.Text != "")
            {
                var par = harbor - Convert.ToInt32(maskedTextBoxPlace.Text);
                if (par != null)
                {
                    Bitmap bmp = new Bitmap(pictureBoxTake.Width,
                   pictureBoxTake.Height);
                    Graphics gr = Graphics.FromImage(bmp);
                    par.SetPosition(5, 5, pictureBoxTake.Width,
                   pictureBoxTake.Height);
                    par.DrawMVeh(gr);
                    pictureBoxTake.Image = bmp;
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBoxTake.Width,
                   pictureBoxTake.Height);
                    pictureBoxTake.Image = bmp;
                }
                Draw();
            }
        }


    }
}
