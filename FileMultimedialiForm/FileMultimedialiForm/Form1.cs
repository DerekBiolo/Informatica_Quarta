using FileMultimediali;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileMultimedialiForm
{
    public partial class Form1 : Form
    {
        private string estensioneCorrente;
        private List<CMultimediaFile> fileList;
        public int indexSelextedRN;
        public Form1()
        {
            InitializeComponent();
            fileList = new List<CMultimediaFile>();
            estensioneCorrente = ".mp3";
            lbl_NomeFileSelezionato.Text = "Nessun file selezionato";
            Lbl_DurataItemSelezionato.Text = "Nessun file selezionato";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RBtn_Audio.Checked = true;
            Num_Luminosita.Hide();
            Lbl_Luminosita.Hide();
            MTxt_NomeFile.Text = "nomefile" + estensioneCorrente;
        }

        // --- AUDIO ---
        private void RBtn_Audio_CheckedChanged(object sender, EventArgs e)
        {
            if (RBtn_Audio.Checked)
            {
                MTxt_NomeFile.Clear();
                estensioneCorrente = ".mp3";
                Lbl_Durata.Show();
                Txt_Durata.Show();
                Lbl_Volume.Show();
                Num_Volume.Show();
                Num_Luminosita.Hide();
                Lbl_Luminosita.Hide();

                if (string.IsNullOrWhiteSpace(MTxt_NomeFile.Text))
                    MTxt_NomeFile.Text = "nomefile" + estensioneCorrente;
            }
        }

        // --- IMMAGINE ---
        private void RBtn_Immagine_CheckedChanged(object sender, EventArgs e)
        {
            if (RBtn_Immagine.Checked)
            {
                MTxt_NomeFile.Clear();
                estensioneCorrente = ".png";
                Lbl_Durata.Hide();
                Txt_Durata.Hide();
                Lbl_Volume.Hide();
                Num_Volume.Hide();
                Lbl_Luminosita.Show();
                Num_Luminosita.Show();

                if (string.IsNullOrWhiteSpace(MTxt_NomeFile.Text))
                    MTxt_NomeFile.Text = "nomefile" + estensioneCorrente;
            }
        }

        // --- VIDEO ---
        private void RBtn_Video_CheckedChanged(object sender, EventArgs e)
        {
            if (RBtn_Video.Checked)
            {
                MTxt_NomeFile.Clear();
                estensioneCorrente = ".mp4";
                Lbl_Durata.Show();
                Txt_Durata.Show();
                Lbl_Volume.Show();
                Num_Volume.Show();
                Num_Luminosita.Show();
                Lbl_Luminosita.Show();

                if (string.IsNullOrWhiteSpace(MTxt_NomeFile.Text))
                    MTxt_NomeFile.Text = "nomefile" + estensioneCorrente;
            }
        }

        // --- USCITA DAL CAMPO NOME FILE ---
        private void MTxt_NomeFile_Leave(object sender, EventArgs e)
        {
            string testo = MTxt_NomeFile.Text.Trim();

            if (string.IsNullOrEmpty(testo))
            {
                MTxt_NomeFile.Text = "nomefile" + estensioneCorrente;
                return;
            }

            if (!testo.EndsWith(estensioneCorrente, StringComparison.OrdinalIgnoreCase))
            {
                int punto = testo.LastIndexOf('.');
                if (punto > 0)
                    testo = testo.Substring(0, punto);

                MTxt_NomeFile.Text = testo + estensioneCorrente;
            }
        }

        // --- AGGIUNTA FILE ---
        private void btn_AddFile_Click(object sender, EventArgs e)
        {
            // variabili base
            string nomeFile = MTxt_NomeFile.Text.Trim();
            string durataText = Txt_Durata.Text.Trim();
            int durata = 0;
            int volume = (int)Num_Volume.Value;
            int luminosita = (int)Num_Luminosita.Value;

            // --- controlli base ---
            if (string.IsNullOrEmpty(nomeFile))
            {
                MessageBox.Show("Inserisci un nome valido.");
                return;
            }

            // --- controllo durata formato mm:ss ---
            if (!string.IsNullOrEmpty(durataText))
            {
                string[] parts = durataText.Split(':');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int minuti) &&
                    int.TryParse(parts[1], out int secondi) &&
                    minuti >= 0 && secondi >= 0 && secondi < 60)
                {
                    durata = minuti * 60 + secondi;
                }
                else if (!RBtn_Immagine.Checked) // l'immagine non ha durata
                {
                    MessageBox.Show("Formato durata non valido. Usa mm:ss (es. 02:45).");
                    return;
                }
            }

            // --- controllo range volume ---
            if (volume < 0 || volume > 100)
            {
                MessageBox.Show("Volume deve essere tra 0 e 100.");
                return;
            }

            // --- controllo range luminosità ---
            if (luminosita < 0 || luminosita > 100)
            {
                MessageBox.Show("Luminosità deve essere tra 0 e 100.");
                return;
            }

            // --- creazione effettiva ---
            if (RBtn_Audio.Checked)
            {
                CAudioFile audio = new CAudioFile(nomeFile, volume, durata, 0);
                fileList.Add(audio);

            }
            else if (RBtn_Immagine.Checked)
            {
                CImmagine immagine = new CImmagine(nomeFile, luminosita);
                fileList.Add(immagine);
            }
            else if (RBtn_Video.Checked)
            {
                CVideo video = new CVideo(nomeFile, volume, 0, durata, luminosita);
                fileList.Add(video);
            }

            AggiornaListbox();
        }

        public void AggiornaListbox()
        {
            Lst_visualizzazione.Items.Clear();
            foreach (var item in fileList)
            {
                if (item == null) return;
                Lst_visualizzazione.Items.Add(item.Stringfy());
            }
        }

        private void Lst_visualizzazione_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (Lst_visualizzazione.SelectedIndex == -1) return;
            indexSelextedRN = Lst_visualizzazione.SelectedIndex;
            CMultimediaFile selezionato = fileList[Lst_visualizzazione.SelectedIndex];
            if (selezionato == null) return;

            lbl_NomeFileSelezionato.Text = selezionato.GetFileName();

            // reset controlli
            Lbl_DurataItemSelezionato.Text = "—";
            bar_Volume.Value = 0;
            bar_Luminosita.Value = 0;

            // --- VIDEO ---
            if (selezionato is CVideo v)
            {
                int minuti = v.minutesDuration / 60;
                int secondi = v.secondsDuration % 60;
                Lbl_DurataItemSelezionato.Text = $"{minuti:D2}:{secondi:D2}";
                bar_Volume.Value = Math.Min(v.volumeLevel, 100);
                bar_Luminosita.Value = Math.Min(v.brightnessLevel, 100);
            }
            // --- IMMAGINE ---
            else if (selezionato is CImmagine i)
            {
                bar_Luminosita.Value = Math.Min(i.brigtness, 100);
                Lbl_DurataItemSelezionato.Text = "—";
                bar_Volume.Value = 0;
            }
            // --- AUDIO ---
            else if (selezionato is CAudioFile a)
            {
                int minuti = a.durationInMinutes / 60;
                int secondi = a.durationInSeconds % 60;
                Lbl_DurataItemSelezionato.Text = $"{minuti:D2}:{secondi:D2}";
                bar_Volume.Value = Math.Min(a.volumeLevel, 100);
                bar_Luminosita.Value = 0;
            }
        }

        private void btn_DecreaseLuminosita_Click(object sender, EventArgs e)
        {
            if (indexSelextedRN < 0 || indexSelextedRN >= fileList.Count) return;

            CMultimediaFile file = fileList[indexSelextedRN];

            if (file is CVideo v)
            {
                v.DecreaseBrightness();
                bar_Luminosita.Value = Math.Max(v.brightnessLevel, 0);
            }
            else if (file is CImmagine i)
            {
                i.DecreaseBrightness();
                bar_Luminosita.Value = Math.Max(i.brigtness, 0);
            }

            AggiornaListbox();
        }

        private void btn_IncreaseBrightness_Click(object sender, EventArgs e)
        {
            if (indexSelextedRN < 0 || indexSelextedRN >= fileList.Count) return;

            CMultimediaFile file = fileList[indexSelextedRN];

            if (file is CVideo v)
            {
                v.IncreaseBrigtness();
                bar_Luminosita.Value = Math.Min(v.brightnessLevel, 100);
            }
            else if (file is CImmagine i)
            {
                i.IncreaseBrigtness();
                bar_Luminosita.Value = Math.Min(i.brigtness, 100);
            }

            AggiornaListbox();
        }

        private void btn_DecreaseVolume_Click(object sender, EventArgs e)
        {
            if (indexSelextedRN < 0 || indexSelextedRN >= fileList.Count) return;

            CMultimediaFile file = fileList[indexSelextedRN];

            if (file is CVideo v)
            {
                v.DecreaseVolume();
                bar_Volume.Value = Math.Max(v.volumeLevel, 0);
            }
            else if (file is CAudioFile a)
            {
                a.DecreaseVolume();
                bar_Volume.Value = Math.Max(a.volumeLevel, 0);
            }

            AggiornaListbox();
        }

        private void btn_IncreaseVOlume_Click(object sender, EventArgs e)
        {
            if (indexSelextedRN < 0 || indexSelextedRN >= fileList.Count) return;

            CMultimediaFile file = fileList[indexSelextedRN];

            if (file is CVideo v)
            {
                v.IncreaseVolume();
                bar_Volume.Value = Math.Min(v.volumeLevel, 100);
            }
            else if (file is CAudioFile a)
            {
                a.IncreaseVolume();
                bar_Volume.Value = Math.Min(a.volumeLevel, 100);
            }

            AggiornaListbox();
        }

    }
}
