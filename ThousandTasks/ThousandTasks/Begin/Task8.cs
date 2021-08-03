using System;

namespace ThousandTasks
{
  public class Task8
  {
    //Даны два числа a и b. Найти их среднее арифметическое

    public void StartTask()
    {
      try
      {
        Console.Write("Введите первое число: ");
        int a = Convert.ToInt16(Console.ReadLine());

        Console.Write("Введите второе число: ");
        int b = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Среднее арифметическое этих числе будет {0}", Average(a, b));
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

    private int Average(int a, int b) => (a + b) / 2;
  }
}