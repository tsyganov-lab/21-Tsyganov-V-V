using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsParusnik
{
    class HarborAlreadyHaveException : Exception
    {
        public HarborAlreadyHaveException() : base("В гавани уже есть такое водное т/c")
        { }

    }
}
