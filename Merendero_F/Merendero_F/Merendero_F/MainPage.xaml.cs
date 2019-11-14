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
                new Merenda { Name = "Speciale", Description = "Pizza farcita con pomodoro, prosciutto cotto e mozzarella",ImgUrl="https://cdn1.imggmi.com/uploads/2019/11/14/c167485a5abb97ed4128bf6b9fc20fb4-full.jpg" , Cost =1.50, Quantity=0 },
                new Merenda { Name = "Focaccia al salame", Description = "Una bella focaccia al salame", ImgUrl = "https://cdn1.imggmi.com/uploads/2019/11/15/2bcb4bd808b417c8e80110617b9deca6-full.jpg" , Cost =1.50, Quantity=0 },
                new Merenda { Name = "Focaccia al crudo", Description = "Una bella focaccia con il prosciutto crudo", ImgUrl = "https://cdn1.imggmi.com/uploads/2019/11/15/7aa36b468d021317a7f29f95fbba6c98-full.jpg" , Cost =1.50, Quantity=0 },
                new Merenda { Name = "Focaccia al cotto", Description = "Una bella focaccia con il prosciutto cotto", ImgUrl = "https://cdn1.imggmi.com/uploads/2019/11/14/b3ac928a8e5b0442b44e639771d0a815-full.jpg" , Cost =1.50, Quantity=0 },
                new Merenda { Name = "Ciambella", Description = "Per uno spuntino veloce e dolce", ImgUrl ="https://cdn1.imggmi.com/uploads/2019/11/14/24ac822e21945f2a1c374e5ca9706aed-full.jpg", Cost =1, Quantity=0 },
                new Merenda { Name = "Lemon Soda", Description = "Classica Lemon Soda", ImgUrl = "https://cdn1.imggmi.com/uploads/2019/11/15/0490e119a18b50d3d6574f163057281c-full.jpg" , Cost =1, Quantity=0 },
                new Merenda { Name = "Coca Cola", Description = "Classica Coca Cola", ImgUrl = "https://cdn1.imggmi.com/uploads/2019/11/14/a643791d83b97ae95f83af47c85972df-full.jpg" , Cost =1, Quantity=0 },
                new Merenda { Name = "Fanta", Description = "Un succo al'arancia Fantastico", ImgUrl = "https://cdn1.imggmi.com/uploads/2019/11/15/4534388405873fcc1e4153bb1b8b5832-full.jpg" , Cost =1, Quantity=0 },
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
