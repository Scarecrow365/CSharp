using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    // Найти длину окружности L и площадь круга S заданного радиуса R
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Задайте радиус круга: ");
            try
            {
                double r = Convert.ToDouble(Console.ReadLine());

                double l = 2 * 3.14 * r;
                double s = 3.14 * (r * r);

                Console.WriteLine("Длина окружности равна {0};\n" + "Площадь заданного круга равен {1}", l,s);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);   
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
