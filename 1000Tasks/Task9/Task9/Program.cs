using System;
namespace Task9
{
    //Даны два неотрицательных числа a и b. Найти их среднее геометрическое, то есть квадратный корень из их произведения  
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Задайте первое положительное число: ");
                int a = Convert.ToInt16(Console.ReadLine());
                Console.Write("Задайте второе положительное число: ");
                int b = Convert.ToInt16(Console.ReadLine());

                double avg = Math.Sqrt(a * b);

                Console.WriteLine("Среднее геометрическое этих чисел равно " + avg);

                
                if (a < 0 || b < 0)
                    throw new ArgumentException("Введено одно или несколько отрицательных чисел");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();            
        }
    }
}
