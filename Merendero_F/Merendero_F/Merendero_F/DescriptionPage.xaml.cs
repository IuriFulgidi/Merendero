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
        public DescriptionPage(Merenda merenda)
        {
            InitializeComponent();
            BindingContext = merenda;

            //attivazione bottone aggiungi
            if (stepper.Value < 1)
                btn_Aggiungi.IsEnabled = false;
        }

        private void Aggiungi_Clicked(object sender, EventArgs e)
        {
            Merenda m= new Merenda();

            m.Name = lbl_nome.Text;
            m.Description = lbl_desc.Text;
            m.ImgUrl = lbl_imgUrl.Text;
            m.Cost =Convert.ToDouble(lbl_costo.Text);
            m.Quantity =Convert.ToInt32(stepper.Value);

            ListaCarrello.Aggiungi(m);
        }

        //attivazione bottone aggiungi
        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (stepper.Value < 1)
                btn_Aggiungi.IsEnabled = false;
            else
                btn_Aggiungi.IsEnabled = true;
        }
    }
}