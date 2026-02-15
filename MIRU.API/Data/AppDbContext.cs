using Microsoft.EntityFrameworkCore;
using MIRU.API.Models;

namespace MIRU.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Ini mendaftarkan model Peminjaman jadi tabel database
        public DbSet<Peminjaman> Peminjamans { get; set; }
    }
}