using System;

namespace ThousandTasks
{
  public class Task16
  {
    //Найти расстояние между двумя точками с заданными координатами
    //x1 и x2 на числовой оси: |x2 − x1|
    
    public void StartTask()
    {
      try
      {
        Console.Write("Введите x1 ");
        double x1 = SetNumber();
        
        Console.Write("Введите x2 ");
        double x2 = SetNumber();

        CalculateNumericAxis(x1, x2);
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

    private void CalculateNumericAxis(double x1, double x2)
    {
      double distance = Math.Abs(x2-x1);
      Console.Write("расстояние между двумя точками с заданными координатами {0}", distance);
    }

    private double SetNumber() => Convert.ToDouble(Console.ReadLine());
  }
}