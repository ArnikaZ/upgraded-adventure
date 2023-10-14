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
        static string[] pozycjeMenu = { "Odczytaj tekst z klawiatury", "Odczytaj tekst z pliku", "Wyjdź" };
        static int aktywnaPozycjaMenu = 0;

        public static void StartMenu()
        {
            Console.Title = "Zlicz liczbę poszczególnych liter";
            Console.CursorVisible = false;
            while (true)
            {
                PokazMenu();
                WybieranieOpcji();
                UruchomOpcje();
            }
        }
        static void PokazMenu()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Wybierz opcję");
            Console.WriteLine();
            for(int i = 0; i < pozycjeMenu.Length; i++)
            {
                if (i == aktywnaPozycjaMenu)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("{0,-35}", pozycjeMenu[i]);
                    Console.BackgroundColor = ConsoleColor.Gray; 
                    
                }
                else
                {
                    Console.WriteLine(pozycjeMenu[i]);
                }
            }
        }
        static void WybieranieOpcji()
        {
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.UpArrow)
                {
                    aktywnaPozycjaMenu = (aktywnaPozycjaMenu > 0) ? aktywnaPozycjaMenu - 1 : pozycjeMenu.Length - 1;
                    PokazMenu();
                }
                else if (klawisz.Key == ConsoleKey.DownArrow)
                {
                    aktywnaPozycjaMenu = (aktywnaPozycjaMenu < (pozycjeMenu.Length - 1)) ? aktywnaPozycjaMenu + 1 : 0;
                    PokazMenu();
                }
                else if (klawisz.Key == ConsoleKey.Escape)
                {
                    aktywnaPozycjaMenu = pozycjeMenu.Length - 1;
                    break;
                }
                else if (klawisz.Key == ConsoleKey.Enter)
                    break;
            }
            while (true);
        }
        static void UruchomOpcje()
        {
            switch (aktywnaPozycjaMenu)
            {
                case 0:Console.Clear();OdczytajTekstZklawiatury();break;
                case 1: Console.Clear();OdczytajTekstZpliku();break;
                case 2:Environment.Exit(0); break;
            }
        }
        public static void OdczytajTekstZklawiatury()
        {
            Console.Write("Podaj łańcuch znaków: ");
            string lancuchWejsciowy = Console.ReadLine();


            Program.WyswietlHistogram(lancuchWejsciowy);

            // pobiera litery i zamienia je w tablice charow
            Console.Write("Podaj po przecinku wybrane litery: ");
            string[] znakiStringArray = Console.ReadLine().Split(',');
            char[] znakiCharArray = new char[znakiStringArray.Length];

            for (int i = 0; i < znakiStringArray.Length; i++)
            {
                znakiCharArray[i] = Char.Parse(znakiStringArray[i].Trim());
            }


            // wyswietla histogram z wybranymi znakami
            Dictionary<char, int> histogramZWybranymiZnakami = Program.HistogramZWybranymiZnakami(lancuchWejsciowy, znakiCharArray);

            foreach (var kvp in histogramZWybranymiZnakami)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
        static void OdczytajTekstZpliku()
        {
            Console.WriteLine("Podaj ścieżkę pliku");
            string plik = Console.ReadLine();
            Console.Clear();
            
            try
            {
                if (File.Exists(plik))
                {
                    string lancuchWejsciowy;
                    using (StreamReader sr = new StreamReader(plik))
                    {
                        lancuchWejsciowy = sr.ReadToEnd();
                    }

                    
                    Program.WyswietlHistogram(lancuchWejsciowy);

                    // pobiera litery i zamienia je w tablice charow
                    Console.Write("Podaj po przecinku wybrane litery: ");
                    string[] znakiStringArray = Console.ReadLine().Split(',');
                    char[] znakiCharArray = new char[znakiStringArray.Length];

                    for (int i = 0; i < znakiStringArray.Length; i++)
                    {
                        znakiCharArray[i] = Char.Parse(znakiStringArray[i].Trim());
                    }

                    // wyswietla histogram z wybranymi znakami
                    Dictionary<char, int> histogramZWybranymiZnakami = Program.HistogramZWybranymiZnakami(lancuchWejsciowy, znakiCharArray);

                    foreach (var kvp in histogramZWybranymiZnakami)
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }
                    
                    Console.WriteLine();

                    Console.ReadKey();
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
            Console.ReadKey();
        }

    }
}
