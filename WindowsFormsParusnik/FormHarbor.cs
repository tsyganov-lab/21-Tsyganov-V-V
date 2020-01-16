using NLog;
using System;
using System.Drawing;
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
        /// <summary>
        /// Логгер
        /// </summary>
        private Logger logger;

        public FormHarbor()
        {
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
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
                    try
                    {
                        var par = harbor[listBoxLevels.SelectedIndex] -
                            Convert.ToInt32(maskedTextBoxPlace.Text);
                        Bitmap bmp = new Bitmap(pictureBoxTake.Width, pictureBoxTake.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        par.SetPosition(5, 5, pictureBoxTake.Width, pictureBoxTake.Height);
                        par.DrawMVeh(gr);
                        pictureBoxTake.Image = bmp;
                        logger.Info("Изъято водное т/с с места " + maskedTextBoxPlace.Text);
                        Draw();
                    }
                    catch (HarborNorFoundException ex)
                    {
                        MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        Bitmap bmp = new Bitmap(pictureBoxTake.Width, pictureBoxTake.Height);
                        pictureBoxTake.Image = bmp;
                        logger.Debug("Не найдено водное т/с на месте " + maskedTextBoxPlace.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Неизвестная ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Debug("Неизвестная ошибка");
                    }

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
                try
                {
                    int place = harbor[listBoxLevels.SelectedIndex] + par;
                    logger.Info("Добавлено т/c " + par.ToString() + " на место "
                        + place);
                    Draw();
                }
                catch (HarborOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    logger.Debug("Ошибка при добавлении т/c, место занято ");
                }
                catch (HarborAlreadyHaveException ex)
                {
                    MessageBox.Show(ex.Message, "Дублирование", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    logger.Debug("Ошибка: такое водное т/c уже есть в гавани");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Debug("Неизвестная ошибка");

                }

            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    harbor.SaveData(saveFileDialog1.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Debug("Неизвестная ошибка");
                }

            }

        }
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    harbor.LoadData(openFileDialog1.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog1.FileName);
                }
                catch (HarborOccupiedPlaceException ex)
                {
                    MessageBox.Show(ex.Message, "Занятое место", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    logger.Debug("Занятое место");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Debug("Неизвестная ошибка");
                }
                Draw();

            }

        }
        private void buttonSort_Click(object sender, EventArgs e)
        {
            harbor.Sort();
            Draw();
            logger.Info("Сортировка уровней");


        }
    }
}
