using ConvertApiDotNet;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApplication4.Database;
using WebApplication4.Database.Model;
using WebApplication4.Interfaces;

namespace WebApplication4.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
             var result = await _productRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetProductByID(int id)
        {
             var result = await _productRepository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("salam");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var result = await _productRepository.CreateAsync(product);
            var jsonString = JsonSerializer.Serialize(result.Name);
            var result1 = QrCodeGenerator.GenerateByteArray(jsonString);

            using (var imageFile = new FileStream("wwwroot/MyImage.png", FileMode.Create))
            {
                imageFile.Write(result1, 0, result1.Length);
                imageFile.Flush();
            }

            return Created(string.Empty,result);
        }

        [HttpPut]
        public async Task <IActionResult> Update(Product product)
        {
            var changed = await _productRepository.GetByIdAsync(product.Id);
            if (changed is null)
            {
                return NotFound(product.Id);
            }
            await _productRepository.UpdateAsync(product);
            
            //var convertApi = new ConvertApi("NewFile");
            //var convert = await convertApi.ConvertAsync("pdf", "txt",
            //    new ConvertApiFileParam(@"C:\Users\DELL\Desktop\Group 1-2.pdf")
            //);
            //await convert.SaveFilesAsync(@"C:\converted-files\");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removed = await _productRepository.GetByIdAsync(id);
            if (removed is null)
            {
                return NotFound(id);
            }
            await _productRepository.RemoveAsync(id);
            return NoContent();

        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile formFile)
        {
            var newFileName = Guid.NewGuid() + "." + Path.GetExtension(formFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newFileName);
            var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);

            return Created("", formFile);
        }
    }
}

