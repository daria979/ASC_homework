using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumbers_Operations
{
    class Program
    {
        static string findSum(string str1, string str2)
        {
            // Before proceeding further, make sure length  
            // of str2 is larger.  
            if (str1.Length > str2.Length)
            {
                string t = str1;
                str1 = str2;
                str2 = t;
            }

            // Take an empty string for storing result  
            string str = "";

            // Calculate length of both string  
            int n1 = str1.Length, n2 = str2.Length;

            // Reverse both of strings 
            char[] ch = str1.ToCharArray();
            Array.Reverse(ch);
            str1 = new string(ch);
            char[] ch1 = str2.ToCharArray();
            Array.Reverse(ch1);
            str2 = new string(ch1);

            int carry = 0;
            for (int i = 0; i < n1; i++)
            {
                // Do school mathematics, compute sum of  
                // current digits and carry  
                int sum = ((int)(str1[i] - '0') +
                        (int)(str2[i] - '0') + carry);
                str += (char)(sum % 10 + '0');

                // Calculate carry for next step  
                carry = sum / 10;
            }

            // Add remaining digits of larger number  
            for (int i = n1; i < n2; i++)
            {
                int sum = ((int)(str2[i] - '0') + carry);
                str += (char)(sum % 10 + '0');
                carry = sum / 10;
            }

            // Add remaining carry  
            if (carry > 0)
                str += (char)(carry + '0');

            // reverse resultant string 
            char[] ch2 = str.ToCharArray();
            Array.Reverse(ch2);
            str = new string(ch2);

            return str;
        }

        // Returns true if str1 is smaller
        // than str2, else false.
        static bool isSmaller(string str1, string str2)
        {
            // Calculate lengths of both string
            int n1 = str1.Length, n2 = str2.Length;

            if (n1 < n2)
                return true;
            if (n2 < n1)
                return false;

            for (int i = 0; i < n1; i++)
            {
                if (str1[i] < str2[i])
                    return true;
                else if (str1[i] > str2[i])
                    return false;
            }
            return false;
        }

        // Function for finding difference of
        // larger numbers
        static string findDiff(string str1, string str2)
        {
            // Before proceeding further,
            // make sure str1 is not smaller
            if (isSmaller(str1, str2))
            {
                string t = str1;
                str1 = str2;
                str2 = t;
            }

            // Take an empty string for
            // storing result
            String str = "";

            // Calculate lengths of both string
            int n1 = str1.Length, n2 = str2.Length;
            int diff = n1 - n2;

            // Initially take carry zero
            int carry = 0;

            // Traverse from end of both strings
            for (int i = n2 - 1; i >= 0; i--)
            {
                // Do school mathematics, compute
                // difference of current digits and carry
                int sub = (((int)str1[i + diff] - (int)'0')
                           - ((int)str2[i] - (int)'0') - carry);
                if (sub < 0)
                {
                    sub = sub + 10;
                    carry = 1;
                }
                else
                    carry = 0;

                str += sub.ToString();
            }

            // subtract remaining digits of str1[]
            for (int i = n1 - n2 - 1; i >= 0; i--)
            {
                if (str1[i] == '0' && carry > 0)
                {
                    str += "9";
                    continue;
                }
                int sub = (((int)str1[i] - (int)'0') - carry);
                if (i > 0 || sub > 0) // remove preceding 0's
                    str += sub.ToString();
                carry = 0;
            }

            // reverse resultant string
            char[] aa = str.ToCharArray();
            Array.Reverse(aa);
            return new string(aa);
        }

        // Multiplies str1 and str2, and prints result.  
        static String multiply(String num1, String num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;
            if (len1 == 0 || len2 == 0)
                return "0";

            // will keep the result number in vector  
            // in reverse order  
            int[] result = new int[len1 + len2];

            // Below two indexes are used to  
            // find positions in result.  
            int i_n1 = 0;
            int i_n2 = 0;
            int i;

            // Go from right to left in num1  
            for (i = len1 - 1; i >= 0; i--)
            {
                int carry = 0;
                int n1 = num1[i] - '0';

                // To shift position to left after every  
                // multipliccharAtion of a digit in num2  
                i_n2 = 0;

                // Go from right to left in num2              
                for (int j = len2 - 1; j >= 0; j--)
                {
                    // Take current digit of second number  
                    int n2 = num2[j] - '0';

                    // Multiply with current digit of first number  
                    // and add result to previously stored result  
                    // charAt current position.  
                    int sum = n1 * n2 + result[i_n1 + i_n2] + carry;

                    // Carry for next itercharAtion  
                    carry = sum / 10;

                    // Store result  
                    result[i_n1 + i_n2] = sum % 10;

                    i_n2++;
                }

                // store carry in next cell  
                if (carry > 0)
                    result[i_n1 + i_n2] += carry;

                // To shift position to left after every  
                // multipliccharAtion of a digit in num1.  
                i_n1++;
            }

            // ignore '0's from the right  
            i = result.Length - 1;
            while (i >= 0 && result[i] == 0)
                i--;

            // If all were '0's - means either both  
            // or one of num1 or num2 were '0'  
            if (i == -1)
                return "0";

            // genercharAte the result String  
            String s = "";

            while (i >= 0)
                s += (result[i--]);

            return s;
        }

        // A function to perform division of large numbers 
        static string Division(string number, int divisor)
        {
            // As result can be very large store it in string 
            string ans = "";

            // Find prefix of number that is larger 
            // than divisor. 
            int idx = 0;
            int temp = (int)(number[idx] - '0');
            while (temp < divisor)
            {
                temp = temp * 10 + (int)(number[idx + 1] - '0');
                idx++;
            }
            ++idx;

            // Repeatedly divide divisor with temp. After 
            // every division, update temp to include one 
            // more digit. 
            while (number.Length > idx)
            {
                // Store result in answer i.e. temp / divisor 
                ans += (char)(temp / divisor + '0');

                // Take next digit of number 
                temp = (temp % divisor) * 10 + (int)(number[idx] - '0');
                idx++;
            }
            ans += (char)(temp / divisor + '0');

            // If divisor is greater than number 
            if (ans.Length == 0)
                return "0";

            // else return ans 
            return ans;
        }

        // Function to find square root 
        // of given number upto given 
        // precision 
        static float squareRoot(int number,
                                int precision)
        {
            int start = 0, end = number;
            int mid;

            // variable to store the answer 
            double ans = 0.0;

            // for computing integral part 
            // of square root of number 
            while (start <= end)
            {
                mid = (start + end) / 2;

                if (mid * mid == number)
                {
                    ans = mid;
                    break;
                }

                // incrementing start if integral 
                // part lies on right side of the mid 
                if (mid * mid < number)
                {
                    start = mid + 1;
                    ans = mid;
                }

                // decrementing end if integral part 
                // lies on the left side of the mid 
                else
                {
                    end = mid - 1;
                }
            }

            // For computing the fractional part 
            // of square root upto given precision 
            double increment = 0.1;
            for (int i = 0; i < precision; i++)
            {
                while (ans * ans <= number)
                {
                    ans += increment;
                }

                // loop terminates when ans * ans > number 
                ans = ans - increment;
                increment = increment / 10;
            }
            return (float)ans;
        }
        static void Main(string[] args)
        {

            string str1 = "123467";
            string str2 = "37";

            //Console.Write(findSum(a, b));
            //Console.WriteLine();
            //Console.Write(findDiff(a, b));
            //Console.WriteLine();

            /*if ((str1[0] == '-' || str2[0] == '-') && (str1[0] != '-' || str2[0] != '-'))
                Console.Write("-");

            if (str1[0] == '-' && str2[0] != '-')
            {
                str1 = str1.Substring(1);
            }
            else if (str1[0] != '-' && str2[0] == '-')
            {
                str2 = str2.Substring(1);
            }
            else if (str1[0] == '-' && str2[0] == '-')
            {
                str1 = str1.Substring(1);
                str2 = str2.Substring(1);
            }
            Console.WriteLine(multiply(str1, str2));*/

            //Console.WriteLine(Division(str1, Convert.ToInt32(str2)));

            // Function calling 
            int x = Convert.ToInt32(str1);
            Console.WriteLine(squareRoot(x, 3));
        }
    }
}
