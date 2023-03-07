using MusicCloud.Server.DataStorage.Models;

namespace MusicCloud.Server.DataStorage;

public interface IMusicStorage {
    public Task<MusicFile> Save(MusicFile file);
}

public class MusicStorage: IMusicStorage {
    public async Task<MusicFile> Save(MusicFile file) {
        using var context = new ApplicationContext();

        await context.MusicFiles.AddAsync(file);
        await context.SaveChangesAsync();

        return file;
    }
}