using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarinCalculator.Models;

namespace xamarinCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddingChar(object sender, EventArgs e) => lblOutput.Text = Calculator.AddingChar(lblOutput.Text, (sender as Button).Text);

        private void CalculateResult(object sender, EventArgs e)
        {
            lblOutput.Text = Calculator.CalculateResult(lblOutput.Text);
            lblHistory.Text = Calculator.History;
        }

        private void DeleteExpression(object sender, EventArgs e)
        {
            Calculator.ClearScreen();
            lblOutput.Text = Calculator.Outuput;
            lblHistory.Text = Calculator.History;
        }

        private void PoppingChar(object sender, EventArgs e) => lblOutput.Text = Calculator.PoppingChar(lblOutput.Text);

        private async void ScientificCalculator(object sender, EventArgs e) => await Navigation.PushModalAsync(new ScientificCalculatorPage());
    }
}