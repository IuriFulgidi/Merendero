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
            lista.Add(m);

            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista.Count; j++)
                {
                    if (i != j && lista[i].Name == lista[j].Name)
                        lista.RemoveAt(i);
                }
            }
        }

    }
}
