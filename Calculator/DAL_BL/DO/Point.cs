namespace DAL_BL.DO
{
    public class Point //-נקודה
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }

        public Point(double x, double y, string name = "")
        {
            X = x;
            Y = y;
            Name = name;
        }
        public Point()
        {
            X = new double();
            Y = new double();

        }

        public override string ToString()
        {
            return ("Name:       " + Name + "\n" +
                    "Point:     " +"("+ X + "," + Y + ")");
        }
    }
}
