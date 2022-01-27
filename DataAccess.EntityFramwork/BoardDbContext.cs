using Games.Common;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    /// <summary>
    /// Реализация контекста базы данных
    /// </summary>
    public class BoardDbContext : DbContext
    {
        public BoardDbContext(DbContextOptions<BoardDbContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<DeveloperStudio> DeveloperStudios { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }

        /// <summary>
        /// Использование Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
               .Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(GameConst.Name.MaxLength);

            modelBuilder.Entity<Genre>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(GenreConst.Name.MaxLength);

            modelBuilder.Entity<DeveloperStudio>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(DeveloperStudioConst.Name.MaxLength);

            modelBuilder.Entity<GameGenre>()
                .HasKey(x => new { x.GameId, x.GenreId });

            modelBuilder.Entity<GameGenre>()
                .HasOne(x => x.Game)
                .WithMany(x => x.Genres)
                .HasForeignKey(x => x.GameId);

            modelBuilder.Entity<GameGenre>()
                .HasOne(x => x.Genre)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.GenreId);
            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
