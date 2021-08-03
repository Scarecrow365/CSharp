using System;

namespace ThousandTasks
{
  public static class Program
  {
    private static readonly Task16 Task = new();
    
    public static void Main(string[] args)
    {
      StartTask();
    }

    private static void StartTask()
    {
      Task.StartTask();
      ExitCheck();
    }
    
    private static void ExitCheck()
    {
      Console.WriteLine("\nВыйти? y / n");
      ConsoleKeyInfo input = Console.ReadKey();

      switch (input.Key)
      {
        case ConsoleKey.N:
          Console.WriteLine("\nПродолжаем...");
          StartTask();
          break;
        case ConsoleKey.Y:
          Console.WriteLine("\nПока");
          break;
        default:
          ExitCheck();
          break;
      }
    }
  }
}