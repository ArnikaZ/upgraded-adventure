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
            Dictionary<char, int> histogram = new Dictionary<char, int>();

            Console.WriteLine("Podaj łańcuch znaków: ");
            string lancuchWejsciowy = Console.ReadLine();

            foreach (char c in lancuchWejsciowy.ToLower())
            {
                if (histogram.ContainsKey(c))
                {
                    histogram[c]++;
                }
                else histogram.Add(c, 1);
            }

            foreach (var kvp in histogram)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            Console.ReadKey();
        }
    }
}
