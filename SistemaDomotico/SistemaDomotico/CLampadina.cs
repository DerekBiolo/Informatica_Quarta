namespace SistemaDomotico
{
    using static System.Console;
    internal class CLampadina : CItem
    {
        public double luminosita;
        public override bool isOn { get; set; }

        public CLampadina(string nome,string stanza, double brightness) 
            : base(nome, stanza)
        {
            this.luminosita = brightness;
        }

        public override void Accendi()
        {
            WriteLine($"La lampadina {nome} nella stanza {stanza} è accesa con luminosità {luminosita}%");
            isOn = true;
        }

        public override void Spegni()
        {
            WriteLine($"La lampadina {nome} nella stanza {stanza} è spenta");
            isOn = false;
        }

        public override void MostraInfo()
        {
            WriteLine($"Lampadina: {nome}, Stanza: {stanza}, Luminosità: {luminosita}%, Stato: {(isOn ? "Accesa" : "Spenta")}");
        }

    }
}
