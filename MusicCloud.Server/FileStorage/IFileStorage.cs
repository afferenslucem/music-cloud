namespace MusicCloud.Server.FileStorage;

public interface IFileStorage {
    Task<FileInfo> SaveFileForUser(IFormFile file, int userId);
}