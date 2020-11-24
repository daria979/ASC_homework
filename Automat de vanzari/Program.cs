using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat_de_vanzari
{
    class Program
    {
        static int coins = 0;
        static int rest = 0;
        static char c = 'O';
        static void Main(string[] args)
        {
            A();
        }
        private static void Write()
        {

            Console.WriteLine($"Ai {coins} centi in automat.");
            Console.WriteLine("         Ce moneda doresti sa introduci?");
            Console.Write("N - Nickel          ");
            Console.Write("D - Dime          ");
            Console.WriteLine("Q - Quarter");
        }

        private static void A()
        {

            if (coins < 20)
            {

                Write();
                GetCoins();
                switch (c)
                {
                    case 'N':
                        coins += 5;
                        B();
                        break;
                    case 'D':
                        coins += 10;
                        C();
                        break;
                    case 'Q':
                        coins += 25;
                        A();
                        break;
                    default:
                        Console.WriteLine("Nu ai introdus bine semnificatia monedei. Mai incearca:");
                        A();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ai primit produsul.");
                rest = coins - 20;
                if (rest > 0) Rest();
            }
        }

        private static void Rest()
        {
            coins -= 20;
            switch (rest)
            {
                case 5:
                    Console.WriteLine("Primesti un Nickel rest");
                    coins -= 5;
                    break;
                case 10:
                    Console.WriteLine("Primesti un Dime rest");
                    coins -= 10;
                    break;
                case 15:
                    Console.WriteLine("Primesti un Nickel rest si un Dime rest");
                    coins -= 15;
                    break;
                case 20:
                    Console.WriteLine("Primesti un Nickel rest si un Dime rest");
                    coins -= 15;
                    B();
                    break;
                default:
                    break;
            }
        }
        private static void D()
        {
            Console.WriteLine("STAREA D");

            Write();
            GetCoins();
            switch (c)
            {
                case 'N':
                    coins += 5;
                    A();
                    break;
                case 'D':
                    coins += 10;
                    A();
                    break;
                case 'Q':
                    coins += 25;
                    B();
                    break;
                default:
                    Console.WriteLine("Nu ai introdus bine semnificatia monedei. Mai incearca:");
                    D();
                    break;
            }


        }
        private static void C()
        {
            Console.WriteLine("STAREA C");
            Write();
            GetCoins();
            switch (c)
            {
                case 'N':
                    coins += 5;
                    D();
                    break;
                case 'D':
                    coins += 10;
                    A();
                    break;
                case 'Q':
                    coins += 25;
                    A();
                    break;
                default:
                    Console.WriteLine("Nu ai introdus bine semnificatia monedei. Mai incearca:");
                    C();
                    break;
            }


        }

        private static void B()
        {
            Console.WriteLine("STAREA B");
            if (coins <= 20)
            {

                Write();
                GetCoins();
                switch (c)
                {
                    case 'N':
                        coins += 5;
                        C();
                        break;
                    case 'D':
                        coins += 10;
                        D();
                        break;
                    case 'Q':
                        coins += 25;
                        A();
                        break;
                    default:
                        Console.WriteLine("Nu ai introdus bine semnificatia monedei. Mai incearca:");
                        B();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ai primit produsul");
                rest = coins - 20;
                if (rest > 0) Rest();
            }

        }

        private static void GetCoins()
        {
            c = char.Parse(Console.ReadLine());
            Console.Clear();

        }
    }
}
