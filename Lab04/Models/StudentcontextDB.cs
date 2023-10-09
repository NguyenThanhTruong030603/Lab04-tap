using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lab04.Models
{
    public partial class StudentcontextDB : DbContext
    {
        public StudentcontextDB()
            : base("name=StudentcontextDB")
        {
        }

        public virtual DbSet<Falculty> Falculties { get; set; }
        
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Falculty>()
                .Property(e => e.FalcultyName)
                .IsFixedLength();

            modelBuilder.Entity<Falculty>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Falculty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentID)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.FullName)
                .IsFixedLength();
        }
    }
}
