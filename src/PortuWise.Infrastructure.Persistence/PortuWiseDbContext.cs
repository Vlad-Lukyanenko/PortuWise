using Microsoft.EntityFrameworkCore;
using PortuWise.WebApi.Domain.Entities;
using System;

namespace PortuWise.DataAccess
{
    public class PortuWiseDbContext : DbContext
    {
        public PortuWiseDbContext(DbContextOptions<PortuWiseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Phrase> Phrases { get; set; }
        public DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
