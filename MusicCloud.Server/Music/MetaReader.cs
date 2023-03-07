using MusicCloud.Server.DataStorage.Models;

namespace MusicCloud.Server.Music;

public class MetaReader {
    public MusicFile GetFileInfo(FileInfo file) {
        var info = TagLib.File.Create(file.FullName);

        var result = new MusicFile();

        result.Title = info.Tag.Title;
        result.Album = info.Tag.Album;
        result.Artists = info.Tag.Performers;
        result.Genres = info.Tag.Genres;
        result.Year = info.Tag.Year;
        result.AlbumTrackCount = info.Tag.TrackCount;
        result.TrackNumber = info.Tag.Track;
        result.Duration = info.Properties.Duration;

        return result;
    }
}