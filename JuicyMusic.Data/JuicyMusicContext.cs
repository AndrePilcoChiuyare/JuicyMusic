using Microsoft.EntityFrameworkCore;
using JuicyMusic.Data.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Update;

namespace JuicyMusic.Data;

internal class JuicyMusicContext : DbContext, IDatabase
{
    public JuicyMusicContext()
    {

    }

    public JuicyMusicContext(DbContextOptions<JuicyMusicContext> options)
        : base(options)
    {

    }

    public DbSet<TrackEntity> Tracks { get; set; }

    public Expression<Func<QueryContext, TResult>> CompileQueryExpression<TResult>(Expression query, bool async, IReadOnlySet<string> nonNullableReferenceTypeParameters)
    {
        throw new NotImplementedException();
    }

    public void Migrate()
        => base.Database.Migrate();

    public int SaveChanges(IList<IUpdateEntry> entries)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync(IList<IUpdateEntry> entries, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=juicymusic.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrackEntity>(entity =>{
            entity
                .ToTable("Track")
                .HasKey(e => e.Id);

            entity
                .Property(i => i.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity
                .Property(i => i.DurationMs)
                .IsRequired();

            entity
                .Property(i => i.Genre)
                .HasMaxLength(100)
                .IsRequired();

            entity
                .Property(i => i.Album)
                .HasMaxLength(100)
                .IsRequired();

            entity
                .Property(i => i.Artist)
                .HasMaxLength(100)
                .IsRequired();

            entity
                .Property(i => i.ImageUrl)
                .IsRequired();
        });
    }
}
