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
                new Merenda { Name = "Focaccia al salame", Description = "Focaccia farcita al salame", ImgUrl = "salame.png" , Cost =1.50, Quantity=0 },
                new Merenda { Name = "Focaccia al crudo", Description = "Focaccia farcita con il prosciutto crudo", ImgUrl = "crudo.png" , Cost =1.50 , Quantity=0 },
                new Merenda { Name = "Focaccia al cotto", Description = "Focaccia farcita con il prosciutto cotto", ImgUrl = "cotto.png" , Cost =1.50 , Quantity=0 }, 
                new Merenda { Name = "Pizza", Description = "Pizza margherita al taglio", ImgUrl = "pizza.png" , Cost =1, Quantity=0 },
            };
            dolce = new ObservableCollection<Merenda>
            {
                new Merenda { Name = "Ciambella", Description = "ciambella fritta con zucchero a velo", ImgUrl = "ciambella.png" , Cost =1 , Quantity=0 },
                new Merenda { Name = "Cornetto vuoto", Description = "Dolce cornetto senza ripieno", ImgUrl = "cornetto_vuoto.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Cornetto alla nutella", Description = "Dolce cornetto ripieno di buonissima nutella", ImgUrl = "cornetto_cioccolato.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Cornetto all'albicocca", Description = "Dolce cornetto ripieno di marmellata all' albicocca", ImgUrl = "cornetto_albicocca.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Cornetto alla crema", Description = "Dolce cornetto ripieno alla crema", ImgUrl = "cornetto_crema.jpg" , Cost =1, Quantity=0 },
                new Merenda { Name = "Bombolone alla crema", Description = "Bombolone fritto ripieno di crema", ImgUrl = "bombolone_crema.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Bombolone alla nutella", Description = "Bombolone fritto ripieno di nutella", ImgUrl = "bombolone_nutella.png" , Cost =1, Quantity=0 },
            };
            bevande = new ObservableCollection<Merenda>
            {
                new Merenda { Name = "Lemon Soda", Description = "Bevanda gassata al gusto di limone", ImgUrl = "lemonsoda.png" , Cost =1 , Quantity=0 },
                new Merenda { Name = "Oran Soda", Description = "Bevanda gassata al gusto di arancia", ImgUrl = "" , Cost =1, Quantity=0 },
                new Merenda { Name = "Coca Cola", Description = "Taste the feeling", ImgUrl = "coca.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Fanta", Description = "Un succo al'arancia Fantastico", ImgUrl = "fanta.png" , Cost =1 , Quantity=0 },
                new Merenda { Name = "Sprite", Description = "Sprite", ImgUrl = "sprite.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Etstathè al Limone", Description = "Brick di thè infuso alla pesca", ImgUrl = "estathe_limone.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Etstathè alla pesca", Description = "Brick di thè infuso al limone", ImgUrl = "etathe_pesca.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Acqua naturale", Description = "Acqua nuaturale", ImgUrl = "acqua_naturale.png" , Cost =1, Quantity=0 },
                new Merenda { Name = "Acqua Frizzante", Description = "Acqua frizzante", ImgUrl = "acqua_frizzante.png" , Cost =1, Quantity=0 }
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