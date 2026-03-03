namespace ListaEsercizi1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> lista1 = new LinkedList<int>();
            LinkedList<int> lista2 = new LinkedList<int>();

            for (int indice = 0; indice < 15; indice++)
            {
                if (indice % 2 == 0)
                    lista1.AggiungiElementoInizio(indice);
                else
                    lista2.AggiungiElementoInizio(indice);
            }

            LinkedList<int> listaCrescenteUnita = new LinkedList<int>();

            foreach(int indice in lista1)
            {
                if (indice > lista2.)
            }
        }
    }
}
