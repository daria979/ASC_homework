using System;
using System.Collections.Generic;
using System.Text;

namespace Conversions
{
    class Program
    {
        static int ten_TO_xbase(int numar, int bazaTinta)
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

            return Convert.ToInt32(result);
        }

        static int xbaze_TO_ten(int numar, int bazaNumar) //adaugat de mine
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

            return result;
            
            
        }

        

        static string ConversieRapida(int numar, int bazaTinta)
        {
            //Console.WriteLine("Introduceti un numar in baza 2");
            
            
            string number2;

            number2 = Convert.ToString(numar);
            Console.WriteLine(numar);
            //Console.ReadLine();
            number2 = number2.TrimStart('0');

            //Console.WriteLine("Introduceti baza in care vreti sa faceti conversia (4, 8, 16):");
            int baza;
            baza = bazaTinta;// int.Parse(Console.ReadLine());


            // 0001 0010 => 12(16)
            // 1010 1111 => AF(16)
            // 10 10 11 11 => 2233(4)
            // 10 101 111 => 257(8)

            Dictionary<string, string> base16 = new Dictionary<string, string>();
            base16.Add("0000", "0");
            base16.Add("0001", "1");
            base16.Add("0010", "2");
            base16.Add("0011", "3");

            base16.Add("0100", "4");
            base16.Add("0101", "5");
            base16.Add("0110", "6");
            base16.Add("0111", "7");

            base16.Add("1000", "8");
            base16.Add("1001", "9");
            base16.Add("1010", "A");
            base16.Add("1011", "B");

            base16.Add("1100", "C");
            base16.Add("1101", "D");
            base16.Add("1110", "E");
            base16.Add("1111", "F");


            Dictionary<string, string> base8 = new Dictionary<string, string>();
            base8.Add("000", "0");
            base8.Add("001", "1");
            base8.Add("010", "2");
            base8.Add("011", "3");

            base8.Add("100", "4");
            base8.Add("101", "5");
            base8.Add("110", "6");
            base8.Add("111", "7");

            Dictionary<string, string> base4 = new Dictionary<string, string>();
            base4.Add("00", "0");
            base4.Add("01", "1");
            base4.Add("10", "2");
            base4.Add("11", "3");



            //foreach (var item in base16.Keys)
            //{
            //    Console.WriteLine($"{item} - {base16[item]}");
            //}
            int nrCifre = 0;
            switch (baza)
            {
                case 4:
                    nrCifre = 2;
                    break;
                case 8:
                    nrCifre = 3;
                    break;
                case 16:
                    nrCifre = 4;
                    break;
                default:
                    Console.WriteLine("Baza tinta nu este corecta.");
                    throw new Exception("Baza nu este corecta");
            }

            int lungimeNumarB2;
            lungimeNumarB2 = number2.Length;

            int nrZerouriDeAdaugat = 0;

            if (lungimeNumarB2 % nrCifre > 0)
            {
                nrZerouriDeAdaugat = nrCifre - lungimeNumarB2 % nrCifre;
            }

            number2 = number2.PadLeft(nrZerouriDeAdaugat + lungimeNumarB2, '0'); //adauga 0 la stanga

            // Console.WriteLine(number2);

            StringBuilder sb = new StringBuilder();
            int i = 0;
            string key;
            while (i < number2.Length / nrCifre)
            {
                key = number2.Substring(i * nrCifre, nrCifre);
                switch (baza)
                {
                    case 4:
                        sb.Append(base4[key]);
                        break;
                    case 8:
                        sb.Append(base8[key]);
                        break;
                    case 16:
                        sb.Append(base16[key]);
                        break;
                }
                i++;
            }

            string result = sb.ToString();

            //result = result.TrimStart('0');
            return result;
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


                //cazuri posibile de convertire//

                if (bazaNumar == 10 && (bazaTinta != 4 || bazaTinta != 8 || bazaTinta != 16))
                {
                    Console.Write("Rezultat:");
                    Console.WriteLine(ten_TO_xbase(numar, bazaTinta));
                }
                if(bazaNumar==10 && (bazaTinta == 4 || bazaTinta == 8 || bazaTinta == 16))
                {
                    Console.Write("Rezultat:");
                    Console.WriteLine(ConversieRapida(ten_TO_xbase(numar, 2), bazaTinta));
                }
                if (bazaTinta == 10 && (bazaTinta != 4 || bazaTinta != 8 || bazaTinta != 16))
                {
                    Console.Write("Rezultat:");
                    Console.WriteLine(xbaze_TO_ten(numar, bazaNumar));
                }
                if(bazaNumar == 2 && (bazaTinta == 4 || bazaTinta == 8 || bazaTinta == 16))
                {
                    Console.Write("Rezultat:");
                    Console.WriteLine(ConversieRapida(numar, bazaTinta));
                }
                if(bazaNumar !=2 && bazaNumar != 10 && (bazaTinta ==4 || bazaTinta == 8||bazaTinta == 16))
                {
                    Console.Write("Rezultat:");
                    Console.WriteLine(ConversieRapida(ten_TO_xbase(xbaze_TO_ten(numar, bazaNumar), 2), bazaTinta));
                }
                if(bazaNumar>=2 && bazaNumar != 10  && (bazaTinta != 4 || bazaTinta != 8 || bazaTinta != 16))
                {
                    Console.Write("Rezultat:");
                    Console.WriteLine(ten_TO_xbase(xbaze_TO_ten(numar, bazaNumar), bazaTinta));

                }

                //cazul care da eroare: din baza 10 in baza 16 :(

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

           
        }
    }
}
