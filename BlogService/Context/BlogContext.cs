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
            //optionsBuilder.UseSqlServer($"Server=192.168.84.132;Database=BlogDb;User=alw;Password=1234;");
            optionsBuilder.UseMySql("Server=192.168.84.132;Port=3306;Database=BlogDb;User=alw;Password=1234;", new MySqlServerVersion(new Version(8, 0, 40)));
        }
    }
}

