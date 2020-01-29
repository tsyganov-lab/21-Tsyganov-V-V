using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsParusnik
{
    public class MultiLevelHarbor
    {
        /// <summary>
        /// Список с уровнями парковки
        /// </summary>
        List<Harbor<IMarineVeh>> harborStages;
        private const int countPlaces = 20;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int pictureHeight;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="countStages">Количество уровенй парковки</param>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public MultiLevelHarbor(int countStages, int pictureWidth, int pictureHeight)
        {
            harborStages = new List<Harbor<IMarineVeh>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
            for (int i = 0; i < countStages; ++i)
            {
                harborStages.Add(new Harbor<IMarineVeh>(countPlaces, pictureWidth,
                    pictureHeight));
            }
        }
        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public Harbor<IMarineVeh> this[int ind]
        {
            get
            {
                if (ind > -1 && ind < harborStages.Count)
                {
                    return harborStages[ind];
                }
                return null;
            }
        }
        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine("CountLevels:" + harborStages.Count);
                foreach (var level in harborStages)
                {
                    sw.WriteLine("Level");
                    for (int i = 0; i < countPlaces; i++)
                    {
                        var ship = level[i];
                        if (ship != null)
                        {
                            if (ship.GetType().Name == "Lodka")
                            {
                                sw.WriteLine(i + ":Lodka:" + ship);
                            }
                            if (ship.GetType().Name == "Parusnik")
                            {
                                sw.WriteLine(i + ":Parusnik:" + ship);
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            int counter = -1;
            IMarineVeh par = null;
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();
                int count;
                bool isValid = line.Contains("CountLevels");
                if (isValid)
                {
                    count = Convert.ToInt32(line.Split(':')[1]);
                    if (harborStages != null)
                    {
                        harborStages.Clear();
                    }
                    harborStages = new List<Harbor<IMarineVeh>>(count);
                }
                else
                {
                    return false;
                }
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "Level")
                    {
                        counter++;
                        harborStages.Add(new Harbor<IMarineVeh>(countPlaces, pictureWidth, pictureHeight));
                        continue;
                    }
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    string[] splitLine = line.Split(':');
                    if (splitLine.Length > 2)
                    {
                        if (splitLine[1] == "Lodka")
                        {
                            par = new Lodka(splitLine[2]);
                        }
                        else
                        {
                            par = new Parusnik(splitLine[2]);
                        }
                        harborStages[counter][Convert.ToInt32(splitLine[0])] = par;
                    }
                }
                return true;
            }
        }
    }
}
