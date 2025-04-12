using FrioAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrioAPI.Infrastructure.DataAccess
{
    internal class FrioApiDBContext : DbContext
    {
        public DbSet<Recibo> Recibos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;DataBase=friodb;Uid=root;Pwd=@password123;";

            var version = new Version(8, 0, 41);
            var serverVersion = new MySqlServerVersion(version);

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
