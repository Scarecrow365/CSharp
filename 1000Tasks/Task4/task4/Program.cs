using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    //Дан диаметр окружности d. Найти её длину L 
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Задайте диаметр окружности: ");
                int d = Convert.ToInt16(Console.ReadLine());

                double l = Math.PI * d;

                Console.WriteLine("Длина диаметра окружности: " + l);
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
