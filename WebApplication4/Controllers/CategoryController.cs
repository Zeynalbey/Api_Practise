using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication4.Database;
using WebApplication4.Interfaces;

namespace WebApplication4.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ProductContext _productContext;
        public CategoryController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        [HttpGet("products/{id}")]
        public async Task <IActionResult> GetAll(int id)
        {
            var result = await _productContext.Categories.Include(x => x.Products)
                .SingleOrDefaultAsync(x => x.Id == id);
            return Ok(result);
        }



    }
}
