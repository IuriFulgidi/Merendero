using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Merendero_F
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummaryPage : ContentPage
    {
        public SummaryPage()
        {
            InitializeComponent();
            List<Merenda> list = ListaCarrello.lista;
            ListView.ItemsSource = list;

            //calcolo totale costo
            double tot = 0;
            foreach (Merenda m in list)
                tot += m.Cost * m.Quantity;

            lbl_Total.Text = $"Totale: {tot} €";

            if(tot==0)
                btn_Ordina.IsEnabled = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Ordine inviato","buon appetito", "ok");
        }
    }
}