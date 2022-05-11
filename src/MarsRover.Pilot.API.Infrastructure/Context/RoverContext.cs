using MarsRover.Pilot.API.Core.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MarsRover.Pilot.API.Infrastructure.Context
{
    public class RoverContext : DbContext
    {
        private const string DATA_FOLDER = "App_Data";

        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!Directory.Exists(DATA_FOLDER)) Directory.CreateDirectory(DATA_FOLDER);
            string databasePath = Path.Combine(DATA_FOLDER, "database.sqlite");
            SqliteConnectionStringBuilder? connectionStringBuilder = new() { DataSource = databasePath };
            string connectionString = connectionStringBuilder.ToString();
            SqliteConnection? connection = new(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>();
        }
    }
}
