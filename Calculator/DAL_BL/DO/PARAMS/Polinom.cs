using System;
using System.Collections.Generic;
namespace DAL_BL.DO.PARAMS
{
    public class Polinom
    {
        public char Para { set; get; }
        public List<double> PreNums { set; get; }
        public override string ToString()
        {
            string ret = "";
            for (int i = PreNums.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    if (PreNums[0] > 0)
                        ret +=  " + "+PreNums[0];
                    if (PreNums.Count < 0)
                        ret += " - " + Math.Abs(PreNums[0]);
                    continue;
                }
                string param_pow = "";
                string before_param = "";
                if (i == 1)
                    param_pow = Para.ToString();
                else
                    param_pow = Para + "^" + i.ToString();
                if (PreNums[i] > 0)
                {
                    if ((PreNums[i]) == 1)
                    {
                        before_param = " + ";
                        if (i == PreNums.Count - 1)
                            before_param = "";
                    }
                    else
                    {
                        before_param = " + " + PreNums[i].ToString();
                        if (i == PreNums.Count - 1)
                            before_param = PreNums[i].ToString();
                    }
                }
                if (PreNums[i] < 0)
                {
                    if (PreNums[i] == -1)
                        before_param = " - ";
                    else
                        before_param = " - " + Math.Abs(PreNums[i]);
                }
                if (PreNums[i] != 0)
                    ret += before_param + param_pow;
            }
            if (ret == "")
                ret = "0";
            return ret;
        }
        public Polinom(char para)
        {
            Para = para;
            PreNums = new List<double>();
        }
    }
}