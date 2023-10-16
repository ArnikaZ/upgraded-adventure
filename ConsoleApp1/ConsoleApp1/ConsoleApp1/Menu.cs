using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal static class Menu
    {
        static string[] pOzYcJeMeNu = { "Odczytaj tekst z klawiatury", "Odczytaj tekst z pliku", "Wyjdź" };
        static int aKtYwNaPoZyCjAmEnU = 0;

        public static void StArTmEnU()
        {
            Console.Title = "Zlicz liczbę poszczególnych liter";
            Console.CursorVisible = false;
            while (true)
            {
                PoKaZmEnU();
                WyBiErAnIeOpCjI();
                UrUcHoMoPcJe();
            }
        }
        static void PoKaZmEnU()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Wybierz opcję");
            Console.WriteLine();
            for(int i = 0; i < pOzYcJeMeNu.Length; i++)
            {
                if (i == aKtYwNaPoZyCjAmEnU)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("{0,-35}", pOzYcJeMeNu[i]);
                    Console.BackgroundColor = ConsoleColor.Gray; 
                    
                }
                else
                {
                    Console.WriteLine(pOzYcJeMeNu[i]);
                }
            }
        }
        static void WyBiErAnIeOpCjI()
        {
            do
            {
                ConsoleKeyInfo kLaWiSz = Console.ReadKey();
                if (kLaWiSz.Key == ConsoleKey.UpArrow)
                {
                    aKtYwNaPoZyCjAmEnU = (aKtYwNaPoZyCjAmEnU > 0) ? aKtYwNaPoZyCjAmEnU - 1 : pOzYcJeMeNu.Length - 1;
                    PoKaZmEnU();
                }
                else if (kLaWiSz.Key == ConsoleKey.DownArrow)
                {
                    aKtYwNaPoZyCjAmEnU = (aKtYwNaPoZyCjAmEnU < (pOzYcJeMeNu.Length - 1)) ? aKtYwNaPoZyCjAmEnU + 1 : 0;
                    PoKaZmEnU();
                }
                else if (kLaWiSz.Key == ConsoleKey.Escape)
                {
                    aKtYwNaPoZyCjAmEnU = pOzYcJeMeNu.Length - 1;
                    break;
                }
                else if (kLaWiSz.Key == ConsoleKey.Enter)
                    break;
            }
            while (true);
        }
        static void UrUcHoMoPcJe()
        {
            switch (aKtYwNaPoZyCjAmEnU)
            {
                case 0:Console.Clear();OdCzYtAjTeKsTzKlAwIaTuRy();break;
                case 1: Console.Clear();OdCzYtAjTeKsTzPlIkU();break;
                case 2:Environment.Exit(0); break;
            }
        }
        public static void OdCzYtAjTeKsTzKlAwIaTuRy()
        {
            Console.Write("Podaj łańcuch znaków: ");
            string lAnCuChWeJsCiOwY = Console.ReadLine();


            Program.WySwIeTlHiStOgRaM(lAnCuChWeJsCiOwY);
            Program.WySwIeTlHiStOgRaMzWyBrAnYmIzNaKaMi(lAnCuChWeJsCiOwY);
            
        }
        static void OdCzYtAjTeKsTzPlIkU()
        {
            Console.WriteLine("Podaj ścieżkę pliku");
            string pLiK = Console.ReadLine();
            pLiK=pLiK.Replace("\"","");
            Console.Clear();
            
            try
            {
                if (File.Exists(pLiK))
                {
                    string lAnCuChWeJsCiOwY;
                    using (StreamReader sr = new StreamReader(pLiK))
                    {
                        lAnCuChWeJsCiOwY = sr.ReadToEnd();
                    }

                    
                    Program.WySwIeTlHiStOgRaM(lAnCuChWeJsCiOwY);
                    Program.WySwIeTlHiStOgRaMzWyBrAnYmIzNaKaMi(lAnCuChWeJsCiOwY);

                   
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

    }
}
