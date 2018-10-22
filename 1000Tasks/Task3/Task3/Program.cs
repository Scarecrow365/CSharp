using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    //Даны стороны прямоугольника a и b. Найти его площадь и его периметр
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Задайте сторону а прямоугольника: ");
                int a = Convert.ToInt16(Console.ReadLine());

                Console.Write("Задайте сторону b прямоугольника: ");
                int b = Convert.ToInt16(Console.ReadLine());

                int s = a * b;
                int p = 2 * (a + b);

                Console.WriteLine("Площадь прямоугольника  = " + s);
                Console.WriteLine("Периметр прямоугольника = " + p);

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
