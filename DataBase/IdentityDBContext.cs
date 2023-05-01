using Fusion.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fusion.DataBase
{
    public class IdentityDBContext : IdentityDbContext<User, UserRole, Guid>
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<UsersPicture> UsersPictures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(t => new { t.Id });
            modelBuilder.Entity<User>()
                .HasMany(p => p.UsersPictures)
                .WithOne(u => u.User)
                .HasForeignKey(g => g.UserId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<UsersPicture>()
                .HasOne(f => f.User)
                .WithMany(d => d.UsersPictures)
                .HasForeignKey(s => s.UserId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
