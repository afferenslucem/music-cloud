namespace MusicCloud.Server.Music;

public interface IMusicManager {
    Task SaveFiles(IFormFileCollection files, int userId);
    Task SaveFile(IFormFile file, int userId);
}