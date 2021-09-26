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
        
        public DbSet<CustomerGroup> CustomerGroups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerGroupPricing> CustomerGroupPricings { get; set; }
        public DbSet<CustomerGroupPricingDetail> CustomerGroupPricingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(x =>
                x.HasOne(c => c.Company)
                    .WithMany(c => c.Branches)
                    .HasForeignKey(c => c.CompanyCode));

            modelBuilder.Entity<Branch>(x => x.HasIndex(c => new {c.BranchCode, c.CompanyCode}).IsUnique());

            modelBuilder.Entity<CustomerGroup>(
                x => x.HasIndex(c => new {c.CustomerGroupCode, c.CompanyCode}).IsUnique());
            
            modelBuilder.Entity<Product>(
                x => x.HasIndex(c => new {c.ProductCode, c.CompanyCode}).IsUnique());
            
            modelBuilder.Entity<CustomerGroupPricing>(x =>
                x.HasOne(c => c.Product)
                    .WithMany(c => c.CustomerGroupPricings)
                    .HasForeignKey(c => c.ProductId));
            
            modelBuilder.Entity<CustomerGroupPricing>(x =>
                x.HasOne(c => c.CustomerGroup)
                    .WithMany(c => c.CustomerGroupPricings)
                    .HasForeignKey(c => c.CustomerGroupId));
            
            modelBuilder.Entity<CustomerGroupPricingDetail>(x =>
                x.HasOne(c => c.CustomerGroupPricing)
                    .WithMany(c => c.CustomerGroupPricingDetails)
                    .HasForeignKey(c => c.CustomerGroupPricingId));
        }
    }
}