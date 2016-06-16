using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication
{
    public class MathFormulaExecutor : IMathExecutor
    {
        private List<string> strList;
        public MathFormulaExecutor(List<string> strList)
        {
            this.strList = strList;
        }

        public float Calculate()
        {
            var arry = ConverArry(strList);

            return Convert.ToSingle(arry[0]);
        }
        
        private List<string> ConverArry(List<string> strList, int index = 0, bool star = false)
        {
            int count=1;
            bool flag = false;
            for (int i = index; i < strList.Count; i++)
            {
                count++;
                switch (strList[i])
                {
                    case "(":
                        strList = ConverArry(strList, i + 1, true);
                        break;
                    case ")":
                        if (star)
                        {                                                   
                            string[] strArry = new string[strList.Count];
                            strList.CopyTo(strArry);
                            List<string> tempStrList = new List<string>(strArry);

                            tempStrList.RemoveRange(i, tempStrList.Count - i);
                            tempStrList.RemoveRange(0, index);
                            tempStrList = ConverIntoParen(tempStrList);

                            strList.RemoveRange(index - 1, count);
                            strList.Insert(index-1,tempStrList[0]);
                            
                            strList = ConverArry(strList);
                            flag = true;
                        }

                        break;
                }

                if (flag)
                {
                    break;
                }
            }

            if (!flag)
            {
               ConverIntoParen(strList); 
            }
            return strList;
        }

        private List<string> ConverIntoParen(List<string> strList)
        {

            int count = 4;
            while (0 < count)
            {
                for (int j = 0; j < strList.Count; j++)
                {
                    if (count == 4 && strList[j] == "*")
                    {
                        string mul = (Double.Parse(strList[j - 1]) * Double.Parse(strList[j + 1])).ToString();
                        strList.RemoveAt(j - 1);
                        strList.RemoveAt(j - 1);
                        strList.RemoveAt(j - 1);
                        strList.Insert(j - 1, mul);
                        ConverIntoParen(strList);
                        continue;
                    }
                    if (count == 3 && strList[j] == "/")
                    {
                        string div = (Double.Parse(strList[j - 1]) / Double.Parse(strList[j + 1])).ToString();
                        strList.RemoveAt(j - 1);
                        strList.RemoveAt(j - 1);
                        strList.RemoveAt(j - 1);
                        strList.Insert(j - 1, div);
                        ConverIntoParen(strList);
                        continue;
                    }
                    if (count == 2 && strList[j] == "+")
                    {
                        string sum = (Double.Parse(strList[j - 1]) + Double.Parse(strList[j + 1])).ToString();
                        strList.RemoveAt(j - 1);
                        strList.RemoveAt(j - 1);
                        strList.RemoveAt(j - 1);
                        strList.Insert(j-1, sum);
                        ConverIntoParen(strList);
                        continue;
                    }
                    if (count == 1 && strList[j] == "-")
                    {
                        string sub = (Double.Parse(strList[j - 1]) - Double.Parse(strList[j + 1])).ToString();
                        strList.RemoveAt(j - 1);
                        strList.RemoveAt(j - 1);
                        strList.RemoveAt(j - 1);
                        strList.Insert(j - 1, sub);
                        ConverIntoParen(strList);
                    }
                }

                count--;
            }           
 
            return strList;
        }
    }
}