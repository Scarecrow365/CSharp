using System;

namespace ThousandTasks
{
  public class Task13
  {
    //Даны два круга с общим центром и радиусами R1 и R2 (R1 > R2).
    //Найти площади этих кругов S1 и S2, а также площадь S3 кольца,
    //внешний радиус которого равен R1, а внутренний радиус равен R2:

    public void StartTask()
    {
      try
      {
        var r1 = 5f;
        var r2 = 3f;

        float firstCircle = AreaOfCircle(r1);
        float secondCircle = AreaOfCircle(r2);

        float thirdCircle = firstCircle - secondCircle;
        Console.WriteLine("Площадь третьего круга с внешним радиусом {0} и внутреннем радиусом {1}: {2}", r1, r2, thirdCircle);
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

    private float AreaOfCircle(float radius)
    {
      float area = MathF.PI * (radius * radius);
      Console.WriteLine("Площадь круга с радиусом {0}: {1}", radius, area);
      return area;
    }
  }
}