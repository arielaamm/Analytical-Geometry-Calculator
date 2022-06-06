using System;
using System.Collections.Generic;

namespace DAL_BL.DO.PARAMS
{
    public static class methods
    {
        public static Polinom PolinomsCombine(Polinom p1, Polinom p2)
        {
            Polinom ret = new Polinom(p1.Para);
            for (int i = 0; i < p1.PreNums.Count + p2.PreNums.Count - 1; i++)
            {
                ret.PreNums.Add(0);
            }

            for (int k = 0; k < p1.PreNums.Count; k++)
            {
                for (int j = 0; j < p2.PreNums.Count; j++)
                {
                    //Console.WriteLine("in");
                    ret.PreNums[k + j] += p1.PreNums[k] * p2.PreNums[j];
                }
            }
            return ret;
        }

    }
}