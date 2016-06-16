using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestConsoleApplication
{
    public static class Infrastract
    {
        private static char parL = '(';
        private static char parR = ')';
        private static string pattern = @"\w*[^0-9*^\+*^\-*^\**^\/*^\,*^\(*^\)*]";

        private static Regex regex = new Regex(pattern);

        public static bool RegexMatExp(string str)
        {
            return !regex.IsMatch(str);
        }

        public static bool ParenthesesEqual(string strLine)
        {
            int parLFirst = strLine.IndexOf(parL);
            int parLLast = strLine.IndexOf(parR);

            if (parLFirst == -1 && parLLast == -1)
            {
                return true;
            }

            if (parLFirst > parLLast)
            {
                return false;
            }

            int pareL = strLine.Where(m => m == parL).Count();
            int pareR = strLine.Where(m => m == parR).Count();

            if (pareL != pareR)
            {
                return false;
            }
            return true;
        }

        public static List<string> ConverList(string str)
        {
            List<string> tempList = new List<string>();

            SubConverList(str, tempList);

            return tempList;
        }

        private static void SubConverList(string str, List<string> tempList)
        {
                bool flag = false;
                float number;
                bool numberEnd = true;

                for (int i = 0; i < str.Length; i++)
                {
                    switch (str[i])
                    {
                        case '(':
                            tempList.Add(str[i].ToString());
                            SubConverList(str.Substring(i + 1), tempList);
                            flag = true;
                            break;
                        case ')':
                        case '*':
                        case '/':
                        case '+':                            
                            if (tempList.Count != 0 && tempList.Count != 1 && tempList[tempList.Count - 1] == ")")
                            {
                                tempList.Add(str[i].ToString());
                                SubConverList(str.Substring(i + 1), tempList);
                                flag = true;
                            }
                            else
                            {
                                tempList.Add(str.Substring(0, i));
                                tempList.Add(str[i].ToString());
                                SubConverList(str.Substring(i + 1), tempList);
                                flag = true;
                            }
                            break;
                        case '-':
                            if (tempList.Count == 0 | i == 0 | tempList.Count == 1)
                            {
                                break;
                            }                            
                            
                            if (tempList[tempList.Count - 1] == ")")
                            {
                                tempList.Add(str[i].ToString());
                                SubConverList(str.Substring(i + 1), tempList);
                                flag = true;
                            }
                            else
                            {
                                tempList.Add(str.Substring(0, i));
                                tempList.Add(str[i].ToString());
                                SubConverList(str.Substring(i + 1), tempList);
                                flag = true;
                            }
                            break;
                    }

                    if (numberEnd && Single.TryParse(str, out number))
                    {
                        tempList.Add(str);
                        numberEnd = false;
                    }

                    if (flag)
                    {
                        break;
                    }
                }
        }

        public static bool SigMatExpLocWro(string strLine)
        {
            bool flag = true;

            for (int i = 0; i < strLine.Length; i++)
            {
                if (strLine[i] == '*' | strLine[i] == '/' | strLine[i] == '+' | strLine[i] == '-' | strLine[i] == ',')
                {
                    if (strLine[0] == ',' | strLine[strLine.Length-1] == ',')
                    {
                        flag = false;
                    }

                    if (strLine[i] == ',' & i + 1 < strLine.Length & i - 1 <= 0)
                    {
                        try
                        {
                            Convert.ToInt32(strLine[i + 1]);
                            Convert.ToInt32(strLine[i - 1]);
                        }
                        catch (Exception)
                        {
                            flag = false;
                        }
                    }

                    if (i + 1 < strLine.Length && strLine[i + 1] == '*' | strLine[i + 1] == '/' | strLine[i + 1] == '+' | strLine[i + 1] == '-' | strLine[i + 1] == ',')
                    {
                        flag = false;
                    }
                }

                if (!flag)
                {
                    break;
                }
            }

            return flag;
        }
    }
}
