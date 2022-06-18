using System.Collections.Generic;
using System;
using Actions = DAL_BL.DO.Simple_Stractures.Action;

namespace DAL_BL.DO.Simple_Stractures
{
    public class Line  //-ישר
    {
        public string Name { get; set; }
        public List<Point> PointOnLine { set; get; } = new();
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public double[] Vector
        {
            get
            {
                double[] vector = new double[2];
                vector[0] = EndPoint.X - StartPoint.X;
                vector[1] = EndPoint.Y - StartPoint.Y;
                return vector;
            }
        }
        public Equation Equation
        {
            get
            {
                double slope = GetSlope();
                double Num_part = StartPoint.Y - StartPoint.X * slope;
                Equation line = new Equation { NumPart = Num_part, Slope = slope };
                return line;
            }
            set { }
        }
        public double Lengh
        {
            get
            {
                return Math.Sqrt(Math.Pow(StartPoint.X - EndPoint.X, 2) + Math.Pow(StartPoint.Y - EndPoint.Y, 2));
            }
            set { }
        }


        public Line(Equation equation, string name_in = "")
        {
            if (name_in == "")
                Name = equation.ToString();
            else
                Name = name_in;
            StartPoint = new Point { X = 0, Y = equation.NumPart };//נקודת חיתןך ציר וואי
            EndPoint = new Point { X = -equation.NumPart / equation.Slope, Y = 0 };//נקודת חיתוך עם ציר איקס
            PointOnLine = new List<Point>();
        }

        public Line(List<Point> pointOnLine, Point startPoint, Point endPoint, string name = "")
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
            EndPoint = new Point { X = 0, Y = p.Y - slope * p.X };//נקודת חיתוך עם הציר הוואי כאשר איקס שווה 0
            PointOnLine = new List<Point>();
            PointOnLine.Add(p);

        }

        public double GetSlope() => Actions.GetSlope_points(StartPoint, EndPoint);

        public Point XEqualK(double k) => new Point { X = k, Y = Equation.Slope * k + Equation.NumPart };

        public Point YEqualK(double k) => new Point { X = (k - Equation.NumPart) / Equation.Slope, Y = k };




        public override string ToString()
        {
            return "Name:             " + Name + "\n" +
                    "Length:           " + Lengh + "\n" +
                    "StartPoint:       " + StartPoint.Name + ":" + "   (" + StartPoint.X + "," + StartPoint.Y + ")" + "\n" +
                    "EndPoint:         " + EndPoint.Name + ":" + "   (" + EndPoint.X + "," + EndPoint.Y + ")" + "\n" +
                     "Equation:     " + Equation.ToString();
        }
    }
}
