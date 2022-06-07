using System;
using System.Collections.Generic;

namespace DAL_BL.DO.PARAMS
{
    public static class methods
    {
        public static Polinom PolinomsCombine(Polinom p1, Polinom p2) // הנחה: שני הפולינומים בעלי אותו נעלם
        {
            Polinom ret = new Polinom(p1.Type);
            for (int i = 0; i < p1.PreNums.Count + p2.PreNums.Count - 1; i++)
            {
                ret.PreNums.Add(0);
            }

            for (int k = 0; k < p1.PreNums.Count; k++)
            {
                for (int j = 0; j < p2.PreNums.Count; j++)
                {
                    ret.PreNums[k + j] += p1.PreNums[k] * p2.PreNums[j];
                }
            }
            return ret;
        }
        public static Polinom PolinomsAdd(Polinom p1, Polinom p2) // הנחה: שני הפולינומים בעלי אותו נעלם
        {
            Polinom ret = new Polinom(p1.Type);
            ret.PreNums = new(Math.Max(p1.PreNums.Count, p2.PreNums.Count));
            for (int i = 0; i < Math.Max(p1.PreNums.Count, p2.PreNums.Count); i++)
            {
                ret.PreNums.Add(0);
            }
            for (int k = 0; k < p1.PreNums.Count; k++)
            {
                ret.PreNums[k] = p1.PreNums[k];

            }
            for (int j = 0; j < p2.PreNums.Count; j++)
            {
                ret.PreNums[j] += p2.PreNums[j];
            }
            return ret;
        }

    }
}