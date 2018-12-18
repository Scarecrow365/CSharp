using System;

namespace DistPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите x1 значение: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Введите y1 значение: ");
            double y1 = double.Parse(Console.ReadLine());
            Console.Write("Введите x2 значение: ");
            double x2 = double.Parse(Console.ReadLine());
            Console.Write("Введите y2 значение: ");
            double y2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Расстояние между точками = {0:N}", R(x1,x2,y1,y2));
            Console.ReadKey();
        }

        static double R (double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
