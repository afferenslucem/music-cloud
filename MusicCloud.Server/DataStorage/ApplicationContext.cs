using Microsoft.EntityFrameworkCore;
using MusicCloud.Server.DataStorage.Models;

namespace MusicCloud.Server.DataStorage;

public class ApplicationContext : DbContext
{
    public DbSet<MusicFile> MusicFiles;

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=45432;Database=music_cloud;User Id=music_cloud;Password=masterkey;");
    }
}