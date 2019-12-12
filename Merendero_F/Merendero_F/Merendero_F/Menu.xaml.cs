using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Merendero_F
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        //dichiarazione lista
        public ObservableCollection<Merenda> salato;
        public ObservableCollection<Merenda> dolce;
        public ObservableCollection<Merenda> bevande;
        public Menu()
        {
            InitializeComponent();
            Load();
        }

        //caricamento liste
        private void Load(string search = null)
        {
            salato = new ObservableCollection<Merenda>
            {
                new Merenda { Name = "Speciale", Description = "Pizza farcita con pomodoro, prosciutto cotto e mozzarella",ImgUrl="speciale.png" , Cost =1.50 , Quantity=0 },
                new Merenda { Name = "Focaccia al salame", Description = "Una bella focaccia al salame", ImgUrl = "salame.png" , Cost =1.50, Quantity=0 },
                new Merenda { Name = "Focaccia al crudo", Description = "Una bella focaccia con il prosciutto crudo", ImgUrl = "crudo.png" , Cost =1.50 , Quantity=0 },
                new Merenda { Name = "Focaccia al cotto", Description = "Una bella focaccia con il prosciutto cotto", ImgUrl = "cotto.png" , Cost =1.50 , Quantity=0 },
                new Merenda { Name = "Pizza", Description = "Pizza margherita al taglio", ImgUrl = "pizza.png" , Cost =1, Quantity=0 },
            };
            dolce = new ObservableCollection<Merenda>
            {
                new Merenda { Name = "Ciambella", Description = "Per uno spuntino veloce e dolce", ImgUrl = "ciambella.png" , Cost =1 , Quantity=0 },
                new Merenda { Name = "Cornetto vuoto", Description = "Dolce cornetto semplice", ImgUrl = "cornetto_vuoto.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Cornetto al cioccolato", Description = "Dolce cornetto ripieno al cioccolato", ImgUrl = "cornetto_cioccolato.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Cornetto all'albicocca", Description = "Dolce cornetto ripieno all' albicocca", ImgUrl = "cornetto_albicocca.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Cornetto alla crema", Description = "Dolce cornetto ripieno alla crema", ImgUrl = "cornetto_crema.jpg" , Cost =1, Quantity=0 },
            };
            bevande = new ObservableCollection<Merenda>
            {
                new Merenda { Name = "Lemon Soda", Description = "Classica Lemon Soda", ImgUrl = "lemonsoda.png" , Cost =1 , Quantity=0 },
                new Merenda { Name = "Coca Cola", Description = "Classica Coca Cola", ImgUrl = "coca.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Fanta", Description = "Un succo al'arancia Fantastico", ImgUrl = "fanta.png" , Cost =1 , Quantity=0 }
            };
            //new Merenda { Name = "", Description = "", ImgUrl = "" , Cost =1, Quantity=0 },
        }
        
        private async void Bevande_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(bevande));
        }

        private async void Dolce_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(dolce));
        }

        private async void Salato_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(salato));
        }

        //apertura pagina con riepilogo/carrello per ordinare
        private async void Riepologo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SummaryPage());
        }
    }
}