using FrioAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrioAPI.Infrastructure.DataAccess
{
    internal class FrioApiDBContext : DbContext
    {
        public FrioApiDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Recibo> Recibos { get; set; }

    }
}
