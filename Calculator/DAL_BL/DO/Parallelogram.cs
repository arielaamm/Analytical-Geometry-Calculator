using System.Collections.Generic;

namespace DAL_BL.DO
{
    public class Parallelogram //-מקבילית
    {
        public double ObtuseAngle { set; get; }
        public double SharpAngle { set; get; }
        public double LongRib { set; get; }
        public double ShortRib { set; get; }
        public string Name { set; get; }
        public List<Point> PointsOnShape { set; get; }
    }
}
