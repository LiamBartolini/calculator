using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
            if (lblOutput.Text == "Operation doesn't find" || lblOutput.Text == "Division by zero Error!")
                lblOutput.Text = (sender as Button).Text;
            else
                lblOutput.Text += (sender as Button).Text;
        }

        private void CalculateResult(object sender, EventArgs e)
        {
            char[] operators = new char[] { '+', '-', '*', '/', '%' };
            string[] strOperators = new string[] { "sum", "subtraction", "multiplication", "division", "mod" };

            // try to find the operator
            List<string> data = new List<string>();
            bool isFind = false;
            string op = "";
            string expression = lblOutput.Text;

            //if (expression.Contains(','))
            //    Debug.WriteLine("comma");

            for (int i = 0; i < operators.Length; i++)
                if (expression.Contains(operators[i]))
                {
                    isFind = true;
                    data = lblOutput.Text.Split(operators[i]).ToList();
                    op = strOperators[i];
                    break;
                }
                else
                    isFind = false;

            if (!isFind)
                lblOutput.Text = "Operation doesn't find";
            else
            {
                // Faccio i calcoli
                double.TryParse(data[0], out double firstOperator);
                double.TryParse(data[1], out double secondOperator);
                lblHistory.Text = lblOutput.Text; // Save expression into history label
                if (op == "division")
                {
                    if (data[1] == "0")
                        lblOutput.Text = "Division by zero Error!";
                    else
                        lblOutput.Text = Convert.ToString(firstOperator / secondOperator);
                }
                else if (op == "sum")
                {
                    lblOutput.Text = Convert.ToString(firstOperator + secondOperator);
                }
                else if (op == "subtraction")
                {
                    lblOutput.Text = Convert.ToString(firstOperator - secondOperator);
                }
                else if (op == "multiplication")
                {
                    lblOutput.Text = Convert.ToString(firstOperator * secondOperator);
                }
                else if (op == "mod")
                {
                    lblOutput.Text = Convert.ToString(firstOperator % secondOperator);
                }
            }
        }

        private void DeleteExpression(object sender, EventArgs e)
        {
            lblOutput.Text = null;
            lblHistory.Text = null;
        }

        private void PoppingChar(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (lblOutput.Text.Length != 0)
            {
                List<char> listExpression = lblOutput.Text.ToList();
                listExpression.RemoveAt(listExpression.Count - 1);
                foreach (char c in listExpression)
                    sb.Append(c.ToString());
                lblOutput.Text = sb.ToString();
            }
            else
                lblOutput.Text = null;
        }

        private double width = 0;
        private double height = 0;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;

                if (width > height)
                    outerStack.Orientation = StackOrientation.Horizontal;
                else
                    outerStack.Orientation = StackOrientation.Vertical;
            }
        }
    }
}