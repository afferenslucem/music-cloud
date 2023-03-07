namespace MusicCloud.Server.FileStorage;

public interface IFileStorage {
    Task<FileInfo> SaveFileForUser(IFormFile file, long userId);

    FileInfo RenameFile(string name, long fileId, long userId);
}