namespace MusicCloud.Server.FileStorage;

public class FileStorage: IFileStorage {
    public async Task<FileInfo> SaveFileForUser(IFormFile file, long userId) {
        var path = this.GetFilePath(userId, file.FileName);

        using var fileStream = new FileStream(path, FileMode.Create); 

        await file.CopyToAsync(fileStream);

        return new FileInfo(path);
    }

    public FileInfo RenameFile(string name, long fileId, long userId) {
        var oldPath = this.GetFilePath(userId, name);
        var newPath = this.GetFilePath(userId, fileId.ToString());

        File.Move(oldPath, newPath);

        return new FileInfo(newPath);
    }

    private string GetFilePath(long userId, string name) {
        var path = $"/media/music-cloud/{userId}/{name}";

        return path;
    }
}