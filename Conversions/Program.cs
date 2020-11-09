using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Conversions
{
    class Program
    {
        
        static void ten_TO_xbase(int numar, int bazaTinta)
        {
            
            int cat, rest;

            string result = "";
            Stack<int> stiva = new Stack<int>();

            while (numar > 0)
            {
                cat = numar / bazaTinta;
                rest = numar % bazaTinta;

                stiva.Push(rest);

                numar = numar / bazaTinta;
            }


            string[] hex = { "A", "B", "C", "D", "E", "F" };
            while (stiva.Count > 0)
            {
                int cifra = stiva.Pop();
                if (cifra >= 10)
                {
                    // metoda 1 - folosind ASCII
                    cifra += 55;
                    result = result + (char)cifra;

                    // metoda 2 - folosind un Array cu valorile
                    // result = result + hex[cifra - 10];
                }
                else
                {
                    result = result + cifra;
                }
            }

            Console.WriteLine(result);
        }

        static void xbaze_TO_ten(int numar, int bazaNumar)
        {
            int number_copy = numar;
            int exponent = -1;
            while(numar>0)
            {
                exponent++;
                numar = numar / 10;
            }

            //Console.WriteLine("exponentu este " + exponent);
            Stack<int> stiva = new Stack<int>();
            while (number_copy>0)
            {
                stiva.Push(number_copy%10);
                number_copy = number_copy / 10;
                //int cifra = stiva.Pop();
                //Console.WriteLine(cifra);
            }
            int produs = 0;
            int result=0;
            while (stiva.Count>0)
            {

                int cifra = stiva.Pop();
                produs = cifra * (int)Math.Pow(bazaNumar, exponent);
                result =result + produs;
                exponent--;
            }
            Console.WriteLine(result);
            
        }
        static void Main(string[] args)
        {
            try
            {
                // creati nume de identificatori expresivi
                int numar = 0;
                int bazaNumar = 0;
                int bazaTinta = 0;
                

                // Introducem numarul pe care vrem sa il convertim
                Console.WriteLine("Introduceti numarul pe care vreti sa-l convertiti: ");

                if (!int.TryParse(Console.ReadLine(), out numar))
                {
                    throw new Exception("Nu ati introdus un numar !");
                }

                Console.WriteLine("Introduceti baza numarului pe care vreti sa-l convertiti: ");

                if (!int.TryParse(Console.ReadLine(), out bazaNumar))
                {
                    throw new Exception("Nu ati introdus un numar !");
                }


                // Introducem baza tinta
                Console.WriteLine("Introduceti baza tinta (un numar natural intre 2 si 16):");

                if (!int.TryParse(Console.ReadLine(), out bazaTinta))
                {
                    throw new Exception("Nu ati introdus un numar !");
                }


                if (bazaTinta < 2 || bazaTinta > 16)
                {
                    throw new Exception("Baza tinta poate fi cuprinsa intre 2 si 16");
                }

                if (bazaNumar == 10)
                    ten_TO_xbase(numar, bazaTinta);
                if (bazaTinta == 10)
                    xbaze_TO_ten(numar, bazaNumar);
                if(bazaNumar!=10 && bazaTinta!=10)
                {
                    int x = bazaNumar;
                    int y = bazaTinta;
                    bool ok1 = true;
                    bool ok2 = true;
                    while(x>0)
                    {
                        if(x % 2==0)
                            continue;
                        else
                        {
                            ok1 = false;
                            break;
                        }
                    }
                    while (y > 0)
                    {
                        if (y % 2 == 0)
                            continue;
                        else
                        {
                            ok2 = false;
                            break;
                        }
                    }
                    if(ok1==true && ok2==true)
                    {
                        ConversieRapida();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

           
        }
    }
}
