using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wasapi.CoreAudioApi.Interfaces;
using NAudio.Wave;

namespace Battaglia_Navale_Eventi
{
    internal class SoundManager
    {
        private WaveOutEvent audioPlayer;
        public void PlayMancata()
        {
            var audio = new AudioFileReader("mancata.mp3");
            if(audio != null)
            {
                Play(audio);
            } else
            {
                MessageBox.Show($"Audio non trovato per {audio}");
            }
        }

        public void PlayColpita()
        {
            var audio = new AudioFileReader("colpita.mp3");
            if (audio != null)
            {
                Play(audio);
            }
            else
            {
                MessageBox.Show($"Audio non trovato per {audio}");
            }
        }

        public void PlayAffondata()
        {
            var audio = new AudioFileReader("affondata.mp3");
            if (audio != null)
            {
                Play(audio);
            }
            else
            {
                MessageBox.Show($"Audio non trovato per {audio}");
            }
        }

        private void Play(AudioFileReader audio)
        {
            audioPlayer?.Stop();
            audioPlayer?.Dispose();

            audioPlayer = new WaveOutEvent();
            audioPlayer.Init(audio);
            audioPlayer.Play();

            audioPlayer.PlaybackStopped += (s, e) =>
            {
                audio.Dispose();
            };
        }
    }
}
