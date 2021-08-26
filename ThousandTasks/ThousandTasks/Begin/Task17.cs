using System;

namespace ThousandTasks
{
  public class Task17
  {
    /*Даны три точки A,B,C на числовой оси. Найти длины отрезков AC и BC и их сумму*/

    public void StartTask()
    {
      try
      {
        Console.Write("Введите точку A ");
        double a = SetNumber();
        
        Console.Write("Введите точку B ");
        double b = SetNumber();
        
        Console.Write("Введите точку C ");
        double c = SetNumber();

        double ac = FindLengthOfTwoPoints(a, c);
        Console.WriteLine($"Длина отрезков AC: {ac}");
        
        double bc = FindLengthOfTwoPoints(b, c);
        Console.WriteLine($"Длина отрезков BC: {bc}");

        double sumOfLenght = ac + bc;
        Console.WriteLine($"Сумма длины отрезков AC и BC: {sumOfLenght}");
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

    private double FindLengthOfTwoPoints(double lhs, double rhs) => lhs + rhs;
    private double SetNumber() => Convert.ToDouble(Console.ReadLine());
  }
}