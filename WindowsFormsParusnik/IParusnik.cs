using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsParusnik
{
    public interface IParusnik
    {
        void DrawParusa(CountParusa Count, Graphics g);
    }
}