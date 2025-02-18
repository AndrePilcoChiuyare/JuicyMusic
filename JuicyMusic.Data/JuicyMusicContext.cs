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
        modelBuilder.Entity<TrackEntity>(entity =>
        {
            entity
                .ToTable("Tracks")
                .HasKey(e => e.Id);

            entity
                .Property(i => i.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity
                .Property(i => i.DurationMs)
                .IsRequired();

            entity
                .Property(i => i.ImageUrl)
                .IsRequired();

            // Foreign Key Relationships
            entity
                .HasOne(i => i.Genre)
                .WithMany(i => i.Tracks)
                .HasForeignKey(i => i.GenreId)
                .IsRequired();

            entity
                .HasOne(i => i.Album)
                .WithMany(i => i.Tracks)
                .HasForeignKey(i => i.AlbumId)
                .IsRequired();

            entity
                .HasOne(i => i.Artist)
                .WithMany(i => i.Tracks)
                .HasForeignKey(i => i.ArtistId)
                .IsRequired();
        });

        modelBuilder.Entity<AlbumEntity>(entity =>
        {
            entity
                .ToTable("Albums")
                .HasKey(e => e.Id);

            entity
                .Property(i => i.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity
                .Property(i => i.TypeId)
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
                .Property(i => i.ImageUrl)
                .IsRequired();

            // Foreign Key for Genre
            entity
                .HasOne(i => i.Genre)
                .WithMany(i => i.Albums)
                .HasForeignKey(i => i.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(i => i.Artist)
                .WithMany(i => i.Albums)
                .HasForeignKey(i => i.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

        });

        modelBuilder.Entity<ArtistEntity>(entity =>
        {
            entity
                .ToTable("Artists")
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
                .Property(i => i.ImageUrl)
                .IsRequired();
        });

        modelBuilder.Entity<FavoriteAlbumEntity>(entity =>
        {
            entity
                .ToTable("FavoriteAlbums")
                .HasKey(e => e.Id);

            // Foreign Key for Album
            entity
                .HasOne(i => i.Album)
                .WithMany(i => i.FavoriteAlbums)
                .HasForeignKey(i => i.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

            // Foreign Key for User
            entity
                .HasOne(i => i.User)
                .WithMany(i => i.FavoriteAlbums)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<FavoriteArtistEntity>(entity =>
        {
            entity
                .ToTable("FavoriteArtists")
                .HasKey(e => e.Id);

            // Foreign Key for Artist
            entity
                .HasOne(i => i.Artist)
                .WithMany(i => i.FavoriteArtists)
                .HasForeignKey(i => i.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            // Foreign Key for User
            entity
                .HasOne(i => i.User)
                .WithMany(i => i.FavoriteArtists)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<FavoriteTrackEntity>(entity =>
        {
            entity
                .ToTable("FavoriteTracks")
                .HasKey(e => e.Id);

            // Foreign Key for Track
            entity
                .HasOne(i => i.Track)
                .WithMany(i => i.FavoriteTracks)
                .HasForeignKey(i => i.TrackId)
                .OnDelete(DeleteBehavior.Cascade);

            // Foreign Key for User
            entity
                .HasOne(i => i.User)
                .WithMany(i => i.FavoriteTracks)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<GenreEntity>(entity =>
        {
            entity
                .ToTable("Genres")
                .HasKey(e => e.Id);

            entity
                .Property(i => i.Name)
                .HasMaxLength(50)
                .IsRequired();
        });

        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity
                .ToTable("Users")
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
