using System.Diagnostics;
using System.Threading.Tasks;
using GameBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GameBlogDBContext _context;

        public HomeController(ILogger<HomeController> logger, GameBlogDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.blogpost.ToListAsync();
            return View(data);
        }

        [HttpPost]
        [Route("NewBlogSubmit/{title}/{post}")]
        public JsonResult NewBlogSubmit(string title, string post)
        {
          var result =  _context.SubmitNewPost(title, post);
            return Json(new { success = result });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
