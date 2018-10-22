using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //Дана сторона квадрата a. Найти его площадь.
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Напишите число одной из сторон квадрата: ");
            try
            {
                int a = Convert.ToInt16(Console.ReadLine());
                int s;
                s = a * a;
                Console.WriteLine("Площадь квадрата равна " + s);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);   
            }
            Console.ReadKey();
        }
    }
}
