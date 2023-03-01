using Microsoft.EntityFrameworkCore;

namespace Amagi.Thumbnail.DataLayer.Context;

public partial class AmagiContext : DbContext
{
    public AmagiContext(DbContextOptions<AmagiContext> options)
        : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost;Database=Amagi;Trusted_Connection=true;TrustServerCertificate=true;");
    }

    public DbSet<Models.ThumbnailMeta> ThumbnailMeta { get; set; }
    public DbSet<Models.Thumbnail> Thumbnail { get; set; }
}
