using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace WebServicesLearning.Controllers
{
    public class PageData
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }
        public List<User> Data { get; set; }
        public SupportInfo Support { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Avatar { get; set; }
    }

    public class SupportInfo
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private PageData data;

        [HttpPost]
        public IActionResult AddUser([FromBody] PageData pageData)
        {
            if (pageData == null || pageData.Data == null || !pageData.Data.Any())
            {
                return BadRequest("Invalid data received.");
            }

            data = pageData;

            return Ok(new { Message = "User data received successfully", TotalUsers = data.Data.Count });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedData)
        {
            if (updatedData == null)
            {
                return BadRequest("Invalid user ID.");
            }
            
            var user = data?.Data?.FirstOrDefault(u => u.Id == id);
            
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            user.Email = updatedData.Email;
            user.First_Name = updatedData.First_Name;
            user.Last_Name = updatedData.Last_Name;
            user.Avatar = updatedData.Avatar;

            return Ok(new { Message = "User updated successfully", UpdatedUser = user });
        }
    }
}
