namespace MusicCloud.Server.DataStorage.Models;

public class MusicFile
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string[] Artists { get; set; }
    public string Album { get; set; }
    public string Publisher { get; set; }
    public string[] Genres { get; set; }
    public string[] Tags { get; set; }
    public uint Year { get; set; }
    public TimeSpan Duration { get; set; }

    public uint AlbumTrackCount { get; set; }

    public uint TrackNumber { get; set; }

    public string FilePath { get; set; }
}