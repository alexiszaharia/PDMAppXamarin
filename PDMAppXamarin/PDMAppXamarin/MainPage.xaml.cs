using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;

namespace PDMAppXamarin
{
	public partial class MainPage : ContentPage
	{
        List<CursValutar> listaValute;
        CursValutarDAO cursValutarDAO;
        public MainPage()
		{
            cursValutarDAO = new CursValutarDAO();

            listaValute = new List<CursValutar>(); /*{ new CursValutar(3.7f, "USD", DateTime.Now),
            new CursValutar(4.5f, "EUR", DateTime.Now),
            new CursValutar(5.5f, "GBP", DateTime.Now),
            new CursValutar(3.5f, "CAD", DateTime.Now),
            new CursValutar(4.2f, "SWD", DateTime.Now),
            new CursValutar(2.3f, 100f, "HUN", DateTime.Now)};*/
            InitializeComponent();
            this.FindByName<Button>("buton");
            var buton = this.FindByName<Button>("buton");
            buton.Clicked += Buton_Clicked;
            //buton.Clicked += (sender, e) => buton.Text = "Apasat";
            listView.ItemSelected += (sender, e) => Navigation.PushAsync(new PaginaDetaliiValuta());

            
            
		}

        private async void Buton_Clicked(object sender, EventArgs e)
        {
            List<CursValutar> cursBD = new List<CursValutar>();
            cursBD = cursValutarDAO.getLista();
            if(cursBD.Count == 0)
            {
                HttpClient httpClient = new HttpClient();
                //String xml = await httpClient.GetStringAsync(new Uri("http://www.bnr.ro/nbrfxrates.xml"));
                Stream fileStream = await httpClient.GetStreamAsync(new Uri("http://www.bnr.ro/nbrfxrates.xml"));
                XmlReader xmlReader = XmlReader.Create(fileStream);
                DateTime dataCurs = DateTime.Now;
                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement())
                    {
                        switch (xmlReader.Name)
                        {
                            case "Cube":
                                //xmlReader["date"]
                                String data = xmlReader["date"];
                                dataCurs = DateTime.ParseExact(data, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                break;

                            case "Rate":
                                CursValutar cursValutar = new CursValutar();
                                cursValutar.DataCurs = dataCurs;
                                cursValutar.DenumireValuta = xmlReader["currency"];
                                if (xmlReader["multiplier"] != null)
                                {
                                    cursValutar.Multiplicator = float.Parse(xmlReader["multiplier"]);
                                }
                                xmlReader.Read();
                                cursValutar.ValoareMoneda = float.Parse(xmlReader.Value);
                                listaValute.Add(cursValutar);
                                cursValutarDAO.insertCursValutar(cursValutar);
                                break;
                        }
                    }
                }

                Console.WriteLine("S-a preluat de pe net informatia!");
            } else
            {
                listaValute.AddRange(cursBD);
                Console.WriteLine("S-a preluat din BD informatia!");
            }

           


            //await DisplayAlert("Alerta", xml, "OK");

            //buton.Text = "Apasat";
            listView.ItemsSource = listaValute;
            //listView.BindingContext = listaValute;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ActivityConversie());

        }
    }
}
