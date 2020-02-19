using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elemek_ShuhS2
{
    class Elemek
    {
        public int Rendszam;
        public string Vegyjel;
        public string Nev;
        public double Atomtomeg;
        public double Olvadasho;
        public double Forrasho;
        public double Elektronnegativ;

        public Elemek (string sor)
        {
            var dbok = sor.Split(';');
            this.Rendszam = int.Parse(dbok[0]);
            this.Vegyjel = dbok[1];
            this.Nev = dbok[2];
            this.Atomtomeg = double.Parse(dbok[3]);
            this.Olvadasho = double.Parse(dbok[4]);
            this.Forrasho = double.Parse(dbok[5]);
            this.Elektronnegativ = double.Parse(dbok[6]);
        }
    }
}
