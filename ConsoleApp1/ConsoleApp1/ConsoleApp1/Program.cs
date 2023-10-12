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
            Console.Write("Podaj łańcuch znaków: ");
            string lancuchWejsciowy = Console.ReadLine();

            // wyswietla histogram
            Dictionary<char, int> histogram = Program.Histogram(lancuchWejsciowy);

            foreach (var kvp in histogram)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine();

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

        public static Dictionary<char, int> HistogramZWybranymiZnakami(string lancuchWejsciowy, char[] znaki)
        {
            Dictionary<char, int> histogram = Program.Histogram(lancuchWejsciowy);
            Dictionary<char, int> histogramOutput = new Dictionary<char, int>();

            foreach (var kvp in histogram)
            {
                if (znaki.Contains(kvp.Key))
                {
                    histogramOutput.Add(kvp.Key, kvp.Value);
                }
            }

            return histogramOutput;
        }

        public static Dictionary<char, int> Histogram(string lancuchWejsciowy)
        {
            Dictionary<char, int> histogram = new Dictionary<char, int>();

            foreach (char c in lancuchWejsciowy.ToLower())
            {
                // omijamy spacje
                if (c.Equals(' '))
                {
                    continue;
                }

                if (histogram.ContainsKey(c))
                {
                    histogram[c]++;
                }
                else histogram.Add(c, 1);
            }

            return histogram;
        }
    }
}
