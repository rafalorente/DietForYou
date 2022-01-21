using DietForYou.Models;
using Microsoft.EntityFrameworkCore;

namespace DietForYou.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<HistoricoUsersDados> HistoricoUsersDados { get; set; }
    }
}
