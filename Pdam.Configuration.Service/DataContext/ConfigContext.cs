using System;
using Microsoft.EntityFrameworkCore;

namespace Pdam.Configuration.Service.DataContext
{
    public class ConfigContext : DbContext
    {
        public ConfigContext(DbContextOptions<ConfigContext> options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql($"{Environment.GetEnvironmentVariable("PdamConfigurationConnectionString")}");
            }
        }
        
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(x =>
                x.HasOne(c => c.Company)
                    .WithMany(c => c.Branches)
                    .HasForeignKey(c => c.CompanyCode));

            modelBuilder.Entity<Branch>(x => x.HasIndex(c => new {c.BranchCode, c.CompanyCode}).IsUnique());
        }
    }
}