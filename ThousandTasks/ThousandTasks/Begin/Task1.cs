using System;

namespace ThousandTasks
{
  public class Task1
  {
    public void StartTask()
    {
      Console.Write("Задайте сторону квадрата для вычисления его периметра: ");
      try
      {
        FindPerimeterOfSquare();
      }
      
      catch (FormatException e)
      {                
        Console.WriteLine(e.Message);          
        StartTask();
      }
      
      catch (OverflowException ex)
      {
        Console.WriteLine(ex.Message);
        StartTask();
      }             
    }

    private void FindPerimeterOfSquare()
    {
      int a = Convert.ToInt16(Console.ReadLine());
      int p = a * 4;
      Console.WriteLine("Периметр квадрата = " + p);
    }
  }
}