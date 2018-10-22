using System;
using System.Diagnostics;
using System.Reflection;

namespace Task10
{
    //Даны два ненулевых числа. Найти сумму, разность, произведение и частное их квадратов
    class Program
    {        

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите первое ненулевое число ");
                int a = Convert.ToInt16(Console.ReadLine());

                if (a == 0)
                {
                    Console.WriteLine("Вводите не 0");
                    Console.ReadKey();
                    Process.Start(Assembly.GetExecutingAssembly().Location);
                    Environment.Exit(0);
                }

                Console.Write("Введите второе ненулевое число ");
                int b = Convert.ToInt16(Console.ReadLine());             
                
                if (b == 0)
                {
                    Console.WriteLine("Вводите не 0");
                    Console.ReadKey();
                    Process.Start(Assembly.GetExecutingAssembly().Location);
                    Environment.Exit(0);
                }

                a = a * a;
                b = b * b;

                Console.WriteLine("Сумма их квадратов: {0}", a + b);
                Console.WriteLine("Разность их квадратов: {0}", a - b);
                Console.WriteLine("Произведение их квадратов: {0}", a * b);
                Console.WriteLine("Частное их квадратов: {0}", a / b);

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
