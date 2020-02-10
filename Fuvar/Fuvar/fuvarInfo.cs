using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar
{
    class fuvarInfo
    {
        public int Azonosito { get; set; }
        public string Idobelyegzo { get; set; }
        public int Idotartam { get; set; }
        public double MegtettTavolsag { get; set; }
        public double Viteldij { get; set; }
        public double Borravalo { get; set; }
        public string FizetesModja { get; set; }

        public fuvarInfo(int az, string ib, int it, double mt, double vt, double bv, string fm)
        {
            this.Azonosito = az;
            this.Idobelyegzo = ib;
            this.Idotartam = it;
            this.MegtettTavolsag = mt;
            this.Viteldij = vt;
            this.Borravalo = bv;
            this.FizetesModja = fm;
        }

        public fuvarInfo()
        {

        }
        public fuvarInfo(string ib)
        {
            this.Idobelyegzo = ib;
        }
        public string kiiroString()
        {
            return $"{this.Azonosito};{this.Idobelyegzo};{this.Idotartam};{this.MegtettTavolsag};{this.Viteldij};{this.Borravalo};{this.FizetesModja}";
        }
    }
}
