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
        //dichiarazione lista
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
                new Merenda { Name = "Speciale", Description = "Pizza farcita con pomodoro, prosciutto cotto e mozzarella",ImgUrl="speciale.jpg" , Cost =1.50 , Quantity=0 },
                new Merenda { Name = "Focaccia al salame", Description = "Una bella focaccia al salame", ImgUrl = "salame.jpg" , Cost =1.50, Quantity=0 },
                new Merenda { Name = "Focaccia al crudo", Description = "Una bella focaccia con il prosciutto crudo", ImgUrl = "crudo.png" , Cost =1.50 , Quantity=0 },
                new Merenda { Name = "Focaccia al cotto", Description = "Una bella focaccia con il prosciutto cotto", ImgUrl = "cotto.jpg" , Cost =1.50 , Quantity=0 },
                new Merenda { Name = "Ciambella", Description = "Per uno spuntino veloce e dolce", ImgUrl = "ciambella.png" , Cost =1 , Quantity=0 },
                new Merenda { Name = "Lemon Soda", Description = "Classica Lemon Soda", ImgUrl = "lemonsoda.jpg" , Cost =1 , Quantity=0 },
                new Merenda { Name = "Coca Cola", Description = "Classica Coca Cola", ImgUrl = "coca.jpg" , Cost =1, Quantity=0 },
                new Merenda { Name = "Fanta", Description = "Un succo al'arancia Fantastico", ImgUrl = "fanta.jpg" , Cost =1 , Quantity=0 }
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
        private async void ListView_ItemSelcted(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new DescriptionPage(e.SelectedItem as Merenda));
        }

        //ricerca
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = e.NewTextValue;
            Load(search);
        }

        //apertura pagina con riepilogo/carrello per ordinare
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
