using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext 
    {
        // constructer
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options) // ctor "tab" "tab"
        {

        }

        // DbSets represents your tables
        // Create the DbSets Properties inside DbContext
        // Inject the ConnectionString from the Startup file (read the connection string from appsetting.json) to DbContext using DbContextOptions
        // Migrations, run migrations against the DbContext Class which is located in Infrastructure
        // Commands that we are gonna tell Entity Framework to reac our DbContext, DbSets, entities, properties..
        // Make sure Migrations are named in a meaningful way, think of them as SQL Scripts
        // Add your very first migration using Add-Migration InitialCreate
        // **Always check the created Migration File, to make sure it has things you are expecting. It has 2 methods Up() & Down().
            
            // 1. Using Data Annotations: attributes we use on our Entities
            // 2. Fluent API -- put constraint (more flexible & has more options in advanced scenarios)

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Cast> Casts { get; set; }
        //public DbSet<Crew> Crews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasMany(m=>m.Genres).WithMany(g=>g.Movies)
                .UsingEntity<Dictionary<string, object>>("MovieGenre", 
                m => m.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                g => g.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));

            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(mc => new { mc.CastId, mc.MovieId, mc.Character }); // primary key
            builder.HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCasts).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(mc => mc.Cast).WithMany(mc => mc.MovieCasts).HasForeignKey(mc => mc.CastId);
        }

        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.HasKey(c => c.Id); // primary key
            builder.Property(c => c.Name).HasMaxLength(2084);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }
        
        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id); // primary key
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
            builder.Property(t => t.Name).HasMaxLength(2084);
        }

        private void ConfigureMovie(EntityTypeBuilder<Movie> builder) 
        {
            // user Fluent API Rules

            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256);
            builder.Ignore(m => m.Rating); // it's for business logic, so ignore this property
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
