﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fuvar
{
    class Program
    {
        static void Main(string[] args)
        {
            string elsoSor = "";

            List<fuvarInfo> lista = new List<fuvarInfo>();

            using (StreamReader sr = new StreamReader("fuvar.csv", Encoding.UTF8))
            {
                elsoSor = sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    int az = Int32.Parse(sor.Split(';')[0]);
                    string ib = sor.Split(';')[1];
                    int it = Int32.Parse(sor.Split(';')[2]);
                    double mt = Double.Parse(sor.Split(';')[3]);
                    double vd = Double.Parse(sor.Split(';')[4]);
                    double bv = Double.Parse(sor.Split(';')[5]);
                    string fm = sor.Split(';')[6];
                    fuvarInfo fi = new fuvarInfo(az, ib, it, mt, vd, bv, fm);
                    lista.Add(fi);
                }
            }
            Console.WriteLine($"3.feladat: {lista.Count} fuvar");

            double osszViteldij = 0.0d;
            int fuvarSzam = 0;

            foreach (var item in lista)
            {
                if (item.Azonosito == 6185)
                {
                    fuvarSzam++;
                    osszViteldij += item.Viteldij;
                }
            }
            Console.WriteLine($"4.feladat: {fuvarSzam} fuvar alatt: {osszViteldij}$");

            Dictionary<string, int> mivelHanyszor = new Dictionary<string, int>();

            foreach (var item in lista)
            {
                string fizetesiMod = item.FizetesModja;
                int darabSzam = 0;

                foreach (KeyValuePair<string, int> elem in mivelHanyszor)
                {
                    if (elem.Key == fizetesiMod)
                    {
                        darabSzam = elem.Value;
                        mivelHanyszor.Remove(fizetesiMod);
                        break;
                    }
                }
                mivelHanyszor.Add(fizetesiMod, ++darabSzam);
            }

            Console.WriteLine("5.feladat: ");
            foreach (KeyValuePair<string, int> item in mivelHanyszor)
            {
                Console.WriteLine($"\t{item.Key}: {item.Value} fuvar");
            }

            double osszFutottMerfold = 0.0d;

            foreach (var item in lista)
            {
                osszFutottMerfold += item.MegtettTavolsag;
            }

            Console.WriteLine($"6.feladat: {osszFutottMerfold * 1.6:F2}km");

            fuvarInfo leghosszabb = new fuvarInfo();

            foreach (var item in lista)
            {
                if (item.Idotartam >= leghosszabb.Idotartam)
                {
                    leghosszabb = item;
                }
            }

            Console.WriteLine("7.feladat: ");
            Console.WriteLine($"\tFuvar hossza: {leghosszabb.Idotartam} másodperc");
            Console.WriteLine($"\tTaxi azonosito {leghosszabb.Azonosito}");
            Console.WriteLine($"\tMegtett távolsag {leghosszabb.MegtettTavolsag * 1.6} km");
            Console.WriteLine($"\tViteldíj: {leghosszabb.Viteldij} $");

            Console.WriteLine("8.feladat: hibak.txt");

            List<fuvarInfo> nullasok = new List<fuvarInfo>();
            fuvarInfo fiNullas = new fuvarInfo("3");
            nullasok.Add(fiNullas);

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Idotartam != 0 && lista[i].Viteldij != 0 && lista[i].MegtettTavolsag == 0)
                {
                    for (int j = 0; j < nullasok.Count; j++)
                    {
                        if (String.Compare(lista[i].Idobelyegzo, nullasok[j].Idobelyegzo) < 0)
                        {
                            nullasok.Insert(j, lista[i]);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(nullasok.Count);

            using (StreamWriter sw = new StreamWriter("hibak.txt", false, Encoding.UTF8))
            {
                sw.WriteLine(elsoSor);
                foreach (var item in nullasok)
                {
                    sw.WriteLine(item.kiiroString());
                }
            }

            Console.ReadKey(true);
        }
    }
}
