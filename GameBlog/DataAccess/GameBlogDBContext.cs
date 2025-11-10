using GameBlog.Models.DBModels;
using Microsoft.EntityFrameworkCore;

public class GameBlogDBContext : DbContext
{
    public GameBlogDBContext(DbContextOptions<GameBlogDBContext> options) : base(options) { }

    public DbSet<blogpost> blogpost { get; set; }


}