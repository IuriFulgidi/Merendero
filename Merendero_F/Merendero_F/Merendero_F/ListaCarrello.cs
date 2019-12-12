using System;
using System.Collections.Generic;
using System.Text;

namespace Merendero_F
{
    class ListaCarrello
    {
        public static List<Merenda> lista = new List<Merenda>();

        //metodo per controllare di 
        public static void Aggiungi(Merenda m)
        {
            lista.Add(m);
            //se la merenda è già stata scelta si sostituisce
            for(int i = 0;i < lista.Count;i++ )
            {
                if (m.Name == lista[i].Name)
                    lista.RemoveAt(i);
            }
            lista.Add(m);
        }
    }
}
