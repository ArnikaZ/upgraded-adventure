using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj łańcuch znaków: ");
            string lancuchWejsciowy = Console.ReadLine();

            Dictionary<char, int> histogram = Program.Histogram(lancuchWejsciowy);

            foreach (var kvp in histogram)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

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
