using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        // 75/100 -> Test #4 (Incorrect answer), Test #6 (Incorrect answer) 

        var playlist = new List<Song>();
        var plalistSecondsLength = 0;

        int songsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < songsCount; i++)
        {
            try
            {
                var songsArgs = Console.ReadLine().Split(';');
                var artistName = songsArgs[0];
                var songName = songsArgs[1];
                var songLength = songsArgs[2].Split(':');
                int minutes = int.Parse(songLength[0]);
                int seconds = int.Parse(songLength[1]);

                var song = new Song(artistName, songName, minutes, seconds);
                playlist.Add(song);
                Console.WriteLine("Song added.");

                plalistSecondsLength += seconds + minutes * 60;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    Console.WriteLine(ex.Message);
                }
                else if (ex is FormatException || ex is IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid song.");
                }
            }
        }
        TimeSpan length = TimeSpan.FromSeconds(plalistSecondsLength);

        Console.WriteLine($"Songs added: {playlist.Count}");
        Console.WriteLine($"Playlist length: {length.Hours}h {length.Minutes}m {length.Seconds}s");
    }
}
