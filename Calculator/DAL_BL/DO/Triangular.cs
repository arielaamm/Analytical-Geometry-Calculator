using System.Collections.Generic;

namespace DAL_BL.DO
{
    public class Triangular //-משולש
    {
        public double A_Angle { set; get; }
        public double B_Angle { set; get; }
        public double C_Angle { set; get; }
        public double A_Rib { set; get; }
        public double B_Rib { set; get; }
        public double C_Rib { set; get; }
        public string Name { set; get; }
        public List<Point> PointOnShape { set; get; }
    }
}
