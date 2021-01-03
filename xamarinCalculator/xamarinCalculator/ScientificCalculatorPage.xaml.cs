using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xamarinCalculator.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarinCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScientificCalculatorPage : ContentPage
    {
        public ScientificCalculatorPage()
        {
            InitializeComponent();
        }

        private async void btnMainPage_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new MainPage());
    }
}