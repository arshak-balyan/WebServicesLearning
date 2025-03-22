using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace WebServicesLearning.Controllers
{
    public class Data
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
    
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly List<Data> records = new()
        {
            new Data { ID = 1, UserID = 1, Title = "qui est esse", Content = "et iusto sed quo iure\nvoluptatem occaecati omnis eligendi aut ad\nvoluptatem doloribus vel accusantium quis pariatur\nmolestiae porro eius odio et labore et velit aut" },
            new Data { ID = 2, UserID = 2, Title = "bla bla bla", Content = "a lot of text" },
            new Data { ID = 3, UserID = 3, Title = "ea molestias quasi exercitationem repellat qui ipsa sit aut", Content = "et iusto sed quo iure\nvoluptatem occaecati omnis eligendi aut ad\nvoluptatem doloribus vel accusantium quis pariatur\nmolestiae porro eius odio et labore et velit aut" }
        };

        [HttpGet]
        public IActionResult GetByIDandTitle(int userID, string title)
        {
            var searchInData = records
                .Where(p => p.UserID == userID && p.Title == title)
                .ToList();

            if (!searchInData.Any())
            {
                return NotFound("No data found.");
            }

            return Ok(searchInData);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var searchInData = records
                .Where(p => p.UserID == id)
                .ToList();

            if (!searchInData.Any())
            {
                return NotFound("No data found.");
            }

            return Ok(searchInData);
        }
    }
}
