using MusicCloud.Server.DataStorage;
using MusicCloud.Server.FileStorage;

namespace MusicCloud.Server.Music;

public interface IMusicManager {
    Task SaveFiles(IFormFileCollection files, int userId);
    Task SaveFile(IFormFile file, int userId);
}

public class MusicManager: IMusicManager
{
    private IFileStorage fileStorage;
    private IMusicStorage musicStorage;

    public MusicManager(IFileStorage fileStorage, IMusicStorage musicStorage) {
        this.fileStorage = fileStorage;
        this.musicStorage = musicStorage;
    }

    public async Task SaveFiles(IFormFileCollection files, int userId) {
        foreach(var file in files) {
            await SaveFile(file, userId);
        }
    }

    public async Task SaveFile(IFormFile file, int userId) {
        var savedFile = await this.fileStorage.SaveFileForUser(file, userId);
        var metadata = new MetaReader().GetFileInfo(savedFile);
        await this.musicStorage.Save(metadata);
        this.fileStorage.RenameFile(savedFile.Name, metadata.Id, userId);
    }

    private string GetUserPath(int userId) {
        return $"/media/music-cloud/{userId}";
    }
}
