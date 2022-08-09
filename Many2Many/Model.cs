using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Many2Many
{
    public class AppDb : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data source=tcp:192.168.10.124,30000; Initial Catalog = ManyToMany; Persist Security Info=True;User ID=sa;Password=D0naldDuck");
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; } = new();
    }

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public List<Student> Students { get; } = new();
    }
}

