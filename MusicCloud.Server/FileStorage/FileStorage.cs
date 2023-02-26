namespace MusicCloud.Server.FileStorage;

public class FileStorage: IFileStorage {
    public async Task<FileInfo> SaveFileForUser(IFormFile file, int userId) {
        var path = $"/media/music-cloud/{userId}/{file.FileName}";

        using var fileStream = new FileStream(path, FileMode.Create); 

        await file.CopyToAsync(fileStream);

        return new FileInfo(path);
    }
}