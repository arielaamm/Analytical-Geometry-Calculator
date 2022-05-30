using DAL_BL.DO;
using System;
namespace DAL_BL
{
    public static class Action
    {
        public static double GetSlope(Point p1, Point p2) => (p1.Y-p2.Y)/(p1.X-p2.X);

        public static double GetNegativeInverse(double slope) => -1/slope;

        public static double GetDistans(Point p1, Point p2) => Math.Sqrt(Math.Pow(p1.Y-p2.Y, 2) + Math.Pow(p1.X-p2.X, 2));

        public static Line GetLineEquation(Point p, double slope) // לא לשכוח כל פעם שמשתמשים להכניס את הנקודות התחלה וסוף והנלווה
        {
            Line line = new Line();
            line.PointOnLine.Add(p);
            Equation equation = new Equation()
            {
                Slope = slope,
                NumPart = slope*p.X - p.Y,
                VariablePart =  new Variable() { MultipliedBy = slope }
            };
            line.Equation = equation;
            return line;
        }

        public static Line GetLineEquation(Point point1, Point point2)
        {
            Line line = new Line();
            line.PointOnLine.Add(point1);
            line.PointOnLine.Add(point2);
            line.StartPoint = point1;
            line.EndPoint = point2;
            line.Name = point1.Name + point2.Name;
            line.Length = GetDistans(point1, point2);
            double slope = GetSlope(point1, point2);
            Equation equation = new Equation()
            {
                NumPart = -slope*point1.X + point1.Y,
                VariablePart =  new Variable() { MultipliedBy = slope },
                Slope = slope,
            };
            line.Equation = equation;
            return line;
        }

        public static bool IsPointOnLine(Line line, Point point)
        {
            if ((line.PointOnLine.Contains(point)) || (point.Y == line.Equation.NumPart + line.Equation.VariablePart.MultipliedBy * point.X))
                return true;
            return false;
        }

        public static void AddPointToLine(Line line, Point point)
        {
            if (IsPointOnLine(line, point))
                line.PointOnLine.Add(point);
        }

        // Numerator הוא הרחוק מ pointStart
        // Denominator הוא הרחוק מ pointEnd
        public static Point GetMiddlePoint(Point pointStart, Point pointEnd, double Numerator = 1, double Denominator = 1) // Numerator - מונה , Denominator - מכנה
        {
            return new Point()
            {
                X = (pointEnd.X*Denominator + pointStart.X*Numerator)/(Numerator+Denominator),
                Y = (pointEnd.Y*Denominator + pointStart.Y*Numerator)/(Numerator+Denominator),
            };
        }

        public static double GetArea(Point point1, Point point2, Point point3)
        {
            return (Math.Abs(point1.X*(point3.Y-point2.Y)+point2.X*(point1.Y-point3.Y)+point3.X*(point2.Y-point1.Y)))/2;
        }

        public static Point FindIntersection(Line line1, Line line2)
        {
            if (line1.Equation.VariablePart.MultipliedBy == line2.Equation.VariablePart.MultipliedBy)
                throw new ParallelException("The two lines are parallel and therefore will never meet");
            Point point = new();
            point.X = (line1.Equation.NumPart - line2.Equation.NumPart)/(line2.Equation.VariablePart.MultipliedBy - line1.Equation.VariablePart.MultipliedBy);
            point.Y = line1.Equation.NumPart + line1.Equation.VariablePart.MultipliedBy * point.X;
            return point;
        }
        /// <summary>
        /// Get area by using line and a point
        /// </summary>
        /// <param name="point">The point opposite the line</param>
        /// <param name="line">The line</param>
        /// <returns></returns>
        public static double GetArea(Point point, Line line)
        {
            Line altitude = GetLineEquation(point, GetNegativeInverse(line.Equation.Slope));
            return (GetDistans(point, FindIntersection(line, altitude)) * line.Length)/2;
        }

        public static Point IntersectionX(Line line)
        {
            Point point = new() { Y = 0 };
            point.X = (-line.Equation.NumPart)/(line.Equation.VariablePart.MultipliedBy);
            return point;
        }
        public static Point IntersectionY(Line line) => new() { X = 0, Y = line.Equation.NumPart };
    }
}
