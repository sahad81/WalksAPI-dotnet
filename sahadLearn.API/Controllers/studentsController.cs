using Microsoft.AspNetCore.Mvc;

namespace sahadLearn.API.Controllers
{


    [Route("/api/[controller]")]
    [ApiController]
    public class studentsController : Controller
    {
        [HttpGet]
        public IActionResult GetAllStudens()
        {
            String[] studentNames = new String[] { "jhon", "Sahad", "Fawas", "basi" };

            return Ok(studentNames);
        }
    }
}
