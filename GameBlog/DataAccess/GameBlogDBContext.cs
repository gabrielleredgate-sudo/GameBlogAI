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

    public int[] GetCreationMonthCounts()
    {
        List<int> finalCounts = new List<int>();
        var listOfBlogs = blogpost.Where(a => a.PostDate.Year == DateTime.Now.Year);

        for( int i = 1; i < 13; i++)
        {
            finalCounts.Add(listOfBlogs.Where(a => a.PostDate.Month == i).Count());
        }

        return finalCounts.ToArray();
    }


}