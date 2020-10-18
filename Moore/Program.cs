using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Legea lui Moore:");
            Console.WriteLine();
            Console.WriteLine("Puterea de calcul se dubleaza la fiecare 18 luni, dar pretul ramane acelasi.");
            Console.WriteLine();
            Console.WriteLine("Pentru a afla peste cati ani vom avea procesoare de n ori mai puternice decat azi, introduceti numarul de ani dorit:");
            Console.WriteLine("n: ");
            int n;
            n = int.Parse(Console.ReadLine());
            int luni = Convert.ToInt32(Math.Log(n, 2) * 18);
            int ani = luni / 12;
            luni = luni % 12;
            Console.Write($"Puterea procesorului va fi de {n} ori mai mare in (aproximativ) {ani} ani si {luni} luni");


        }
    }
}


