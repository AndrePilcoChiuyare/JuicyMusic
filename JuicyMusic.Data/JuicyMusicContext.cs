using Microsoft.EntityFrameworkCore;
using JuicyMusic.Data.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Update;
using JuicyMusic.Domain.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
    public DbSet<AlbumEntity> Albums { get; set; }
    public DbSet<ArtistEntity> Artists { get; set; }
    public DbSet<FavoriteAlbumEntity> FavoriteAlbums { get; set; }
    public DbSet<FavoriteArtistEntity> FavoriteArtists { get; set; }
    public DbSet<FavoriteTrackEntity> FavoriteTracks { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<UserEntity> Users { get; set; }

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
                .IsRequired();

            entity
                .Property(i => i.Album)
                .IsRequired();

            entity
                .Property(i => i.Artist)
                .IsRequired();

            entity
                .Property(i => i.ImageUrl)
                .IsRequired();
        });

        modelBuilder.Entity<AlbumEntity>(entity => {
            entity
                .ToTable("Album")
                .HasKey(e => e.Id);

            entity
                .Property(i => i.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity
                .Property(i => i.Type)
                .IsRequired();

            entity
                .Property(i => i.TotalTracks)
                .IsRequired();

            entity
                .Property(i => i.ReleaseDate)
                .IsRequired();

            entity
                .Property(i => i.DurationMs)
                .IsRequired();

            entity
                .Property(i => i.Genre)
                .IsRequired();

            entity
                .Property(i => i.ImageUrl)
                .IsRequired();
        });

        modelBuilder.Entity<ArtistEntity>(entity => {
            entity
                .ToTable("Artist")
                .HasKey(e => e.Id);

            entity
                .Property(i => i.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity
                .Property(i => i.Followers)
                .IsRequired();

            entity
                .Property(i => i.Description)
                .HasMaxLength(1000)
                .IsRequired();

            entity
                .Property(i => i.Genre)
                .IsRequired();

            entity
                .Property(i => i.ImageUrl)
                .IsRequired();
        });

        modelBuilder.Entity<FavoriteAlbumEntity>(entity => {
            entity
                .ToTable("FavoriteAlbum")
                .HasKey(e => e.Id);

            entity
                .Property(i => i.Album)
                .IsRequired();

            entity
                .Property(i => i.User)
                .IsRequired();
        });

        modelBuilder.Entity<FavoriteArtistEntity>(entity => {
            entity
                .ToTable("FavoriteArtist")
                .HasKey(e => e.Id);

            entity
                .Property(i => i.Artist)
                .IsRequired();

            entity
                .Property(i => i.User)
                .IsRequired();
        });

        modelBuilder.Entity<FavoriteTrackEntity>(entity => {
            entity
                .ToTable("FavoriteTrack")
                .HasKey(e => e.Id);

            entity
                .Property(i => i.Track)
                .IsRequired();

            entity
                .Property(i => i.User)
                .IsRequired();
        });

        modelBuilder.Entity<GenreEntity>(entity => {
            entity
                .ToTable("Genre")
                .HasKey(e => e.Id);

            entity
                .Property(i => i.Name)
                .HasMaxLength(50)
                .IsRequired();
        });

       modelBuilder.Entity<UserEntity>(entity => {
            entity
                .ToTable("User")
                .HasKey(e => e.Id);

            entity
                .Property(i => i.Username)
                .HasMaxLength(50)
                .IsRequired();

            entity
                .Property(i => i.ImageUrl)
                .IsRequired();
        });
    }
}
