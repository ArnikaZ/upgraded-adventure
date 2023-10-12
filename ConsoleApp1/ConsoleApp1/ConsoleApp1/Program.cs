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

        public static void PoliczWybraneZnaki(char[] znaki)
        {

        }

        public static Dictionary<char, int> Histogram(string lancuchWejsciowy) // generuje histogram
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
