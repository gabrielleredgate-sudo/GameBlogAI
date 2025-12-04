using GameBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using OpenAI;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;


namespace GameBlog.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class ChartController : ApiController
    {
        private readonly GameBlogDBContext _context;


        public ChartController( GameBlogDBContext context)
        {
            _context = context;
        }

        // GET: api/test/ GetChart
        [HttpGet("GetChart")]
        public JsonResult GetChart()
        {
            string[] xAxis = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            int[] yAxis = _context.GetCreationMonthCounts();
            GraphData model = new GraphData()
            {
                Xaxis = xAxis,
                Yaxis = yAxis
            };
            return new JsonResult(model);
        }
    }
}
