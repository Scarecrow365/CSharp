using System;

namespace ThousandTasks
{
  public class Task9
  {
    //Даны два неотрицательных числа a и b. Найти их среднее геометрическое,
    //то есть квадратный корень из их произведения  

    public void StartTask()
    {
      try
      {
        Console.Write("Задайте первое положительное число: ");
        int a = Convert.ToInt16(Console.ReadLine());

        Console.Write("Задайте второе положительное число: ");
        int b = Convert.ToInt16(Console.ReadLine());

        if (a < 0 || b < 0)
        {
          Console.WriteLine("Введено одно или несколько отрицательных чисел");
          StartTask();
        }

        GeometricalAverage(a, b);
      }

      catch (ArgumentException exception)
      {
        Console.WriteLine(exception.Message);
      }

      catch (FormatException e)
      {
        Console.WriteLine(e.Message);
      }

      catch (OverflowException ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void GeometricalAverage(int a, int b)
    {
      double avg = Math.Sqrt(a * b);
      Console.WriteLine("Среднее геометрическое этих чисел равно {0}", avg);
    }
  }
}