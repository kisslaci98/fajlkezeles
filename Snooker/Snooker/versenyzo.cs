using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker
{
    class versenyzo
    {
        public int Helyezes { get; set; }
        public string Nev { get; set; }
        public string Orszag { get; set; }
        public int Nyeremeny { get; set; }

        public versenyzo(int h, string n, string o, int ny)
        {
            this.Helyezes = h;
            this.Nev = n;
            this.Orszag = o;
            this.Nyeremeny = ny;
        }
    }
}
