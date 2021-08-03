using System;

namespace ThousandTasks
{
  public class Task6
  {
    //Даны длины ребер a,b,c прямоугольного параллелепипеда. Найти его объем V и его площадь S 

    public void StartTask()
    {
      try
      {
        Console.Write("Введите первую сторону ребра: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите вторую сторону ребра: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите третью сторону ребра: ");
        double c = Convert.ToDouble(Console.ReadLine());

        double v = VolumeOfRectangleParallelepiped(a, b, c);
        double s = Area(a, b, c);

        Console.WriteLine("Объем прямоугольного параллелипипеда = {0}; \nЕго площадь = {1}", v, s);
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

    private double Area(double a, double b, double c) => 2 * (a * b + b * c + c * a);
    private double VolumeOfRectangleParallelepiped(double a, double b, double c) => a * b * c;
  }
}