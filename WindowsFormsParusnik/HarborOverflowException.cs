using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsParusnik
{
    class HarborOverflowException : Exception
    {
        public HarborOverflowException() : base("В гавани нет свободных мест")
        { }

    }
}
