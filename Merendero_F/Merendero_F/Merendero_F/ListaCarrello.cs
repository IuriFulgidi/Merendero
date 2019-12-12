using System;
using System.Collections.Generic;
using System.Text;

namespace Merendero_F
{
    class ListaCarrello
    {
        public static List<Merenda> lista = new List<Merenda>();

        
        public static void Aggiungi(Merenda m)
        {
            //aggiungp
            lista.Add(m);

            //se la merenda è già stata scelta si tolgono tutte quelle uguali
            for(int i = 0;i < lista.Count;i++ )
            {
                if (m.Name == lista[i].Name)
                {
                    lista.Remove(m);
                    lista.Remove(m);
                }
            }

            //si rimentte
            lista.Add(m);
        }

    }
}
