using System;
using System.Collections.Generic;
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
        /// Конструктор
        /// </summary>
        /// <param name="countStages">Количество уровенй парковки</param>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public MultiLevelHarbor(int countStages, int pictureWidth, int pictureHeight)
        {
            harborStages = new List<Harbor<IMarineVeh>>();
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
    }
}
