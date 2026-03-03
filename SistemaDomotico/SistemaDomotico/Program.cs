namespace SistemaDomotico
{
    using static System.Console;
    internal class Program
    {
        static void Main(string[] args)
        {
            // Come posso creare un elenco unico di dispositivi per accenderli tutti insieme?
            List<CItem> dispositivi = new List<CItem>();

            dispositivi.Add(new CLampadina("Lampadina1", "Soggiorno", 75.0));

            dispositivi.Add(new CTermostato("Termostato1", "Camera da letto", 22.5));

            foreach (CItem dispositivo in dispositivi)
            {
                dispositivo.Accendi();
            }


        }
    }
}
