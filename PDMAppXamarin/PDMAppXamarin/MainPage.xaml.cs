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
        List<CursValutar> listaValute;
        public MainPage()
		{
            listaValute = new List<CursValutar> { new CursValutar(3.7f, "USD", DateTime.Now),
            new CursValutar(4.5f, "EUR", DateTime.Now),
            new CursValutar(5.5f, "GBP", DateTime.Now),
            new CursValutar(3.5f, "CAD", DateTime.Now),
            new CursValutar(4.2f, "SWD", DateTime.Now),
            new CursValutar(2.3f, 100f, "HUN", DateTime.Now)};
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
            listView.BindingContext = listaValute;
        }
    }
}
