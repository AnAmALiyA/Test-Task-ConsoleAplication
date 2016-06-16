using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestConsoleApplication
{
    internal class Program
    {
        private static void Main()
        {
            string strLine;
            
            Console.WriteLine("Enter your mathematical expression\n");

            while (true)
            {				
                strLine = Console.ReadLine(); 

                if (String.IsNullOrEmpty(strLine))
                {
                    Console.WriteLine("Enter your mathematical expression\n");
                }
                else
                {
                    if (String.Format(strLine).ToLower() == "exit")
                    {
                        break;
                    }

                    if (Infrastract.RegexMatExp(strLine))
                    {
                        if (Infrastract.ParenthesesEqual(strLine))
                        {
                            bool smelw = Infrastract.SigMatExpLocWro(strLine);

                            if (smelw)
                            {
                                var strArry = Infrastract.ConverList(strLine);

                                IMathExecutor instance = new MathFormulaExecutor(strArry);
                                float expr = instance.Calculate();

                                Console.WriteLine("The calculation of the mathematical expression: {0}", expr);
                            }
                            else
                            {
                                Console.WriteLine("Signs in mathematical expression is located wrong");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Mathematical expression have error with parentheses");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Mathematical expression is not entered incorrectly");
                    }
                }
                Console.WriteLine("To exit the application, enter: Exit\n");
            }
        }
    }
}
