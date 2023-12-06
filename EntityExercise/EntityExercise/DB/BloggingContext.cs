using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExercise.DB
{
    internal class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<BlogAuthor> blogAuthors { get; set; }
        public string DbPath { get; set; }
        public BloggingContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "blogging.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder op) => op.UseSqlite($"Data source={DbPath}");
    }
}
