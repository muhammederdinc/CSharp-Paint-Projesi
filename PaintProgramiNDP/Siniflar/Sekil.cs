using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PaintProgramiNDP.Siniflar;


namespace PaintProgramiNDP
{
    abstract public class Sekil
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Renk { get; set; }
      

        
        public virtual void Ciz(Graphics cizimAraci)
        {

        }

    }
}
