using System;

namespace ThousandTasks
{
  public class Task14
  {
    //Дана длина L окружности. Найти ее радиус R и площадь S круга,
    //ограниченного этой окружностью

    public void StartTask()
    {
      try
      {
        Console.Write("Введите длину окружности ");
        var lengthOfRound = Convert.ToDouble(Console.ReadLine());

        var radius = FindRadiusOfCircle(lengthOfRound);
        FindAreaOfCircle(radius);
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

    private double FindRadiusOfCircle(double lengthOfRound)
    {
      double radius = lengthOfRound / (2 * Math.PI);
      Console.WriteLine("Радиус круга: {0}", radius);
      return radius;
    }

    private void FindAreaOfCircle(double radius)
    {
      double area = Math.PI * (radius * radius);
      Console.WriteLine("Площадь круга: {0}", area);
    }
  }
}