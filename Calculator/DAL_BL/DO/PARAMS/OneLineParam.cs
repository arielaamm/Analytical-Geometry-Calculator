using System;
using System.Collections.Generic;
namespace DAL_BL.DO.PARAMS
{
    
    public class OneLineParam
    {
        List<Polinom> polinoms { set; get; }
        public OneLineParam(Polinom p1, Polinom p2)
        {
            polinoms = new List<Polinom>();
            polinoms.Add(p1); polinoms.Add(p2);
        }
        public override string ToString()
        {
            string ret = "";
            for (int i = 0; i < polinoms.Count; i++)
            {
                ret += polinoms[i].ToString();
            }
            return ret;
        }
    }
}