using System;

namespace ThousandTasks
{
  public class Task12
  {
    //Даны катеты прямоугольного треугольника a и b.
    //Найти его гипотенузу c и периметр P

    public void StartTask()
    {
      try
      {
        Console.Write("Введите катет первого угла ");
        var a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите катет второго угла ");
        var b = Convert.ToDouble(Console.ReadLine());

        double c = FindHypotenuse(a, b);
        FindPerimeter(a, b, c);
      }
      
      catch (OverflowException e)
      {
        Console.WriteLine(e.Message);
      }

      catch (FormatException ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private double FindHypotenuse(double a, double b)
    {
      double c = Math.Sqrt(a * a + b * b);
      
      Console.WriteLine("Гипотенуза: {0}", c);

      return c;
    }

    private void FindPerimeter(double a, double b, double c) => Console.WriteLine("Периметр: {0}", a + b + c);
  }
}