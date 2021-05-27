using API.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasOne(p => p.account).WithOne(a => a.person)
                .HasForeignKey<Account>(a => a.NIK);
            modelBuilder.Entity<Account>().HasOne(a => a.profiling).WithOne(p => p.account)
                .HasForeignKey<Profiling>(p => p.NIK);
            //Many otomatis gausah pake .HasForeignKey<Profiling>(p => p.NIK);
            modelBuilder.Entity<Education>().HasMany(e => e.profiling).WithOne(p => p.education);
            modelBuilder.Entity<University>().HasMany(u => u.education).WithOne(e => e.university);

        }
    }
}
