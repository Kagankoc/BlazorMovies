using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorMovies.Server
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesActors>().HasKey(x => new { x.MovieId, x.PersonId });
            modelBuilder.Entity<MoviesGenres>().HasKey(x => new { x.MovieId, x.GenreId });

            //var roleAdminId = "3b5b8095-0e4f-483b-b4b0-39cb5257ba3c";
            //var userAdminId = "a31bdbe6-912e-4195-b633-b2f2ba802cf9";

            //var hasher = new PasswordHasher<IdentityUser>();

            //var userAdmin = new IdentityUser()
            //{

            //    Id = userAdminId,
            //    Email = "cemsukagan@hotmail.com",
            //    UserName = "cemsukagan@hotmail.com",
            //    NormalizedEmail = "cemsukagan@hotmail.com",
            //    NormalizedUserName = "cemsukagan@hotmail.com",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "Oracle3005!")


            //};

            //modelBuilder.Entity<IdentityUser>().HasData(userAdmin);

            //modelBuilder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>()
            //{
            //    Id = 1,
            //    ClaimType = ClaimTypes.Role,
            //    ClaimValue = "Admin",
            //    UserId = userAdminId

            //});


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }


    }
}
