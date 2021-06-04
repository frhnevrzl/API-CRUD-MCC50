using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options): base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<RegisterVM> RegisterVM { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.account)
                .WithOne(a => a.person)
                .HasForeignKey<Account>(a => a.NIK);
        
            modelBuilder.Entity<Account>()
                .HasOne(a => a.profiling)
                .WithOne(p => p.account)
                .HasForeignKey<Profiling>(p => p.NIK);
            //Many otomatis gausah pake .HasForeignKey<Profiling>(p => p.NIK);
           // modelBuilder.Entity<Profiling>().HasOne(p => p.education).WithMany(e => e.profiling);
            modelBuilder.Entity<Education>()
                .HasMany(e => e.profiling)
                .WithOne(p => p.education);

            modelBuilder.Entity<University>()
                .HasMany(u => u.education)
                .WithOne(e => e.university);
            modelBuilder.Entity<AccountRole>().HasKey(ar => new { ar.AccountNIK, ar.RoleId });

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountRoles)
                .WithOne(a => a.Account);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.AccountRoles)
                .WithOne(r => r.Roles);

            /* modelBuilder.Entity<Role>()
                 .HasMany(r => r.AccountRoles)
                 .WithMany(a => a.Role);*/

            /* modelBuilder.Entity<Account>()
                 .HasOne(a => a.Acco)
                 .WithOne(a => a.Account);*/
            
            modelBuilder.Entity<RegisterVM>().HasNoKey();

        }
    }
}
