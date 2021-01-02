using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarinCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddingChar(object sender, EventArgs e)
        {
            lblOutput.Text += (sender as Button).Text;
        }

        private void CalculateResult(object sender, EventArgs e)
        {
            char[] operators = new char[] { '+', '-', '*', '/' };
            string[] strOperators = new string[] { "sum", "subtraction", "multiplication", "division" };

            // try to find the operator
            List<string> data = new List<string>();
            bool isFind = false;
            string op = "";
            string expression = lblOutput.Text;
            for (int i = 0; i < operators.Length; i++)
                if (expression.Contains(operators[i]))
                {
                    isFind = true;
                    data = lblOutput.Text.Split(operators[i]).ToList();
                    op = strOperators[i];
                    break;
                }

            if (!isFind)
                lblOutput.Text = "Operation doesn't find";

            // Faccio i calcoli
            double.TryParse(data[0], out double firstOperator);
            double.TryParse(data[1], out double secondOperator);

            if (op == "division")
                if (data[1] == "0")
                    lblOutput.Text = "Division by zero Error!";
                else
                    lblOutput.Text = Convert.ToString(firstOperator / secondOperator);
            else if (op == "sum")
                lblOutput.Text = Convert.ToString(firstOperator + secondOperator);
            else if (op == "subtraction")
                lblOutput.Text = Convert.ToString(firstOperator - secondOperator);
            else
                lblOutput.Text = Convert.ToString(firstOperator * secondOperator);
        }

        private void DeleteExpression(object sender, EventArgs e)
        {
            lblOutput.Text = "";
        }

        private void PoppingChar(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<char> listExpression = lblOutput.Text.ToList();
            listExpression.RemoveAt(listExpression.Count - 1);
            foreach (char c in listExpression)
                sb.Append(c.ToString());
            lblOutput.Text = sb.ToString();
        }
    }
}