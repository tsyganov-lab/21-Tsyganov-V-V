using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsParusnik
{
    class HarborNorFoundException : Exception
    {
        public HarborNorFoundException(int i) : base("Не найдено водное т/с по месту "
            + i)
        { }

    }
}
