using System;
using DAL_BL.DO;
using DAL_BL.DO.PARAMS;
using Actions2 = DAL_BL.DO.PARAMS.methods;
using Action = DAL_BL.DO.Action;
using System.Collections.Generic;

//f
namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter teh pres for the first polinom, end send -5");
            Polinom p1 = new('x');
            double num1 = double.Parse(Console.ReadLine());
            int i = 0;
            while(num1 != -5)
            {
                p1.PreNums.Add(num1);
                i++;
                num1 = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter teh pres for the second polinom, end send -5");
            Polinom p2 = new('x');
            num1 = double.Parse(Console.ReadLine());
            i = 0;
            while (num1 != -5)
            {
                p2.PreNums.Add(num1);
                i++;
                num1 = double.Parse(Console.ReadLine());
            }

            Console.WriteLine(Actions2.PolinomsCombine(p1, p2).ToString());


            Console.WriteLine("enter 4 point pleases");
            num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            double num3 = double.Parse(Console.ReadLine());
            double num4 = double.Parse(Console.ReadLine());

            double num5 = double.Parse(Console.ReadLine());
            double num6 = double.Parse(Console.ReadLine());

            double num7 = double.Parse(Console.ReadLine());
            double num8 = double.Parse(Console.ReadLine());



            Point point1 = new() { Name = "A", X = num1, Y = num2 };
            Point point2 = new() { Name = "B", X = num3, Y = num4 };
            Line line = new Line (point1, point2);
            Point point3 = new() { Name = "C", X = num5, Y = num6 };
            Point point4 = new() { Name = "D", X = num7, Y = num8 };
            Line line2 = new Line (point3, point4);
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
