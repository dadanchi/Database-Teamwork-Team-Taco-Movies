using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using TacoMovies.Data.Contracts;
using TacoMovies.Models;

namespace TacoMovies.Data
{
    public class MoviesDbContext : DbContext, IMovieDbContext
    {
        public MoviesDbContext() : base("MoviesDB")
        {
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<Genre> Genres { get; set; }

        public virtual IDbSet<Award> Awards { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Account> Account { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            this.OnMovieModelCreating(modelBuilder);
            this.OnUserModelCreating(modelBuilder);
            this.OnGenreModelCreating(modelBuilder);
            this.OnCountryModelCreating(modelBuilder);
            this.OnArtistModelCreating(modelBuilder);
            this.OnAccountModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void OnAccountModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(x => x.AccountNumber)
                .IsRequired()
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(
                        new IndexAttribute("IX_AccountNumber")
                        {
                            IsUnique = true
                        }));
        }


        private void OnArtistModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .Property(x => x.DateOfBirth)
                .IsOptional();

            modelBuilder.Entity<Artist>()
                .HasMany<Movie>(x => x.Movies)
                .WithMany(x => x.Actors);
        }

        private void OnCountryModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(
                        new IndexAttribute("IX_Name")
                        {
                            IsUnique = true
                        }));
        }

        private void OnGenreModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(
                        new IndexAttribute("IX_Name")
                        {
                            IsUnique = true
                        }));
        }

        private void OnMovieModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Entity<Movie>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(
                        new IndexAttribute("IX_Name")
                        {
                            IsUnique = true
                        }));

            dbModelBuilder.Entity<Movie>()
                .Property(x => x.Rating)
                .IsOptional();
        }

        private void OnUserModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Entity<User>()
                .Property(x => x.Username)
                .IsRequired()
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(
                        new IndexAttribute("IX_Username")
                        {
                            IsUnique = true
                        }));

            dbModelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            dbModelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(40);

            dbModelBuilder.Entity<User>()
                .Property(x => x.Password)
                .IsRequired();

            dbModelBuilder.Entity<User>()
                .HasMany<Movie>(x => x.Movies)
                .WithMany(x => x.Users);
        }
    }
}
