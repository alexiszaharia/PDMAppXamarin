using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PDMAppXamarin
{
	public partial class MainPage : ContentPage
	{
        List<string> listaValute;
        public MainPage()
		{
            listaValute = new List<string> { "1 EUR = 4.7 RON",
            "1 USD = 3.8 RON",
            "1 GBP = 5.2 RON",
            "1 CAD = 3.5 RON",
            "1 BGN = 2.3 RON"};
            InitializeComponent();
            this.FindByName<Button>("buton");
            var buton = this.FindByName<Button>("buton");
            buton.Clicked += Buton_Clicked;
            //buton.Clicked += (sender, e) => buton.Text = "Apasat";
            listView.ItemSelected += (sender, e) => Navigation.PushAsync(new PaginaDetaliiValuta());
		}

        private void Buton_Clicked(object sender, EventArgs e)
        {
            //buton.Text = "Apasat";
            listView.ItemsSource = listaValute;
        }
    }
}
