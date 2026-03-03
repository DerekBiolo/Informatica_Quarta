using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cucina
{
    public partial class Form1 : Form
    {
        string[] menuDelGiorno = {
        "Lasagne alla Bolognese",
        "Risotto ai Funghi Porcini",
        "Spaghetti alla Carbonara",
        "Pizza Margherita",
        "Tagliata di Manzo",
        "Salmone al Forno",
        "Gnocchi alla Sorrentina",
        "Pollo alla Cacciatora",
        "Fritto Misto di Pesce",
        "Melanzane alla Parmigiana",
        "Ossobuco alla Milanese",
        "Tortellini in Brodo",
        "Pasta alla Norma",
        "Costata di Maiale",
        "Zuppa di Pesce",
        "Ravioli Ricotta e Spinaci",
        "Arrosto di Vitello",
        "Bistecca alla Fiorentina",
        "Orecchiette alle Cime di Rapa",
        "Baccalà alla Vicentina",
        "Paella Valenciana",
        "Sushi Misto",
        "Hamburger Gourmet",
        "Pad Thai di Gamberi",
        "Couscous di Verdure",
        "Anatra all'Arancia",
        "Goulash d'Ungheria",
        "Moussaka Greca",
        "Tacos al Pastore",
        "Ratatouille di Verdure"
    }; //piatti a casaccio perche fa figo
        //variabili x ui
        private List<Panel> pianiCotturaUI = new List<Panel>();
        private List<Panel> cuochiUI = new List<Panel>();
        private ListBox logListBox;
        private Label lblStato;

        //const variabili
        private const int NUM_PIANI = 2; //piani di cottura disponibili
        private const int NUM_CUOCHI = 4; // cuochi che saranno in attesa

        public Form1()
        {
            InitializeComponent();
            //form ui
            this.Width = 1100;
            this.Height = 600;
            this.Text = "Sistema Gestione Cucina";
            this.BackColor = Color.LightGray;

            //inizializo la cucina coi piani che ho scelto prima
            Cuoco.Cucina.Inizializza(NUM_PIANI);

            InizializzaUI();
        }

        private void InizializzaUI()
        {
            //creo i piani cottura
            Label lblPiani = new Label //title
            {
                Text = "PIANI COTTURA",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(20, 80),
                AutoSize = true
            };
            Controls.Add(lblPiani);

            for (int i = 0; i < NUM_PIANI; i++) //panels
            {
                Panel piano = new Panel
                {
                    Width = 140,
                    Height = 140,
                    BackColor = Color.FromArgb(46, 204, 113),
                    BorderStyle = BorderStyle.None,
                    Left = 20 + (i * 160),
                    Top = 110,
                    Tag = i
                };

                Label lblPiano = new Label //testo dei piani
                {
                    Text = $"Piano {i}\nLIBERO",
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };

                //aggiungo tutto
                piano.Controls.Add(lblPiano);
                Controls.Add(piano);
                pianiCotturaUI.Add(piano);
            }

            //cuochi
            //titile
            Label lblCuochi = new Label
            {
                Text = "CUOCHI",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(20, 270),
                AutoSize = true
            };
            Controls.Add(lblCuochi);

            // panels e testo
            for (int i = 0; i < NUM_CUOCHI; i++)
            {
                Panel cuoco = new Panel
                {
                    Width = 100,
                    Height = 80,
                    BackColor = Color.FromArgb(149, 165, 166),
                    BorderStyle = BorderStyle.None,
                    Left = 20 + (i * 115),
                    Top = 300,
                    Tag = i
                };

                Label lblCuoco = new Label
                {
                    Text = $"Cuoco {i + 1}\nIn attesa",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };

                //aggiungo
                cuoco.Controls.Add(lblCuoco);
                Controls.Add(cuoco);
                cuochiUI.Add(cuoco);
            }

            // log title
            Label lblLog = new Label
            {
                Text = "LOG EVENTI",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(500, 80),
                AutoSize = true
            };
            Controls.Add(lblLog);

            //log efettivo
            logListBox = new ListBox
            {
                Left = 500,
                Top = 110,
                Width = 450,
                Height = 270,
                Font = new Font("Consolas", 9),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(logListBox);

            //titiolo pulsanti
            lblStato = new Label
            {
                Text = "Premi START per iniziare",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(20, 400),
                Width = 450,
                Height = 30,
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            Controls.Add(lblStato);

            // start
            btn_Start.Text = "START";
            btn_Start.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btn_Start.Width = 120;
            btn_Start.Height = 45;
            btn_Start.Left = 20;
            btn_Start.Top = 440;
            btn_Start.BackColor = Color.FromArgb(52, 152, 219);
            btn_Start.ForeColor = Color.White;
            btn_Start.FlatStyle = FlatStyle.Flat;
            btn_Start.FlatAppearance.BorderSize = 0;
            btn_Start.Cursor = Cursors.Hand;

            // reset simulazione
            Button btnReset = new Button
            {
                Text = "RESET",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Width = 120,
                Height = 45,
                Left = 150,
                Top = 440,
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Click += (s, e) => //listener di ocsa fa il pulsante
            {
                logListBox.Items.Clear();
                Cuoco.Cucina.Inizializza(NUM_PIANI);
                ResetUI();
                lblStato.Text = "Sistema resettato. Premi START.";
            };
            Controls.Add(btnReset);
        }

        private void ResetUI() //resetto ttto la ui
        {
            for (int i = 0; i < pianiCotturaUI.Count; i++)
            {
                pianiCotturaUI[i].BackColor = Color.FromArgb(46, 204, 113);
                ((Label)pianiCotturaUI[i].Controls[0]).Text = $"Piano {i}\nLIBERO";
            }

            for (int i = 0; i < cuochiUI.Count; i++)
            {
                cuochiUI[i].BackColor = Color.FromArgb(149, 165, 166);
                ((Label)cuochiUI[i].Controls[0]).Text = $"Cuoco {i + 1}\nIn attesa";
            }
        }

        private async void btn_Start_Click(object sender, EventArgs e)
        {
            btn_Start.Enabled = false; //disattivo durante la simulazione
            logListBox.Items.Clear();
            ResetUI();

            lblStato.Text = "Sistema in esecuzione...";
            lblStato.ForeColor = Color.FromArgb(230, 126, 34);

            Random r = new Random();
            Cuoco[] cuochi =
            {
                new Cuoco(1, r.Next(1000,10001)),
                new Cuoco(2, r.Next(1000,10001)),
                new Cuoco(3, r.Next(1000,10001)),
                new Cuoco(4, r.Next(1000, 10001))
            };

            //aggiungo gli eventi a ogi cuoco
            foreach (var cuoco in cuochi)
                cuoco.StatoCambiato += GestisciEvento;

            //prendo tutti i cuochi e li faccio lavorare e il task che si crea poi li metto in un array
            Task[] tasks = cuochi.Select(c => c.LavoraAsync()).ToArray();

            //aspetto finche tutti i task non sono finiti (cosi la UI no si rompe perche la fermo)
            await Task.WhenAll(tasks);

            lblStato.Text = "Tutti i cuochi hanno terminato!";
            lblStato.ForeColor = Color.FromArgb(39, 174, 96);
            btn_Start.Enabled = true;

            for(int i = 0; i < 4; i++)
{
                this.BackColor = Color.Green;
                await AspettaBg();

                this.BackColor = Color.LightGray;
                await AspettaBg();
            }
        }

        private Task AspettaBg()
        {
            return Task.Delay(100);
        }

        private void GestisciEvento(object sender, CuocoEventArgs e)
        {
            this.Invoke(new MethodInvoker(() => //faccio invokare i cuochi un evento dal main thread (unico che puo modificare la ui) cosi da poter modificare
            {

                string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
                logListBox.Items.Add($"[{timestamp}] Cuoco {e.IdCuoco}: {e.Messaggio}");
                logListBox.TopIndex = logListBox.Items.Count - 1;

                int cuocoIndex = e.IdCuoco - 1;

                // aggiorno lo stato del cuoco
                if (e.Messaggio.Contains("richiede")) //se il messaggio e richiede allora significa che sta aspettando
                {
                    cuochiUI[cuocoIndex].BackColor = Color.FromArgb(243, 156, 18);
                    ((Label)cuochiUI[cuocoIndex].Controls[0]).Text = $"Cuoco {e.IdCuoco}\nIn attesa..."; //prendo il lbl del cuoco corrispondente
                }
                else if (e.Messaggio.Contains("ha ottenuto il piano")) //se lo ha ottenuto
                {
                    string[] parti = e.Messaggio.Split(new[] { "piano " }, StringSplitOptions.None); // dicido la stringa a piano (str1 = ha ottenuto il, str2 = n) cosi prendo il numero del piano
                    if (parti.Length > 1) // controllo che ci siano le 2 parti
                    {
                        int pianoId = int.Parse(parti[1].Trim()); //prendo la seconda parte (il numero)
                        if (pianoId >= 0 && pianoId < pianiCotturaUI.Count) //check
                        {
                            //aggiorno la ui con le nuove info
                            pianiCotturaUI[pianoId].BackColor = Color.FromArgb(231, 76, 60);
                            ((Label)pianiCotturaUI[pianoId].Controls[0]).Text = $"Piano {pianoId}\nCuoco {e.IdCuoco}";
                        }
                    }

                    //aggiorno ui cuoco
                    cuochiUI[cuocoIndex].BackColor = Color.FromArgb(52, 152, 219);
                    ((Label)cuochiUI[cuocoIndex].Controls[0]).Text = $"Cuoco {e.IdCuoco}\nha il piano";
                }
                else if (e.Messaggio.Contains("sta preparando")) // se prepara
                {
                    Random r = new Random();
                    cuochiUI[cuocoIndex].BackColor = Color.FromArgb(155, 89, 182);
                    ((Label)cuochiUI[cuocoIndex].Controls[0]).Text = $"Cuoco {e.IdCuoco}\nsta cucinando\n{menuDelGiorno[r.Next(0, 30)]}";
                }
                else if (e.Messaggio.Contains("ha terminato")) // se ha gia finito (non finisce in quel istante)
                {
                    cuochiUI[cuocoIndex].BackColor = Color.FromArgb(26, 188, 156);
                    ((Label)cuochiUI[cuocoIndex].Controls[0]).Text = $"Cuoco {e.IdCuoco}\nTerminato";
                }
                else if (e.Messaggio.Contains("ha rilasciato")) // se finisce in quel istante
                {
                    string[] parti = e.Messaggio.Split(new[] { "piano " }, StringSplitOptions.None); //rifaccio la divisione
                    if (parti.Length > 1)
                    {
                        int pianoId = int.Parse(parti[1].Trim()); //pprendo id
                        if (pianoId >= 0 && pianoId < pianiCotturaUI.Count)
                        {
                            pianiCotturaUI[pianoId].BackColor = Color.FromArgb(46, 204, 113); //lo mostro libero
                            ((Label)pianiCotturaUI[pianoId].Controls[0]).Text = $"Piano {pianoId}\nLIBERO";
                        }
                    }

                    //aggiorno ui cuoco
                    cuochiUI[cuocoIndex].BackColor = Color.FromArgb(39, 174, 96);
                    ((Label)cuochiUI[cuocoIndex].Controls[0]).Text = $"Cuoco {e.IdCuoco}\nCompletato";
                }
            }));
        }
    }

    class CuocoEventArgs : EventArgs
    {
        public int IdCuoco { get; } //id del messaggio dek cuoco
        public string Messaggio { get; }//messaggio che porta

        public CuocoEventArgs(int idCuoco, string messaggio)
        {
            IdCuoco = idCuoco;
            Messaggio = messaggio;
        }
    }

    class Cuoco
    {
        public int Id { get; private set; } //id del cuoco vero e proprio
        private int tempoPreparazione;
        static Random r = new Random(); //uso static per sostituire shared (non so perche ma va)
        private int mioPiano; //piano che il cuoco sta usanfo

        public event EventHandler<CuocoEventArgs> StatoCambiato; //event

        public Cuoco(int id, int tempoPreparazione)
        {
            Id = id;
            this.tempoPreparazione = tempoPreparazione;
        }

        public async Task LavoraAsync() //funzione che li fa lavorare
        {
            await RichiediPiano(); //aspetto il primo priano libero
            await PreparaPiatto();  //lavoro
            RilasciaPiano(); //mollo il piano
        }

        private async Task RichiediPiano()
        {
            await Task.Delay(r.Next(0, 500)); //per un po di varieta
            OnStatoCambiato("richiede il piano di cottura..."); //cambio stato del cuoco

            await Cucina.PianoCottura.WaitAsync(); //controlo se il semaphore ha posti liberi

            lock (Cucina.PianiLiberi) //lock evita che 2 cuochi prendano lo stesso piano (quello che arriva dopo aspetta il piano si liberi o un altro sia libero)
            {
                mioPiano = Cucina.PianiLiberi.Dequeue(); //prendo il primo numero disponibile
            }

            int ordine = Interlocked.Increment(ref Cucina.OrdineAccesso); //passagio atommico (evito che si salti numeri)
            OnStatoCambiato($"Ordine {ordine}: ha ottenuto il piano {mioPiano}");
        }

        private async Task PreparaPiatto()
        {
            OnStatoCambiato($"sta preparando il piatto ({tempoPreparazione} ms)..."); //dico che prepara
            await Task.Delay(tempoPreparazione); //aspetto per qunanto e il tempo di preparazione del piato
            OnStatoCambiato("ha terminato il piatto."); //dico che ha finto
        }

        private void RilasciaPiano()
        {
            lock (Cucina.PianiLiberi) //uno alla volta (evito che 2 piani vogliano lo stesso posto in coda)
            {
                Cucina.PianiLiberi.Enqueue(mioPiano);  //metto all'ultimo posto il mio piano liberato
            }

            Cucina.PianoCottura.Release(); //libero
            OnStatoCambiato($"ha rilasciato il piano {mioPiano}"); //dico che ho lasciato
        }

        protected virtual void OnStatoCambiato(string messaggio)
        {
            StatoCambiato?.Invoke(this, new CuocoEventArgs(Id, messaggio)); //invoca l'evento con i vari messagi
        }

        public class Cucina
        {
            public static SemaphoreSlim PianoCottura; //semaforo che coordina tuto
            public static int OrdineAccesso = 0; //numero complessivo dell ordine
            public static Queue<int> PianiLiberi = new Queue<int>();

            public static void Inizializza(int numeroPiani)
            {
                PianoCottura = new SemaphoreSlim(numeroPiani, numeroPiani); // creo il semaforo (posti iniziali = piani iniziali, MAX contemporaneo = MAX piani)
                OrdineAccesso = 0;

                PianiLiberi.Clear();
                for (int i = 0; i < numeroPiani; i++) // metto tutti i piani liberi
                    PianiLiberi.Enqueue(i);
            }
        }
    }
}