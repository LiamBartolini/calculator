using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xamarinCalculator.Models
{
    static class Calculator
    {
        public static string History { get; private set; }
        public static string Outuput { get; private set; }
        static bool isBracked = false;

        public static string AddingChar(string output, string btnText)
        {
            if (btnText == "(/)" && !isBracked)
            {
                isBracked = true;
                return output += "(";
            }
            
            if (btnText == "(/)" && isBracked)
            {
                isBracked = false;
                return output += ")";
            }

            if (output == "Operation doesn't find" || output == "Divisio by zero Error")
                return btnText;
            else
                return output += btnText;
        }

        public static string CalculateResult(string output)
        {
            char[] operators = new char[] { '+', '-', '*', '/', '%', 's', '!' };
            string[] strOperators = new string[] { "sum", "subtraction", "multiplication", "division", "mod", "sqrt", "fact"};

            // find the operator
            List<string> data = new List<string>();
            bool isFind = false;
            string op = "";
            for (int i = 0; i < operators.Length; i++)
                if (output.Contains(operators[i].ToString()))
                {
                    isFind = true;
                    data = output.Split(operators[i]).ToList();
                    op = strOperators[i];
                    break;
                }
                else
                    isFind = false;

            if (!isFind)
                return "Operation doesn't find";
            else
            {
                double.TryParse(data[0], out double firstOperator);
                double.TryParse(data[1], out double secondOperator);
                History = output + " =";
                
                switch(op)
                {
                    case "division":
                        if (data[1] == "0")
                            return "Division by zero Error!";
                        else
                            return (firstOperator / secondOperator).ToString();
                    case "sum":
                        return (firstOperator / secondOperator).ToString();
                    case "subtraction":
                        return (firstOperator - secondOperator).ToString();
                    case "multiplication":
                        return (firstOperator * secondOperator).ToString();
                    case "mod":
                        return (firstOperator % secondOperator).ToString();
                    case "sqrt":
                        return Math.Sqrt(firstOperator).ToString();
                    case "fact":
                        int f = 1;
                        for (int i = (int)firstOperator; i < firstOperator - 1; i++)
                            f *= i;
                        return f.ToString();
                    default:
                        return "Can't resolve";
                }
            }
        }

        public static void ClearScreen()
        {
            Outuput = null;
            History = null;
            isBracked = false;
        }

        public static string PoppingChar(string output)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(output))
            {
                List<char> listExpression = output.ToList();
                if (listExpression[listExpression.Count - 1] == ')')
                    isBracked = true;
                else
                    isBracked = false;

                if (listExpression[listExpression.Count - 1] == ' ')
                    listExpression.RemoveRange(listExpression.Count - 3, 3);
                else
                    listExpression.RemoveAt(listExpression.Count - 1);
                foreach (char c in listExpression)
                    sb.Append(c.ToString());
                return sb.ToString();
            }

            return null;
        }
    }
}