using System;

namespace ThousandTasks
{
  public class Task2
  {
    public void StartTask()
    {
      Console.Write("Напишите число одной из сторон квадрата: ");
      
      try
      {
        FindSquareArea();
      }

      catch (FormatException ex)
      {
        Console.WriteLine(ex.Message);
      }
      
      catch (OverflowException e)
      {
        Console.WriteLine(e.Message);
      }
    }

    private void FindSquareArea()
    {
      int a = Convert.ToInt16(Console.ReadLine());
      int s = a * a;
      Console.WriteLine($"Площадь квадрата равна {s}");
    }
  }
}