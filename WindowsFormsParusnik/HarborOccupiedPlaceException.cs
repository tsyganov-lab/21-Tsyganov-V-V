using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsParusnik
{
    class HarborOccupiedPlaceException : Exception
    {
        public HarborOccupiedPlaceException(int i) : base("На месте " + i
            + "уже стоит автомобиль")
        { }

    }
}
