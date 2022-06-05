using System.Collections.Generic;
using System;
using Actions = DAL_BL.Action;
namespace DAL_BL.DO
{
    public class Line  //-ישר
    {
        public string Name { get; set; }
        public List<Point> PointOnLine { set; get; } = new();
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Line(Equation equation, string name_in = "")
        {
            if (name_in == "")
                Name = equation.ToString();
            else
                Name = name_in;
            StartPoint = new Point(0, equation.NumPart);//נקודת חיתןך ציר וואי
            EndPoint = new Point(-equation.NumPart/equation.Slope, 0);//נקודת חיתוך עם ציר איקס
            PointOnLine  = new List<Point>();
        }
        public Line(string name, List<Point> pointOnLine, Point startPoint, Point endPoint)
        {
            Name = name;
            PointOnLine = pointOnLine;
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
        public Line(Point p1, Point p2, string name_in = "")
        {
            if (name_in == "")
                Name = p1.Name + p2.Name;
            else
                Name = name_in;
            StartPoint = p1;
            EndPoint = p2;
            PointOnLine = new List<Point>();
            PointOnLine.Add(p1); PointOnLine.Add(p2);
        }
        public Line(Point p, double slope, string name_in = "")
        {
            if (name_in == "")
                Name = p.Name;
            else
                Name = name_in;
            StartPoint = p;
            EndPoint = new Point(0, p.Y - slope * p.X);//נקודת חיתוך עם הציר הוואי כאשר איקס שווה 0
            PointOnLine = new List<Point>();
            PointOnLine.Add(p);

        }
        public Line()
        {
            Name = "";
            StartPoint = new Point();
            EndPoint = new Point();
            PointOnLine = new List<Point>();

        }
        public Equation GetEquation()
        {
            double slope = GetSlope();
            double Num_part = StartPoint.Y - StartPoint.X * slope;
            Equation line = new Equation(Num_part, slope);
            return line;
        }
        public double GetSlope()
        {
            return Actions.GetSlope_points(StartPoint, EndPoint);
        }

        public double GetLengh()
        {
            return Math.Sqrt(Math.Pow(StartPoint.X-EndPoint.X,2) + Math.Pow(StartPoint.Y-EndPoint.Y,2));
        }
        public double[] GetVector()
        {
            double [] vector = new double[2];
            vector[0] = EndPoint.X-StartPoint.X;
            vector[1] = EndPoint.Y-StartPoint.Y;
            return vector;
        }

        public Point xEqualK(double k)
        {
            return new Point(k, GetEquation().Slope * k + GetEquation().NumPart);
        }
        public Point yEqualK(double k)
        {
            return new Point((k - GetEquation().NumPart) / GetEquation().Slope, k);
        }


        public override string ToString()
        {
            return ("Name:             " + Name + "\n" +
                    "Length:           " + GetLengh() + "\n" +
                    "StartPoint-       "  +  StartPoint.Name + ":"+ "   (" + StartPoint.X + "," + StartPoint.Y + ")" + "\n" +
                    "EndPoint-         " +  EndPoint.Name + ":"+  "   ("+ EndPoint.X + "," + EndPoint.Y + ")"+ "\n" +
                     "Equation:     " + GetEquation().ToString());
        }
    }
}
