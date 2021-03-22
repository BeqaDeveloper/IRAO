using IRAO.Domain.Entities;
using IRAO.Domain.Interfaces.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRAO.Repositories.Context
{
    public class IraoDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWork
    {
        public void Commit()
        {
            try
            {
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public IraoDbContext(DbContextOptions<IraoDbContext> options) : base(options) { }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Market> Markets { get; set; }
        public virtual DbSet<CompanyMarketPlace> CompanyMarketPlaces { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyMarketPlace>()
                .HasKey(bc => new { bc.MarketId, bc.CompanyId });

            modelBuilder.Entity<CompanyMarketPlace>()
                .HasOne(pc => pc.Market)
                .WithMany(b => b.CompanyMarketPlaces)
                .HasForeignKey(pc => pc.MarketId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CompanyMarketPlace>()
                .HasOne(pc => pc.Company)
                .WithMany(c => c.CompanyMarketPlaces)
                .HasForeignKey(pc => pc.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

    }
}
