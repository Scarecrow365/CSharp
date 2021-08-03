using System;

namespace ThousandTasks
{
  public class Task15
  {
    //Дана площадь S круга. Найти его диаметр D и длину L окружности,
    //ограничивающей этот круг

    public void StartTask()
    {
      try
      {
        double squareOfCircle = SetSquareOfCircle();

        var radius = RadiusOfCircle(squareOfCircle);
        LenghtOfCircle(radius);
        DiameterOfCircle(radius);
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

    private double SetSquareOfCircle()
    {
      Console.Write("Введите площадь круга ");
      return Convert.ToDouble(Console.ReadLine());
    }

    private double RadiusOfCircle(double squareOfCircle) => 
      Math.Sqrt(squareOfCircle / Math.PI);

    private void LenghtOfCircle(double radius)
    {
      var lenght = 2 * Math.PI * radius;
      Console.WriteLine("Длина окружности ограничевающий этот круг: {0}", lenght);
    }

    private void DiameterOfCircle(double radius)
    {
      Console.WriteLine("Диаметр: {0}", 2 * radius);
    }
  }
}