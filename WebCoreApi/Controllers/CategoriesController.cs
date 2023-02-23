using Microsoft.AspNetCore.Mvc;

namespace WebCoreApi.Controllers
{
    public class CategoriesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Categories");
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            return Ok("category by id");
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("post category");
        }

        [HttpDelete]

        public IActionResult Delete()
        {
            return Ok("Delete category");
        }
    }
}
