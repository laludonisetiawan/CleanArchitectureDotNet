using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        // constructor & dependency injection
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService) 
        {
            _blogService = blogService;
        }

        // ambil semua data blog
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogService.GetAllAsync();
            return Ok(blogs);
        }

        // ambil data berdasarkan Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        // membuat data baru
        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            var createdBlog = await _blogService.CreateAync(blog);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);  
        }

        // mengedit data blog berdasarkan Id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Blog updateBlog)
        {
            int existingBlog = await _blogService.UpdateAsync(id, updateBlog);
            if (existingBlog == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // menghapus data blog berdasarkan Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int blog = await _blogService.DeleteAsync(id);
            if(blog == 0)
            {
                return BadRequest();
            }
            return NoContent(); 
        }
    }
}
