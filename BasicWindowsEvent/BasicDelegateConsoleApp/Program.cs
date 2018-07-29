using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDelegateConsoleApp
{
    class Program
    {
        public delegate void DelegateUsingNumbers(int numToSumtheDigit);
        
        static void Main(string[] args)
        {      

            DelegateUsingNumbers sumTheDigits = new DelegateUsingNumbers(SumofDigits);
            DelegateUsingNumbers reverseTheDigits = new DelegateUsingNumbers(ReverseTheDigits);
            //d(100);            //d1(12345);
            //d += d1;  - GetInvocationList of the Base Class MultiCastDelegate
            //      d(12345);
            //Dynamically you can decide which method to call only by passing the delegate as parameters along with the value;
            //DoWork(sumTheDigits, 12345);
            //DoWork(reverseTheDigits, 12345);
            //DoWork(reverseTheDigits, 53215);

            sumTheDigits += reverseTheDigits;  // One Single Point and Multiple Handler is handled differently that is power of Delegates.
            DoWork(sumTheDigits, 642135); // One Single Point and Multiple Handler is handled differently that is power of Delegates.


            Console.ReadLine();
        }

        public static void DoWork(DelegateUsingNumbers d, int num)
        {
            d(num);
        }
        public static void SumofDigits(int digits)
        {          
            int len = digits.ToString().Length;
            int sum = 0;
            for (int i = 0; i < len; i++)
            {
                sum += digits % 10;
                digits = digits / 10;
            }
            Console.WriteLine("Sum of the Digits :{0}", sum.ToString());
        }

        public  static void ReverseTheDigits(int revDigits)
        {
            Console.WriteLine("Before Reverse of the Digits :{0}", revDigits.ToString());
            int len = revDigits.ToString().Length;
            string sum ="";
            for (int i = 0; i < len; i++)
            {
                sum = sum + (revDigits % 10).ToString();
                revDigits = revDigits / 10;
            }
            Console.WriteLine("Reverse of the Digits :{0}", sum.ToString());
        }

    }
}
