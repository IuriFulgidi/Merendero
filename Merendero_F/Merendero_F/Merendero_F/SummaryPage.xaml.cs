﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;

namespace Merendero_F
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummaryPage : ContentPage
    {
        public SummaryPage()
        {
            InitializeComponent();

            //caricamento listview
            ObservableCollection<Merenda> list = ListaCarrello.lista;
            ListView.ItemsSource = list;

            //calcolo totale costo
            CalcTotale(list);
        }

        private void CalcTotale(ObservableCollection<Merenda> list)
        {
            double tot = 0;
            foreach (Merenda m in list)
                tot += m.Cost * m.Quantity;

            //show del totale
            lbl_Total.Text = $"Totale: {tot} €";

            if (tot == 0)
            {
                //non si può ordinare se il carrello è vuoto
                btn_Ordina.IsEnabled = false;

                //non si svuota il carrello vuoto
                btn_Svuota.IsEnabled = false;
            }
        }

        //svuota carrello
        private async void Btn_Svuota_Clicked(object sender, EventArgs e)
        {
            bool scelta = await DisplayAlert("Attenzione!", "Sicuro di voler svuotare il carrello", "Si", "No");
            if(scelta)
                ListaCarrello.lista.Clear();

            //aggiornamento totale
            CalcTotale(ListaCarrello.lista);
        }

        //invio ordine
        private void Btn_Ordina_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Ordine inviato", "buon appetito", "ok");
        }
    }
}