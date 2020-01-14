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
    public partial class FormParConfig : Form
    {
        /// <summary>
        /// Переменная-выбранная машина
        /// </summary>
        IMarineVeh par = null;
        private event parDelegate eventAddPar;

        public FormParConfig()
        {
            InitializeComponent();
            panelBlack.MouseDown += panelColor_MouseDown;
            panelOrange.MouseDown += panelColor_MouseDown;
            panelGrey.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;

            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }
        /// <summary>
        /// Отрисовать машину
        /// </summary>
        private void DrawPar()
        {
            if (par != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxParConfig.Width, pictureBoxParConfig.Height);
                Graphics gr = Graphics.FromImage(bmp);
                par.SetPosition(5, 5, pictureBoxParConfig.Width, pictureBoxParConfig.Height);
                par.DrawMVeh(gr);
                pictureBoxParConfig.Image = bmp;
            }
        }
        public void AddEvent(parDelegate ev)
        {
            if (eventAddPar == null)
            {
                eventAddPar = new parDelegate(ev);
            }
            else
            {
                eventAddPar += ev;
            }
        }

        private void labelLodka_MouseDown(object sender, MouseEventArgs e)
        {
            labelLodka.DoDragDrop(labelLodka.Text, DragDropEffects.Move |
                DragDropEffects.Copy);
        }

        private void labelParusnik_MouseDown(object sender, MouseEventArgs e)
        {
            labelParusnik.DoDragDrop(labelParusnik.Text, DragDropEffects.Move |
                DragDropEffects.Copy);
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelParConfig_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Действия при приеме перетаскиваемой информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelParConfig_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Лодка":
                    par = new Lodka(Color.White);
                    break;
                case "Парусник":
                    par = new Parusnik(Color.White, Color.Black, true, true);
                    break;
            }
            DrawPar();
        }

        /// Отправляем цвет с панели
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor,
           DragDropEffects.Move | DragDropEffects.Copy);
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMainCol_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void labelDopCol_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Принимаем основной цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMainCol_DragDrop(object sender, DragEventArgs e)
        {
            if (par != null)
            {
                par.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawPar();
            }
        }

        /// <summary>
        /// Принимаем дополнительный цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDopCol_DragDrop(object sender, DragEventArgs e)
        {
            if (par != null)
            {
                if (par is Parusnik)
                {
                    (par as
                   Parusnik).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawPar();
                }
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            eventAddPar.Invoke(par);
            Close();
        }


    }
}
