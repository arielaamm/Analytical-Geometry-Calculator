namespace DAL_BL.DO
{
    public class Equation //y = Slope * x + NumPart
    {
        public double NumPart { set; get; }
        public double Slope { set; get; }

        public Equation(double a, double b)
        {
            NumPart = a; Slope = b; 
        }
        public Equation()
        {
            NumPart = new double();
            Slope = new double();
        }
        public override string ToString()
        {
            return "y = " + Slope.ToString() + " * x + " + NumPart.ToString();  
        }
    }
}
