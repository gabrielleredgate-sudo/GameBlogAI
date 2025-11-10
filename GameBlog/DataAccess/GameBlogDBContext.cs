using GameBlog.Models.DBModels;
using Microsoft.EntityFrameworkCore;

public class GameBlogDBContext : DbContext
{
    public GameBlogDBContext(DbContextOptions<GameBlogDBContext> options) : base(options) { }

    public DbSet<blogpost> blogpost { get; set; }

    public bool SubmitNewPost(string title, string posst)
    {
        try
        {
            blogpost post = new blogpost();
            post.title = title;
            post.post = posst;
            post.PostDate = DateTime.Now;

            blogpost.Add(post);
            SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }


}