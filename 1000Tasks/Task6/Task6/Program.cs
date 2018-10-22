using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        //Даны длины ребер a,b,c прямоугольного параллелепипеда. Найти его объем V и его площадь S 
        
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите первую сторону ребра: ");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите вторую сторону ребра: ");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите третью сторону ребра: ");
                double c = Convert.ToDouble(Console.ReadLine());

                double v = a * b * c;
                double s = 2 * (a * b + b * c + c * a);

                Console.WriteLine("Объем прямоугольного параллелипипеда = {0}; \n" +  "Его площадь = {1}",v,s);
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
