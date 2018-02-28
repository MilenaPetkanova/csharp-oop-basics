using System;

public class Song
{
    private const string InvalidSongException = "Invalid song.";
    private const string InvalidArtistNameException = "Artist name should be between 3 and 20 symbols.";
    private const string InvalidSongNameException = "Song name should be between 3 and 30 symbols.";
    private const string InvalidSongLengthException = "Invalid song length.";
    private const string InvalidSongMinutesException = "Song minutes should be between 0 and 14.";
    private const string InvalidSongSecondsException = "Song seconds should be between 0 and 59.";

    public string ArtistName { get; set; }
    public string SongName { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    public Song(string artist, string song, int minutes, int seconds)
    {
        this.ArtistName = artist;
        this.SongName = song;
        this.Minutes = minutes;
        this.Seconds = seconds;
        ValidateSong();
    }

    private void ValidateSong()
    {
        if (ArtistName.Length < 3 || ArtistName.Length > 20)
        {
            throw new ArgumentException(InvalidArtistNameException);
        }
        else if (SongName.Length < 3 || SongName.Length > 30)
        {
            throw new ArgumentException(InvalidSongNameException);
        }
        else if (Minutes > 14 && Seconds >= 0 && Seconds <= 59)
        {
            throw new ArgumentException(InvalidSongLengthException);
        }
        else if (Minutes < 0 || Minutes > 14)
        {
            throw new ArgumentException(InvalidSongMinutesException);
        }
        else if (Seconds < 0 || Seconds > 59)
        {
            throw new ArgumentException(InvalidSongSecondsException);
        }
    }
}