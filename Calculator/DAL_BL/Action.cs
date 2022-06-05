﻿using DAL_BL.DO;
using System;
using System.Collections.Generic;

namespace DAL_BL
{
    public static class Action
    {
        public static double GetSlope_points(Point p1, Point p2) => (p1.Y-p2.Y)/(p1.X-p2.X);

        public static double GetNegativeInverse_slope(double slope) => -1/slope;

        public static double GetNegativeInverse_line(Line line) => GetNegativeInverse_slope(line.GetSlope());

        public static double MultipicateVectors(double[] vec1, double[] vec2)
        {
            return vec1[0] * vec2[0] + vec1[1] * vec2[1];
        }
        public static double GetAngleBetweenTwoLines(Line line1, Line line2)
        {
            return Math.Acos(MultipicateVectors(line1.GetVector(), line1.GetVector()) / (line1.GetLengh() * line2.GetLengh()));

        }
        public static List<Line> CheckLineInLines(Line line, List<Line> all_lines)
        {

            bool is_line_in_list = false;
            for (int i = 0; i < all_lines.Count; i++)
            {
                if (line.GetEquation() == all_lines[i].GetEquation())
                {
                    for (int k = 0; k < line.PointOnLine.Count; k++)
                    {
                        Point p = line.PointOnLine[k];
                        is_line_in_list = true;
                        bool n_p = false;
                        for (int j = 0; j < all_lines[i].PointOnLine.Count; j++)
                        {
                            if (all_lines[i].PointOnLine[j] == p) n_p = true;
                        }
                        if (n_p == false)
                            all_lines[i].PointOnLine.Add(p);
                    }

                }

            }
            if (is_line_in_list == false)
                all_lines.Add(line);
            return all_lines;
        }
        public static List<Line> BuildLine(Point p1, Point p2, List<Line> all_lines)
        {
            Line line = new Line(p1, p2);
            return CheckLineInLines(line, all_lines);

        }
        public static List<Line> BuildLine(Point p1, double slope, List<Line> all_lines)
        {
            Line line = new Line(p1, slope);
            return CheckLineInLines(line, all_lines);

        }
        public static double GetDistans(Point p1, Point p2) => Math.Sqrt(Math.Pow(p1.Y-p2.Y, 2) + Math.Pow(p1.X-p2.X, 2));


        public static Line GetLineEquation(Point point1, Point point2)
        {
            Line line = new Line();
            line.PointOnLine.Add(point1);
            line.PointOnLine.Add(point2);
            line.StartPoint = point1;
            line.EndPoint = point2;
            line.Name = point1.Name + point2.Name;
            double slope = GetSlope_points(point1, point2);  
            return line;
        }

        public static bool IsPointOnLine(Line line, Point point)
        {
            if ((line.PointOnLine.Contains(point)) || (point.Y == line.GetEquation().NumPart + line.GetEquation().Slope * point.X))
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
            if (line1.GetEquation().Slope == line2.GetEquation().Slope)
                throw new ParallelException("The two lines are parallel and therefore will never meet");
            Point point = new();
            point.X = (line1.GetEquation().NumPart - line2.GetEquation().NumPart)/(line2.GetEquation().Slope - line1.GetEquation().Slope);
            point.Y = line1.GetEquation().NumPart + line1.GetEquation().Slope * point.X;
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
            Line altitude = new Line(point, GetNegativeInverse_line(line));
            return (GetDistans(point, FindIntersection(line, altitude)) * line.GetLengh())/2;
        }

        public static Point IntersectionX(Line line)
        {
            Point point = new() { Y = 0 };
            point.X = (-line.GetEquation().NumPart)/(line.GetEquation().Slope);
            return point;
        }
        public static Point IntersectionY(Line line) => new() { X = 0, Y = line.GetEquation().NumPart };
    }
}
