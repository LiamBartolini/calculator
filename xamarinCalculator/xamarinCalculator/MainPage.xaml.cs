﻿using System;
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
                lblHistory.Text = lblOutput.Text + " ="; // Save expression into history label
                if (op == "division")
                    if (data[1] == "0")
                        lblOutput.Text = "Division by zero Error!";
                    else
                        lblOutput.Text = Convert.ToString(firstOperator / secondOperator);
                else if (op == "sum")
                    lblOutput.Text = Convert.ToString(firstOperator + secondOperator);
                else if (op == "subtraction")
                    lblOutput.Text = Convert.ToString(firstOperator - secondOperator);
                else if (op == "multiplication")
                    lblOutput.Text = Convert.ToString(firstOperator * secondOperator);
                else if (op == "mod")
                    lblOutput.Text = Convert.ToString(firstOperator % secondOperator);
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
            if (lblOutput.Text.Length != 0 || !string.IsNullOrEmpty(lblOutput.Text))
            {
                List<char> listExpression = lblOutput.Text.ToList();
                if (listExpression[listExpression.Count - 1] == ' ')
                    listExpression.RemoveRange(listExpression.Count - 3, 3);
                else
                    listExpression.RemoveAt(listExpression.Count - 1);
                foreach (char c in listExpression)
                    sb.Append(c.ToString());
                lblOutput.Text = sb.ToString();
            }
            else
                lblOutput.Text = null;
        }

        private void ScientificCalculator(object sender, EventArgs e)
        {
            // 7x5
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                },
                BackgroundColor = Color.Cyan,
                Margin = 50
            };
            grid.Children.Add(new Button { Text = " ! " }, 0, 0);
            grid.Children.Add(new Button { Text = " 2^x " }, 0, 1);
            grid.Children.Add(new Button { Text = " x^2 " }, 1, 0);
            grid.Children.Add(new Button { Text = " x^3 " }, 1, 1);
            Content = grid;
        }

        //private double width = 0;
        //private double height = 0;

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);
        //    if (this.width != width || this.height != height)
        //    {
        //        this.width = width;
        //        this.height = height;

        //        if (width > height)
        //            outerStack.Orientation = StackOrientation.Horizontal;
        //        else
        //            outerStack.Orientation = StackOrientation.Vertical;
        //    }
        //}
    }
}