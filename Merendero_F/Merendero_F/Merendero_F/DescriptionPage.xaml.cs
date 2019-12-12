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
        double costo;
        string imgUrl;
        public DescriptionPage(Merenda merenda)
        {
            InitializeComponent();
            BindingContext = merenda;

            costo = merenda.Cost;
            imgUrl = merenda.ImgUrl;
        }

        private void Aggiungi_Clicked(object sender, EventArgs e)
        {
            Merenda m= new Merenda();

            m.Name = lbl_nome.Text;
            m.Description = lbl_desc.Text;
            m.ImgUrl = imgUrl;
            m.Cost =costo;
            m.Quantity =Convert.ToInt32(stepper.Value);

            ListaCarrello.Aggiungi(m);
        }
    }
}