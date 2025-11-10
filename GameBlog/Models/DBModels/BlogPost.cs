namespace GameBlog.Models.DBModels
{
    public class blogpost
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string post { get; set; }
        public DateTime PostDate { get; set; }
    }
}
