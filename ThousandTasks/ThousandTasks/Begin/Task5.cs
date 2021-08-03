using System;

namespace ThousandTasks
{
  public class Task5
  {
    public void StartTask()
    {
      try
      {
        Console.Write("Введите длину ребра куба: ");
        var a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Объем куба = {0} \nПлощадь его поверхности = {1}", CubeVolume(a), SquareOfCube(a));
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

    private double SquareOfCube(double a) => 6 * (a * a);
    private double CubeVolume(double a) => a * a * a;
  }
}