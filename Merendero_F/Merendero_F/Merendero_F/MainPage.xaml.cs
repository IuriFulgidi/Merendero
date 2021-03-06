﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Merendero_F
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage(ObservableCollection<Merenda> merende)
        {
            InitializeComponent();

            //caricamento Listview
            ListView.ItemsSource = merende;
        }

        //apertura pagina con dettagli
        private async void ListView_ItemSelcted(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new DescriptionPage(e.SelectedItem as Merenda));
        }
    }
}
