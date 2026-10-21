using Microsoft.EntityFrameworkCore;
using SportComplexTemplate.Models;

namespace SportComplexTemplate.Data
{
    public class SportComplexDbContext : DbContext
    {
        // Регистрация новых таблиц в EF Core
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Membership> Memberships => Set<Membership>();
        public DbSet<LockerKey> LockerKeys => Set<LockerKey>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Настройка подключения к новой локальной SQLite БД
            optionsBuilder.UseSqlite("Data Source=sportcomplex_adv.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Жесткая настройка связи «Один к Одному»
            modelBuilder.Entity<Client>()
                .HasOne(c => c.LockerKey)
                .WithOne(k => k.Client)
                .HasForeignKey<LockerKey>(k => k.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Корректная конвертация decimal цены для стабильной работы SQLite
            modelBuilder.Entity<Membership>()
                .Property(m => m.Price)
                .HasConversion<double>();
        }
    }
}
