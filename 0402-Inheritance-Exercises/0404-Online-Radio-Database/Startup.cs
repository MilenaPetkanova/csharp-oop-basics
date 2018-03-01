using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var playlist = new List<Song>();

        int songsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < songsCount; i++)
        {
            var songsArgs = Console.ReadLine().Split(';');
            try
            {
                var artistName = songsArgs[0];
                var songName = songsArgs[1];
                var songLength = songsArgs[2].Split(':');
                int minutes;
                int seconds;
                if (int.TryParse(songLength[0], out minutes) && int.TryParse(songLength[1], out seconds))
                {
                    playlist.Add(new Song(artistName, songName, minutes, seconds));
                    Console.WriteLine("Song added.");
                }
                else
                {
                    throw new InvalidSongLengthException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        var totalDurationSeconds = playlist.Sum(s => s.Minutes * 60 + s.Seconds);
        TimeSpan length = TimeSpan.FromSeconds(totalDurationSeconds);

        Console.WriteLine($"Songs added: {playlist.Count}");
        Console.WriteLine($"Playlist length: {length.Hours}h {length.Minutes}m {length.Seconds}s");
    }
}
