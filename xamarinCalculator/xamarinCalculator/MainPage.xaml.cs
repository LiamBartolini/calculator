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

        private void AggiungiCarattere(object sender, EventArgs e)
        {
            lblOutput.Text += (sender as Button).Text;
        }

        private void CalcolaRisultato(object sender, EventArgs e)
        {
            char[] operators = new char[] { '+', '-', '*', '/' };

            // Cerca il simbolo e divide i due numeri e poi fa i calcoli e ritorna il risultato
            string[] splittedExpression = lblOutput.Text.Split(' ');

            for (int i = 0; i < operators.Length; i++)
                // Provo a convertire se non riesce ...
                try
                {
                    if (splittedExpression[1].Contains(operators[i]))
                        lblOutput.Text = splittedExpression[1];
                }
                catch
                {
                    continue;
                }
        }
    }
}