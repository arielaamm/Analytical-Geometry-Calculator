using System;
using DAL_BL.DO;
using DAL_BL;
using Action = DAL_BL.Action;
//f
namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter 4 point pleases");
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            double num3 = double.Parse(Console.ReadLine());
            double num4 = double.Parse(Console.ReadLine());

            double num5 = double.Parse(Console.ReadLine());
            double num6 = double.Parse(Console.ReadLine());

            double num7 = double.Parse(Console.ReadLine());
            double num8 = double.Parse(Console.ReadLine());



            Point point1 = new() { Name = "A", X = num1, Y = num2 };
            Point point2 = new() { Name = "B", X = num3, Y = num4 };
            Line line = Action.GetLineEquation(point1, point2);
            Point point3 = new() { Name = "C", X = num5, Y = num6 };
            Point point4 = new() { Name = "D", X = num7, Y = num8 };
            Line line2 = Action.GetLineEquation(point3, point4);
            Point point;
            try
            {
                point = Action.FindIntersection(line, line2);
                point.Name = "O";
                Console.WriteLine(line.ToString());
                Console.WriteLine();
                Console.WriteLine(line2.ToString());
                Console.WriteLine();
                Console.WriteLine(point.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
