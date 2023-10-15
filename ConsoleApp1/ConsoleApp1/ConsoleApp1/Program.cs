using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu.StArTmEnU();
        }


        public static void WySwIeTlHiStOgRaM(string lAnCuChWeJsCiOwY)
        {
            // wyswietla histogram
            Dictionary<char, int> hIsToGrAm = Program.HiStOgRaM(lAnCuChWeJsCiOwY);

            foreach (var kvp in hIsToGrAm)
            {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
             Console.WriteLine();
        }
        public static void WySwIeTlHiStOgRaMzWyBrAnYmIzNaKaMi(string lAnCuChWeJsCiOwY)
        {
            // pobiera litery i zamienia je w tablice charow
            Console.Write("Podaj po przecinku wybrane litery: ");
            string[] zNaKiStRiNgArRaY = Console.ReadLine().Split(',');
            char[] zNaKiChArArRaY = new char[zNaKiStRiNgArRaY.Length];

            for (int i = 0; i < zNaKiStRiNgArRaY.Length; i++)
            {
                zNaKiChArArRaY[i] = Char.Parse(zNaKiStRiNgArRaY[i].Trim());
            }


            // wyswietla histogram z wybranymi znakami
            Dictionary<char, int> hIsToGrAmZwYbRaNyMiZnAkAmI = Program.HiStOgRaMzWyBrAnYmIzNaKaMi(lAnCuChWeJsCiOwY, zNaKiChArArRaY);

            foreach (var kvp in hIsToGrAmZwYbRaNyMiZnAkAmI)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
       
        
        public static Dictionary<char, int> HiStOgRaMzWyBrAnYmIzNaKaMi(string lAnCuChWeJsCiOwY, char[] zNaKi)
        {
            Dictionary<char, int> hIsToGrAm = Program.HiStOgRaM(lAnCuChWeJsCiOwY);
            Dictionary<char, int> hIsToGrAmOuTpUt = new Dictionary<char, int>();

            foreach (var kvp in hIsToGrAm)
            {
                if (zNaKi.Contains(kvp.Key))
                {
                    hIsToGrAmOuTpUt.Add(kvp.Key, kvp.Value);
                }
            }

            return hIsToGrAmOuTpUt;
        }

        public static Dictionary<char, int> HiStOgRaM(string lAnCuChWeJsCiOwY)
        {
            Dictionary<char, int> hIsToGrAm = new Dictionary<char, int>();

            foreach (char c in lAnCuChWeJsCiOwY.ToLower())
            {
                // omijamy spacje
                if (c.Equals(' '))
                {
                    continue;
                }

                if (hIsToGrAm.ContainsKey(c))
                {
                    hIsToGrAm[c]++;
                }
                else hIsToGrAm.Add(c, 1);
            }

            return hIsToGrAm;
        }
    }
}
