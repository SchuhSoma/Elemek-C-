using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace elemek_ShuhS2
{
    class Program
    {
        static List<Elemek> ELemekList;
        static double szen;
        static double hidrogen;
        static double oxigen;
        static void Main(string[] args)
        {
            Feladat1Beolvasas();
            Feladat2ElemekSzama();
            Feladat3Rendszam1030();
            Feladat4Szobaho();
            Feladat5Atlag();
            Feladat6Legmagasabb();
            Feladat7Kereses();
            Feladat8SzoloCukor();
            Feladat9();
            Console.ReadKey();
        }

        private static void Feladat9()
        {
            Console.WriteLine("\n9.Feladat: egy karakteres vegyjelek kiírása");
            var sw = new StreamWriter(@"egykarakteres.csv",false,Encoding.UTF8);
            long hossz =0;
            foreach (var e in ELemekList)
            {   hossz = e.Vegyjel.Length;
                if(hossz<2)
                {
                  //  Console.WriteLine("{0},{1},{2}",e.Vegyjel,e.Rendszam,e.Forrasho-e.Olvadasho);
                    sw.WriteLine("{0},{1},{2}", e.Vegyjel, e.Rendszam, e.Forrasho - e.Olvadasho);
                }
            }
            sw.Close();
            Console.WriteLine("\tKiírás sikeres");
        }

        private static void Feladat8SzoloCukor()
        {
            Console.WriteLine("\n8.Feladat: Szőlőcukor molekoláris tömege");
           
            Szen();
            Hidrogen();
            Oxigen();
            
            double atomtomeg = 0;
            atomtomeg = 6 * szen + 12 * hidrogen + 6 * oxigen;
            Console.WriteLine("\tSzőlöcukor atomtömege: {0}", atomtomeg);
        }

        private static void Oxigen()
        {
            int kulcs = 8;
            int szamlalo = 0;
            
            while (szamlalo < ELemekList.Count && kulcs != ELemekList[szamlalo].Rendszam)
            {
                szamlalo++;
            }
            if (szamlalo == ELemekList.Count)
            {
                Console.WriteLine("\tSajnos nincs ilyen elem");
            }
            else
            {
                oxigen = ELemekList[szamlalo].Atomtomeg;
            }
        }

        private static void Hidrogen()
        {
            int kulcs = 1;
            int szamlalo = 0;
           
            while (szamlalo < ELemekList.Count && kulcs != ELemekList[szamlalo].Rendszam)
            {
                szamlalo++;
            }
            if (szamlalo == ELemekList.Count)
            {
                Console.WriteLine("\tSajnos nincs ilyen elem");
            }
            else
            {
                hidrogen = ELemekList[szamlalo].Atomtomeg;
            }
        }

        private static void Szen()
        {
            int kulcs = 6;
            int szamlalo = 0;
            double szen;
            while(szamlalo<ELemekList.Count && kulcs!=ELemekList[szamlalo].Rendszam )
            {
                szamlalo++;
            }
            if(szamlalo==ELemekList.Count)
            {
                Console.WriteLine("\tSajnos nincs ilyen elem");
            }
            else
            {
                szen=ELemekList[szamlalo].Atomtomeg;
            }
        }

        private static void Feladat7Kereses()
        {
            Console.WriteLine("\n7.Feladat: Keresés");
            Console.Write("\tKérem adja meg a keresett elem rendszámát: ");
            int kulcs = int.Parse(Console.ReadLine());
            int szamlalo = 0;
            while(szamlalo<ELemekList.Count && kulcs!=ELemekList[szamlalo].Rendszam )
            {
                szamlalo++;
            }
            if(szamlalo==ELemekList.Count)
            {
                Console.WriteLine("\tSajnos nincs ilyen elem");
            }
            else
            {
                Console.WriteLine("\t{0}",ELemekList[szamlalo].Atomtomeg);
            }
        }

        private static void Feladat6Legmagasabb()
        {
            Console.WriteLine("\n5.Feladat: Legmagasabb olvadaspont");
            double MaxOlvas = double.MinValue;
            string MaxNEv = "cica";
            foreach (var e in ELemekList)
            {
                if(e.Olvadasho>MaxOlvas)
                {
                    MaxOlvas = e.Olvadasho;
                    MaxNEv = e.Nev;
                }
            }
            Console.WriteLine("\tLegymagasabb olvadáshővel rendelkező elem: {0} ({1})",MaxNEv,MaxOlvas);
        }

        private static void Feladat5Atlag()
        {
            Console.WriteLine("\n5.Feladat: átlagos atomtömeg");
            double Ossz = 0;
            double Atlag = 0;
            foreach (var e in ELemekList)
            {
                Ossz += e.Atomtomeg;
                Atlag = Ossz / ELemekList.Count;
            }
            Console.WriteLine("\tA listán szereplő elemek átlagos atomtömege: {0:0.00}",Atlag);
        }

        private static void Feladat4Szobaho()
        {
            Console.WriteLine("\n4.Feladat: szobahőmérsékleten folyékony anyag");
            int db = 0;
            foreach (var e in ELemekList)
            {
                if(e.Olvadasho<293 && 293<e.Forrasho)
                {
                    db++;
                    Console.WriteLine("\t {0,-3},  {1,-15}, {2}, {3}, {4}", e.Rendszam, e.Nev, e.Vegyjel, e.Olvadasho,e.Forrasho);
                }
            }
            Console.WriteLine("\n\tFolyékony elemek száma: {0}",db);
        }

        private static void Feladat3Rendszam1030()
        {
            Console.WriteLine("\n3.Feladat: elemek rendszáma 10 és 30 között");
            int db = 0;
            foreach (var e in ELemekList)
            {
                if(10<e.Rendszam && e.Rendszam<=30)
                {
                    db++;
                    Console.WriteLine("\t {0,-3},  {1,-15}, {2}",e.Rendszam,e.Nev,e.Vegyjel);
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("\t{0} eleme van  aminek rendszáma 10 és 30 között van", db);
        }

        private static void Feladat2ElemekSzama()
        {
            Console.WriteLine("\n2.Feladat: Elemek száma");
            int db = 0;
            foreach (var e in ELemekList)
            {
                db++;
            }
            Console.WriteLine("\tElemek száma: {0}",db);
            Console.WriteLine("\tElemek száma: {0}",ELemekList.Count);
        }

        private static void Feladat1Beolvasas()
        {
            Console.WriteLine("1.Feladat: Adatok beolvasása");
            ELemekList = new List<Elemek>();
            var sr = new StreamReader(@"elemek.csv", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                ELemekList.Add(new Elemek(sr.ReadLine()));
            }
            sr.Close();
            Console.WriteLine("\tSikeres beolvasa");
        }
    }
}
