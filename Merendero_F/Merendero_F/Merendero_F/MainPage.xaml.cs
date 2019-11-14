using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Merendero_F
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Merenda> merende;

        public MainPage()
        {
            InitializeComponent();
            Load();
        }

        //caricamento lista
        private void Load(string search = null)
        {
            merende = new ObservableCollection<Merenda>
            {
                new Merenda { Name = "Speciale", Description = "Pizza farcita con pomodoro, prosciutto cotto e mozzarella",ImgUrl="https://www.ifood.it/wp-content/uploads/2017/10/focaccia-laica-dettaglio-1160x773.jpg" , Cost =1.50, Quantity=0 },
                new Merenda { Name = "Ciambella", Description = "Per uno spuntino veloce e dolce", ImgUrl ="https://images.pexels.com/photos/41300/berliner-breakfast-bun-cake-41300.jpeg", Cost =1, Quantity=0 },
                new Merenda { Name = "Lemon Soda", Description = "Classica Lemon Soda", ImgUrl = "http://www.italianherkut.fi/970-large_default/lemonsoda-33cl-campari.jpg" , Cost =1, Quantity=0 },
                new Merenda { Name = "Coca Cola", Description = "Classica Coca Cola", ImgUrl = "https://www.cicalia.com/it/img/imgproducts/1525/l_1525.jpg" , Cost =1, Quantity=0 },
                new Merenda { Name = "Fanta", Description = "Un succo al'arancia Fantastico", ImgUrl = "https://www.cicalia.com/it/img/imgproducts/44234/l_44234.jpg" , Cost =1, Quantity=0 },
                new Merenda { Name = "Focaccia al salame", Description = "Una bella focaccia al salame", ImgUrl = "https://www.lineasnack.it/wp-content/uploads/2017/07/focaccia-salame.jpg" , Cost =1.50, Quantity=0 },
                new Merenda { Name = "Focaccia al crudo", Description = "Una bella focaccia con il prosciutto crudo", ImgUrl = "https://www.lineasnack.it/wp-content/uploads/2017/07/focaccia-crudo.jpg" , Cost =1.50, Quantity=0 },
                new Merenda { Name = "Focaccia al cotto", Description = "Una bella focaccia con il prosciutto cotto", ImgUrl = "https://www.lineasnack.it/wp-content/uploads/2017/07/cotto.jpg" , Cost =1.50, Quantity=0 }
                //new item template
                //new Merenda { Name = "", Description = "", ImgUrl = "" , Cost =1, Quantity=0 },
            };
            //ricerca
            if (search == null)
                ListView.ItemsSource = merende;
            else
                ListView.ItemsSource = merende.Where(m => m.Name.ToLower().Contains(search.ToLower()));
        }

        //apertura pagina con dettagli
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new DescriptionPage(e.SelectedItem as Merenda));
        }

        //ricerca
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = e.NewTextValue;
            Load(search);
        }

        private async void Riepologo_Clicked(object sender, EventArgs e)
        {
            //lista riepilogo
            List<Merenda> list = new List<Merenda>();
            foreach(Merenda m in merende)
            {
                if (m.Quantity > 0)
                    list.Add(m);
            }

            await Navigation.PushAsync(new SummaryPage(list));
        }
    }
}
