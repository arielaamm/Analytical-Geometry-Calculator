using System;
using System.IO;
using DAL_BL.DO.PARAMS;
using Actions2 = DAL_BL.DO.PARAMS.methods;
using Action = DAL_BL.DO.Simple_Stractures.Action;
using System.Collections.Generic;
using DAL_BL.DO.Simple_Stractures;
using Drawing;
using System.Drawing;
using System.Drawing.Imaging;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Image image1 = Image.FromFile(projectDirectory + "\\images.jpg");
            //Pen p12 = new Pen(Color.FromName("Black"));
            //var graphic = Graphics.FromImage(image1);
            //graphic.DrawLine(p12, (int)(image1.Width / 2), 0, (int)(image1.Width/2), image1.Height);
            //image1.Save(projectDirectory + "\\image.jpg");
            DAL_BL.DO.Simple_Stractures.Point p = new DAL_BL.DO.Simple_Stractures.Point();
            var p2 = new DAL_BL.DO.Simple_Stractures.Point();
            var p3 = new DAL_BL.DO.Simple_Stractures.Point();
            p.X = 1; p.Y = 2; p2.X = 0; p2.Y = 0; p3.X = 10; p3.Y = 10;
            Line line1 = new Line(p, p2);
            List<DAL_BL.DO.Simple_Stractures.Point> points = new List<DAL_BL.DO.Simple_Stractures.Point>();
            points.Add(p); points.Add(p2); points.Add(p3);
            List <Line> lines = new List<Line>();
            lines.Add(line1);
            Drawing.Drawing.GetCoordinateSystem(image1, lines, points);




            



            Console.WriteLine("Enter the pres for the first polinom, end send -5");
            Polinom p1 = new('x');
            double num1 = double.Parse(Console.ReadLine());
            int i = 0;
            while(num1 != -5)
            {
                p1.PreNums.Add(num1);
                i++;
                num1 = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter  pres for the second polinom, end send -5");
            Polinom p12 = new('x');
            num1 = double.Parse(Console.ReadLine());
            i = 0;
            while (num1 != -5)
            {
                p12.PreNums.Add(num1);
                i++;
                num1 = double.Parse(Console.ReadLine());
            }

            Console.WriteLine(Actions2.PolinomsAdd(p1, p12).ToString());
            Console.WriteLine(Actions2.PolinomsCombine(p1, p12).ToString());


            Console.WriteLine("enter 4 point pleases");
            num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            double num3 = double.Parse(Console.ReadLine());
            double num4 = double.Parse(Console.ReadLine());

            double num5 = double.Parse(Console.ReadLine());
            double num6 = double.Parse(Console.ReadLine());

            double num7 = double.Parse(Console.ReadLine());
            double num8 = double.Parse(Console.ReadLine());


            
            DAL_BL.DO.Simple_Stractures.Point point1 = new() { Name = "A", X = num1, Y = num2 };
            DAL_BL.DO.Simple_Stractures.Point point2 = new() { Name = "B", X = num3, Y = num4 };
            Line line = new Line (point1, point2);
            DAL_BL.DO.Simple_Stractures.Point point3 = new() { Name = "C", X = num5, Y = num6 };
            DAL_BL.DO.Simple_Stractures.Point point4 = new() { Name = "D", X = num7, Y = num8 };
            Line line2 = new Line (point3, point4);
            DAL_BL.DO.Simple_Stractures.Point point;
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
