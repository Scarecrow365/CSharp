using System;

namespace Task1

{//Дана сторона квадрата а. Найти его периметр.
    class Program
    {
        static void Main(string[] args)
        {            
            Console.Write("Задайте сторону квадрата для вычисления его периметра: ");
            try
            {
                int a = Convert.ToInt16(Console.ReadLine());
                int p;
                p = a * 4;
                Console.WriteLine("Периметр квадрата = " + p);               

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
