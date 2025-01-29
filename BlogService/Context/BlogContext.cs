using BlogService.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogService.Context
{

    public class BlogContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<BlogModel> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string server = "192.168.84.132";
            string database = "BlogDb";
            string user = "alw";
            string password = "1234";

            optionsBuilder.UseMySQL($"Server={server};Database={database};User={user};Password={password};");
        }
    }
}

