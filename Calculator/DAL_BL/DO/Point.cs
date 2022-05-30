namespace DAL_BL.DO
{
    public class Point //-נקודה
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return ("Name:       " + Name + "\n" +
                    "Point:     " +"("+ X + "," + Y + ")");
        }
    }
}
