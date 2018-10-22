using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    //Дана длина ребра куба а. Найти объем куба V и площадь его поверхности S 
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите a - длину ребра куба: ");
                double a = Convert.ToDouble(Console.ReadLine());

                #region 1 решение 
                //double v = Math.Pow(a, 3);
                //double s = 6 * Math.Pow(a, 2);

                #endregion

                #region 2 решение 
                double v = a * a *a ;
                double s = 6 * (a*a);

                #endregion

                Console.WriteLine("Объем куба = {0} \n" + "Площадь его поверхности = {1}", v,s );
            }

            catch(OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
