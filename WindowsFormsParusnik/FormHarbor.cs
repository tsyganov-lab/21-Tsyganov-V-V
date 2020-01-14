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
        /// <summary>
        /// Объект от класса многоуровневой парковки
        /// </summary>
        MultiLevelHarbor harbor;
        /// <summary>
        /// Форма для добавления
        /// </summary>
        FormParConfig form;
        /// <summary>
        /// Количество уровней-парковок
        /// </summary>
        private const int countLevel = 5;
        public FormHarbor()
        {
            InitializeComponent();
            harbor = new MultiLevelHarbor(countLevel, pictureBox1.Width,
                pictureBox1.Height);
            //заполнение listBox
            for (int i = 0; i < countLevel; i++)
            {
                listBoxLevels.Items.Add("Уровень " + (i + 1));
            }
            listBoxLevels.SelectedIndex = 0;

        }
        private void Draw()
        {
            if (listBoxLevels.SelectedIndex > -1)
            {//если выбран один из пуктов в listBox (при старте программы ни один пункт
             //не будет выбран и может возникнуть ошибка, если мы попытаемся обратиться к элементу listBox)
                Bitmap bmp = new Bitmap(pictureBox1.Width,
                    pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                harbor[listBoxLevels.SelectedIndex].Draw(gr);
                pictureBox1.Image = bmp;
            }
        }

        /// <summary>
        /// Метод обработки выбора элемента на listBoxLevels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                if (maskedTextBox1.Text != "")
                {
                    var par = harbor[listBoxLevels.SelectedIndex] -
                        Convert.ToInt32(maskedTextBox1.Text);
                    if (par != null)
                    {
                        Bitmap bmp = new Bitmap(pictureBox2.Width,
                            pictureBox2.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        par.SetPosition(5, 5, pictureBox2.Width,
                            pictureBox2.Height);
                        par.DrawMVeh(gr);
                        pictureBox2.Image = bmp;
                    }
                    else
                    {
                        Bitmap bmp = new Bitmap(pictureBox2.Width,
                        pictureBox2.Height);
                        pictureBox2.Image = bmp;
                    }
                    Draw();
                }
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Добавить автомобиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            form = new FormParConfig();
            form.AddEvent(AddPar);
            form.Show();
        }
        /// <summary>
        /// Метод добавления машины
        /// </summary>
        /// <param name="car"></param>
        private void AddPar(IMarineVeh par)
        {
            if (par != null && listBoxLevels.SelectedIndex > -1)
            {
                int place = harbor[listBoxLevels.SelectedIndex] + par;
                if (place > -1)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Т/с не удалось поставить");
                }
            }
        }


    }
}
