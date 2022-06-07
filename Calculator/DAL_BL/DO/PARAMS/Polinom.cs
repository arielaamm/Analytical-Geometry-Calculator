using System;
using System.Collections.Generic;
namespace DAL_BL.DO.PARAMS
{
    public class Polinom
    {
        public char Type { set; get; }
        private string[] degrees = new string[] { "", "x", "x^2", "x^3", "x^4", "x^5", "x^6", "x^7"};
        public List<double> PreNums { set; get; }
        public override string ToString()
        {
            string ret = "";
            for (int i = 0; i < PreNums.Count; i++)
            {
                if (PreNums[i]!=0)
                {
                    if (PreNums[i]>0 && i!=0)
                        ret += " + ";
                    if (PreNums[i]<0)
                        ret += " - ";
                    ret += Math.Abs(PreNums[i]).ToString();
                    ret += degrees[i];
                }
            }
            return ret;
        }
        public Polinom(char para)
        {
            Type = para;
            PreNums = new();
        }
    }
}