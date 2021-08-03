using System;

namespace ThousandTasks
{
  public class Task10
  {
    //Даны два ненулевых числа. Найти сумму, разность, произведение и частное их квадратов

    public void StartTask()
    {
      try
      {
        double a = SetFirstNumber();
        double b = SetSecondNumber();

        a *= a;
        b *= b;

        GetResult(a, b);
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

    private double SetFirstNumber()
    {
      Console.Write("Введите первое ненулевое число ");
      var a = Convert.ToDouble(Console.ReadLine());

      if (a == 0)
      {
        Console.WriteLine("Вводите не 0");
        Console.ReadKey();
        StartTask();
      }

      return a;
    }

    private double SetSecondNumber()
    {
      Console.Write("Введите второе ненулевое число ");
      var b = Convert.ToDouble(Console.ReadLine());

      if (b == 0)
      {
        Console.WriteLine("Вводите не 0");
        Console.ReadKey();
        StartTask();
      }

      return b;
    }

    private void GetResult(double a, double b)
    {
      Console.WriteLine("Сумма их квадратов: {0}", a + b);
      Console.WriteLine("Разность их квадратов: {0}", a - b);
      Console.WriteLine("Произведение их квадратов: {0}", a * b);
      Console.WriteLine("Частное их квадратов: {0}", a / b);
    }
  }
}