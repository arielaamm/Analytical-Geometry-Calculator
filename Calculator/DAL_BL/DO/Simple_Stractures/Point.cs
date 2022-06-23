using System.Collections.Generic;
using System;
using Actions = DAL_BL.DO.Simple_Stractures.Action;

namespace DAL_BL.DO.Simple_Stractures
{
    public class Point //-נקודה
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }
        public bool on (Line line)
        {
            return Math.Abs(Y - line.GetSlope() * X + line.Equation.NumPart) < 0.01;
                
        }
        public override string ToString()
        {
            return "Name:       " + Name + "\n" +
                    "Point:     " + "(" + X + "," + Y + ")";
        }
    }
}
