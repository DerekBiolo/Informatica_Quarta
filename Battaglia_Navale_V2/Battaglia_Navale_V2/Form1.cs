public partial class Form1 : Form
{
    private GameManager gameManager;
    private Button[,] player1Buttons;
    private Button[,] player2Buttons;

    public Form1()
    {
        InitializeComponent();
        // Rimuovi InizializeGame() dal costruttore - verrà chiamato dopo la lobby
    }

    // CORREZIONE: Rinominato da InizializeGame a InitializeGame
    private void InitializeGame(bool isPvP)
    {
        if (isPvP)
        {
            gameManager = new GameManager(
                new Player("Giocatore 1", TipoPlayer.Normale),
                new Player("Giocatore 2", TipoPlayer.Normale)
            );
        }
        else
        {
            gameManager = new GameManager(
                new Player("Giocatore", TipoPlayer.Normale),
                new ComputerPlayer("Computer")
            );
        }

        gameManager.OnGameLog += OnGameLog;
        gameManager.OnGameStateChanged += OnGameStateChanged;

        CreaGriglieDiGioco();

        // Posizionamento automatico navi
        gameManager.PosizionaNaviAutomaticamente();
        AggiornaUI();
    }

    private void CreaGriglieDiGioco()
    {
        player1Buttons = CreaGriglia(pnlPlayer1, 10, 10, OnPlayer1CellClick);
        player2Buttons = CreaGriglia(pnlPlayer2, 10, 10, OnPlayer2CellClick);
    }

    // METODO UNIFICATO per il click sulle celle
    private void OnGridCellClick(object sender, EventArgs e, bool isPlayer1Grid)
    {
        if (gameManager.FaseAttuale != FaseGioco.Battaglia) return;

        var pulsante = (Button)sender;
        var punto = (Point)pulsante.Tag;

        // Determina il giocatore target in base alla griglia cliccata
        Player giocatoreTarget = isPlayer1Grid ? gameManager.p2 : gameManager.p1;

        // Verifica che sia il turno del giocatore umano
        if (gameManager.currentPlayer.Tipo != TipoPlayer.Normale) return;

        // Esegui la mossa
        gameManager.currentPlayer.EseguiMossa(punto.X, punto.Y, giocatoreTarget);

        AggiornaUI();

        if (gameManager.IsGameOver())
        {
            MessageBox.Show($"Game over, Vince: {gameManager.currentPlayer.Nome}");
            return;
        }

        gameManager.CambiaTurno();
        AggiornaUI();
    }

    private void OnPlayer1CellClick(object sender, EventArgs e)
    {
        OnGridCellClick(sender, e, false); // Clic su griglia player1 = target player2
    }

    private void OnPlayer2CellClick(object sender, EventArgs e)
    {
        OnGridCellClick(sender, e, true); // Clic su griglia player2 = target player1
    }

    private void OnGameLog(object sender, string mex)
    {
        if (lstLog.InvokeRequired)
        {
            lstLog.Invoke(new Action<string>(OnGameLog), mex);
            return;
        }

        lstLog.Items.Add($"{DateTime.Now:HH:mm:ss} - {mex}");
        lstLog.TopIndex = lstLog.Items.Count - 1;

        // Aggiorna solo se gameManager è inizializzato
        if (gameManager?.currentPlayer != null)
            lblNaviRimanenti.Text = $"Navi rimaste: {gameManager.currentPlayer.FlottaRimasta}";
    }

    private void OnGameStateChanged(FaseGioco fase)
    {
        if (InvokeRequired)
        {
            Invoke(new Action<FaseGioco>(OnGameStateChanged), fase);
            return;
        }
        AggiornaUI();
    }

    private void AggiornaUI()
    {
        if (gameManager?.currentPlayer == null) return;

        lblMosse.Text = $"Mosse: {gameManager.currentPlayer.MosseEffettuate}";
        lblNaviRimanenti.Text = $"Navi Rimaste: {gameManager.currentPlayer.FlottaRimasta}";

        AggiornaColoriGriglia();
        AggiornaStatoControlli();
    }

    private void AggiornaStatoControlli()
    {
        bool inBattaglia = gameManager?.FaseAttuale == FaseGioco.Battaglia;
        bool inPosizionamento = gameManager?.FaseAttuale == FaseGioco.Posizionamento;

        btnPosizionaAuto.Enabled = inPosizionamento;
        btnIniziaBattaglia.Enabled = inPosizionamento;
    }

    private void AggiornaColoriGriglia()
    {
        if (gameManager?.p1 == null || gameManager?.p2 == null) return;

        AggiornaColoriPlayer(gameManager.p1, player1Buttons);
        AggiornaColoriPlayer(gameManager.p2, player2Buttons);
    }

    private void AggiornaColoriPlayer(Player player, Button[,] buttons)
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                var cella = player.Tabella.GetCella(x, y);
                var pulsante = buttons[x, y];

                if (cella != null && pulsante != null)
                {
                    // Nascondi le navi avversarie durante la battaglia
                    if (gameManager.FaseAttuale == FaseGioco.Battaglia &&
                        cella.Status == StatusCella.Nave &&
                        player != gameManager.currentPlayer)
                    {
                        pulsante.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        pulsante.BackColor = cella.Status switch
                        {
                            StatusCella.Vuota => Color.LightBlue,
                            StatusCella.Nave => Color.Gray,
                            StatusCella.Colpita => Color.Red,
                            StatusCella.Mancata => Color.WhiteSmoke,
                            StatusCella.Affondata => Color.DarkRed,
                            _ => Color.LightBlue
                        };
                    }
                }
            }
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        FLobby f = new FLobby();
        this.Hide();
        DialogResult lobbyResult = f.ShowDialog();

        if (lobbyResult == DialogResult.OK)
        {
            InitializeGame(true); // PvP
            this.Show();
        }
        else if (lobbyResult == DialogResult.Yes)
        {
            InitializeGame(false); // PvAI
            this.Show();
        }
        else
        {
            this.Close();
        }
    }

    // Aggiungi questi bottoni al designer
    private void btnPosizionaAuto_Click(object sender, EventArgs e)
    {
        gameManager?.PosizionaNaviAutomaticamente();
        AggiornaUI();
    }

    private void btnIniziaBattaglia_Click(object sender, EventArgs e)
    {
        gameManager?.IniziaBattaglia();
        AggiornaUI();
    }

    private void btnNuovaPartita_Click(object sender, EventArgs e)
    {
        // Ricarica il form per una nuova partita
        Application.Restart();
    }
}