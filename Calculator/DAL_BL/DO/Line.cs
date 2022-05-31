using System.Collections.Generic;

namespace DAL_BL.DO
{
    public class Line  //-ישר
    {
        public string Name { get; set; }
        public List<Point> PointOnLine { set; get; } = new();
        public Equation Equation { get; set; }
        public double Length { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public override string ToString()
        {
            return ("Name:             " + Name + "\n" +
                    "Length:           " + Length + "\n" +
                    "StartPoint-       "  +  StartPoint.Name + ":"+ "   (" + StartPoint.X + "," + StartPoint.Y + ")" + "\n" +
                    "EndPoint-         " +  EndPoint.Name + ":"+  "   ("+ EndPoint.X + "," + EndPoint.Y + ")"+ "\n" +
                    "Equation:     " + "  y = " + Equation.Slope + "x" + " + " + Equation.NumPart);
        }
    }
}
