using System.Collections.Generic;

namespace DAL_BL.DO
{
    public class Triangular //-משולש
    {
        public Point A { set; get; }
        public Point B { set; get; }
        public Point C { set; get; }
        public string Name { set; get; }
        public List<Point> PointOnShape { set; get; }
    }
}
