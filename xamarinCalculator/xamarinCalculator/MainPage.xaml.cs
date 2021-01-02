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
<<<<<<< HEAD
            string[] strOperators = new string[] { "sum", "subtraction", "multiplication", "division" };

            // Cerca il simbolo e divide i due numeri e poi fa i calcoli e ritorna il risultato
            string expression = lblOutput.Text;

            for (int i = 0; i < operators.Length; i++)
                if (expression.Contains(operators[i]))
                {
                    lblOutput.Text = strOperators[i];
                    break;
                }

            lblOutput.Text = "Operazione non trovata";
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
=======

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
>>>>>>> e17f312ceeccb7b30454c827cbf3b38e253dd060
        }
    }
}