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
    public partial class DescriptionPage : ContentPage
    {
        //merenda da aggiungere
        Merenda m = new Merenda();
        public DescriptionPage(Merenda merenda)
        {
            InitializeComponent();
            BindingContext = merenda;

            //valori della merenda visualizzata in qulla da aggiungere
            m = merenda;
        }

        //aggiunta nella lista globale
        private void Aggiungi_Clicked(object sender, EventArgs e)
        {
            ListaCarrello.Aggiungi(m);
        }
    }
}