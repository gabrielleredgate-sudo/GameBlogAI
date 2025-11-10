using GameBlog.Models;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Chat;
using Org.BouncyCastle.Asn1.Crmf;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GameBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GameBlogDBContext _context;
        private readonly OpenAIClient _client;

        public HomeController(ILogger<HomeController> logger, GameBlogDBContext context, OpenAIClient openAIClient)
        {
            _logger = logger;
            _context = context;
            _client = openAIClient;
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
            var result = _context.SubmitNewPost(title, post);
            return Json(new { success = result });
        }

        [HttpPost]
        [Route("Chat/{post}")]
        public JsonResult Chat(string post)
        {
            var client = _client.GetChatClient("gpt-5-nano");
            var Messages = new List<ChatMessage>
    {
        ChatMessage.CreateUserMessage(post)
    };

            var result = client.CompleteChat(Messages);


            return Json(new {success = true, message = result.Value.Content.FirstOrDefault().ToString() });
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
