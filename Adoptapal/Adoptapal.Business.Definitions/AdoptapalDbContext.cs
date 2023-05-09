﻿using Adoptapal.Business.Definitions.Config;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Business.Definitions
{
    public class AdoptapalDbContext : DbContext
    {
        public AdoptapalDbContext(DbContextOptions<AdoptapalDbContext> options) : base(options)
        {
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Notice>().Property(e => e.Content).HasMaxLength(256);
            modelBuilder.ApplyConfiguration(new NoticeConfiguration());
        }

        public DbSet<Notice> Notices { get; set; }
    }
}
