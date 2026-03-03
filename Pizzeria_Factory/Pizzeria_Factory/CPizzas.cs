using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria_Factory
{
    internal abstract class CPizzas : IPizza
    {
        protected string nome;
        protected string ingredienti;
        protected int tempoCotura;
        protected decimal prezzo;

        public virtual string Prepara()
        {
            return $"Preparando una pizza {nome}. Ingredienti: {ingredienti}";
        }

        public virtual string Cucina()
        {
            return $"Cucinando la {nome}. Tempo stimato: {tempoCotura} minuti";
        }

        public string GetNome()
        {
            return nome;
        }

        public decimal GetPrezzo()
        {
            return prezzo;
        }
    }

    internal class Margherita : CPizzas
    {
        public Margherita()
        {
            nome = "Margherita";
            ingredienti = "Pomodoro, Mozzarella, Basilico";
            tempoCotura = 10;
            prezzo = 5.5m;
        }
    }

    internal class FrassonElPasticcion : CPizzas
    {
        public FrassonElPasticcion()
        {
            nome = "Frasson El Pasticcion";
            ingredienti = "Doppia Mozzarella, Salsiccia, Patate al forno, Bacon croccante, Gorgonzola, Cipolla caramellata";
            tempoCotura = 18;
            prezzo = 12.5m;
        }
    }

    internal class Schiavi : CPizzas
    {
        public Schiavi()
        {
            nome = "Schiavi";
            ingredienti = "Pomodoro San Marzano, Olio EVO, Aglio, Peperoncino fresco, Pancetta tesa, Pecorino grattugiato";
            tempoCotura = 11;
            prezzo = 7.5m;
        }
    }

    internal class Suan : CPizzas
    {
        public Suan()
        {
            nome = "Suan";
            ingredienti = "Mozzarella di Bufala, Pomodorini ciliegino, Prosciutto crudo di Parma, Scaglie di Grana Padano, Rucola fresca";
            tempoCotura = 10;
            prezzo = 9.5m;
        }
    }

    internal class SergenteRicino : CPizzas
    {
        public SergenteRicino()
        {
            nome = "Sergente Ricino";
            ingredienti = "Doppia passata di Pomodoro, Mozzarella, Peperoncino fresco tritato (molto), Fagioli neri piccanti, Cicoria saltata in padella (tante fibre!), 'Nduja calabrese";
            tempoCotura = 13;
            prezzo = 9.2m;
        }
    }

    internal class Marinara : CPizzas
    {
        public Marinara()
        {
            nome = "Marinara";
            ingredienti = "Pomodoro, Aglio, Origano, Olio";
            tempoCotura = 8;
            prezzo = 4.5m;
        }
    }

    internal class ProsciuttoFunghi : CPizzas
    {
        public ProsciuttoFunghi()
        {
            nome = "Prosciutto e Funghi";
            ingredienti = "Pomodoro, Mozzarella, Prosciutto cotto, Funghi champignon";
            tempoCotura = 12;
            prezzo = 6.5m;
        }
    }

    internal class QuattroFormaggi : CPizzas
    {
        public QuattroFormaggi()
        {
            nome = "Quattro Formaggi";
            ingredienti = "Mozzarella, Gorgonzola, Fontina, Parmigiano Reggiano";
            tempoCotura = 10;
            prezzo = 7.5m;
        }
    }

    internal class Ortolana : CPizzas
    {
        public Ortolana()
        {
            nome = "Ortolana";
            ingredienti = "Pomodoro, Mozzarella, Zucchine, Melanzane, Peperoni, Olive";
            tempoCotura = 11;
            prezzo = 7.0m;
        }
    }

    internal class LaBiondonaPorcellona : CPizzas
    {
        public LaBiondonaPorcellona()
        {
            nome = "La Biondona Porcellona";
            ingredienti = "Mozzarella, Panna fresca, Salsiccia di maiale, Pancetta a cubetti, Patate al forno, Olio al rosmarino";
            tempoCotura = 14;
            prezzo = 10.5m;
        }
    }
}