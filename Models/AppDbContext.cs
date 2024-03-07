using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Models
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<FavoritedGame> FavoritedGames { get; set; }
        public DbSet<FavoritedGenre> FavoritedGenres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +
                "port=3306;" +
                "user=root;" +
                "password=admin123;" +
                "database=gamedib;",
                ServerVersion.Parse("5.7.33-winx64")
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(

                new Genre
                {
                    Id = 1,
                    Name = "Murder",
                    Description = "Blood and Knife",
                },
                new Genre 
                { 
                    Id = 2,
                    Name = "Horror", 
                    Description = "Scary with Jumpscares" 
                },
                new Genre
                {
                    Id = 3,
                    Name = "Adventure",
                    Description = "Exploration and Quests in a vast world."
                },
                new Genre
                {
                    Id = 4,
                    Name = "Sci-Fi",
                    Description = "Futuristic settings, advanced technology, and space exploration."
                },
                new Genre
                {
                    Id = 5,
                    Name = "Fantasy",
                    Description = "Magic, mythical creatures, and epic adventures."
                },
                new Genre
                {
                    Id = 6,
                    Name = "Simulation",
                    Description = "Realistic representation of various activities or systems."
                },
                new Genre
                {
                    Id = 7,
                    Name = "Racing",
                    Description = "Fast-paced competitive racing with various vehicles."
                },
                new Genre
                {
                    Id = 8,
                    Name = "Sports",
                    Description = "Simulations or arcade-style games based on real-world sports."
                },
                new Genre
                {
                    Id = 9,
                    Name = "Strategy",
                    Description = "Tactical planning and resource management."
                },
                new Genre
                {
                    Id = 10,
                    Name = "Puzzle",
                    Description = "Challenges that test logic, pattern recognition, and problem-solving skills."
                },
                new Genre
                {
                    Id = 11,
                    Name = "Role-Playing Game (RPG)",
                    Description = "Character development, story-driven gameplay, and decision-making."
                }
            );

            modelBuilder.Entity<Game>().HasData(

                new Game
                {
                    Id = 1,
                    GenreId = 2,
                    Name = "Five Nights at Freddy's",
                    Description = "Survive five nights as a night security guard",
                    Rating = 5,
                    Release = new DateTime(2014, 08, 08, 9, 15, 0)
                },
                new Game
                {
                    Id = 2,
                    GenreId = 3,
                    Name = "The Legend of Zelda: Breath of the Wild",
                    Description = "Epic adventure in the kingdom of Hyrule.",
                    Rating = 4.8,
                    Release = new DateTime(2017, 03, 03, 12, 0, 0)
                },
                new Game
                {
                    Id = 3,
                    GenreId = 6,
                    Name = "The Sims 4",
                    Description = "Life simulation with open-ended creativity.",
                    Rating = 4.5,
                    Release = new DateTime(2014, 09, 02, 10, 0, 0)
                },
                new Game
                {
                    Id = 4,
                    GenreId = 7,
                    Name = "Mario Kart 8 Deluxe",
                    Description = "Fast-paced kart racing with beloved Nintendo characters.",
                    Rating = 4.7,
                    Release = new DateTime(2017, 04, 28, 11, 0, 0)
                },
                new Game
                {
                    Id = 5,
                    GenreId = 11,
                    Name = "The Witcher 3: Wild Hunt",
                    Description = "Epic RPG with a rich open world and captivating story.",
                    Rating = 4.9,
                    Release = new DateTime(2015, 05, 19, 9, 0, 0)
                }
            );

            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = 1,
                     Name = "admin1",
                     Username = "admin1",
                     Password = SecureHasher.Hash("1234"),
                     IsAdmin = true,
                 },
                 new User
                 {
                     Id = 2,
                     Name = "user1",
                     Username = "user1",
                     Password = SecureHasher.Hash("1234"),
                     IsAdmin = false,
                 },
                 new User
                 {
                     Id = 3,
                     Name = "Daniel",
                     Username = "Duckie",
                     Password = SecureHasher.Hash("6465"),
                     IsAdmin = false,
                 }
            );

            modelBuilder.Entity<FavoritedGame>().HasData(
                 new FavoritedGame
                 {
                     Id = 1,
                     GameId = 1,
                     UserId = 1,
                 }
            );

            modelBuilder.Entity<FavoritedGenre>().HasData(
                 new FavoritedGenre
                 {
                     Id = 1,
                     GenreId = 1,
                     UserId = 1,
                 }
            );
        }
    }
}
