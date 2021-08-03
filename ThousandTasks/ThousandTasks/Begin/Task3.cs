using System;

namespace ThousandTasks
{
  public class Task3
  {
    public void StartTask()
    {
      try
      {
        Console.Write("Задайте сторону а прямоугольника: ");
        int a = Convert.ToInt16(Console.ReadLine());

        Console.Write("Задайте сторону b прямоугольника: ");
        int b = Convert.ToInt16(Console.ReadLine());

        FindSquareOfRectangle(a, b);
        FindPerimeterOfRectangle(a, b);
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

    private void FindPerimeterOfRectangle(int a, int b)
    {
      int p = 2 * (a + b);
      Console.WriteLine("Периметр прямоугольника = {0}", p);
    }

    private void FindSquareOfRectangle(int a, int b)
    {
      int s = a * b;
      Console.WriteLine("Площадь прямоугольника = {0}", s);
    }
  }
}