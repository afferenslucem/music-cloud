using MusicCloud.Server.FileStorage;

namespace MusicCloud.Server.Music;

public class MusicManager: IMusicManager
{
    private IFileStorage fileStorage;

    public MusicManager(IFileStorage fileStorage) {
        this.fileStorage = fileStorage;
    }

    public async Task SaveFiles(IFormFileCollection files, int userId) {
        foreach(var file in files) {
            await SaveFile(file, userId);
        }
    }

    public async Task SaveFile(IFormFile file, int userId) {
        var savedFile = await this.fileStorage.SaveFileForUser(file, userId);

        Console.WriteLine(savedFile.DirectoryName);
    }

    private string GetUserPath(int userId) {
        return $"/media/music-cloud/{userId}";
    }
}
