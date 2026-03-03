namespace FileMultimediali
{
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;
    using static System.Console;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<CMultimediaFile> mediaFiles = new();

            int choiceMenu;
            int index;

            // chiedi quanti file creare
            do
            {
                WriteLine("Inserisci il numero di file multimediali da creare:");
            } while (!(int.TryParse(ReadLine(), out index) && index > 0));

            while (index > 0)
            {
                do
                {
                    WriteLine("Che tipo di file multimediale vuoi creare? (1: Audio, 2: Video, 3: Immagine, 4: Esci)");
                } while (!(int.TryParse(ReadLine(), out choiceMenu) && choiceMenu >= 1 && choiceMenu <= 4));

                if (choiceMenu == 4)
                    break;

                FillList(choiceMenu, mediaFiles);
                index--;
            }

            int i = 1;
            WriteLine("\nRiproduzione dei file multimediali creati:");
            foreach (var mediaFile in mediaFiles)
            {
                Write($"File {1} ==> {mediaFile.Stringfy()}");
                WriteLine("\n");
                i++;
            }

            //confronto tra due video
            CompareVideos(mediaFiles);
        }

        public static void FillList(int choiceMenu, List<CMultimediaFile> mediaFiles)
        {
            switch (choiceMenu)
            {
                case 1:
                    {
                        string fileName;
                        int durationInSeconds;
                        int durationInMinutes;
                        int volumeLevel;

                        do
                        {
                            WriteLine("Inserisci il nome del file audio (deve terminare con .mp3):");
                            fileName = ReadLine();
                        } while (string.IsNullOrEmpty(fileName) || !fileName.EndsWith(".mp3"));

                        do
                        {
                            WriteLine("Inserisci il livello del volume (0-100):");
                        } while (!(int.TryParse(ReadLine(), out volumeLevel) && volumeLevel >= 0 && volumeLevel <= 100));

                        do
                        {
                            WriteLine("Inserisci la durata in secondi:");
                        } while (!(int.TryParse(ReadLine(), out durationInSeconds) && durationInSeconds >= 0));

                        do
                        {
                            WriteLine("Inserisci la durata in minuti:");
                        } while (!(int.TryParse(ReadLine(), out durationInMinutes) && durationInMinutes >= 0));

                        CAudioFile audio = new(fileName, volumeLevel, durationInSeconds, durationInMinutes);
                        mediaFiles.Add(audio);
                        break;
                    }

                case 2:
                    {
                        string fileName;
                        int durationInSeconds;
                        int durationInMinutes;
                        int volumeLevel;
                        int brightnessLevel;

                        do
                        {
                            WriteLine("Inserisci il nome del file video (deve terminare con .mp4):");
                            fileName = ReadLine();
                        } while (string.IsNullOrEmpty(fileName) || !fileName.EndsWith(".mp4"));

                        do
                        {
                            WriteLine("Inserisci il livello del volume (0-100):");
                        } while (!(int.TryParse(ReadLine(), out volumeLevel) && volumeLevel >= 0 && volumeLevel <= 100));

                        do
                        {
                            WriteLine("Inserisci la durata in secondi:");
                        } while (!(int.TryParse(ReadLine(), out durationInSeconds) && durationInSeconds >= 0));

                        do
                        {
                            WriteLine("Inserisci la durata in minuti:");
                        } while (!(int.TryParse(ReadLine(), out durationInMinutes) && durationInMinutes >= 0));

                        do
                        {
                            WriteLine("Inserisci il livello di luminosità (0-100):");
                        } while (!(int.TryParse(ReadLine(), out brightnessLevel) && brightnessLevel >= 0 && brightnessLevel <= 100));

                        CVideo video = new(fileName, volumeLevel, durationInSeconds, durationInMinutes, brightnessLevel);
                        mediaFiles.Add(video);
                        break;
                    }

                case 3:
                    {
                        string fileName;
                        int brightnessLevel;

                        do
                        {
                            WriteLine("Inserisci il nome del file immagine (deve terminare con .jpg o .png):");
                            fileName = ReadLine();
                        } while (string.IsNullOrEmpty(fileName) || !(fileName.EndsWith(".jpg") || fileName.EndsWith(".png")));

                        do
                        {
                            WriteLine("Inserisci il livello di luminosità (0-100):");
                        } while (!(int.TryParse(ReadLine(), out brightnessLevel) && brightnessLevel >= 0 && brightnessLevel <= 100));

                        CImmagine image = new(fileName, brightnessLevel);
                        mediaFiles.Add(image);
                        break;
                    }
            }
        }

        // ---- funzione separata per il confronto tra due video ----
        public static void CompareVideos(List<CMultimediaFile> mediaFiles)
        {
            List<CVideo> videoFiles = new();

            foreach (var mediaFile in mediaFiles)
            {
                if (mediaFile is CVideo video)
                {
                    videoFiles.Add(video);
                }
            }

            if (videoFiles.Count < 2)
            {
                WriteLine("\nNon ci sono abbastanza file video per effettuare un confronto.");
                return;
            }

            WriteLine("\nConfronto tra due file video:");
            for (int i = 0; i < videoFiles.Count; i++)
            {
                WriteLine($"{i + 1}: {videoFiles[i].GetFileName()}");
            }

            int firstChoice, secondChoice;

            do
            {
                WriteLine("Scegli il primo file video da confrontare (inserisci il numero):");
            } while (!(int.TryParse(ReadLine(), out firstChoice) && firstChoice >= 1 && firstChoice <= videoFiles.Count));

            do
            {
                WriteLine("Scegli il secondo file video da confrontare (inserisci il numero):");
            } while (!(int.TryParse(ReadLine(), out secondChoice) && secondChoice >= 1 && secondChoice <= videoFiles.Count && secondChoice != firstChoice));

            CVideo firstVideo = videoFiles[firstChoice - 1];
            CVideo secondVideo = videoFiles[secondChoice - 1];

            int comparisonResult = firstVideo.CompareTo(secondVideo);

            if (comparisonResult < 0)
                WriteLine("Il primo video è più corto del secondo.");
            else if (comparisonResult > 0)
                WriteLine("Il primo video è più lungo del secondo.");
            else
                WriteLine("I due video hanno la stessa durata.");
        }
    }
}
