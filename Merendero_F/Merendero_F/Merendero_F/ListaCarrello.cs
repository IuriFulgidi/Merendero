using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Merendero_F
{
    class ListaCarrello
    {
        public static ObservableCollection<Merenda> lista = new ObservableCollection<Merenda>();

        
        public static void Aggiungi(Merenda m)
        {
            lista.Add(m);

            //cancella doppioni
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista.Count; j++)
                {
                    if (i != j && lista[i].Name == lista[j].Name)
                        lista.RemoveAt(i);
                }
            }

            //cancella zeri
            for(int i=0;i<lista.Count;i++)
            {
                if (lista[i].Quantity == 0)
                    lista.RemoveAt(i);
            }

        }

    }
}
