using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fajlkezeles1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tomb = new int[30];
            int negativ = 0;
            int osszeg = 0;
            List<int> paratlanok = new List<int>();

            using (StreamReader sr = new StreamReader("szamok30.txt", Encoding.UTF8))
            {
                for (int i = 0; i < 30; i++)
                {
                    tomb[i] = Int32.Parse(sr.ReadLine());
                    osszeg += tomb[i];
                    if (tomb[i] < 0)
                    {
                        negativ++;
                    }
                    if (tomb[i] % 2 == 1)
                    {
                        paratlanok.Add(tomb[i]);
                    }
                }
            }

            Console.WriteLine($"1.feladat: A számok összege: {osszeg}");
            Console.WriteLine($"2.feladat: {negativ} db negatív szám van a fájlban.");
            Console.WriteLine($"3.feladat: A páratlan számok: ");
            foreach (var item in paratlanok)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine(" ");
            Console.WriteLine($"4.feladat: A kétszámjegyű számok: ");
            for (int j = 0; j < tomb.Length; j++)
            {
                if (Math.Abs(tomb[j]) > 9 && Math.Abs(tomb[j]) < 100)
                {
                    Console.Write($"{tomb[j]} ");
                }
            }

            Console.WriteLine("5.feladat: Kérek egy számot 50 és 100 között: ");
            int szam = Int32.Parse(Console.ReadLine());
            int szamlal = 0;
            string kiir = "";
            for (int k = 0; k < tomb.Length; k++)
            {
                szamlal += tomb[k];
                if (szamlal < szam)
                {
                    kiir += $"{tomb[k]} +";
                }
                else
                {
                    continue;
                    kiir += $"{tomb[k]} >= {szam}";
                }
            }
            Console.WriteLine(kiir);



            Console.ReadKey(true);
        }
    }
}
