using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    //Даны два числа a и b. Найти их среднее арифметическое
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите первое число: ");
                int a = Convert.ToInt16(Console.ReadLine());
                Console.Write("Введите второе число: ");
                int b = Convert.ToInt16(Console.ReadLine());

                int avg = (a + b) / 2;
                Console.WriteLine("Среднее арифметическое этих числе будет " + avg);

            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
