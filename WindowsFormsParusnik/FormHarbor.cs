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
            harbor = new MultiLevelHarbor(countLevel, pictureBoxMVeh.Width,
                pictureBoxMVeh.Height);
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
                Bitmap bmp = new Bitmap(pictureBoxMVeh.Width,
                    pictureBoxMVeh.Height);
                Graphics gr = Graphics.FromImage(bmp);
                harbor[listBoxLevels.SelectedIndex].Draw(gr);
                pictureBoxMVeh.Image = bmp;
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
        private void buttonTake_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                if (maskedTextBoxPlace.Text != "")
                {
                    var par = harbor[listBoxLevels.SelectedIndex] -
                        Convert.ToInt32(maskedTextBoxPlace.Text);
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
        /// <summary>
        /// Обработка нажатия кнопки "Добавить автомобиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
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

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (harbor.SaveData(saveFile.FileName))
                {
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не сохранилось", "Результат",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (harbor.LoadData(openFile.FileName))
                {
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не загрузили", "Результат", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                Draw();
            }

        }

    }
}
