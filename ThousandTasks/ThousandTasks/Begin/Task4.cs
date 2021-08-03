using System;

namespace ThousandTasks
{
  public class Task4
  {
    public void StartTask()
    {
      try
      {
        Console.Write("Задайте диаметр окружности: ");
        int d = Convert.ToInt16(Console.ReadLine());

        FindLenghtOfDiameterOfCircle(d);
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

    private void FindLenghtOfDiameterOfCircle(int d)
    {
      double l = Math.PI * d;
      Console.WriteLine("Длина диаметра окружности: {0}", l);
    }
  }
}