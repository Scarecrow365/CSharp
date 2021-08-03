using System;

namespace ThousandTasks
{
  public class Task7
  {
    // Найти длину окружности l и площадь круга S заданного радиуса r

    public void StartTask()
    {
      Console.Write("Задайте радиус круга: ");
      try
      {
        double r = Convert.ToDouble(Console.ReadLine());

        double l = LenghtOfRound(r);
        double s = AreaOfCircle(r);

        Console.WriteLine("Длина окружности равна {0};\nПлощадь заданного круга равен {1}", l, s);
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

    private double AreaOfCircle(double r) => MathF.PI * (r * r);
    private double LenghtOfRound(double r) => 2 * MathF.PI * r;
  }
}